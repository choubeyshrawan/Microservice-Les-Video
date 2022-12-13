using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.IRepo;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;
using Platform = PlatformService.Models.Platform;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _imapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo platformRepo, IMapper imapper, ICommandDataClient commandDataClient)
        {
            _platformRepo = platformRepo;
            _imapper = imapper;
            _commandDataClient = commandDataClient;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms()
        {
            Console.WriteLine("Getting platforms. . . . . . .");
            IEnumerable<Platform> plotforms=await _platformRepo.GetAll();
            return Ok(_imapper.Map<IEnumerable<PlatformReadDto>>(plotforms));
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatform(int id)
        {
            var platform = await _platformRepo.GetById(id);
            if (platform == null)
            {
                return NotFound();
            }
            return Ok(_imapper.Map<PlatformReadDto>(platform));
        }

        // POST: api/Platforms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> PostPlatform(PlatformCreateDto createplatform)
        {
            Platform platform = _imapper.Map<Platform>(createplatform);
            _platformRepo.Create(platform);
            _platformRepo.SaveChanges();
            
            //return created platform
            PlatformReadDto platformReadDto = _imapper.Map<PlatformReadDto>(platform);
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Could not send platform data to command service synchronously {ex.Message}");
            }
            return CreatedAtAction("GetPlatform", new { id = platform.Id }, platformReadDto);
        }

    }
}
