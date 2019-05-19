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
    public class UsuarioDomain : IUsuarioDomain
    {
        public Usuario ValidateLogin
                (string login, string password)
        {
            using (var uw = new AppUnitOfWork())
            {
                return uw.UsuarioRepository
                   .GetAll(item=>item.Login==login 
                            && item.Password==password)
                            .FirstOrDefault();

            }
        }
    }
}
