﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

public class WebNarudzbaContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public WebNarudzbaContext() : base("WebNarudzbaContext")
    {
        
    }

    public System.Data.Entity.DbSet<DAL.Dobavljac> Dobavljac { get; set; }

    public System.Data.Entity.DbSet<DAL.Model.Kupac> Kupac { get; set; }

    public System.Data.Entity.DbSet<DAL.Model.Proizvod> Proizvod { get; set; }

    public System.Data.Entity.DbSet<DAL.Model.Narudzbe> Narudzbe { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        
    }
}
