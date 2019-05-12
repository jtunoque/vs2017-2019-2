using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using App.Services.WCFLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.WCFLib
{
    public partial class MantenimentosService : IMantenimientosService
    {
        public IEnumerable<ConsultaTracks> TrackBuscar(string trackName
                                                        , int genero)
        {
            ITrackDomain domain = new TrackDomain();
            return domain.Buscar(trackName, genero);
        }
    }
}
