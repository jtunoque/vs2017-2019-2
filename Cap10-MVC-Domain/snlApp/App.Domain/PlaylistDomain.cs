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
    public class PlaylistDomain : IPlaylistDomain
    {
        public IEnumerable<Playlist> GetAll(string Name )
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.PlaylistRepository.GetAll(item => item.Name.Contains(Name));

            }
        }

        
    }
}
