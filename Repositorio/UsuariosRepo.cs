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

        public void guardaSSOUserRol(SSO_Users_Role userRol)
        {
            dominio.Add(userRol);
            dominio.SaveChanges();
        }

        public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> listaUsuariosXPerfil()
        {
            IEnumerable<SSO_GetUsuariosXPerfilResultSet01> result = dominio.SSO_GetUsuariosXPerfil().ToList();

            return result;
        }
    }
}
