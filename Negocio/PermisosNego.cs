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
    }
}
