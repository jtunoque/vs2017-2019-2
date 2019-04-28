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
    public class ArtistDomain : IArtistDomain
    {
        public bool DeleteArtist(int id)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.ArtistRepository.Remove(new Artist() {ArtistId=id });

            }

        }

        public IEnumerable<Artist> GetArtist(string nombre)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.ArtistRepository.GetAll(
                    x=>x.Name.Contains(nombre)                    
                    );
            }

        }

        public Artist GetArtistById(int id)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.ArtistRepository.GetById<int>(id);
            }
        }

        public bool SaveArtist(Artist entity)
        {
            bool result = false;

            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    //Nuevo registro
                    if (entity.ArtistId == 0)
                    {
                        uw.ArtistRepository.Add(entity);
                    }
                    else
                    {
                        uw.ArtistRepository.Update(entity);
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
