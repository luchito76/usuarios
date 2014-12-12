using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class RolesRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<SSO_Role> listaRoles()
        {
            IEnumerable<SSO_Role> result = dominio.SSO_Roles.OrderBy(c => c.Name).ToList();

            return result;
        }

        public IEnumerable<SSO_Users_Role> listaUserRolXIdUsuario(int idUsuario)
        {
            IEnumerable<SSO_Users_Role> result = dominio.SSO_Users_Roles.Where(c => c.UserId == idUsuario).ToList();

            return result;
        }

        public IEnumerable<SSO_GetAppByRolResultSet0> listaRolesXAplicacion(int rol, int efector)
        {
            IEnumerable<SSO_GetAppByRolResultSet0> result = dominio.SSO_GetAppByRol(rol, efector).ToList();

            return result;
        }

        public void guardarRol(SSO_Role rol)
        {
            dominio.Add(rol);
            dominio.SaveChanges();
        }

        public void actualizarRol(SSO_Role rol)
        {
            dominio.AttachCopy(rol);
            dominio.SaveChanges();
        }

        public void guardaRoleGroup(SSO_RoleGroup rolGroup)
        {
            dominio.Add(rolGroup);
            dominio.SaveChanges();
        }

        public SSO_RoleGroup obtieneUltimoIdRolGroup()
        {
            IEnumerable<SSO_RoleGroup> result = dominio.SSO_RoleGroups;
            SSO_RoleGroup rolGroup = result.Last();

            return rolGroup;
        }

        public IEnumerable<SSO_RoleGroup> eliminarAplicacionXRol(int idEfector, int idPerfil, int idAplicacion)
        {
            IEnumerable<SSO_RoleGroup> result = dominio.SSO_RoleGroups.Where(c => c.IdEfector == idEfector && c.IdPerfil == idPerfil && c.IdAplicacion == idAplicacion);

            return result;
        }

        public int devuelveIdRolGroup(int idEfector, int idPerfil, int idAplicacion)
        {
            int idRolGroup = 0;

            SSO_RoleGroup rolGroup = new SSO_RoleGroup();
            rolGroup = dominio.SSO_RoleGroups.Where(c => c.IdEfector == idEfector && c.IdPerfil == idPerfil && c.IdAplicacion == idAplicacion).FirstOrDefault();

            if (rolGroup != null)
                idRolGroup = rolGroup.Id;

            return idRolGroup;
        }

        public int devuelveIdRolGroupXPermisos(int idEfector, int idPerfil, int idAplicacion)
        {
            var rolGroup = (from roleGroups in dominio.SSO_RoleGroups
                            join permisos in dominio.SSO_Permissions on roleGroups.Id equals permisos.Source
                            where (roleGroups.IdEfector == idEfector && roleGroups.IdPerfil == idPerfil && roleGroups.IdAplicacion == idAplicacion)
                            select new { source = permisos.Source }).FirstOrDefault();

            int idRolGroup = rolGroup.source;

            return idRolGroup;
        }


        public void borrarRoleGroups(int idRoleGroup)
        {
            IList<SSO_RoleGroup> listaRolGroup = dominio.SSO_RoleGroups.Where(c => c.Id == idRoleGroup).ToList();

            if (listaRolGroup != null)
            {
                foreach (SSO_RoleGroup data in listaRolGroup)
                    dominio.Delete(data);
            }

            dominio.SaveChanges();
        }

        public void borrarUserRol(int idUsuario)
        {
            IList<SSO_Users_Role> borrarUserRole = dominio.SSO_Users_Roles.Where(c => c.UserId == idUsuario).ToList();

            {
                foreach (SSO_Users_Role data in borrarUserRole)
                {
                    dominio.Delete(data);
                    dominio.SaveChanges();
                }
            }
        }
    }
}
