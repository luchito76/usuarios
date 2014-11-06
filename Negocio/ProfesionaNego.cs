using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Negocio
{
    public class ProfesionaNego
    {
        ProfesionalRepo profesionalRepo = new ProfesionalRepo();

        public IEnumerable<SSO_GetProfesionalesResultSet0> listaProfesionales()
        {
            return profesionalRepo.listaProfesionales();
        }

        public void vincularProfesional(SSO_StoredVariable vincularProfesional)
        {
            profesionalRepo.vincularProfesional(vincularProfesional);
        }

        public IEnumerable<SSO_StoredVariable> devuelveProfesionalXUsuario(int idUsuario)
        {
            return profesionalRepo.devuelveProfesionalXUsuario(idUsuario);
        }

        public IEnumerable<Sys_Profesional> listaProfesionalXIdProfesional(int idProfesional)
        {
            return profesionalRepo.listaProfesionalXIdProfesional(idProfesional);
        }
    }
}
