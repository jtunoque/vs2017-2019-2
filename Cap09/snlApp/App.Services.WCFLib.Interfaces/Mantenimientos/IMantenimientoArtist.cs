using App.Entities.Base;
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
        IEnumerable<Artist> GetArtistAll(string nombre);

        [OperationContract]
        Artist GetArtist(int id);

        [OperationContract]
        bool SaveArtist(Artist entity);

        [OperationContract]
        bool DeleteArtist(int id);

    }
}
