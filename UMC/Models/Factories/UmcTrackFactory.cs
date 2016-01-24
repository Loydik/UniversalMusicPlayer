using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using UMC.Models.Constants;

namespace UMC.Models.Factories
{
    public class UmcTrackFactory
    {
        public static UmcTrack CreateTrackFromUrl(string url)
        {
            url = url.ToLower();

            if (Regex.IsMatch(url, ValidationConstants.SoundcloudUrlRegex, RegexOptions.IgnoreCase))
            {
                return new SoundcloudTrack {Url = url};
            }

            if (Regex.IsMatch(url, ValidationConstants.YoutubeUrlRegex, RegexOptions.IgnoreCase))
            {
                return new YoutubeTrack {Url = url};
            }

            return null;
        }
    }
}