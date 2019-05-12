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
    }
}
