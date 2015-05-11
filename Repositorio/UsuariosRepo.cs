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

        public IEnumerable<SSO_User> listaUsuarios()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_User> result = dominio.SSO_Users.Select(x => new SSO_User { Id = x.Id, Surname = String.Format("{0}, {1} - {2}", x.Surname, x.Name, x.Documento) }).OrderBy(c => c.Surname).Distinct().ToList();

                return result;
            }
        }

        public IEnumerable<SSO_GetUsuariosXPerfilResultSet02> listaUsuariosXPerfil()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetUsuariosXPerfilResultSet02> result = dominio.SSO_GetUsuariosXPerfil().ToList();

                return result;
            }
        }

        public IEnumerable<SSO_GetAplicacionesXEfectorResultSet0> listaAppXUsuario(int idUsuario, int idEfector, int idRolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                //IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> result = dominio.Sp_SSO_AllowedAppsByEfector(idUsuario, idEfector).ToList();
                IEnumerable<SSO_GetAplicacionesXEfectorResultSet0> result = dominio.SSO_GetAplicacionesXEfector(idUsuario, idEfector, idRolGroup).ToList();

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
