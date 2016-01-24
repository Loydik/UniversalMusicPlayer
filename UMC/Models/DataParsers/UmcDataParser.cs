using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMC.Models.DataParsers
{
    public abstract class UmcDataParser
    {
        public abstract UmcTrack GetTrackInfo(string url, ApplicationUser currentUser);
    }
}