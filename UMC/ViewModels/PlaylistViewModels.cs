using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UMC.Models;
using UMC.Models.Attrributes;

namespace UMC.ViewModels
{
    public class PlaylistViewModel
    {
        private List<UmcTrack> _tracks;
        public ApplicationUser CurrentUser { get; set; }

        public PlaylistViewModel()
        { }

        public PlaylistViewModel(ApplicationUser currentUser)
        {
            CurrentUser = currentUser;
        }

        public List<UmcTrack> Tracks
        {
            get
            {
                if (CurrentUser != null)
                {
                    _tracks = CurrentUser.ApplicationUserData.Tracks as List<UmcTrack>;
                }
                else
                {
                    _tracks = new List<UmcTrack>();
                }
                
                return _tracks;
            }

            set { _tracks = value; }
        }

        public PlaylistMode Mode { get; set; }

        [UmcTrackUrlValidator]
        [DataType(DataType.Url)]
        [DisplayName("Enter Url")]
        public string NewUrl { get; set; }
    }


    public enum PlaylistMode
    {
        Shuffle, Normal
    }
}