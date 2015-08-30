namespace UserStories.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UserStories.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Groups.Count() == 0)
            {
                List<Group> groups = new List<Group>();

                for (int i = 1; i < 10; i++)
                {
                    var g = new Group();
                    g.Name = "GROUP" + i;
                    g.Description = "Description" + i;
                    groups.Add(g);

                }
                context.Groups.AddOrUpdate(groups.ToArray());

            }
           

        }
       
    }
}
