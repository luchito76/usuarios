using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Newtonsoft.Json;
namespace AdminRoles
{
    public partial class Modulo : System.Web.UI.Page
    {
        #region helperModulo
        public class moduloHelper
        {
            private int idModulo;

            public int IdModulo
            {
                get { return idModulo; }
                set { idModulo = value; }
            }

            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

        }
        #endregion

        ModulosNego moduloNego = new ModulosNego();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string devuelveModulosXAplicacionJson()
        {
            string json = string.Empty;

            int idAplicacion = int.Parse(Request["idAplicacion"].ToString());

            List<SSO_Module> listaModulosXAplicacion = moduloNego.listaModulosXIdAplicacion(idAplicacion).ToList();

            List<moduloHelper> lista = new List<moduloHelper>();

            foreach (SSO_Module data in listaModulosXAplicacion)
            {
                moduloHelper helper = new moduloHelper();

                helper.IdModulo = data.Id;
                helper.Descripcion = data.Description;

                lista.Add(helper);
            }

            return json = JsonConvert.SerializeObject(lista);
        }

    }
}