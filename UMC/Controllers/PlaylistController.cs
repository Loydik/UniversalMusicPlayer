using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SoundCloud.API.Client;
using SoundCloud.API.Client.Objects.Auth;
using UMC.Models;
using UMC.Models.Factories;
using UMC.ViewModels;

namespace UMC.Controllers
{
    public class PlaylistController : Controller
    {
        private ApplicationDbContext _db;

        private ApplicationUserManager _manager;

        private ApplicationUser _currentUser;


        private readonly ISoundCloudConnector soundCloudConnector = new SoundCloudConnector();

        //put your app credentials here
        private const string clientId = "77dbaa2be42c37e39251326aad765645";
        private const string clientSecret = "671c9b4d79c630672396cbc6abf7dee7";

        //specify redirect_uri
        private const string redirectUri = "http://localhost:2309/Playlist/GetCode";


        public PlaylistController()
        {
            _db = ApplicationDbContext.Create();

            _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
        }


        // GET: Playlist
        //public ActionResult _PlaylistPartial()
        //{
        //    var currentUser = _manager.FindById(User.Identity.GetUserId());

        //    PlaylistViewModel vm = new PlaylistViewModel(currentUser);

        //    return PartialView(vm);
        //}

        [Authorize]
        public ActionResult RequestCode()
        {
            var requestTokenUri = soundCloudConnector.GetRequestTokenUri(clientId, redirectUri, SCResponseType.Code, SCScope.NonExpiring, SCDisplay.Popup, null);
            return Redirect(requestTokenUri.ToString());
        }

        [Authorize]
        public ActionResult GetCode(string error, [Bind(Prefix = "error_description")] string errorDescription, string code)
        {
            if (!string.IsNullOrEmpty(error))
            {
                return Content(string.Format("Error: {0}", errorDescription));
            }

            //connect with code
            var soundCloudClient = soundCloudConnector.Connect(clientId, clientSecret, code, redirectUri);

            var accessToken = soundCloudClient.CurrentToken;

            //you also can connect next time with token
            soundCloudClient = soundCloudConnector.Connect(accessToken);

            var user = soundCloudClient.Me.GetUser();

            _currentUser = _manager.FindById(User.Identity.GetUserId());

            _currentUser.ApplicationUserData.SoundcloudToken = accessToken.AccessToken;

            _db.ApplicationUserData.Find(User.Identity.GetUserId()).SoundcloudToken = accessToken.AccessToken;
            _db.SaveChanges();

            _currentUser = _manager.FindById(User.Identity.GetUserId());

            return Redirect("http://localhost:2309");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddTrack(PlaylistViewModel viewModel)
        {
            _currentUser = _manager.FindById(User.Identity.GetUserId());

            PlaylistViewModel returnModel = new PlaylistViewModel(_currentUser);

            if (ModelState.IsValid)
            {
                UmcTrack track = UmcTrackFactory.CreateTrackFromUrl(viewModel.NewUrl);


                    //if (_currentUser.ApplicationUserData.SoundcloudToken == null)
                    //{
                    //    return RequestCode();
                    //}

                    track = UmcTrackDataFactory.GetTrackInfo(track, _currentUser);

                    track.User = _currentUser.ApplicationUserData;
                    returnModel.CurrentUser.ApplicationUserData.Tracks.Add(track);

                    _db.Tracks.Add(track);
                    _db.SaveChanges();
            }

            return PartialView("_PlaylistPartial", returnModel);
        }

        //// GET: UmcLibrary/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: UmcLibrary/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UmcLibrary/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UmcLibrary/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UmcLibrary/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UmcLibrary/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UmcLibrary/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
