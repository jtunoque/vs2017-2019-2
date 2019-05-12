
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
    public class TrackRepository : GenericRepository<Track>
                        ,ITrackRepository
    {
        public TrackRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<ConsultaTracks> Buscar
                (string trackName, int genero)
        {
            return _context.Database.SqlQuery<ConsultaTracks>
                ("usp_GetTracks @TrackName,@GenreId ",
                new SqlParameter("@TrackName", trackName),
                new SqlParameter("@GenreId", genero)
                ).ToList();
        }
    }
}
