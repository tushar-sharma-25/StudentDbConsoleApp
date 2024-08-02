using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentDbConsoleApp.Infrastructure;

namespace StudentDbConsoleApp.Application;

internal class DbContextProvider : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(configuration["ConnectionStrings:StudentDb"]);

        return new AppDbContext(optionsBuilder.Options);

    }
}
