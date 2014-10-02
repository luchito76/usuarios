using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class ModulosNego
    {
        ModulosRepo moduloRepo = new ModulosRepo();

        public IEnumerable<SSO_Module> listaModulosXIdAplicacion(int idAplicacion)
        {
            return moduloRepo.listaModulosXIdAplicacion(idAplicacion);
        }
    }
}
