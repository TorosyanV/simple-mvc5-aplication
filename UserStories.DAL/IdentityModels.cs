using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStories.DAL.Migrations;
using UserStories.DAL;
using System.Collections.Generic;

namespace UserStories.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            JoinedGroups = new HashSet<Group>();
            Stories = new HashSet<Story>();
            
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public virtual ICollection<Group> JoinedGroups { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }

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