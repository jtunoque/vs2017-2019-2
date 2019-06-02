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
    public class MediosDomain : IMediosDomain
    {
        public IEnumerable<MediaType> GetAll(string name)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.MediosRepository.GetAll(item=>item.Name.Contains(name));
            }
        }
    }
}
