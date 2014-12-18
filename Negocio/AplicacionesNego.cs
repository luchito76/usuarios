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
        ConfigRepo configRepo = new ConfigRepo();

        public string idHospital()
        {
            string idHospital = string.Empty;

            //List<SSO_Config> listaConfig = configRepo.listaConfig().ToList();
            idHospital = configRepo.listaConfig().ValueStr;

            //foreach (SSO_Config data in listaConfig)
            //{
            //    if (data.Name == "idHospital")
            //        idHospital = data.ValueStr;
            //}

            return idHospital;
        }
        public IEnumerable<SSO_Application> listaAplicaciones()
        {
            if (idHospital() != "0")
                return aplicacionesRepo.listaAplicacionesHospital();
            else
                return aplicacionesRepo.listaAplicacionesNivelCentral();
        }

        public IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> listaUsuariosXAplicacion(int idAplicacion)
        {
            return aplicacionesRepo.listaUsuariosXAplicacion(idAplicacion);
        }
    }
}
