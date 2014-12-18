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
        public SSO_Config idHospiatlConfig()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_Config result = dominio.SSO_Configs.Where(c => c.Name  == "idHospital").FirstOrDefault();

                return result;
            }
        }
    }
}
