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
    }
}
