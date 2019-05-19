using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitOfWork:IDisposable
    {
        int Complete();
        IArtistRepository ArtistRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        ITrackRepository TrackRepository { get; set; }
        IGenreRepository GenreRepository { get; set; }
        IUsuarioRepository UsuarioRepository { get; set; }
    }
}
