using Data;
using Entities.Entities;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.DataLogic.PhotoLogic
{
    public class PhotoLogic : IPhotoLogic
    {
        private readonly PhotoManagerContext _photoManagerContext;
        public PhotoLogic()
        {
            this._photoManagerContext = new PhotoManagerContext();
        }

        public void ValidatePhotoEntityInsert(PhotoEntity photoEntity)
        {
            if (photoEntity.Active || String.IsNullOrWhiteSpace(photoEntity.Title)
                || photoEntity.File.Length == 0 || photoEntity.Id > 0 || photoEntity.UploadDate == default(DateTime)) {
                throw new ValidationException("Error en la validación de la foto.");
            }
        }
        public async Task<int> AddPhotoEntity(PhotoEntity photoEntity)
        {
            try
            {
                ValidatePhotoEntityInsert(photoEntity);
                photoEntity.Active = true;
                photoEntity.IdWeb = Guid.NewGuid();
                _photoManagerContext.Photos.Add(photoEntity);
                await _photoManagerContext.SaveChangesAsync();
                return photoEntity.Id;
            }
            catch(Exception e)
            {
                throw new Exception("Error al insertar foto en base.");
            }
        }
        public async Task<int> UpdatePhotoEntity(PhotoEntity photoEntity)
        {
            try
            {
                ValidatePhotoEntityInsert(photoEntity);
                var photoToEdit = _photoManagerContext.Set<PhotoEntity>()
                    .FirstOrDefault(p => p.Id == photoEntity.Id && p.IdWeb == photoEntity.IdWeb);
                if(photoToEdit == null || photoToEdit.Active == false)
                {
                    throw new Exception("La foto que quiere editar no fue encontrada en base.");
                }
                photoToEdit = photoEntity;
                photoToEdit.UploadDate = DateTime.Now;
                await _photoManagerContext.SaveChangesAsync();
                return 200;
            }
            catch (Exception e)
            {
                throw new Exception("Error al modificar foto en base.");
            }
        }
        public async Task<int> DeletePhotoEntity(int Id)
        {
            try
            {
                var photoToDelete = _photoManagerContext.Set<PhotoEntity>()
                    .FirstOrDefault(p => p.Id == Id);
                if (photoToDelete == null)
                {
                    throw new Exception("La foto que quiere inactivar no fue encontrada en base.");
                }
                photoToDelete.Active = false;
                await _photoManagerContext.SaveChangesAsync();
                return 200;
            }
            catch (Exception e)
            {
                throw new Exception("Error al inactivar foto en base.");
            }
        }
        public async Task<IEnumerable<PhotoEntity>> GetAllPhotos()
        {
            try
            {
                return  await _photoManagerContext.Photos.Where(p => p.Active).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error al inactivar foto en base.");
            }
        }
        public async Task<IEnumerable<PhotoEntity>> GetPhotosByCriteria(PhotoSearchCriteriaModel photoCriteriaModel)
        {
            try
            {
                return await _photoManagerContext.Photos.Where(p => p.Active).ToListAsync();
                //criterias not implemented
            }
            catch (Exception e)
            {
                throw new Exception("Error al inactivar foto en base.");
            }
        }
    }
}
