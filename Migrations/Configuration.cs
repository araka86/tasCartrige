﻿namespace CartrigeAltstar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CartrigeAltstar.Model.ContexAltstar>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CartrigeAltstar.Model.ContexAltstar";
        }

        protected override void Seed(CartrigeAltstar.Model.ContexAltstar context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
