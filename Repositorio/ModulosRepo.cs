using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ModulosRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<SSO_Module> listaModulosXIdAplicacion(int idAplicacion)
        {
            IEnumerable<SSO_Module> result = dominio.SSO_Modules.Where(c => c.ApplicationId == idAplicacion).ToList();

            return result;
        }
    }
}
