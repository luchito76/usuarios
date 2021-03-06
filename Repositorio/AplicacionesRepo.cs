﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class AplicacionesRepo
    {
        public IEnumerable<SSO_Application> listaAplicacionesHospital()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Application> result = dominio.SSO_Applications.Where(c => c.Hospital == true && c.Intefase_visible == true).OrderBy(c => c.Description).ToList();

                return result;
            }
        }

        public IEnumerable<SSO_Application> listaAplicacionesNivelCentral()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_Application> result = dominio.SSO_Applications.Where(c => c.Sips == true && c.Intefase_visible == true).OrderBy(c => c.Description).ToList();

                return result;
            }
        }

        public IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> listaUsuariosXAplicacion(int idAplicacion)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetUsuariosXAplicacionResultSet0> result = dominio.SSO_GetUsuariosXAplicacion(idAplicacion).ToList();

                return result;
            }
        }

        public IEnumerable<SSO_GetAplicacionesXPerfilResultSet0> listaAplicacionesXPerfil(int idRolGroup)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetAplicacionesXPerfilResultSet0> result = dominio.SSO_GetAplicacionesXPerfil(idRolGroup).ToList();

                return result;
            }
        }
    }
}
