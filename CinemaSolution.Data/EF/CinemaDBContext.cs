using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSolution.Data.Configurations;
using CinemaSolution.Data.Entities;
using CinemaSolution.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CinemaSolution.Data.EF
{
    public class CinemaDBContext : DbContext
    {
        public CinemaDBContext(DbContextOptions<CinemaDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInRoleConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieInCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new MovieImageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieImageConfiguration());

            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentLikeConfiguration());

            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriumConfiguration());
            modelBuilder.ApplyConfiguration(new ScreeningConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());

            modelBuilder.ApplyConfiguration(new SeatStatusConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SeatTypeConfiguration());

            modelBuilder.ApplyConfiguration(new DefaultPriceTableConfiguration());

            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInProductComboConfiguration());
            modelBuilder.ApplyConfiguration(new ProductComboConfiguration());
            modelBuilder.ApplyConfiguration(new ProductComboInOrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());

            // Data Seeding
            modelBuilder.Seeding();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieInCategory> MovieInCategories { get; set; }

        public DbSet<MovieImageType> MovieImageTypes { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Screening> Screenings { get; set; }

        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<SeatStatus> SeatStatuses { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public DbSet<DefaultPriceTable> DefaultPriceTables { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInProductCombo> ProductInProductCombos { get; set; }
        public DbSet<ProductCombo> ProductCombos { get; set; }
        public DbSet<ProductComboInOrder> ProductComboInOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
