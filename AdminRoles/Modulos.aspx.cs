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

            private bool estado;

            public bool Estado
            {
                get { return estado; }
                set { estado = value; }
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
            Session["llamada"] = Request.QueryString["llamada"];
        }

        public string devuelveNombreAplicacion()
        {
            string nombreAplicacion = Request["nombreAplicacion"].ToString();

            return nombreAplicacion;
        }

        #region GuardaModulos
        [ScriptMethod(), WebMethod(EnableSession = true)]
        public static void guardarModulos(int idModulo, bool estadoModulo)
        {
            string llamada = HttpContext.Current.Session["llamada"].ToString();

            if (llamada == "aplicacion")
            {
                guardaSSO_Permission(idModulo, estadoModulo);
            }

            guardaSSO_PermissionCache(idModulo, estadoModulo);
        }

        private static void guardaSSO_Permission(int idModulo, bool estadoModulo)
        {
            RolesNego rolNego = new RolesNego();
            PermisosNego permisoNego = new PermisosNego();

            System.Web.UI.Page session = new Page();

            int idEfector = int.Parse(session.Session["idEfector"].ToString());
            int idAplicacion = int.Parse(session.Session["idAplicacion"].ToString());
            int idRol = int.Parse(session.Session["idRol"].ToString());

            int idRolGroup = rolNego.devuelveIdRolGroupXPermisos(idEfector, idRol, idAplicacion);

            SSO_Permission ssoPermisos = new SSO_Permission();
            ssoPermisos = permisoNego.listaPermisosXId(idRolGroup, idModulo).FirstOrDefault();

            ssoPermisos.Allow = estadoModulo;
            ssoPermisos.Readonly = false;

            permisoNego.permisoModulo(ssoPermisos);
        }

        public static void guardaSSO_PermissionCache(int idModulo, bool estadoModulo)
        {
            System.Web.UI.Page session = new Page();

            int idPerfil = 0;
            int idUsuario = 0;

            if (session.Session["idRol"] != null)
                idPerfil = int.Parse(session.Session["idRol"].ToString());

            if (session.Session["idUsuario"] != null)
                idUsuario = int.Parse(session.Session["idUsuario"].ToString());

            int idAplicacion = int.Parse(session.Session["idAplicacion"].ToString());

            UsuariosNego usuarioNego = new UsuariosNego();

            IList<SSO_Users_Role> ssoUserRol = usuarioNego.listaUsuariosXIdPerfil(idPerfil).ToList();

            if (idUsuario == 0)
            {
                foreach (SSO_Users_Role data in ssoUserRol)
                {
                    guardaEnPermisosCache(data.UserId, idAplicacion, idModulo, estadoModulo);
                }
            }
            else
                guardaEnPermisosCache(idUsuario, idAplicacion, idModulo, estadoModulo);
        }

        private static void guardaEnPermisosCache(int idUsuario, int idAplicacion, int idModulo, bool estadoModulo)
        {
            PermisosNego permisoNego = new PermisosNego();

            SSO_Permissions_Cache ssoPermisosCache = new SSO_Permissions_Cache();
            ssoPermisosCache = permisoNego.listaPermisosCacheXIdUsuario(idUsuario, idAplicacion, idModulo).FirstOrDefault();

            ssoPermisosCache.Allow = estadoModulo;
            ssoPermisosCache.Readonly = false;

            permisoNego.permisoModuloUsuario(ssoPermisosCache);
        }

        #endregion

        #region Carga de Módulos

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
                helper.Estado = data.Estado;

                lista.Add(helper);
            }

            return lista;
        }

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
                helper.Estado = data.Estado;

                lista.Add(helper);
            }

            return lista;
        }

        public string devuelveModulos()
        {
            string json = string.Empty;

            int idUsuario = 0;

            if (Request.QueryString["idUsuario"] != null)
                idUsuario = int.Parse(Request.QueryString["idUsuario"].ToString());

            if (idUsuario != 0)
            {
                json = JsonConvert.SerializeObject(devuelveModulosXUsuario());
            }
            else
            {
                json = JsonConvert.SerializeObject(devuelveModulosXAplicacionJson());
            }

            return json;
        }
        #endregion
    }
}