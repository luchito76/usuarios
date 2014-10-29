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
        PermisosNego permisoNego = new PermisosNego();
        RolesNego rolNego = new RolesNego();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Session["idRol"] = Request.QueryString["idRol"];
            Session["idUsuario"] = Request.QueryString["idUsuario"];
        }

        public string devuelveNombreAplicacion()
        {
            string nombreAplicacion = Request["nombreAplicacion"].ToString();

            return nombreAplicacion;
        }

        [ScriptMethod(), WebMethod(EnableSession = true)]
        public static void guardarModulos(int habilitados)
        {
            if (HttpContext.Current.Session["idRol"] != null)
            {
                guardaSSO_Permission(habilitados);
            }
            else if (HttpContext.Current.Session["idUsuario"] != null)
            {
                guardaSSO_PermissionCache(habilitados);
            }
        }

        private static void guardaSSO_Permission(int habilitados)
        {
            RolesNego rolNego = new RolesNego();
            PermisosNego permisoNego = new PermisosNego();

            SSO_Permission ssoPermisos = new SSO_Permission();

            System.Web.UI.Page session = new Page();

            int idEfector = int.Parse(session.Session["idEfector"].ToString());
            int idAplicacion = int.Parse(session.Session["idAplicacion"].ToString());
            int idRol = int.Parse(session.Session["idRol"].ToString());

            int idRolGroup = rolNego.devuelveIdRolGroup(idEfector, idRol, idAplicacion);

            ssoPermisos = permisoNego.listaPermisosXId(idRolGroup, habilitados).FirstOrDefault();

            bool allow = true;

            if (ssoPermisos.Allow == true)
                allow = false;

            ssoPermisos.Allow = allow;
            ssoPermisos.Readonly = false;

            permisoNego.permisoModulo(ssoPermisos);
        }

        public static void guardaSSO_PermissionCache(int habilitados)
        {
            System.Web.UI.Page session = new Page();

            int idAplicacion = int.Parse(session.Session["idAplicacion"].ToString());
            int idUsuario = int.Parse(session.Session["idUsuario"].ToString());

            PermisosNego permisoNego = new PermisosNego();

            SSO_Permissions_Cache ssoPermisosCache = new SSO_Permissions_Cache();
            ssoPermisosCache = permisoNego.listaPermisosCacheXIdUsuario(idUsuario, idAplicacion, habilitados).FirstOrDefault();

            bool allow = true;

            if (ssoPermisosCache.Allow == true)
                allow = false;

            ssoPermisosCache.Allow = allow;
            ssoPermisosCache.Readonly = false;

            permisoNego.permisoModuloUsuario(ssoPermisosCache);
        }

        private IList<moduloHelper> devuelveModulosXAplicacionJson()
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

            return lista; //json = JsonConvert.SerializeObject(lista);
        }

        //*********************************Módulos x Usuario****************************
        private IList<moduloHelper> devuelveModulosXUsuario()
        {
            string json = string.Empty;

            moduloHelper mod = new moduloHelper();

            int idEfector = int.Parse(Session["idEfector"].ToString());
            Session["idAplicacion"] = int.Parse(Request["idAplicacion"].ToString());
            Session["idUsuario"] = int.Parse(Request["idusuario"].ToString());

            int idAplicacion = int.Parse(Session["idAplicacion"].ToString());
            int idUsuario = int.Parse(Session["idUsuario"].ToString());

            List<SSO_GetModulosXUsuarioResultSet0> listaModulosXAplicacion = moduloNego.listaModulosXUsuario(idEfector, idUsuario, idAplicacion).ToList();

            List<moduloHelper> lista = new List<moduloHelper>();

            foreach (SSO_GetModulosXUsuarioResultSet0 data in listaModulosXAplicacion)
            {
                moduloHelper helper = new moduloHelper();

                helper.IdModulo = data.idModulo;
                helper.Nombre = data.Nombre;
                helper.Descripcion = data.Descripcion;
                helper.Habilitado = data.Habilitado;

                lista.Add(helper);
            }

            return lista; //json = JsonConvert.SerializeObject(lista);
        }

        public string devuelveModulos()
        {
            string json = string.Empty;

            if (Request["idUsuario"] != null)
            {
                json = JsonConvert.SerializeObject(devuelveModulosXUsuario());
            }
            else
            {
                json = JsonConvert.SerializeObject(devuelveModulosXAplicacionJson());
            }

            return json;
        }

    }
}