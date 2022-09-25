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
            PhotoModelList = new List<PhotoModel>();
        }
        public PhotoModel PhotoModel { get; set; }
        public List<PhotoModel> PhotoModelList { get; set; }
    }
    public class PhotoModel : PhotoEntity
    {
        public string Base64File
        {
            get
            {
                if (File != null && File.Length > 0)
                    return File.Length > 0 ? Convert.ToBase64String(File) : "";
                else
                    return "";
            }
        }
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
        public PhotoModel FromPhotoEntity(PhotoEntity p)
        {
            this.Id = p.Id;
            this.IdWeb = p.IdWeb;
            this.Title = p.Title;
            this.Description = p.Description;
            this.UploadDate = p.UploadDate;
            this.UpdateDate = p.UpdateDate;
            this.File = p.File;
            this.Active = p.Active;
            this.UserId = p.UserId;
            return this;
        }
    }
}
