using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data;

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

        public void guardaProfesionalEnGuardia(int idProfesional, bool estado)
        {
            //Refactorizar todo esto!!!
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            SqlParameter param;
            SqlParameter param1;
            DataSet ds = new DataSet();

            connetionString = "Data Source=10.1.232.23;Initial Catalog=SSO_8;User ID=sa;Password=ssecure";
            connection = new SqlConnection(connetionString);

            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SSO_SetProfesionalEnGuardia";


            param = new SqlParameter("@idProfesional", idProfesional);
            param1 = new SqlParameter("@estado", estado);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            command.Parameters.Add(param);
            command.Parameters.Add(param1);

            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            connection.Close();
        }

        public IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> listaProfesionalesEnGuardiaXIdProfesional(int idProfesional)
        {
            IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> result = dominio.SSO_GetProfesionalesXGuardia(idProfesional).ToList();

            return result;
        }
    }
}
