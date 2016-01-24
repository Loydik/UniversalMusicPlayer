using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoundCloud.API.Client;
using SoundCloud.API.Client.Objects.Auth;
using SoundCloud.API.Client.Objects.TrackPieces;
using SoundCloudClient = SoundCloud.API.Client.SoundCloudClient;

namespace UMC.Models.DataParsers
{
    public class SoundcloudDataParser : UmcDataParser
    {
        private const string clientId = "77dbaa2be42c37e39251326aad765645";
        private const string clientSecret = "671c9b4d79c630672396cbc6abf7dee7";

        public override UmcTrack GetTrackInfo(string url, ApplicationUser currentUser)
        {
            ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();

            string token = currentUser.ApplicationUserData.SoundcloudToken;
            //string token = "ssadad";

            UmcTrack resultTrack = new SoundcloudTrack();

            //var tokenLogin = soundCloudConnector.RefreshToken(clientId, clientSecret, token);

            //var newToken = tokenLogin.AccessToken;

            //var soundCloudClient = soundCloudConnector.Connect(new SCAccessToken {AccessToken = token});
            var soundCloudClient = soundCloudConnector.UnauthorizedConnect(clientId, clientSecret);  
              
                var track = soundCloudClient.Resolve.GetTrack(url);
                resultTrack.Url = url;
                resultTrack.Title = track.Title;
                resultTrack.Artist = track.User.UserName;
                resultTrack.Year = track.CreatedAt.Year.ToString();
                resultTrack.InternalId = track.Id;
                
            return resultTrack;
        }
    }
}