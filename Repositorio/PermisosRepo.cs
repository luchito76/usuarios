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
        public void guardarPermisos(SSO_Permission permisos)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.Add(permisos);
                dominio.SaveChanges();
            }
        }

        /// <summary>
        /// Deshabilita el módulo seleccionado del perfil correspondiente.
        /// </summary>
        public void permisoModulo(SSO_Permission permisoModulo)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.AttachCopy(permisoModulo);
                dominio.SaveChanges();
            }
        }

        /// <summary>
        /// Deshabilita el módulo seleccionado del usuario correspondiente.
        /// </summary>
        public void permisoModuloUsuario(SSO_Permissions_Cache ssoPermisoCache)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.AttachCopy(ssoPermisoCache);
                dominio.SaveChanges();
            }
        }

        public SSO_Permission listaPermisosXId(int source, int idPermiso)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Permission result = dominio.SSO_Permissions.FirstOrDefault(c => c.Target == idPermiso && c.Source == source);

                return dominio.CreateDetachedCopy(result);
            }
        }

        public SSO_Permissions_Cache listaPermisosCacheXIdUsuario(int idUsuario, int idAplicacion, int idModulo, int idRolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Permissions_Cache result = dominio.SSO_Permissions_Caches.FirstOrDefault(c => c.UserId == idUsuario && c.ApplicationId == idAplicacion && c.Target == idModulo && c.GroupId == idRolGroup);

                if (result != null)
                    return dominio.CreateDetachedCopy(result);
                else
                    return null;
            }
        }

        public SSO_Permissions_Cache listaPermisoCacheXIdUsuario(int idUsuario, int idAplicacion, int idRolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Permissions_Cache result = dominio.SSO_Permissions_Caches.FirstOrDefault(c => c.UserId == idUsuario && c.ApplicationId == idAplicacion && c.GroupId == idRolGroup);

                if (result != null)
                    return dominio.CreateDetachedCopy(result);
                else
                    return null;
            }
        }

        public void borraPermisos(int idRolGroup, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_Module> listaModulos = dominio.SSO_Modules.Where(c => c.ApplicationId == idAplicacion).ToList();

                List<SSO_Permission> listaPermisos = new List<SSO_Permission>();

                foreach (SSO_Module data in listaModulos)
                {
                    SSO_Permission ssoPermiso = new SSO_Permission();
                    ssoPermiso = dominio.SSO_Permissions.Where(c => c.Source == idRolGroup && c.Target == data.Id).FirstOrDefault();

                    if (ssoPermiso != null)
                        listaPermisos.Add(ssoPermiso);
                }

                if (listaPermisos.Count != 0)
                {
                    foreach (SSO_Permission data in listaPermisos)
                        dominio.Delete(data);
                }

                dominio.SaveChanges();
            }
        }

        public void borrarPermisosCacheXIdRolGroup(int idRolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_Permissions_Cache> ssoPermisoCache = dominio.SSO_Permissions_Caches.Where(c => c.GroupId == idRolGroup).ToList();

                if (ssoPermisoCache != null)
                {
                    foreach (SSO_Permissions_Cache data in ssoPermisoCache)
                        dominio.Delete(data);
                }

                dominio.SaveChanges();
            }
        }

        public void borrarPermisosCacheXIdUsuario(int idRolGroup, int idUsuario, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_Permissions_Cache> ssoPermisoCache = dominio.SSO_Permissions_Caches.Where(c => c.GroupId == idRolGroup && c.UserId == idUsuario && c.ApplicationId == idAplicacion).ToList();

                if (ssoPermisoCache != null)
                {
                    foreach (SSO_Permissions_Cache data in ssoPermisoCache)
                        dominio.Delete(data);
                }

                dominio.SaveChanges();
            }
        }

        public void borrarPermisosCacheXIdUsuario(int idRolGroup, int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_Permissions_Cache> ssoPermisoCache = dominio.SSO_Permissions_Caches.Where(c => c.GroupId == idRolGroup && c.UserId == idUsuario).ToList();

                if (ssoPermisoCache != null)
                {
                    foreach (SSO_Permissions_Cache data in ssoPermisoCache)
                        dominio.Delete(data);
                }

                dominio.SaveChanges();
            }
        }

        public void borrarPermisosCacheXIdUsuario(int idusuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IList<SSO_Permissions_Cache> ssoPermisosCache = dominio.SSO_Permissions_Caches.Where(c => c.UserId == idusuario).ToList();

                if (ssoPermisosCache != null)
                {
                    foreach (SSO_Permissions_Cache data in ssoPermisosCache)
                        dominio.Delete(data);

                }

                dominio.SaveChanges();
            }
        }

        public IEnumerable<SSO_GetPermisosXUsuarioResultSet0> listaPermisosXUsuario(int idPerfil, int idEfector)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetPermisosXUsuarioResultSet0> result = dominio.SSO_GetPermisosXUsuario(idPerfil, idEfector).ToList();

                return result;
            }
        }

        public void guardaPermisosCache(SSO_Permissions_Cache permisosCache)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.Add(permisosCache);
                dominio.SaveChanges();
            }
        }

        /// <summary>
        /// Devuelve un listado de los Efectores asociados al perfil del usuario.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SSO_AllowedAppsByEfectorCentralResultSet0> listaEfectoresXPerfil(int idUsuario, int idPerfil)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_AllowedAppsByEfectorCentralResultSet0> result = dominio.SSO_AllowedAppsByEfectorCentral(idUsuario, idPerfil).ToList();

                return result;
            }
        }

        public void guardaPermisosCache(int idPerfil, int idAplicacion, int groupId)
        {
            //dominio.SSO_Set_PermissionCache(idPerfil, idAplicacion, groupId);            

        }
    }
}
