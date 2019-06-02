using App.Data.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class AlbumDomain : IAlbumDomain
    {
        public bool DeleteAlbum(int id)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.AlbumRepository.Remove(new Album() {AlbumId=id });

            }

        }

        public IEnumerable<Album> GetAlbum(string nombre)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.AlbumRepository.GetAll(
                    x=>x.Title.Contains(nombre)                    
                    );
            }

        }

        public Album GetAlbumById(int id)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.AlbumRepository.GetById<int>(id);
            }
        }

        public bool SaveAlbum(Album entity)
        {
            bool result = false;

            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    //Nuevo registro
                    if (entity.AlbumId == 0)
                    {
                        uw.AlbumRepository.Add(entity);
                    }
                    else
                    {
                        uw.AlbumRepository.Update(entity);
                    }

                    uw.Complete();
                }

                result = true;
            }
            catch(Exception ex)
            {

            }


            return result;
        }
    }
}
