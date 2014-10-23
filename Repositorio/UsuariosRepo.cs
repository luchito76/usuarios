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

        public IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> listaAppXUsuario(int idUsuario, int idEfector)
        {
            IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> result = dominio.Sp_SSO_AllowedAppsByEfector(idUsuario, idEfector).ToList();

            dominio.Dispose();

            return result;
        }
    }
}
