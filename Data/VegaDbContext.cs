﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Data
{
    public class VegaDbContext : DbContext
    {

        public VegaDbContext(DbContextOptions<VegaDbContext> options)
            :base(options)
        {
                
        }


        public DbSet<Game> Games { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<GameMechanic> GameMechanics{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameMechanic>().HasKey(gm => new { gm.GameId, gm.MechanicId });

        }


    }
}
