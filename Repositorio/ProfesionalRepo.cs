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
            dominio.SSO_Actualiza_StoredVariables(idUsuario);
        }       

        public IEnumerable<SSO_StoredVariable> devuelveProfesionalXUsuario(int idUsuario)
        {
            IEnumerable<SSO_StoredVariable> result = dominio.SSO_StoredVariables.Where(c => c.Target == idUsuario).ToList();

            return result;
        }

        public IEnumerable<Sys_Profesional> listaProfesionalXIdProfesional(int idProfesional)
        {
            IEnumerable<Sys_Profesional> result = dominio.Sys_Profesionals.Where(c => c.IdProfesional == idProfesional).ToList();

            return result;
        }
    }
}
