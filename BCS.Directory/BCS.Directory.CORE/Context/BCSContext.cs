﻿using BCS.Directory.CORE.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.CORE.Context
{
    public class BCSContext : DbContext
    {
        public BCSContext(DbContextOptions<BCSContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
