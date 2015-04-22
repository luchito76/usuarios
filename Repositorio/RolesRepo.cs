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

        public IEnumerable<SSO_Role> listaEfectores()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Role> result = dominio.SSO_Roles.Where(c => c.Parent == 494).OrderBy(c => c.Name).ToList();

                return dominio.CreateDetachedCopy(result);
            }
        }

        public SSO_Role listaRolesXId(int idRol)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Role result = dominio.SSO_Roles.Where(c => c.Id == idRol).FirstOrDefault();

                return dominio.CreateDetachedCopy(result);
            }
        }

        public IEnumerable<SSO_Users_Role> listaUserRolXIdUsuario(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Users_Role> result = dominio.SSO_Users_Roles.Where(c => c.UserId == idUsuario).ToList();

                return dominio.CreateDetachedCopy(result);
            }
        }

        public SSO_RoleGroups_Member validaRolGroupMember(int idRolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_RoleGroups_Member result = dominio.SSO_RoleGroups_Members.FirstOrDefault(c => c.GroupId == idRolGroup);

                if (result != null)
                    return dominio.CreateDetachedCopy(result);
                else
                    return null;
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

        public void guardaRolGroupMember(SSO_RoleGroups_Member ssoRolGroupMember)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.Add(ssoRolGroupMember);
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

        public IEnumerable<SSO_RoleGroup> eliminarAplicacionXRol(int idEfector, int idPerfil)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_RoleGroup> result = dominio.SSO_RoleGroups.Where(c => c.IdEfector == idEfector && c.IdPerfil == idPerfil).ToList();

                return dominio.CreateDetachedCopy(result);
            }
        }

        public int devuelveIdRolGroup(int idEfector, int idPerfil)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                int idRolGroup = 0;

                SSO_RoleGroup rolGroup = new SSO_RoleGroup();
                rolGroup = dominio.SSO_RoleGroups.Where(c => c.IdEfector == idEfector && c.IdPerfil == idPerfil).FirstOrDefault();

                if (rolGroup != null)
                    idRolGroup = rolGroup.Id;

                return idRolGroup;
            }
        }

        public int devuelveIdRolGroupXPermisos(int idEfector, int idPerfil)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Permission rol = (from permiso in dominio.SSO_Permissions
                                      join rolGroup in dominio.SSO_RoleGroups on permiso.Source equals rolGroup.Id
                                      where rolGroup.IdEfector == idEfector && rolGroup.IdPerfil == idPerfil
                                      select permiso).FirstOrDefault();

                int idRolGroup = rol.Source;

                return idRolGroup;
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

        public void borrarUserRol(int idUsuario, int idEfector)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_Users_Role> borrarUserRole = dominio.SSO_Users_Roles.Where(c => c.UserId == idUsuario && c.RoleId == idEfector).ToList();
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
