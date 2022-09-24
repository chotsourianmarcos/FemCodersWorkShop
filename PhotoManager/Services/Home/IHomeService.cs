using PhotoManager.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Services.Home
{
    public interface IHomeService
    {
        List<PhotoModel> GetPhotosByCriteria(PhotosSearchCriteriaModel photosSearchCriteriaModel);
        int AddPhoto(PhotoModel photoModel);
        int DeletePhoto(PhotoModel photoModel);
        int UpdatePhoto(PhotoModel photoModel);
    }
}
