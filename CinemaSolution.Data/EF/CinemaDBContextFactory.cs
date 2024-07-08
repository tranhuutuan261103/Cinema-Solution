using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CinemaSolution.Data.EF
{
    internal class CinemaDBContextFactory : IDesignTimeDbContextFactory<CinemaDBContext>
    {
        public CinemaDBContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=MSI;Database=CinemaDBContext;User Id=tuan;password=tuan261103;Trusted_Connection=False;MultipleActiveResultSets=true;Encrypt=False";

            var optionsBuilder = new DbContextOptionsBuilder<CinemaDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();

            return new CinemaDBContext(optionsBuilder.Options);
        }
    }
}
