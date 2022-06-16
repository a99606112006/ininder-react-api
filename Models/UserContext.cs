using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace share_login_api.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        /* for unique email 
        protected override void onModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<User>(entity=> { entity.HasIndex(e:User => entity.Email).IsUnique(); })
        }
        */ 
    }
}
