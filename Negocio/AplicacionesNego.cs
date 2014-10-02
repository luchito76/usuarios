using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class AplicacionesNego
    {
        AplicacionesRepo aplicacionesRepo = new AplicacionesRepo();

        public IEnumerable<SSO_Application> listaAplicaciones()
        {
            return aplicacionesRepo.listaAplicaciones();
        }
    }
}
