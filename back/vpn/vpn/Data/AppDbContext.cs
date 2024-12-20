﻿using Microsoft.EntityFrameworkCore;
using vpn.Models;

namespace vpn.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<VpnProfile> VpnProfiles { get; set; }
    }
}