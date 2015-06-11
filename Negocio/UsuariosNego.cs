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

        public SSO_User devuelveUsuarioXIdUsuario(int idUsuario)
        {
            return usuarioRepo.devuelveUsuarioXIdUsuario(idUsuario);
        }

        public void actualizarUsuario(SSO_User ssoUsuario)
        {
            usuarioRepo.actualizarUsuario(ssoUsuario);
        }

        public IEnumerable<SSO_User> listaUsuarios()
        {
            return usuarioRepo.listaUsuarios();
        }

        public IEnumerable<SSO_GetUsuariosXPerfilResultSet02> listaUsuariosXPerfil(string filtro)
        {
            IList<SSO_GetUsuariosXPerfilResultSet02> listaXUsuarios = usuarioRepo.listaUsuariosXPerfil().ToList();
            List<SSO_GetUsuariosXPerfilResultSet02> lista = new List<SSO_GetUsuariosXPerfilResultSet02>();

            if (filtro == "true")
            {
                foreach (SSO_GetUsuariosXPerfilResultSet02 data in listaXUsuarios)
                {
                    if (data.RolId != null)
                        lista.Add(data);
                }
                return lista;
            }
            else
                return usuarioRepo.listaUsuariosXPerfil();
        }

        public void guardaSSOUserRol(SSO_Users_Role userRol)
        {
            usuarioRepo.guardaSSOUserRol(userRol);
        }

        public IEnumerable<SSO_GetAplicacionesXEfectorResultSet0> listaAppXUsuario(int idUsuario, int idEfector, int idRolGroup)
        {
            return usuarioRepo.listaAppXUsuario(idUsuario, idEfector, idRolGroup);
        }

        public IEnumerable<SSO_Users_Role> listaUsuariosXIdPerfil(int idPerfil)
        {
            return usuarioRepo.listaUsuariosXIdPerfil(idPerfil);
        }

        public IEnumerable<SSO_Users_Role> listaPerfilXIdUsuario(int idUsuario)
        {
            return usuarioRepo.listaPerfilXIdUsuario(idUsuario);
        }

        public string devuelveEfectorSolicitadoXUsuario(int idUsuario)
        {
            string efectorSolicitado = usuarioRepo.devuelveUserRolesTempXUsuario(idUsuario, 494);

            return efectorSolicitado;
        }

        public string devuelvePerfilSolicitadoXUsuario(int idUsuario)
        {
            string perfilSolicitado = usuarioRepo.devuelveUserRolesTempXUsuario(idUsuario, 12);

            return perfilSolicitado;
        }
    }
}
