using App.Data.Repository.Interface;
using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class PlaylistTrackRepository : GenericRepository<PlaylistTrack>
                        , IPlaylistTrackRepository
    {
        public PlaylistTrackRepository(DbContext context) : base(context)
        {

        }

        
    }
}
