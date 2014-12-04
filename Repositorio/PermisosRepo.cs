﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class PermisosRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public void guardarPermisos(SSO_Permission permisos)
        {
            dominio.Add(permisos);
            dominio.SaveChanges();
        }

        /// <summary>
        /// Deshabilita el módulo seleccionado del perfil correspondiente.
        /// </summary>
        public void permisoModulo(SSO_Permission permisoModulo)
        {
            dominio.AttachCopy(permisoModulo);
            dominio.SaveChanges();
        }

        /// <summary>
        /// Deshabilita el módulo seleccionado del usuario correspondiente.
        /// </summary>
        public void permisoModuloUsuario(SSO_Permissions_Cache ssoPermisoCache)
        {
            dominio.AttachCopy(ssoPermisoCache);
            dominio.SaveChanges();
        }

        public IEnumerable<SSO_Permission> listaPermisosXId(int source, int idPermiso)
        {
            IEnumerable<SSO_Permission> result = dominio.SSO_Permissions.Where(c => c.Target == idPermiso && c.Source == source).ToList();

            return result;
        }

        public IEnumerable<SSO_Permissions_Cache> listaPermisosCacheXIdUsuario(int idUsuario, int idAplicacion, int idModulo)
        {
            IEnumerable<SSO_Permissions_Cache> result = dominio.SSO_Permissions_Caches.Where(c => c.UserId == idUsuario && c.ApplicationId == idAplicacion && c.Target == idModulo).ToList();

            return result;
        }

        public IEnumerable<SSO_Permissions_Cache> listaPermisosCacheXIdUsuario(int idUsuario, int idAplicacion)
        {
            IEnumerable<SSO_Permissions_Cache> result = dominio.SSO_Permissions_Caches.Where(c => c.UserId == idUsuario && c.ApplicationId == idAplicacion).ToList();

            return result;
        }

        public void borrarPermisos(int idPermiso)
        {
            IList<SSO_Permission> ssoPermiso = dominio.SSO_Permissions.Where(c => c.Source == idPermiso).ToList();

            if (ssoPermiso != null)
            {
                foreach (SSO_Permission data in ssoPermiso)
                    dominio.Delete(data);
            }

            dominio.SaveChanges();
        }

        public void borrarPermisosCacheXIdRolGroup(int idRolGroup)
        {
            IList<SSO_Permissions_Cache> ssoPermisoCache = dominio.SSO_Permissions_Caches.Where(c => c.GroupId == idRolGroup).ToList();

            if (ssoPermisoCache != null)
            {
                foreach (SSO_Permissions_Cache data in ssoPermisoCache)
                    dominio.Delete(data);
            }

            dominio.SaveChanges();
        }

        public void borrarPermisosCacheXIdUsuario(int idusuario)
        {
            IList<SSO_Permissions_Cache> ssoPermisosCache = dominio.SSO_Permissions_Caches.Where(c => c.UserId == idusuario).ToList();

            if (ssoPermisosCache != null)
            {
                foreach (SSO_Permissions_Cache data in ssoPermisosCache)
                    dominio.Delete(data);

            }

            dominio.SaveChanges();
        }

        public IEnumerable<SSO_GetPermisosXUsuarioResultSet0> listaPermisosXUsuario(int idPerfil, int idEfector)
        {
            IEnumerable<SSO_GetPermisosXUsuarioResultSet0> result = dominio.SSO_GetPermisosXUsuario(idPerfil, idEfector).ToList();

            return result;
        }

        public void guardaPermisosCache(SSO_Permissions_Cache permisosCache)
        {
            dominio.Add(permisosCache);
            dominio.SaveChanges();            
        }

        public void guardaPermisosCache(int idPerfil, int idAplicacion, int groupId)
        {
            //dominio.SSO_Set_PermissionCache(idPerfil, idAplicacion, groupId);            
            
        }
    }
}
