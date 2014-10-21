using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class UsuariosNego
    {
        UsuariosRepo usuarioRepo = new UsuariosRepo();
        
        public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> listaUsuariosXPerfil()
        {
            return usuarioRepo.listaUsuariosXPerfil();
        }

        public void guardaSSOUserRol(SSO_Users_Role userRol)
        {
            usuarioRepo.guardaSSOUserRol(userRol);
        }
    }
}
