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
        public SSO_User devuelveUsuarioXIdUsuario(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_User ssoUser = dominio.SSO_Users.FirstOrDefault(c => c.Id == idUsuario);

                return dominio.CreateDetachedCopy(ssoUser);
            }
        }

        public void actualizarUsuario(SSO_User ssoUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.AttachCopy(ssoUsuario);
                dominio.SaveChanges();
            }
        }

        public void guardaSSOUserRol(SSO_Users_Role userRol)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.Add(userRol);
                dominio.SaveChanges();
            }
        }

        public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> listaUsuariosXPerfil()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetUsuariosXPerfilResultSet01> result = dominio.SSO_GetUsuariosXPerfil().ToList();

                return result;
            }
        }

        public IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> listaAppXUsuario(int idUsuario, int idEfector)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> result = dominio.Sp_SSO_AllowedAppsByEfector(idUsuario, idEfector).ToList();

                return result;
            }
        }

        public IEnumerable<SSO_Users_Role> listaUsuariosXIdPerfil(int idPerfil)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Users_Role> result = dominio.SSO_Users_Roles.Where(c => c.RoleId == idPerfil).ToList();

                return result;
            }
        }

        public IEnumerable<SSO_Users_Role> listaPerfilXIdUsuario(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Users_Role> result = dominio.SSO_Users_Roles.Where(c => c.UserId == idUsuario).ToList();

                return dominio.CreateDetachedCopy(result);
            }
        }
    }
}
