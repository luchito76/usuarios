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

        public IEnumerable<SSO_User> devuelveUsuarioXIdUsuario(int idUsuario)
        {
            IEnumerable<SSO_User> result = dominio.SSO_Users.Where(c => c.Id == idUsuario).ToList();
            // SSO_User user = dominio.SSO_Users.Where(c => c.Id == idUsuario).FirstOrDefault();

            return result;
        }

        public SSO_User traeUsuario(int id)
        {
            using (ModeloDominio dbContext = new ModeloDominio())
            {
                SSO_User car = dbContext.SSO_Users.FirstOrDefault(c => c.Id == id);
                return dbContext.CreateDetachedCopy(car);
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
            dominio.Add(userRol);
            dominio.SaveChanges();
        }

        public IEnumerable<SSO_GetUsuariosXPerfilResultSet01> listaUsuariosXPerfil()
        {
            IEnumerable<SSO_GetUsuariosXPerfilResultSet01> result;

            using (ModeloDominio dominio = new ModeloDominio())
            {
                result = dominio.SSO_GetUsuariosXPerfil().ToList();
            }

            return result;
        }

        public IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> listaAppXUsuario(int idUsuario, int idEfector)
        {
            IEnumerable<sp_SSO_AllowedAppsByEfectorResultSet0> result;

            using (ModeloDominio dominio = new ModeloDominio())
            {

                result = dominio.Sp_SSO_AllowedAppsByEfector(idUsuario, idEfector).ToList();
            }

            return result;
        }

        public IEnumerable<SSO_Users_Role> listaUsuariosXIdPerfil(int idPerfil)
        {
            IEnumerable<SSO_Users_Role> result;

            using (ModeloDominio dominio = new ModeloDominio())
            {
                result = dominio.SSO_Users_Roles.Where(c => c.RoleId == idPerfil).ToList();
            }

            return result;
        }

        public IEnumerable<SSO_Users_Role> listaPerfilXIdUsuario(int idUsuario)
        {
            IEnumerable<SSO_Users_Role> result;

            using (ModeloDominio dominio = new ModeloDominio())
            {
                result = dominio.SSO_Users_Roles.Where(c => c.UserId == idUsuario).ToList();
            }

            return result;
        }
    }
}
