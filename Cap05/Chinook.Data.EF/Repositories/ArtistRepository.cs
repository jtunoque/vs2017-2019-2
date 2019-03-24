using Chinook.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.EF.Repositories
{
    public class ArtistRepository
    {
        private readonly AppDataModel _context;

        public ArtistRepository()
        {
            _context = new AppDataModel();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }

        public Artist Get(int id)
        {
            return _context.Artist.Find(id);
        }


        public IEnumerable<Artist> GetAll(string nombre)
        {

            IQueryable<Artist> query = _context.Artist;

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(a => a.Name.Contains(nombre));
            }

            //ordernamiento
            query = query.OrderBy(o => o.Name);

            return query.ToList();
        }

        public int Insert(Artist entity)
        {
            //Se agrega la información al contexto de EF
            _context.Artist.Add(entity);
            //Confiema la trasacción
            _context.SaveChanges();

            return entity.ArtistId;
        }

        public bool Update(Artist entity)
        {
            //Atachando en memoría el objeto que
            //se quiere atualizar
            _context.Artist.Attach(entity);
            //Cambiando el estado de
            //Unchanged a Modified
            _context.Entry(entity).State = 
                EntityState.Modified;

            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;

        }

        public bool Delete(Artist entity)
        {
            //Atachando en memoría el objeto que
            //se quiere atualizar
            _context.Artist.Attach(entity);

            //Cambiando el estado de
            //Unchanged a Deleted
            _context.Artist.Remove(entity);
            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;

        }


    }
}
