using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UMC.DAL;
using UMC.Models;
using UMC.ViewModels;

namespace UMC.Controllers
{
    public class HomeController : Controller
    {
        #region Private Members

        private ApplicationDbContext _db;

        private ApplicationUserManager _manager;

        #endregion


        #region Construction

        public HomeController()
        {
            _db = ApplicationDbContext.Create();

            _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
        }

        #endregion


        public ActionResult Index()
        {
            var currentUser = _manager.FindById(User.Identity.GetUserId());

            HomeViewModel vm = new HomeViewModel(currentUser);

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}