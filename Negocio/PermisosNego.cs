﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class PermisosNego
    {
        PermisosRepo permisosRepo = new PermisosRepo();

        public void guardarPermisos(SSO_Permission permisos)
        {
            permisosRepo.guardarPermisos(permisos);
        }

        public void borrarPermisos(int idPermiso)
        {
            permisosRepo.borrarPermisos(idPermiso);
        }
        public void permisoModulo(SSO_Permission permisoModulo)
        {
            permisosRepo.permisoModulo(permisoModulo);
        }

        public void permisoModuloUsuario(SSO_Permissions_Cache ssoPermisoCache)
        {
            permisosRepo.permisoModuloUsuario(ssoPermisoCache);
        }

        public IEnumerable<SSO_Permission> listaPermisosXId(int source, int idPermiso)
        {
            return permisosRepo.listaPermisosXId(source, idPermiso);
        }

        public IEnumerable<SSO_Permissions_Cache> listaPermisosCacheXIdUsuario(int idUsuario, int idAplicacion, int idModulo)
        {
            return permisosRepo.listaPermisosCacheXIdUsuario(idUsuario, idAplicacion, idModulo);
        }

        /// <summary>
        /// Este método comprueba si el usuario ya tiene permisos sobre una aplicación en la tabla Permission_Cache
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idAplicacion"></param>
        /// <returns></returns>
        public bool esUsuarioEnPermisoCache(int idUsuario, int idAplicacion)
        {
            bool compruebaUsuario = false;

            IList<SSO_Permissions_Cache> listaPermisoCache = permisosRepo.listaPermisosCacheXIdUsuario(idUsuario, idAplicacion).ToList();

            if (listaPermisoCache.Count == 0)
                compruebaUsuario = true;

            return compruebaUsuario;
        }

        public void borrarPermisosCacheXIdRolGroup(int idRolGroup)
        {
            permisosRepo.borrarPermisosCacheXIdRolGroup(idRolGroup);
        }

        public void borrarPermisosCacheXIdUsuario(int idusuario)
        {
            permisosRepo.borrarPermisosCacheXIdUsuario(idusuario);
        }

        public IEnumerable<SSO_GetPermisosXUsuarioResultSet0> listaPermisosXUsuario(int idPerfil, int idEfector)
        {
            return permisosRepo.listaPermisosXUsuario(idPerfil, idEfector);
        }

        public void guardaPermisosCache(SSO_Permissions_Cache permisosCache)
        {
            permisosRepo.guardaPermisosCache(permisosCache);
        }

        public void guardaPermisosCache(int idPerfil, int idAplicacion, int groupId)
        {
            permisosRepo.guardaPermisosCache(idPerfil, idAplicacion, groupId);
        }
    }
}
