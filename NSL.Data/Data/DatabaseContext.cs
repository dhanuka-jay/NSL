using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NSL.Configurations.Entities;

namespace NSL.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    FirstName = "Dhanuka",
                    MiddleName = "Sudeera",
                    LastName = "Ilandarage",
                    DOB = new DateTime(1984, 10, 15),
                    PhoneNumber = "0432009680",
                    Email = "dhanuka.singhe@gmail.com"
                }
            );
        }
    }
}
