using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Announcements.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class AnnouncementContext : IdentityDbContext
    {
        public AnnouncementContext()
            : base("DefaultConnection")
        {
        }

        public static AnnouncementContext Create()
        {
            return new AnnouncementContext();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Announcement_Category> Announcement_Category { get; set; }

        //need to ignore default conversion in header row in DB
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Announcement>().HasRequired(x => x.User)
                .WithMany(x => x.Announcements)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}