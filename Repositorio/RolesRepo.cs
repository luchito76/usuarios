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
        public IEnumerable<SSO_Role> listaRoles()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Role> result = dominio.SSO_Roles.OrderBy(c => c.Name).ToList();

                return dominio.CreateDetachedCopy(result);
            }
        }

        public SSO_Users_Role listaUserRolXIdUsuario(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Users_Role result = dominio.SSO_Users_Roles.FirstOrDefault(c => c.UserId == idUsuario);

                return dominio.CreateDetachedCopy(result);
            }
        }

        public IEnumerable<SSO_GetAppByRolResultSet0> listaRolesXAplicacion(int rol, int efector)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetAppByRolResultSet0> result = dominio.SSO_GetAppByRol(rol, efector).ToList();

                return result;
            }
        }

        public void guardarRol(SSO_Role rol)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.Add(rol);
                dominio.SaveChanges();
            }
        }

        public void actualizarRol(SSO_Role rol)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.AttachCopy(rol);
                dominio.SaveChanges();
            }
        }

        public void guardaRoleGroup(SSO_RoleGroup rolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.Add(rolGroup);
                dominio.SaveChanges();
            }
        }

        public SSO_RoleGroup obtieneUltimoIdRolGroup()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_RoleGroup> result = dominio.SSO_RoleGroups;
                SSO_RoleGroup rolGroup = result.Last();

                return rolGroup;
            }
        }

        public IEnumerable<SSO_RoleGroup> eliminarAplicacionXRol(int idEfector, int idPerfil, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_RoleGroup> result = dominio.SSO_RoleGroups.Where(c => c.IdEfector == idEfector && c.IdPerfil == idPerfil && c.IdAplicacion == idAplicacion).ToList();

                return dominio.CreateDetachedCopy(result);
            }
        }

        public int devuelveIdRolGroup(int idEfector, int idPerfil, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                int idRolGroup = 0;

                SSO_RoleGroup rolGroup = new SSO_RoleGroup();
                rolGroup = dominio.SSO_RoleGroups.Where(c => c.IdEfector == idEfector && c.IdPerfil == idPerfil && c.IdAplicacion == idAplicacion).FirstOrDefault();

                if (rolGroup != null)
                    idRolGroup = rolGroup.Id;

                return idRolGroup;
            }
        }

        public int devuelveIdRolGroupXPermisos(int idEfector, int idPerfil, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                //SSO_RoleGroup rolGroup = (from roleGroups in dominio.SSO_RoleGroups
                //                join permisos in dominio.SSO_Permissions on roleGroups.Id equals permisos.Source
                //                where (roleGroups.IdEfector == idEfector && roleGroups.IdPerfil == idPerfil && roleGroups.IdAplicacion == idAplicacion)
                //                select new { source = permisos.Source }).FirstOrDefault();

                //SSO_RoleGroup idRolGroup = rolGroup.;

                //return idRolGroup;

                SSO_RoleGroup rol = (from roleGroups in dominio.SSO_RoleGroups
                                join permisos in dominio.SSO_Permissions on roleGroups.Id equals permisos.Source
                                where roleGroups.IdEfector == idEfector && roleGroups.IdPerfil == idPerfil && roleGroups.IdAplicacion == idAplicacion
                                select roleGroups).FirstOrDefault();

                int idRolGroup = rol.
            }
        }


        public void borrarRoleGroups(int idRoleGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_RoleGroup> listaRolGroup = dominio.SSO_RoleGroups.Where(c => c.Id == idRoleGroup).ToList();

                if (listaRolGroup != null)
                {
                    foreach (SSO_RoleGroup data in listaRolGroup)
                        dominio.Delete(data);
                }

                dominio.SaveChanges();
            }
        }

        public void borrarUserRol(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
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
}
