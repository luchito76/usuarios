using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class RolesNego
    {
        RolesRepo rolesRepo = new RolesRepo();

        public IEnumerable<SSO_Role> listaRoles(int parent, bool enable)
        {
            IList<SSO_Role> rol = rolesRepo.listaRoles().ToList();

            List<SSO_Role> listaRoles = new List<SSO_Role>();

            foreach (SSO_Role data in rol)
            {
                if ((data.Parent == parent) && (data.Enabled == enable))
                {
                    SSO_Role ssoRol = new SSO_Role();

                    ssoRol.Id = data.Id;
                    ssoRol.Name = data.Name;
                    listaRoles.Add(ssoRol);
                }
            }

            return listaRoles;
        }

        public IEnumerable<SSO_GetAppByRolResultSet0> listaRolesXAplicacion(int rol, int efector)
        {
            return rolesRepo.listaRolesXAplicacion(rol, efector);
        }

        public void guardarRol(SSO_Role rol)
        {
            rolesRepo.guardarRol(rol);
        }

        public void actualizarRol(SSO_Role rol)
        {
            rolesRepo.actualizarRol(rol);
        }

        public void guardaRoleGroup(SSO_RoleGroup rolGroup)
        {
            rolesRepo.guardaRoleGroup(rolGroup);
        }

        public SSO_RoleGroup obtieneUltimoIdRolGroup()
        {
            return rolesRepo.obtieneUltimoIdRolGroup();
        }
        public void guardarRolGroupMember(SSO_RoleGroups_Member rolGroupmember)
        {
            rolesRepo.guardarRolGroupMember(rolGroupmember);
        }

    }
}
