using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salud.Security.SSO;
using Newtonsoft.Json;

namespace AdminRoles
{
    public partial class EfectoresXPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SSOHelper.Authenticate();
        }

        public string devuelveEfectores()
        {
            string json = string.Empty;

            return json;
        }

        public string devuelveNombreUsuario()
        {
            string nombreUsuario = Request["nombreUsuario"].ToString();

            return nombreUsuario;
        }
    }
}