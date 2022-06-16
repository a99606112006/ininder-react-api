using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace share_login_api.Models
{
    public class ProfileDbContext:DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        { 
        
        }

        public DbSet<ProfileModel> Profile { get; set; }
    }
}
