using Logic.Models;
using PhotoManager.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Services.Home
{
    public interface IHomeService
    {
        Task<IEnumerable<PhotoModel>> GetAllPhotos();
        Task<IEnumerable<PhotoModel>> GetPhotosByCriteria(PhotoSearchCriteriaModel photoSearchCriteriaModel);
        Task<int> AddPhoto(PhotoModel photoModel);
        Task<int> DeletePhoto(int Id);
        Task<int> UpdatePhoto(PhotoModel photoModel);
    }
}
