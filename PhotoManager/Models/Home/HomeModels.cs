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
        }
        public PhotoModel PhotoModel { get; set; }
    }
    public class PhotoModel : PhotoEntity
    {
        //Model properties not implemented
        public PhotoEntity ToPhotoEntity()
        {
            var photoEntity = new PhotoEntity();
            photoEntity.Id = this.Id;
            photoEntity.IdWeb = this.IdWeb;
            photoEntity.Title = this.Title;
            photoEntity.Description = this.Description;
            photoEntity.UploadDate = this.UploadDate;
            photoEntity.UpdateDate = this.UpdateDate;
            photoEntity.File = this.File;
            photoEntity.Active = this.Active;
            photoEntity.UserId = this.UserId;
            return photoEntity;
        }
    }
}
