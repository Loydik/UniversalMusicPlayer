using System.ComponentModel.DataAnnotations;
using UMC.DAL;

namespace UMC.Models
{
    public abstract class UmcTrack
    {
        public int ID { get; set; }

        [Required]
        public string Url { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Year { get; set; }

        public string InternalId { get; set; }

        public virtual ApplicationUserData User { get; set; }
    }
}