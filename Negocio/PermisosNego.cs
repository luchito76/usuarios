using System;
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

        public void borrarPermisos(int idRolGroup, int idAplicacion)
        {
            permisosRepo.borraPermisos(idRolGroup, idAplicacion);
        }

        public void permisoModulo(SSO_Permission permisoModulo)
        {
            permisosRepo.permisoModulo(permisoModulo);
        }

        public void permisoModuloUsuario(SSO_Permissions_Cache ssoPermisoCache)
        {
            permisosRepo.permisoModuloUsuario(ssoPermisoCache);
        }

        public SSO_Permission listaPermisosXId(int source, int idPermiso)
        {
            return permisosRepo.listaPermisosXId(source, idPermiso);
        }

        public SSO_Permissions_Cache listaPermisosCacheXIdUsuario(int idUsuario, int idAplicacion, int idModulo)
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

            SSO_Permissions_Cache listaPermisoCache = new SSO_Permissions_Cache();
            listaPermisoCache = permisosRepo.listaPermisosCacheXIdUsuario(idUsuario, idAplicacion);

            if (listaPermisoCache == null)
                compruebaUsuario = true;

            return compruebaUsuario;
        }

        public void borrarPermisosCacheXIdRolGroup(int idRolGroup)
        {
            permisosRepo.borrarPermisosCacheXIdRolGroup(idRolGroup);
        }

        public void borrarPermisosCacheXIdUsuario(int idRolGroup, int idusuario, int idAplicacion)
        {
            permisosRepo.borrarPermisosCacheXIdUsuario(idRolGroup, idusuario, idAplicacion);
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

        public IEnumerable<SSO_AllowedAppsByEfectorCentralResultSet0> listaPerfilesXEfector(int idUsuario)
        {
            return permisosRepo.listaPerfilesXEfector(idUsuario);
        }

        public void guardaPermisosCache(int idPerfil, int idAplicacion, int groupId)
        {
            permisosRepo.guardaPermisosCache(idPerfil, idAplicacion, groupId);
        }
    }
}
