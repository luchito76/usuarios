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
    public partial class UsuariosXAplicacion : System.Web.UI.Page
    {
        AplicacionesNego aplicacionesNego = new AplicacionesNego();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string devuelveUsuariosXAplicacionJson()
        {
            string json = string.Empty;

            int idApp = int.Parse(Request["idAplicacion"].ToString());

            IList<SSO_GetUsuariosXAplicacionResultSet0> lista = aplicacionesNego.listaUsuariosXAplicacion(idApp).ToList();

            return json = JsonConvert.SerializeObject(lista, Formatting.Indented);
        }
    }
}