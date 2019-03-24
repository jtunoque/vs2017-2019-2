using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.EF.Repositories
{
    public class TrackRepository
    {
        private readonly AppDataModel _context;

        public TrackRepository()
        {
            _context = new AppDataModel();
        }

        public int Count()
        {
            return _context.Track.Count();
        }

        public Track Get(int id)
        {
            return _context.Track.Find(id);
        }


        public IEnumerable<Track> GetAll(string nombre)
        {

            IQueryable<Track> query = _context.Track;

            //Includes (EDGER LOADING)
            query = query.Include(item => item.Album);

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(a => a.Name.Contains(nombre));
            }

            //ordernamiento
            query = query.OrderBy(o => o.Name);

            return query.ToList();
        }

        public int Insert(Track entity)
        {
            //Se agrega la información al contexto de EF
            _context.Track.Add(entity);
            //Confiema la trasacción
            _context.SaveChanges();

            return entity.TrackId;
        }

        public bool Update(Track entity)
        {
            //Atachando en memoría el objeto que
            //se quiere atualizar
            _context.Track.Attach(entity);
            //Cambiando el estado de
            //Unchanged a Modified
            _context.Entry(entity).State = 
                EntityState.Modified;

            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;

        }

        public bool Delete(Track entity)
        {
            //Atachando en memoría el objeto que
            //se quiere atualizar
            _context.Track.Attach(entity);

            //Cambiando el estado de
            //Unchanged a Deleted
            _context.Track.Remove(entity);
            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;

        }


    }
}
