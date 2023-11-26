﻿using System;
using Microsoft.EntityFrameworkCore;


public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

    public DbSet<Catalog> Catalogs { get; set; }
}

