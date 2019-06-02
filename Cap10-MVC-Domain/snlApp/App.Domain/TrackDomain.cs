using App.Data.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class TrackDomain : ITrackDomain
    {
        public IEnumerable<ConsultaTracks> Buscar(string trackName, int genero)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.TrackRepository.Buscar(trackName,genero);

            }
        }

        public bool Guardar(Track entity)
        {
            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    if (entity.TrackId == 0)
                    {
                        var playIds = entity.Playlist.Select(item => item.PlaylistId).ToList();

                        entity.Playlist = null;
                        uw.TrackRepository.Add(entity);

                       
                        uw.Complete();

                        foreach (var id in playIds)
                        {
                            uw.PlaylistTrackRepository.Add(
                                new PlaylistTrack()
                                {
                                    PlaylistId = id,
                                    TrackId = entity.TrackId
                                }
                            );
                        }

                        uw.Complete();

                    }
                    else
                    {

                    }

                    uw.Complete();
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
