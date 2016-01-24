using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoundCloud.API.Client.Objects.Auth;
using UMC.Models.DataParsers;

namespace UMC.Models.Factories
{
    public class UmcTrackDataFactory
    {
        public static UmcTrack GetTrackInfo(UmcTrack track, ApplicationUser currentUser)
        {
            if (track is SoundcloudTrack)
            {
                SoundcloudDataParser dataParser = new SoundcloudDataParser();

                track = dataParser.GetTrackInfo(track.Url, currentUser);

                return track;
            }

            return null;
        }
    }
}