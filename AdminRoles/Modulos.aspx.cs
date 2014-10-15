using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;

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

            private string nombre;

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            private string descripcion;

            public string Descripcion
            {
                get { return descripcion; }
                set { descripcion = value; }
            }

            private bool habilitado;

            public bool Habilitado
            {
                get { return habilitado; }
                set { habilitado = value; }
            }
        }


        #endregion

        ModulosNego moduloNego = new ModulosNego();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public string devuelveNombreAplicacion()
        //{
        //    string nombreAplicacion = Request["nombreAplicacion"].ToString();

        //    return nombreAplicacion;
        //}

        public string devuelveModulosXAplicacionJson()
        {
            string json = string.Empty;
            moduloHelper mod = new moduloHelper();

            int idEfector = int.Parse(Session["idEfector"].ToString());
            Session["idAplicacion"] = int.Parse(Request["idAplicacion"].ToString());
            Session["idRol"] = int.Parse(Request["idRol"].ToString());

            int idAplicacion = int.Parse(Session["idAplicacion"].ToString());
            int idRol = int.Parse(Session["idRol"].ToString());

            List<SSO_GetModulosXAplicacionResultSet0> listaModulosXAplicacion = moduloNego.listaModulosXPermisos(idEfector, idRol, idAplicacion).ToList();

            List<moduloHelper> lista = new List<moduloHelper>();

            foreach (SSO_GetModulosXAplicacionResultSet0 data in listaModulosXAplicacion)
            {
                moduloHelper helper = new moduloHelper();

                helper.IdModulo = data.idModulo;
                helper.Nombre = data.Nombre;
                helper.Descripcion = data.Descripcion;
                helper.Habilitado = data.Habilitado;

                lista.Add(helper);
            }

            return json = JsonConvert.SerializeObject(lista);
        }

        [ScriptMethod(), WebMethod()]
        public static void guardarModulos(int habilitados)
        {
            System.Web.UI.Page session = new Page();

            int idEfector = int.Parse(session.Session["idEfector"].ToString());
            int idAplicacion = int.Parse(session.Session["idAplicacion"].ToString());
            int idRol = int.Parse(session.Session["idRol"].ToString());

            RolesNego rolNego = new RolesNego();
            PermisosNego permisoNego = new PermisosNego();

            IList<SSO_RoleGroup> lista = rolNego.eliminarAplicacionXRol(idEfector, idRol, idAplicacion).ToList();

            int idRolGroup = 0;

            foreach (SSO_RoleGroup data in lista)
            {
                idRolGroup = data.Id;
            }

            SSO_Permission permisos = new SSO_Permission();
            permisos = permisoNego.listaPermisosXId(idRolGroup, habilitados).FirstOrDefault();

            bool allow = true;

            if (permisos.Allow == true)
                allow = false;


            //permisos.SourceType = 3;
            //permisos.Source = idRolGroup;
            //permisos.TargetType = 2;
            //permisos.Target = habilitados;
            permisos.Allow = allow;
            permisos.Readonly = false;

            permisoNego.permisoModulo(permisos);
        }
    }
}