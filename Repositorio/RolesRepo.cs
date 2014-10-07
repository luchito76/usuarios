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
            IEnumerable<SSO_Role> result = dominio.SSO_Roles.ToList();

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

        public void guardarRolGroupMember(SSO_RoleGroups_Member rolGroupmember)
        {
            dominio.Add(rolGroupmember);
            dominio.SaveChanges();
        }
    }
}
