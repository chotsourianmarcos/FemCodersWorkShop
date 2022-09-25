using Entities.Entities;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.DataLogic.PhotoLogic
{
    public interface IPhotoLogic
    {
        Task<int> AddPhotoEntity(PhotoEntity photoEntity);
        Task<int> UpdatePhotoEntity(PhotoEntity photoEntity);
        Task<int> DeletePhotoEntity(int Id);
        Task<IEnumerable<PhotoEntity>> GetAllPhotos();
        Task<IEnumerable<PhotoEntity>> GetPhotosByCriteria(PhotoSearchCriteriaModel photoCriteriaModel);
    }
}
