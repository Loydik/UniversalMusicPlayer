using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UMC.Models;

namespace UMC.DAL
{
    //public class UmcUser : ApplicationUser
    //{
    //    //public virtual ApplicationUserData ApplicationUserData { get; set; }
    //}

    public class ApplicationUserData
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
