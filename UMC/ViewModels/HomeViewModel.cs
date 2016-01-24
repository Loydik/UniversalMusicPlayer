using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMC.DAL;
using UMC.Models;

namespace UMC.ViewModels
{
    public class HomeViewModel
    {
        public ApplicationUser CurrentUser { get; set; }

        public PlaylistViewModel PlaylistVm { get; set; }

        public HomeViewModel(ApplicationUser currentUser)
        {
            CurrentUser = currentUser;
            PlaylistVm = new PlaylistViewModel(currentUser);
        }
    }
}