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

        //public SSO_User traeUsuario(int id)
        //{
        //    return usuarioRepo.traeUsuario(id);
        //}

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
