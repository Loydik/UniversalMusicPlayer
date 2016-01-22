using UMC.DAL;

namespace UMC.Models
{
    public class Track
    {
        public int ID { get; set; }
        public string Url { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Year { get; set; }

        public virtual ApplicationUserData User { get; set; }
    }
}