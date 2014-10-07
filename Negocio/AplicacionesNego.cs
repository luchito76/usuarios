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

        public IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> listaUsuariosXAplicacion(int idAplicacion)
        {
            return aplicacionesRepo.listaUsuariosXAplicacion(idAplicacion);
        }
    }
}
