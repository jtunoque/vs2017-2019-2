using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.WCFLib.Interfaces
{
    public partial interface IMantenimientosService
    {
        [OperationContract]
        IEnumerable<ConsultaTracks> TrackBuscar(string trackName, int genero);

    }
}
