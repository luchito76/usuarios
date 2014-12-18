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
        public IEnumerable<SSO_Module> listaModulosXIdAplicacion(int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Module> result = dominio.SSO_Modules.Where(c => c.ApplicationId == idAplicacion).ToList();

                return result;
            }
        }

        /// <summary>
        /// Devuelve todo los módulos que están habilitados en la tabla SSO_Permissions de acuerdo a una aplicación (idAPlicacion) seleccionada.
        /// </summary>
        /// <param name="idAplicacion"></param>
        /// <returns></returns>
        public IEnumerable<SSO_GetModulosXAplicacionResultSet0> listaModulosXPermisos(int idEfector, int idPerfil, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetModulosXAplicacionResultSet0> result = dominio.SSO_GetModulosXAplicacion(idEfector, idPerfil, idAplicacion).ToList();

                return result;
            }
        }

        /// <summary>
        /// Devuelve todo los módulos que están habilitados en la tabla SSO_Permissions_Cache de acuerdo a un usuario (idUsuario) seleccionado.
        /// </summary>
        /// <param name="idAplicacion"></param>
        /// <returns></returns>
        public IEnumerable<SSO_GetModulosXUsuarioResultSet0> listaModulosXUsuario(int idEfector, int idUsuario, int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetModulosXUsuarioResultSet0> result = dominio.SSO_GetModulosXUsuario(idEfector, idUsuario, idAplicacion).ToList();

                return result;
            }
        }
    }
}
