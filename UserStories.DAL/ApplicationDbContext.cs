using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStories.DAL.Migrations;
using UserStories.DAL;
using System.Collections.Generic;
using UserStories.Models;

namespace UserStories.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                  .HasMany<Group>(s => s.JoinedGroups)
                  .WithMany(c => c.JoinedUsers)
                  .Map(cs =>
                  {
                      cs.MapLeftKey("UserId");
                      cs.MapRightKey("GroupId");
                      cs.ToTable("UserGroup");
                  });
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
