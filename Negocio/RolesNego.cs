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

        public IEnumerable<SSO_Role> listaEfectores()
        {
            return rolesRepo.listaEfectores();
        }

        public SSO_Role listaRolesXId(int idRol)
        {
            return rolesRepo.listaRolesXId(idRol);
        }

        public IEnumerable<SSO_GetAppByRolResultSet0> listaRolesXAplicacion(int rol, int efector)
        {
            return rolesRepo.listaRolesXAplicacion(rol, efector);
        }

        public IEnumerable<SSO_Users_Role> listaUserRolXIdUsuario(int idUsuario)
        {
            return rolesRepo.listaUserRolXIdUsuario(idUsuario);
        }

        public int validaEfectorXUserRol(int idUsuario, int idEfector)
        {
            int idEfectorSeleccionado = 0;

            IList<SSO_Users_Role> listaUserRole = rolesRepo.listaUserRolXIdUsuario(idUsuario).ToList();

            foreach (SSO_Users_Role data in listaUserRole)
            {
                if (data.RoleId == idEfector)
                    idEfectorSeleccionado = idEfector;
            }

            return idEfectorSeleccionado;
        }

        public int validaPerfilXUserRol(int idUsuario, int idPerfil)
        {
            int idPerfilSeleccionado = 0;

            IList<SSO_Users_Role> listaUserRole = rolesRepo.listaUserRolXIdUsuario(idUsuario).ToList();

            foreach (SSO_Users_Role data in listaUserRole)
            {
                if (data.RoleId == idPerfil)
                    idPerfilSeleccionado = idPerfil;
            }

            return idPerfilSeleccionado;
        }

        public SSO_RoleGroups_Member validaRolGroupMember(int idRolGroup)
        {
            return rolesRepo.validaRolGroupMember(idRolGroup);
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

        public void guardaRolGroupMember(SSO_RoleGroups_Member ssoRolGroupMember)
        {
            rolesRepo.guardaRolGroupMember(ssoRolGroupMember);
        }

        public SSO_RoleGroup obtieneUltimoIdRolGroup()
        {
            return rolesRepo.obtieneUltimoIdRolGroup();
        }
        public IEnumerable<SSO_RoleGroup> eliminarAplicacionXRol(int idEfector, int idPerfil)
        {
            return rolesRepo.eliminarAplicacionXRol(idEfector, idPerfil).ToList();
        }

        public int devuelveIdRolGroupXPermisos(int idEfector, int idPerfil)
        {
            return rolesRepo.devuelveIdRolGroupXPermisos(idEfector, idPerfil);
        }

        public int devuelveIdRolGroup(int idEfector, int idPerfil)
        {
            int idRolGroup = rolesRepo.devuelveIdRolGroup(idEfector, idPerfil);

            return idRolGroup;
        }

        /// <summary>
        /// Comprueba si el efector, el perfil y la aplicacion ya están en la tabla RoleGroup.
        /// </summary>
        /// <param name="idEfector"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idAplicacion"></param>
        /// <returns></returns>
        public bool esAplicacionEnRoleGroup(int idEfector, int idPerfil)
        {
            bool compruebaAplicacionEnRoleGroup = true;

            int? idRolGroup = rolesRepo.devuelveIdRolGroup(idEfector, idPerfil);

            if (idRolGroup != 0)
                compruebaAplicacionEnRoleGroup = false;

            return compruebaAplicacionEnRoleGroup;
        }

        public void borrarRoleGroups(int idRoleGroup)
        {
            rolesRepo.borrarRoleGroups(idRoleGroup);
        }

        /// <summary>
        /// Elimina el perfil y el efector de un usuario en la tabla SSO_Users_Roles. Se usa para los hospitales.
        /// </summary>
        /// <param name="idUsuario"></param>
        public void borrarUserRol(int idUsuario)
        {
            rolesRepo.borrarUserRol(idUsuario);
        }

        /// <summary>
        /// Elimina los efectores o perfiles relacionados a un Usuario de la tabla SSO_Users_Roles dependiendo si el parámetro RolId
        /// es un Perfil o un Efector. Se usa para Nivel Central.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="RolId"></param>
        public void borrarUserRol(int idUsuario, int idEfector)
        {
            rolesRepo.borrarUserRol(idUsuario, idEfector);
        }
    }
}
