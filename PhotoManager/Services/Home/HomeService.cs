using Entities.Entities;
using Logic.DataLogic.PhotoLogic;
using Logic.Models;
using PhotoManager.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Services.Home
{
    public class HomeService : IHomeService
    {
        public readonly IPhotoLogic _photoLogic;
        public HomeService(IPhotoLogic photoLogic)
        {
            _photoLogic = photoLogic;
        }
        public async Task<IEnumerable<PhotoModel>> GetAllPhotos()
        {
            var photoEntities = await _photoLogic.GetAllPhotos();
            var resultList = new List<PhotoModel>();
            foreach(PhotoEntity a in photoEntities)
            {
                resultList.Add((PhotoModel)a);
            }
            return resultList;
        }
        public async Task<IEnumerable<PhotoModel>> GetPhotosByCriteria(PhotoSearchCriteriaModel photoSearchCriteriaModel)
        {
            var photoEntities = await _photoLogic.GetPhotosByCriteria(photoSearchCriteriaModel);
            var resultList = new List<PhotoModel>();
            foreach (PhotoEntity a in photoEntities)
            {
                resultList.Add((PhotoModel)a);
            }
            return resultList;
        }
        public async Task<int> AddPhoto(PhotoModel photoModel)
        {
            return await _photoLogic.AddPhotoEntity(photoModel.ToPhotoEntity());
        }
        public async Task<int> DeletePhoto(PhotoModel photoModel)
        {
            return await _photoLogic.UpdatePhotoEntity(photoModel.ToPhotoEntity());
        }
        public async Task<int> UpdatePhoto(PhotoModel photoModel)
        {
            return await _photoLogic.DeletePhotoEntity(photoModel.ToPhotoEntity());
        }
    }
}
