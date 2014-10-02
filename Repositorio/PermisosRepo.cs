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
    }
}
