using System;
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
    }
}
