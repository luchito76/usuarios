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

        public void borrarPermisos(int idPermiso)
        {
            SSO_Permission ssoPermiso = dominio.SSO_Permissions.Where(c => c.Source == idPermiso).FirstOrDefault();
            dominio.Delete(ssoPermiso);
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

        public IEnumerable<SSO_Permission> listaPermisosXId(int source, int idPermiso)
        {
            IEnumerable<SSO_Permission> result = dominio.SSO_Permissions.Where(c => c.Target == idPermiso && c.Source == source).ToList();

            return result;
        }

        public void borrarPermisosCache(int idusuario)
        {
            SSO_Permissions_Cache ssoPermisosCache = dominio.SSO_Permissions_Caches.Where(c => c.UserId == idusuario).FirstOrDefault();

            if (ssoPermisosCache != null)
            {
                dominio.Delete(ssoPermisosCache);
                dominio.SaveChanges();
            }
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
    }
}
