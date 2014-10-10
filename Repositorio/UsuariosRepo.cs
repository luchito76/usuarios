using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class UsuariosRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<SSO_User> listaUsuarios()
        {
            IEnumerable<SSO_User> result = dominio.SSO_Users.ToList();

            return result;
        }
    }
}
