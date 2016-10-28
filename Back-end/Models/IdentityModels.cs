using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;

namespace Back_end.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string UserNick { get; set; }
        public string Region { get; set; }
        public string ProfileImage { get; set; }
        public string UserQuote { get; set; }
        public string Instagram { get; set; }
        public string KIK { get; set; }
        public string WhatsApp { get; set; }
        public string Twitter { get; set; }
        public string SnapChat { get; set; }
        public string PostCount { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostPoint> PostPoints { get; set; }
        public ICollection<PostReport> PostReports { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentPoint> CommentPoints { get; set; }
        public ICollection<CommentReport> CommentReports { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public System.Data.Entity.DbSet<Back_end.Models.Post> Posts { get; set; }
        public System.Data.Entity.DbSet<Back_end.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<Back_end.Models.CommentReport> CommentReports { get; set; }
        public System.Data.Entity.DbSet<Back_end.Models.PostReport> PostReports { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

       /*     modelBuilder.Entity<Tag>()
                .HasMany<Post>(t => t.Posts)
                .WithMany(p => p.Tags)
                .Map(pt =>
                {
                    pt.MapLeftKey("TagRefId");
                    pt.MapRightKey("PostRefId");
                    pt.ToTable("TagPost");
                }); */
        }

        
    }
}