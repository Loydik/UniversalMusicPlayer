using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMC.Models;

namespace UMC.DAL
{
    public class UmcInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var track = new Track(1, "sdsdsd");
            //context.Tracks.Add(track);
            //context.SaveChanges();

            //var user = new ApplicationUserData {FirstName = "Lalka"};
            //context.ApplicationUserData.Add(user);
            //context.SaveChanges();

            //base.Seed(context);
        }
    }
}