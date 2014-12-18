using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Repositorio
{
    public class ProfesionalRepo
    {
        public IEnumerable<SSO_GetProfesionalesResultSet0> listaProfesionales()
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetProfesionalesResultSet0> result = dominio.SSO_GetProfesionales().ToList();

                return result;
            }
        }

        public void vincularProfesional(SSO_StoredVariable vincularProfesional)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                borrarStoredVariable(vincularProfesional.Target);

                dominio.Add(vincularProfesional);
                dominio.SaveChanges();
            }
        }

        private void borrarStoredVariable(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                dominio.SSO_BorrarStoredVariable(idUsuario);
            }
        }

        public SSO_StoredVariable devuelveProfesionalXUsuario(int idUsuario)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                SSO_StoredVariable result = dominio.SSO_StoredVariables.FirstOrDefault(c => c.Target == idUsuario && c.Name == "Common_Medicos");

                return result;
            }
        }

        public IEnumerable<SSO_GetProfesionalXIdResultSet0> listaProfesionalXIdProfesional(int idProfesional)
        {
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetProfesionalXIdResultSet0> result = dominio.SSO_GetProfesionalXId(idProfesional).ToList();

                return result;
            }
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

            connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["SSO_HOSPITALConnection"].ConnectionString;// "Data Source=10.1.232.15;Initial Catalog=SSO;User ID=sa;Password=ssecure";
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
            using (ModeloDominio dominio = new ModeloDominio())
            {
                IEnumerable<SSO_GetProfesionalesXGuardiaResultSet0> result = dominio.SSO_GetProfesionalesXGuardia(idProfesional).ToList();

                return result;
            }
        }
    }
}
