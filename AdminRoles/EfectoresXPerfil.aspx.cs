using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salud.Security.SSO;
using Newtonsoft.Json;
using Dominio;
using Negocio;

namespace AdminRoles
{
    public partial class EfectoresXPerfil : System.Web.UI.Page
    {
        PermisosNego permisoNego = new PermisosNego();

        private int idUsuario;

        public int IdUsuario
        {
            get
            {
                idUsuario = int.Parse(Request["idUsuario"]);

                return idUsuario;
            }
            set { idUsuario = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SSOHelper.Authenticate();
        }

        public string devuelveEfectores()
        {
            string json = string.Empty;

            List<SSO_AllowedAppsByEfectorCentralResultSet0> listaPerfilesXEfector = permisoNego.listaPerfilesXEfector(IdUsuario).ToList();

            return json = JsonConvert.SerializeObject(listaPerfilesXEfector, Formatting.Indented);
        }

        public string devuelveNombreUsuario()
        {
            string nombreUsuario = Request["nombreUsuario"].ToString();

            return nombreUsuario;
        }
    }
}