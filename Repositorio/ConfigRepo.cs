using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ConfigRepo
    {
        ModeloDominio dominio = new ModeloDominio();
        public IEnumerable<SSO_Config> listaConfig()
        {
            IEnumerable<SSO_Config> result = dominio.SSO_Configs.ToList();

            return result;
        }
    }
}
