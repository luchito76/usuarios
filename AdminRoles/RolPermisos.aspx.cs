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
    public partial class RolPermisos : System.Web.UI.Page
    {
        RolesNego roleNego = new RolesNego();
        AplicacionesNego aplicacionesNego = new AplicacionesNego();
        ModulosNego moduloNego = new ModulosNego();
        PermisosNego permisoNego = new PermisosNego();
        UsuariosNego usuarioNego = new UsuariosNego();
        ConfigNego configNego = new ConfigNego();

        #region propiedades

        private int idEfector;

        public int IdEfector
        {
            get
            {
                SSOHelper.Authenticate();

                if ((IdHospital == "0") && (Request["llamada"] == "usuario"))
                    idEfector = int.Parse(Request["idEfector"].ToString());
                else
                    idEfector = SSOHelper.CurrentIdentity.IdEfectorRol;

                return idEfector;
            }
            set
            { dynamic IdEfector = SSOHelper.CurrentIdentity.IdEfectorRol; }
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

        private int idPerfil;

        public int IdPerfil
        {
            get
            {
                if (IdHospital == "0")
                {
                    if (Request["idPerfil"] != null)
                        idPerfil = int.Parse(Request["idPerfil"].ToString());
                }
                else
                {
                    if (Request["rolId"] != null)
                        idPerfil = int.Parse(Request["rolId"].ToString());
                }

                return idPerfil;
            }
            set { idPerfil = value; }
        }

        private string nombreDePerfil;

        public string NombreDePerfil
        {
            get
            {
                if (Request["perfil"] != null)
                    nombreDePerfil = Request["perfil"].ToString();

                return nombreDePerfil;
            }
            set { nombreDePerfil = value; }
        }

        private string llamada;

        public string Llamada
        {
            get
            {
                if (Request["llamada"] != null)
                    llamada = Request["llamada"].ToString();

                return llamada;
            }
            set { llamada = value; }
        }

        private string idHospital;
        public string IdHospital
        {
            get
            {
                idHospital = configNego.idHospiatlConfig().ValueStr;

                return idHospital;
            }
            set { idHospital = value; }
        }

        #endregion

        public string nomApp = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idUsuario = SSOHelper.CurrentIdentity.Id;

            if (IsPostBack) return;

            llenarListas();

            mostrarTablas();

            hdnIdEfector.Value = IdEfector.ToString();

            Session["llamada"] = Llamada;
            Session["idUsuario"] = IdUsuario;

            if (Request["idEfector"] != null)
                Session["idEfectorSeleccionado"] = int.Parse(Request["idEfector"]);
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
            HashSet<int> listaResultado;

            if (IdUsuario == 0)
            {
                List<SSO_GetAppByRolResultSet0> listaAppXRol = roleNego.listaRolesXAplicacion(IdPerfil, IdEfector).ToList();
                listaResultado = new HashSet<int>(listaAppXRol.Select(s => s.id));
            }
            else
            {
                List<SSO_GetAplicacionesXEfectorResultSet0> listaAppXUsuario = usuarioNego.listaAppXUsuario(IdUsuario, IdEfector).ToList();
                listaResultado = new HashSet<int>(listaAppXUsuario.Select(s => s.id));
            }

            List<SSO_Application> listaAplicaciones = aplicacionesNego.listaAplicaciones().ToList();

            var results = listaAplicaciones.Where(m => !listaResultado.Contains(m.Id)).ToList();

            return results;
        }

        public string devuelveNombreDeRol()
        {
            string rol = string.Empty;

            if (Request["rolName"] != null)
                rol = Request["rolName"].ToString();
            else
                rol = NombreDePerfil;

            return rol;
        }

        public string devuelveAppXRolJson()
        {
            string json = string.Empty;

            List<SSO_GetAppByRolResultSet0> listaAppXRol = roleNego.listaRolesXAplicacion(IdPerfil, IdEfector).ToList();

            return json = JsonConvert.SerializeObject(listaAppXRol);
        }

        public string devuelveAppXUsuario()
        {
            string json = string.Empty;

            int idEfector = 0;

            //if (IdHospital == "0")
            //{
            if (Request["idEfector"] != null)
                idEfector = int.Parse(Request["idEfector"].ToString());
            else
                idEfector = IdEfector;

            //}
            //else
            //{
            //    idEfector = IdEfector;
            //}

            List<SSO_GetAplicacionesXEfectorResultSet0> listaAppXUsuario = usuarioNego.listaAppXUsuario(IdUsuario, idEfector).ToList();

            return json = JsonConvert.SerializeObject(listaAppXUsuario, Formatting.Indented);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idAplicacion = int.Parse(ddlAplicaciones.SelectedValue);
                nomApp = ddlAplicaciones.SelectedItem.ToString();

                guardaRoleGroups(idAplicacion);

                guardaRolGroupMember();

                if ((Request["llamada"] == "aplicacion") || (IdHospital == "0"))
                {
                    guardaSSOPermissions(idAplicacion);
                }

                guardaSSOPermisosCache(idAplicacion);

                ddlAplicaciones.ClearSelection();

                //Se llama éste método para recargar la lista y no llenar el combo con aplicaciones que ya estan en la grilla.
                llenarListas();

                IdUsuario = int.Parse(Session["idUsuario"].ToString());

                ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "MostrarModulos", @"<script type='text/javascript'>MostrarModulos('" + idAplicacion + "','" + IdPerfil + "');</script>", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void guardaRoleGroups(int idAplicacion)
        {
            if (roleNego.esAplicacionEnRoleGroup(IdEfector, IdPerfil))
            {
                SSO_RoleGroup rolGroup = new SSO_RoleGroup();

                rolGroup.Name = nombreRolGroup();
                rolGroup.IdEfector = IdEfector;
                rolGroup.IdPerfil = IdPerfil;
                rolGroup.AutomaticName = true;

                roleNego.guardaRoleGroup(rolGroup);
            }
        }

        private string nombreRolGroup()
        {
            string nombre = string.Empty;

            int idEfector = 0;

            if ((Request["llamada"] == "aplicacion") || (IdHospital == "0"))
                idEfector = int.Parse(Request["idEfector"].ToString());
            else
                idEfector = SSOHelper.CurrentIdentity.IdEfectorRol;

            string nombreEfector = roleNego.listaRoles(494, true).Where(c => c.Id == idEfector).FirstOrDefault().Name;
            string nombrePerfil = devuelveNombreDeRol();

            return nombre = nombreEfector + " + " + nombrePerfil;
        }

        //Devuelve el último idRolGroup insertado en la tabla SSO_RoleGroups.
        private int ultimoIdRolGroup()
        {
            int idRolGroup = roleNego.obtieneUltimoIdRolGroup().Id;

            return idRolGroup;
        }

        private void guardaRolGroupMember()
        {
            SSO_RoleGroups_Member rolGroupMember = new SSO_RoleGroups_Member();

            int idEfectorSeleccionado = IdEfector;
            int idRolGroup = roleNego.devuelveIdRolGroup(idEfectorSeleccionado, IdPerfil);

            if (validaRolGroupMember(idRolGroup))
            {
                List<int> lista = new List<int>();
                lista.Add(idEfectorSeleccionado);
                lista.Add(IdPerfil);

                foreach (int data in lista)
                {
                    SSO_RoleGroups_Member ssorolGroupMember = new SSO_RoleGroups_Member();

                    ssorolGroupMember.GroupId = idRolGroup;
                    ssorolGroupMember.RoleId = data;

                    roleNego.guardaRolGroupMember(ssorolGroupMember);
                }
            }
        }

        private bool validaRolGroupMember(int idRolGroup)
        {
            bool valida = false;

            var rolGroupMember = roleNego.validaRolGroupMember(idRolGroup);

            if (rolGroupMember == null)
                valida = true;
            else
                valida = false;

            return valida;
        }

        private void guardaSSOPermissions(int idAplicacion)
        {
            List<SSO_Module> listaModulosXAplicacion = moduloNego.listaModulosXIdAplicacion(idAplicacion).ToList();

            int? source = 0;

            if (roleNego.esAplicacionEnRoleGroup(IdEfector, IdPerfil))
                source = ultimoIdRolGroup();
            else
                source = roleNego.devuelveIdRolGroup(IdEfector, IdPerfil);

            foreach (SSO_Module data in listaModulosXAplicacion)
            {
                SSO_Permission ssoPermission = new SSO_Permission();

                ssoPermission.SourceType = 3;
                ssoPermission.Source = source.Value;
                ssoPermission.TargetType = 2;
                ssoPermission.Target = data.Id;
                ssoPermission.Allow = true;
                ssoPermission.Readonly = false;

                permisoNego.guardarPermisos(ssoPermission);
            }
        }

        private void guardaSSOPermisosCache(int idAplicacion)
        {
            IList<SSO_Users_Role> listaUsuarios = null;

            if (Request["llamada"] == "aplicacion")
                listaUsuarios = usuarioNego.listaUsuariosXIdPerfil(IdPerfil).ToList();
            else
                listaUsuarios = usuarioNego.listaPerfilXIdUsuario(IdUsuario).ToList();

            List<SSO_Module> listaModulosXAplicacion = moduloNego.listaModulosXIdAplicacion(idAplicacion).ToList();

            int idRolGroup = 0;

            if (IdHospital == "0")
                idRolGroup = roleNego.devuelveIdRolGroup(IdEfector, IdPerfil);
            else
                idRolGroup = ultimoIdRolGroup();

            foreach (SSO_Users_Role data in listaUsuarios)
            {
                if (permisoNego.esUsuarioEnPermisoCache(IdUsuario, idAplicacion, idRolGroup))
                {
                    foreach (SSO_Module data1 in listaModulosXAplicacion)
                    {
                        SSO_Permissions_Cache ssoPermisoCache = new SSO_Permissions_Cache();

                        ssoPermisoCache.UserId = data.UserId;
                        ssoPermisoCache.ApplicationId = idAplicacion;
                        ssoPermisoCache.TargetType = 2;
                        ssoPermisoCache.Target = data1.Id;
                        ssoPermisoCache.GroupId = idRolGroup;
                        ssoPermisoCache.Allow = true;
                        ssoPermisoCache.Readonly = false;

                        permisoNego.guardaPermisosCache(ssoPermisoCache);
                    }
                }
            }
        }

        [WebMethod()]
        public static void eliminarAplicacion(int idPerfil, int idAplicacion)
        {
            string llamadaDesde = HttpContext.Current.Session["llamada"].ToString();

            if (llamadaDesde == "aplicacion")
                eliminarAplicacionXRol(idPerfil, idAplicacion);
            else
                eliminarAplicacionXUsuario(idPerfil, idAplicacion);
        }

        public static void eliminarAplicacionXRol(int idPerfil, int idAplicacion)
        {
            RolesNego rolNego = new RolesNego();
            RolPermisos rolPermiso = new RolPermisos();

            int idRolGroup = rolNego.devuelveIdRolGroup(rolPermiso.IdEfector, idPerfil);

            borrarPermisos(idRolGroup, idAplicacion);

            borrarPermisosCache(idRolGroup);
        }

        public static void eliminarAplicacionXUsuario(int idPerfil, int idAplicacion)
        {
            RolesNego rolNego = new RolesNego();
            RolPermisos rolPermiso = new RolPermisos();

            int idRolGroup = 0;
            int idEfectorSeleccionado = 0;

            if (rolPermiso.IdHospital == "0")
            {
                if (HttpContext.Current.Session["idEfectorSeleccionado"] != null)
                {
                    idEfectorSeleccionado = int.Parse(HttpContext.Current.Session["idEfectorSeleccionado"].ToString());
                }

                idRolGroup = rolNego.devuelveIdRolGroup(idEfectorSeleccionado, idPerfil);
            }
            else
                idRolGroup = rolNego.devuelveIdRolGroup(rolPermiso.IdEfector, idPerfil);

            int idUsuario = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());

            borrarPermisosCache(idRolGroup, idUsuario, idAplicacion);
        }

        private static void borrarPermisosCache(int idRolGroup)
        {
            PermisosNego permisoNego = new PermisosNego();

            permisoNego.borrarPermisosCacheXIdRolGroup(idRolGroup);
        }

        private static void borrarPermisosCache(int idRolGroup, int idUsuario, int idAplicacion)
        {
            PermisosNego permisoNego = new PermisosNego();

            permisoNego.borrarPermisosCacheXIdUsuario(idRolGroup, idUsuario, idAplicacion);
        }

        private static void borrarPermisos(int idRolGroup, int idAplicacion)
        {
            PermisosNego permisoNego = new PermisosNego();

            permisoNego.borrarPermisos(idRolGroup, idAplicacion);
        }

        //private static void borrarRoleGroups(int idRoleGroup)
        //{
        //    RolesNego roleNego = new RolesNego();

        //    roleNego.borrarRoleGroups(idRoleGroup);
        //}
    }
}