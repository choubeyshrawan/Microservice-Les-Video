namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app) 
        {
            using (var ServiceScope = app.ApplicationServices.CreateScope()) 
            {
                SeedData(ServiceScope.ServiceProvider.GetService<ApplicationDbContext>());
            }        
        }

        private static void SeedData(ApplicationDbContext dbContext)
        {
            if (!dbContext.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data");

                dbContext.Platforms.AddRange(
                    new Models.Platform() { Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                    );

                dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We have already data in platform table");
            }
        }
    }
}
