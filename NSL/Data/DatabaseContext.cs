using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NSL.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
