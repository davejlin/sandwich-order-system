﻿using SandwichOrderSystemShared.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class Context : DbContext
    {
        public DbSet<Bread> BreadSet { get; set; }
        public DbSet<Cheese> CheeseSet { get; set; }
        public DbSet<Chips> ChipsSet { get; set; }
        public DbSet<Condiment> CondimentSet { get; set; }
        public DbSet<Drink> DrinkSet { get; set; }
        public DbSet<Filling> FillingSet { get; set; }
        public DbSet<SignatureSandwich> SignatureSandwichSet { get; set; }
        public DbSet<Vegetable> VegetableSet { get; set; }

        public Context() {}

        public Context(IDatabaseInitializerFactory databaseInitializerFactory)
        {
            var databaseInitializer = databaseInitializerFactory.CreateDatabaseInitializer();
            Database.SetInitializer(databaseInitializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
