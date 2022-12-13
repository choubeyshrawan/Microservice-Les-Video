using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.IRepo;
using PlatformService.RepositoryImplementation;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register in memory database (using in memory database just for testing purpose not for production
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));

//Register our dependence
builder.Services.AddScoped<IPlatformRepo, PlatformRepository>();

//Register our http client
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
//register auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

Console.WriteLine($"---> Command Service Endpoint {builder.Configuration["CommandService"]}");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


PrepDb.PrepPopulation(app);

app.Run();

