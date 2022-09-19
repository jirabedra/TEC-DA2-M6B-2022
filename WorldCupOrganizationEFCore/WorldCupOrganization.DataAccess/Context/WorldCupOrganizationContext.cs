﻿using Microsoft.EntityFrameworkCore;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Context
{
    public class WorldCupOrganizationContext : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }

        public WorldCupOrganizationContext(DbContextOptions options) : base(options) { }

    }
}
