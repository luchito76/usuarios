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

        public IEnumerable<SSO_User> devuelveUsuarioXIdUsuario(int idUsuario)
        {
            return usuarioRepo.devuelveUsuarioXIdUsuario(idUsuario);
        }

        public void actualizarUsuario(SSO_User ssoUsuario)
        {
            usuarioRepo.actualizarUsuario(ssoUsuario);
        }

        public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> listaUsuariosXPerfil()
        {
            //int filtro = 0;
            //IList<SSO_GetUsuariosXPerfilResultSet01> listaFiltrada = usuarioRepo.listaUsuariosXPerfil().ToList();

            //List<SSO_GetUsuariosXPerfilResultSet01> lista = new List<SSO_GetUsuariosXPerfilResultSet01>();

            //foreach (SSO_GetUsuariosXPerfilResultSet01 data in listaFiltrada)
            //{
            //    if (data.RolId == 647)
            //    {
            //        lista.Add(data);
            //    }
            //}

            //return lista;
            return usuarioRepo.listaUsuariosXPerfil();
        }

        public void guardaSSOUserRol(SSO_Users_Role userRol)
        {
            usuarioRepo.guardaSSOUserRol(userRol);
        }

        public IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> listaAppXUsuario(int idUsuario, int idEfector)
        {
            return usuarioRepo.listaAppXUsuario(idUsuario, idEfector);
        }

        public IEnumerable<SSO_Users_Role> listaUsuariosXIdPerfil(int idPerfil)
        {
            return usuarioRepo.listaUsuariosXIdPerfil(idPerfil);
        }

        public IEnumerable<SSO_Users_Role> listaPerfilXIdUsuario(int idUsuario)
        {
            return usuarioRepo.listaPerfilXIdUsuario(idUsuario);
        }
    }
}
