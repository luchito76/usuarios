using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RolesRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<SSO_Role> listaRoles()
        {
            IEnumerable<SSO_Role> result = dominio.SSO_Roles.ToList();

            return result;
        }

        public void guardarRol(SSO_Role rol)
        {
            dominio.Add(rol);
            dominio.SaveChanges();
        }
    }
}
