using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class ProfesionalRepo
    {
        ModeloDominio dominio = new ModeloDominio();

        public IEnumerable<SSO_GetProfesionalesResultSet0> listaProfesionales()
        {
            IEnumerable<SSO_GetProfesionalesResultSet0> result = dominio.SSO_GetProfesionales().ToList();

            return result;
        }

        public void vincularProfesional(SSO_StoredVariable vincularProfesional)
        {
            dominio.Add(vincularProfesional);
            dominio.SaveChanges();
        }
    }
}
