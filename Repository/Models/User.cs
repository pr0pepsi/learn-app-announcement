using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repository.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Announcements = new HashSet<Announcement>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }

        #region notMappedField

        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string fullName
        {
            get { return Name + " " + Surname; }
        }

        #endregion

        public virtual ICollection<Announcement> Announcements { get; private set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}