using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IArtistDomain
    {
        IEnumerable<Artist> GetArtist(string nombre);

        Artist GetArtistById(int id);

        bool SaveArtist(Artist entity);

        bool DeleteArtist(int id);

    }
}
