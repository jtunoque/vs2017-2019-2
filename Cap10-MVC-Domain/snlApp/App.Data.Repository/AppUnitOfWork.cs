using App.Data.DataAccess;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public IArtistRepository ArtistRepository { get; set; }
        public ICustomerRepository CustomerRepository { get; set; }
        public ITrackRepository TrackRepository { get; set; }
        public IGenreRepository GenreRepository { get; set; }
        public IUsuarioRepository UsuarioRepository { get; set; }
        public IAlbumRepository AlbumRepository { get; set; }
        public IMediosRepository MediosRepository { get; set; }
        public IPlaylistRepository PlaylistRepository { get; set; }
        public IPlaylistTrackRepository PlaylistTrackRepository { get; set; }

        public AppUnitOfWork()
        {
            _context = new DBDataModel();

            this.ArtistRepository = new ArtistRepository(_context);
            this.CustomerRepository = new CustomerRepository(_context);
            this.TrackRepository = new TrackRepository(_context);
            this.GenreRepository = new GenreRepository(_context);
            this.UsuarioRepository = new UsuarioRepository(_context);
            this.AlbumRepository = new AlbumRepository(_context);
            this.MediosRepository = new MediosRepository(_context);
            this.PlaylistRepository = new PlaylistRepository(_context);
            this.PlaylistTrackRepository = new PlaylistTrackRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
