using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Models.Home
{
    public class HomeModel : ProyectBaseModel
    {
        public HomeModel()
        {
            PhotoModel = new PhotoModel();
            PhotosSearchCriteriaModel = new PhotosSearchCriteriaModel();
            AddPhotoPopUpVM = new AddPhotoPopUp();
        }
        public PhotoModel PhotoModel { get; set; }
        public PhotosSearchCriteriaModel PhotosSearchCriteriaModel { get; set; }
        public AddPhotoPopUp AddPhotoPopUpVM { get; set; }
    }
    public class PhotoModel : PhotoEntity
    {
    }
    public class PhotosSearchCriteriaModel
    {
    }
    public class AddPhotoPopUp
    {
    }
}
