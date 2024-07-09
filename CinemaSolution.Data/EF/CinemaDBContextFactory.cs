using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CinemaSolution.Data.EF
{
    internal class CinemaDBContextFactory : IDesignTimeDbContextFactory<CinemaDBContext>
    {
        public CinemaDBContext CreateDbContext(string[] args)
        {
            //string connectionString = "Server=MSI;Database=CinemaSolutionDB;User Id=tuan;password=tuan261103;Trusted_Connection=False;MultipleActiveResultSets=true;Encrypt=False";
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CinemaSolutionDB"); //lấy chuỗi kết nối đến database

            var optionsBuilder = new DbContextOptionsBuilder<CinemaDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();

            return new CinemaDBContext(optionsBuilder.Options);
        }
    }
}
