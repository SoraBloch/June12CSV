using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace June12CSV.Data
{
    public class PersonDataContextFactory : IDesignTimeDbContextFactory<PersonDataContext>
    {
        public PersonDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}June12CSV.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new PersonDataContext(config.GetConnectionString("ConStr"));
        }
    }
}