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

        /// <summary>
        /// Devuelve todo los módulos que están habilitados en la tabla SSO_Permissions de acuerdo a una aplicación (idAPlicacion) seleccionada.
        /// </summary>
        /// <param name="idAplicacion"></param>
        /// <returns></returns>
        public IEnumerable<SSO_Permission> listaModulosXPermisos(int idAplicacion) { 
            IEnumerable<SSO_Permission> result = dominio.SSO_Permissions.Where(c => c.Target)
        }
    }
}
