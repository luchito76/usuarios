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

        public void borrarPermisos(int idPermiso)
        {
            permisosRepo.borrarPermisos(idPermiso);
        }
        public void permisoModulo(SSO_Permission permisoModulo)
        {
            permisosRepo.permisoModulo(permisoModulo);
        }

        public IEnumerable<SSO_Permission> listaPermisosXId(int source, int idPermiso)
        {
            return permisosRepo.listaPermisosXId(source, idPermiso);
        }

        public void borrarPermisosCache(int idusuario)
        {
            permisosRepo.borrarPermisosCache(idusuario);
        }

        public IEnumerable<SSO_GetPermisosXUsuarioResultSet0> listaPermisosXUsuario(int idPerfil, int idEfector)
        {
            return permisosRepo.listaPermisosXUsuario(idPerfil, idEfector);
        }

        public void guardaPermisosCache(SSO_Permissions_Cache permisosCache)
        {
            permisosRepo.guardaPermisosCache(permisosCache);
        }
    }
}
