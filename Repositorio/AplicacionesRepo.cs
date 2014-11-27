using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class AplicacionesRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<SSO_Application> listaAplicacionesHospital()
        {
            IEnumerable<SSO_Application> result = dominio.SSO_Applications.Where(c => c.Hospital == true).ToList();

            return result;
        }

        public IEnumerable<SSO_Application> listaAplicacionesNivelCentral()
        {
            IEnumerable<SSO_Application> result = dominio.SSO_Applications.Where(c => c.Sips == true).ToList();

            return result;
        }

        public IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> listaUsuariosXAplicacion(int idAplicacion)
        {
            IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> result = dominio.SSO_GetUsuariosXAplicacion(idAplicacion).ToList();

            return result;
        }
    }
}
