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
using Salud.Security.SSO;

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

        #region propiedades

        public int IdEfector
        {
            get { return SSOHelper.CurrentIdentity.IdEfectorRol; }
            set
            { dynamic IdEfector = SSOHelper.CurrentIdentity.IdEfectorRol; }
        }

        private int idPerfil;

        public int IdPerfil
        {
            get
            {
                if (Request["idRol"] != null)
                    idPerfil = int.Parse(Request["idRol"].ToString());

                return idPerfil;
            }
            set { idPerfil = value; }
        }

        private int idAplicacion;

        public int IdAplicacion
        {
            get
            {
                if (Request["idAplicacion"] != null)
                    idAplicacion = int.Parse(Request["idAplicacion"].ToString());

                return idAplicacion;
            }
            set { idAplicacion = value; }
        }

        private int idUsuario;
        public int IdUsuario
        {
            get
            {
                if (Request["idUsuario"] != null)
                    idUsuario = int.Parse(Request["idUsuario"].ToString());

                return idUsuario;
            }
            set { idUsuario = value; }
        }

        #endregion

        public string moduloNuevo;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Request["moduloNuevo"] != null)
                moduloNuevo = Request["moduloNuevo"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SSOHelper.Authenticate();

            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "MostrarModulos", @"<script type='text/javascript'></script>", false);

            if (IsPostBack) return;

            Session["idPerfil"] = IdPerfil;
            Session["idUsuario"] = IdUsuario;
            Session["idAplicacion"] = IdAplicacion;
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
            RolPermisos rolPermiso = new RolPermisos();

            int idAplicacion = int.Parse(HttpContext.Current.Session["idAplicacion"].ToString());
            int idPerfil = int.Parse(HttpContext.Current.Session["idPerfil"].ToString());

            int idRolGroup = rolNego.devuelveIdRolGroupXPermisos(rolPermiso.IdEfector, idPerfil, idAplicacion);

            SSO_Permission ssoPermisos = new SSO_Permission();
            ssoPermisos = permisoNego.listaPermisosXId(idRolGroup, idModulo);

            ssoPermisos.Allow = estadoModulo;
            ssoPermisos.Readonly = false;

            permisoNego.permisoModulo(ssoPermisos);
        }

        public static void guardaSSO_PermissionCache(int idModulo, bool estadoModulo)
        {
            int idPerfil = int.Parse(HttpContext.Current.Session["idPerfil"].ToString());
            int idUsuario = int.Parse(HttpContext.Current.Session["idUsuario"].ToString()); ;
            int idAplicacion = int.Parse(HttpContext.Current.Session["idAplicacion"].ToString());

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
            ssoPermisosCache = permisoNego.listaPermisosCacheXIdUsuario(idUsuario, idAplicacion, idModulo);

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

            List<SSO_GetModulosXAplicacionResultSet0> listaModulosXAplicacion = moduloNego.listaModulosXPermisos(IdEfector, IdPerfil, IdAplicacion).ToList();

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

            List<SSO_GetModulosXUsuarioResultSet0> listaModulosXAplicacion = moduloNego.listaModulosXUsuario(IdEfector, IdUsuario, IdAplicacion).ToList();

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

            if (IdUsuario != 0)
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