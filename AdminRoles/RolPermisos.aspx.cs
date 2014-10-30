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
    public partial class RolPermisos : System.Web.UI.Page
    {
        RolesNego roleNego = new RolesNego();
        AplicacionesNego aplicacionesNego = new AplicacionesNego();
        ModulosNego moduloNego = new ModulosNego();
        PermisosNego permisoNego = new PermisosNego();
        UsuariosNego usuarioNego = new UsuariosNego();

        public string nomApp = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            llenarListas();

            mostrarTablas();

            hdnIdEfector.Value = Session["idEfector"].ToString();
        }

        private void llenarListas()
        {
            var results = quitarAplicacionesDuplicadas();

            ddlAplicaciones.DataSource = results.ToList();
            ddlAplicaciones.DataBind();
            ddlAplicaciones.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        /// <summary>
        /// Muestra la tablas de aplicacions por Rol o de aplicaciones por Usuario dependiendo si la llamada es de Aplicación o Usuario.        
        /// </summary>
        private void mostrarTablas()
        {
            if (Request["llamada"] == "aplicacion")
                divAppXRoles.Visible = true;
            else
                divAppXUsuarios.Visible = true;
        }

        /// <summary>
        /// Verifica que las aplicaciones que se encuentran en la grilla no se muestren en el combo para que el usuario
        /// no agregue a la grilla aplicaciones duplicadas.
        /// </summary>
        /// <returns></returns>
        private List<SSO_Application> quitarAplicacionesDuplicadas()
        {
            int idRol = devuelveIdRol();
            int idEfector = int.Parse(Session["idEfector"].ToString());
            int idUsuario = 0;

            HashSet<int> listaResultado;

            if (Request["idUsuario"] == null)
            {
                List<SSO_GetAppByRolResultSet0> listaAppXRol = roleNego.listaRolesXAplicacion(idRol, idEfector).ToList();
                listaResultado = new HashSet<int>(listaAppXRol.Select(s => s.idAplicacion));
            }
            else
            {
                idUsuario = int.Parse(Request["idUsuario"].ToString());
                List<sp_SSO_AllowedAppsByEfectorResultSet0> listaAppXUsuario = usuarioNego.listaAppXUsuario(idUsuario, idEfector).ToList();
                listaResultado = new HashSet<int>(listaAppXUsuario.Select(s => s.idAplicacion));
            }

            List<SSO_Application> listaAplicaciones = aplicacionesNego.listaAplicaciones().ToList();

            var results = listaAplicaciones.Where(m => !listaResultado.Contains(m.Id)).ToList();

            return results;
        }

        public int devuelveIdRol()
        {
            int rolId = 0;
         
            if (Request["rolId"] != null && Request["rolId"] != "")
                rolId = int.Parse(Request["rolId"].ToString());

            return rolId;
        }

        public string devuelveNombreDeRol()
        {
            string rol = Request["rolName"].ToString();

            return rol;
        }

        public int devuelveIdUsuario()
        {
            int idUsuario = 0;

            if (Request["idUsuario"] != null)
                idUsuario = int.Parse(Request["idUsuario"].ToString());

            return idUsuario;
        }

        public string devuelveAppXRolJson()
        {
            string json = string.Empty;

            int idRol = devuelveIdRol();
            int idEfector = int.Parse(Session["idEfector"].ToString());

            List<SSO_GetAppByRolResultSet0> listaAppXRol = roleNego.listaRolesXAplicacion(idRol, idEfector).ToList();

            return json = JsonConvert.SerializeObject(listaAppXRol);
        }

        public string devuelveAppXUsuario()
        {
            string json = string.Empty;

            int idUsuario = 0;
            int idEfector = int.Parse(Session["idEfector"].ToString());

            if (Request["idUsuario"] != null)
                idUsuario = int.Parse(Request["idUsuario"].ToString());

            List<sp_SSO_AllowedAppsByEfectorResultSet0> listaAppXUsuario = usuarioNego.listaAppXUsuario(idUsuario, idEfector).ToList();

            return json = JsonConvert.SerializeObject(listaAppXUsuario, Formatting.Indented);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idAplicacion = int.Parse(ddlAplicaciones.SelectedValue);
                nomApp = ddlAplicaciones.SelectedItem.ToString();

                guardaRoleGroups(idAplicacion);

                //* Si rolId tiene un valor la aplicación seleccionada es agregada al Perfil.
                //* Si rolId no tiene valor la aplicación seleccionada es agregada al Usuario.
                //if (Request["idUsuario"] == null)
                if (Request["llamada"] == "aplicacion")
                {
                    guardaSSOPermissions(idAplicacion);
                }

                guardaSSOPermisosCache(idAplicacion);

                ddlAplicaciones.ClearSelection();

                //Se llama éste método para recargar la lista y no llenar el combo con aplicaciones que ya estan en la grilla.
                llenarListas();

                ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "MostrarModulos", @"<script type='text/javascript'>MostrarModulos('" + idAplicacion + "','" + devuelveIdRol() + "');</script>", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void guardaRoleGroups(int idAplicacion)
        {
            int idEfector = int.Parse(Session["idEfector"].ToString());
            int idRol = int.Parse(Request["rolId"].ToString());

            SSO_RoleGroup rolGroup = new SSO_RoleGroup();

            rolGroup.IdAplicacion = idAplicacion;
            rolGroup.IdEfector = idEfector;
            rolGroup.IdPerfil = idRol;
            rolGroup.AutomaticName = true;

            roleNego.guardaRoleGroup(rolGroup);
        }

        //Devuelve el último idRolGroup insertado en la tabla SSO_RoleGroups.
        private int ultimoIdRolGroup()
        {
            int idRolGroup = roleNego.obtieneUltimoIdRolGroup().Id;

            return idRolGroup;
        }

        private void guardaSSOPermissions(int idAplicacion)
        {
            List<SSO_Module> listaModulosXAplicacion = moduloNego.listaModulosXIdAplicacion(idAplicacion).ToList();

            int ultimoIdRolGroupInsertado = ultimoIdRolGroup();

            foreach (SSO_Module data in listaModulosXAplicacion)
            {
                SSO_Permission ssoPermission = new SSO_Permission();

                ssoPermission.SourceType = 3;
                ssoPermission.Source = ultimoIdRolGroupInsertado;
                ssoPermission.TargetType = 2;
                ssoPermission.Target = data.Id;
                ssoPermission.Allow = true;
                ssoPermission.Readonly = false;

                permisoNego.guardarPermisos(ssoPermission);
            }
        }

        private void guardaSSOPermisosCache(int idAplicacion)
        {
            IList<SSO_Users_Role> listaUsuarios = usuarioNego.listaUsuariosXIdPerfil(devuelveIdRol()).ToList();

            List<SSO_Module> listaModulosXAplicacion = moduloNego.listaModulosXIdAplicacion(idAplicacion).ToList();

            int ultimoIdRolGroupInsertado = ultimoIdRolGroup();

            foreach (SSO_Users_Role data in listaUsuarios)
            {
                foreach (SSO_Module data1 in listaModulosXAplicacion)
                {
                    SSO_Permissions_Cache ssoPermisoCache = new SSO_Permissions_Cache();

                    ssoPermisoCache.UserId = data.UserId;
                    ssoPermisoCache.ApplicationId = idAplicacion;
                    ssoPermisoCache.TargetType = 2;
                    ssoPermisoCache.Target = data1.Id;
                    ssoPermisoCache.GroupId = ultimoIdRolGroupInsertado;
                    ssoPermisoCache.Allow = true;
                    ssoPermisoCache.Readonly = false;

                    permisoNego.guardaPermisosCache(ssoPermisoCache);
                }
            }
        }

        [ScriptMethod(), WebMethod()]
        public static void eliminarAplicacionXRol(int idEfector, int idPerfil, int idAplicacion)
        {
            RolesNego rol = new RolesNego();

            IList<SSO_RoleGroup> lista = rol.eliminarAplicacionXRol(idEfector, idPerfil, idAplicacion).ToList();

            int idRoleGroup = 0;

            foreach (SSO_RoleGroup data in lista)
            {
                idRoleGroup = data.Id;
            }

            borrarPermisosCache(idRoleGroup);
            borrarRoleGroups(idRoleGroup);
            borrarPermisos(idRoleGroup);
        }

        private static void borrarPermisosCache(int idRolGroup)
        {
            PermisosNego permisoNego = new PermisosNego();

            permisoNego.borrarPermisosCacheXIdRolGroup(idRolGroup);
        }

        private static void borrarPermisos(int idPermiso)
        {
            PermisosNego permisoNego = new PermisosNego();

            permisoNego.borrarPermisos(idPermiso);
        }

        private static void borrarRoleGroups(int idRoleGroup)
        {
            RolesNego roleNego = new RolesNego();

            roleNego.borrarRoleGroups(idRoleGroup);
        }
    }
}