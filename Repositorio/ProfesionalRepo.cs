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
            borrarStoredVariable(vincularProfesional.Target);

            dominio.Add(vincularProfesional);
            dominio.SaveChanges();
        }

        private void borrarStoredVariable(int idUsuario)
        {
            dominio.SSO_BorrarStoredVariable(idUsuario);
        }

        public IEnumerable<SSO_StoredVariable> devuelveProfesionalXUsuario(int idUsuario)
        {
            IEnumerable<SSO_StoredVariable> result = dominio.SSO_StoredVariables.Where(c => c.Target == idUsuario).ToList();

            return result;
        }

        public IEnumerable<SSO_GetProfesionalXIdResultSet0> listaProfesionalXIdProfesional(int idProfesional)
        {
            IEnumerable<SSO_GetProfesionalXIdResultSet0> result = dominio.SSO_GetProfesionalXId(idProfesional).ToList();

            return result;
        }
    }
}
