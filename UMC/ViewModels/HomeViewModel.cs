using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMC.DAL;
using UMC.Models;

namespace UMC.ViewModels
{
    public class HomeViewModel
    {
        public ApplicationUser CurrentUser { get; set; }

        public HomeViewModel(ApplicationUser currentUser)
        {
            CurrentUser = currentUser;
        }
    }
}