using PhotoManager.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoManager.Services.Home
{
    public class HomeService : IHomeService
    {
        public List<PhotoModel> GetPhotosByCriteria(PhotosSearchCriteriaModel photosSearchCriteriaModel)
        {
            return new List<PhotoModel>();
        }
        public int AddPhoto(PhotoModel photoModel)
        {
            return 1;
        }
        public int DeletePhoto(PhotoModel photoModel)
        {
            return 1;
        }
        public int UpdatePhoto(PhotoModel photoModel)
        {
            return 1;
        }
    }
}
