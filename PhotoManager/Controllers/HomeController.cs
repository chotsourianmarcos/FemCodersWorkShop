using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PhotoManager.Models;
using PhotoManager.Models.Home;
using PhotoManager.Services.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IHomeService _homeService;
        public HomeModel _homeModel;
        
        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
            _homeModel = new HomeModel();
        }
        //ver la posibilidad de hacer un controlador base y eso.

        public IActionResult Index()
        {
            return View(_homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult<List<PhotoModel>> GetAllPhotos()
        {
            return _homeService.GetAllPhotos().Result.ToList();
        }

        public ActionResult<List<PhotoModel>> GetPhotosByCriteria(PhotoSearchCriteriaModel photoSearchCriteriaModel)
        {
            return  _homeService.GetPhotosByCriteria(photoSearchCriteriaModel).Result.ToList();
        }

        [HttpPost]
        public ActionResult<int> AddPhoto()
        {
            var requestForm = Request.Form;
            var requestFile = requestForm.Files.FirstOrDefault();
            var requestTitle = requestForm["Title"];
            var requestDescription = requestForm["Description"];

            var photoModel = new PhotoModel();

            if (requestFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    requestFile.CopyTo(ms);
                    photoModel.File = ms.ToArray();
                    photoModel.Title = requestTitle;
                    photoModel.Description = requestDescription;
                    photoModel.UploadDate = DateTime.Now;
                    photoModel.IdWeb = Guid.NewGuid();
                }
            }
            
            return _homeService.AddPhoto(photoModel).Result;
        }

        public ActionResult<int> DeletePhoto(PhotoModel photoModel)
        {
            return _homeService.DeletePhoto(photoModel).Result;
        }

        public ActionResult<int> UpdatePhoto(PhotoModel photoModel)
        {
            return _homeService.UpdatePhoto(photoModel).Result;
        }
    }
}
