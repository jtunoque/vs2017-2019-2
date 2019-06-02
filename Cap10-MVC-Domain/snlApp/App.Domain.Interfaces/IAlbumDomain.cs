using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IAlbumDomain
    {
        IEnumerable<Album> GetAlbum(string nombre);

        Album GetAlbumById(int id);

        bool SaveAlbum(Album entity);

        bool DeleteAlbum(int id);

    }
}
