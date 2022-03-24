#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetActivityTracker.Models;

namespace PetActivityTracker.Data
{
    public class PetActivityTrackerContext : DbContext
    {
        public PetActivityTrackerContext (DbContextOptions<PetActivityTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<PetActivityTracker.Models.User> Users { get; set; }

        public DbSet<PetActivityTracker.Models.Pet> Pet { get; set; }

        public DbSet<PetActivityTracker.Models.PetActivity> PetActivity { get; set; }
    }
}
