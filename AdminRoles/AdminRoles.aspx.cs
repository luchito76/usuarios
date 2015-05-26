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
using System.Security.Principal;
using System.Threading;

namespace AdminRoles
{
    public partial class AdminRoles : System.Web.UI.Page
    {
        RolesNego rolesNego = new RolesNego();
        UsuariosNego usuarioNego = new UsuariosNego();
        PermisosNego permisoNego = new PermisosNego();
        ConfigNego configNego = new ConfigNego();
        AplicacionesNego aplicacionesNego = new AplicacionesNego();

        #region Roles
        public static class Roles
        {
            public const int parent = 12;
            public const bool enable = true;
        }

        public static class Applicacion
        {
            public const int parent = 12;
            public const bool enable = false;
        }

        public static class Efectores
        {
            public const int parent = 494;
            public const bool enable = true;
        }

        #endregion

        #region propiedades

        public int IdEfector
        {
            get { return SSOHelper.CurrentIdentity.IdEfectorRol; }
            set
            { dynamic IdEfector = SSOHelper.CurrentIdentity.IdEfectorRol; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            llenarListas();
            validaIdHospital();
        }

        private void llenarListas()
        {
            ddlAsignarPerfil.DataSource = rolesNego.listaRoles(Roles.parent, Roles.enable).ToList();
            ddlAsignarPerfil.DataBind();
            ddlAsignarPerfil.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlEfector.DataSource = rolesNego.listaRoles(Efectores.parent, Efectores.enable).ToList();
            ddlEfector.DataBind();
            ddlEfector.Items.Insert(0, new ListItem("--Seleccione--", "0"));

            ddlPerfil.DataSource = rolesNego.listaRoles(Roles.parent, Roles.enable).ToList();
            ddlPerfil.DataBind();
            ddlPerfil.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        //Si el usuario ingresa a un hospital, en la tabla de usuarios se muestra la columna perfil, 
        //si ingresa a nivel central se muestra la columna Efectores.
        private void validaIdHospital()
        {
            if (IdHospital == "0")
            {
                columnaPerfil.Visible = false;
                columnaAsignarPerfilXEfector.Visible = true;
                columnaApp.Visible = false;
            }
            else
            {
                columnaAsignarPerfilXEfector.Visible = false;
                columnaEfectores.Visible = false;
                columnaPerfil.Visible = true;
            }
        }

        public string devuelveRolesJson()
        {
            string json = string.Empty;

            List<SSO_Role> listaRoles = rolesNego.listaRoles(Roles.parent, Roles.enable).ToList();

            return json = JsonConvert.SerializeObject(listaRoles);
        }

        public string devuelveUsuariosJson()
        {
            string json = string.Empty;
            string filtro = string.Empty;

            if (Session["filtro"] != null)
                filtro = Session["filtro"].ToString();

            List<SSO_GetUsuariosXPerfilResultSet02> listaUsuario = usuarioNego.listaUsuariosXPerfil(filtro).ToList();

            return json = JsonConvert.SerializeObject(listaUsuario, Formatting.Indented);

        }

        [WebMethod()]
        public static void filtroUsuarios(string filtro)
        {
            AdminRoles adminRoles = new AdminRoles();

            HttpContext.Current.Session["filtro"] = filtro;

            adminRoles.devuelveUsuariosJson();
        }

        public string filtros()
        {
            string filtro = string.Empty;

            if (Session["filtro"] != null)
                filtro = Session["filtro"].ToString();

            return filtro;

        }

        protected void crearRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnIdRol.Value == "")
                {
                    crearRol();
                }
                else
                {
                    actualizarRol();
                }

                Response.Redirect("AdminRoles.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void crearRol()
        {
            SSO_Role rol = new SSO_Role();

            rol.Parent = Roles.parent;
            rol.Name = txtRol.Text.ToUpper();
            rol.Enabled = Roles.enable;

            rolesNego.guardarRol(rol);
        }

        private void actualizarRol()
        {
            SSO_Role rol = new SSO_Role();

            rol.Id = int.Parse(hdnIdRol.Value);
            rol.Parent = Roles.parent;
            rol.Name = txtRol.Text.ToUpper();
            rol.Enabled = Roles.enable;

            rolesNego.actualizarRol(rol);
        }

        //****************Métodos de Pestaña Usuario*************************

        protected void btnAsignarPerfil_ServerClick(object sender, EventArgs e)
        {
            asignarPerfilAUsuario();
        }

        private void asignarPerfilAUsuario()
        {
            int idUsuario = int.Parse(hdfIdUsuario.Value);

            borrarUserRol(idUsuario);

            guardaSSOUserRol(idUsuario);

            borrarPermisosCache(idUsuario);

            guardarPermisosCache(idUsuario);

            habilitaUsuario(idUsuario);
        }

        private void borrarUserRol(int idUsuario)
        {
            rolesNego.borrarUserRol(idUsuario);
        }

        private void guardaSSOUserRol(int idusuario)
        {
            List<int> lista = new List<int>();
            lista.Add(int.Parse(ddlAsignarPerfil.SelectedValue));
            lista.Add(IdEfector);

            foreach (int data in lista)
            {
                SSO_Users_Role userRol = new SSO_Users_Role();

                userRol.UserId = idusuario;
                userRol.RoleId = data;

                usuarioNego.guardaSSOUserRol(userRol);
            }
        }

        private void borrarPermisosCache(int idUsuario)
        {
            permisoNego.borrarPermisosCacheXIdUsuario(idUsuario);
        }

        private void guardarPermisosCache(int idUsuario)
        {
            int idPerfil = int.Parse(ddlAsignarPerfil.SelectedValue);

            IList<SSO_GetPermisosXUsuarioResultSet0> listaPermisosXUsuario = permisoNego.listaPermisosXUsuario(idPerfil, IdEfector).ToList();

            foreach (SSO_GetPermisosXUsuarioResultSet0 data in listaPermisosXUsuario)
            {
                SSO_Permissions_Cache permisosCache = new SSO_Permissions_Cache();

                permisosCache.UserId = idUsuario;
                permisosCache.ApplicationId = int.Parse(data.idAplicacion.ToString());
                permisosCache.TargetType = 2;
                permisosCache.Target = data.target;
                permisosCache.Inherited = true;
                permisosCache.RoleId = 0;
                permisosCache.GroupId = data.id;
                permisosCache.RoleDepthFromUser = 0;
                permisosCache.Allow = data.allow;
                permisosCache.Readonly = false;

                permisoNego.guardaPermisosCache(permisosCache);
            }
        }

        private void habilitaUsuario(int idUsuario)
        {
            SSO_User ssoUser = new SSO_User();
            ssoUser = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario);

            ssoUser.Id = idUsuario;
            ssoUser.Enabled = true;

            usuarioNego.actualizarUsuario(ssoUser);
        }

        [WebMethod(), ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void eliminarPerfil(int idUsuario, int idPerfil)
        {
            Thread.Sleep(3000);

            AdminRoles ad = new AdminRoles();

            if (ad.IdHospital == "0")
                ad.borrarPerfilNivelCentral(idUsuario, idPerfil);
            else
                ad.borrarPerfil(idUsuario);
        }

        private void borrarPerfilNivelCentral(int idUsuario, int idPerfil)
        {
            borrarUserRolNivelCentral(idUsuario, idPerfil);

            borrarPermisoCacheNivelCentral(idUsuario, idPerfil);
        }

        //Borra el perfil y los efectores asociados a dicho perfil en el Nivel Central.
        private void borrarUserRolNivelCentral(int idUsuario, int idPerfil)
        {
            List<SSO_AllowedAppsByEfectorCentralResultSet0> listaEfectoresXPErfil = permisoNego.listaEfectoresXPerfil(idUsuario, idPerfil).ToList();

            foreach (SSO_AllowedAppsByEfectorCentralResultSet0 data in listaEfectoresXPErfil)
            {
                rolesNego.borrarUserRol(idUsuario, int.Parse(data.id.ToString()));
            }

            rolesNego.borrarUserRol(idUsuario, idPerfil);
        }

        private void borrarPermisoCacheNivelCentral(int idUsuario, int idPerfil)
        {
            List<SSO_AllowedAppsByEfectorCentralResultSet0> listaEfectoresXPErfil = permisoNego.listaEfectoresXPerfil(idUsuario, idPerfil).ToList();

            List<SSO_RoleGroup> listaRolGroup = new List<SSO_RoleGroup>();

            foreach (SSO_AllowedAppsByEfectorCentralResultSet0 data in listaEfectoresXPErfil)
            {
                int idRolGroup = rolesNego.devuelveIdRolGroup(int.Parse(data.id.ToString()), idPerfil);

                SSO_RoleGroup rolGroup = new SSO_RoleGroup();

                rolGroup.Id = idRolGroup;

                listaRolGroup.Add(rolGroup);
            }

            foreach (SSO_RoleGroup data in listaRolGroup)
            {
                permisoNego.borrarPermisosCacheXIdUsuario(data.Id, idUsuario);
            }
        }

        private void borrarPerfil(int idUsuario)
        {
            borrarUserRol(idUsuario);

            borrarPermisosCache(idUsuario);
        }

        protected void btnPerfilXEfector_ServerClick(object sender, EventArgs e)
        {
            asignarPerfilXEfector();
        }

        private void asignarPerfilXEfector()
        {
            guardaSSOUserRolCentral();

            guardarPermisosCacheCentral();

            ddlPerfil.ClearSelection();
            ddlEfector.ClearSelection();
        }

        private void guardaSSOUserRolCentral()
        {
            List<int> lista = new List<int>();
            lista.Add(int.Parse(ddlPerfil.SelectedValue));
            lista.Add(int.Parse(ddlEfector.SelectedValue));

            int idUsuario = int.Parse(hdfIdUsuario.Value);
            int idEfector = int.Parse(ddlEfector.SelectedValue);
            int idPerfil = int.Parse(ddlPerfil.SelectedValue);

            int idEfectorSeleccionado = rolesNego.validaEfectorXUserRol(idUsuario, idEfector);
            int idPerfilSeleccionado = rolesNego.validaPerfilXUserRol(idUsuario, idPerfil);

            foreach (int data in lista)
            {
                if ((data != idEfectorSeleccionado) && (data != idPerfilSeleccionado))
                {
                    SSO_Users_Role userRol = new SSO_Users_Role();

                    userRol.UserId = int.Parse(hdfIdUsuario.Value);
                    userRol.RoleId = data;

                    usuarioNego.guardaSSOUserRol(userRol);
                }
            }
        }

        private void guardaRoleGroups()
        {

            int idPerfilSeleccionado = int.Parse(ddlPerfil.SelectedValue);
            int idEfectorSeleccionado = int.Parse(ddlEfector.SelectedValue);

            if (rolesNego.esAplicacionEnRoleGroup(idEfectorSeleccionado, idPerfilSeleccionado))
            {
                SSO_RoleGroup rolGroup = new SSO_RoleGroup();

                rolGroup.Name = nombreRolGroup();
                rolGroup.IdEfector = idEfectorSeleccionado;
                rolGroup.IdPerfil = idPerfilSeleccionado;
                rolGroup.AutomaticName = true;

                rolesNego.guardaRoleGroup(rolGroup);
            }
        }

        private string nombreRolGroup()
        {
            string nombre = string.Empty;

            int idEfectorSeleccionado = int.Parse(ddlEfector.SelectedValue);

            string nombreEfector = rolesNego.listaRoles(494, true).Where(c => c.Id == idEfectorSeleccionado).FirstOrDefault().Name;
            string nombrePerfil = ddlPerfil.SelectedItem.ToString(); //devuelveNombreDeRol();

            return nombre = nombreEfector + " + " + nombrePerfil;
        }

        private void guardarPermisosCacheCentral()
        {
            int idEfector = int.Parse(ddlEfector.SelectedValue);
            int idPerfil = int.Parse(ddlPerfil.SelectedValue);
            string nombrePerfil = ddlPerfil.SelectedItem.ToString();

            int idRolGroup = rolesNego.devuelveIdRolGroup(idEfector, idPerfil);

            if (idRolGroup == 0)
            {
                Response.Redirect("RolPermisos.aspx?idUsuario=" + int.Parse(hdfIdUsuario.Value) + "&idPerfil=" + idPerfil + "&idEfector=" + idEfector + "&perfil=" + nombrePerfil + "&llamada=usuario");
            }


            IList<SSO_GetAplicacionesXPerfilResultSet0> listaPermisosXUsuario = aplicacionesNego.listaAplicacionesXPerfil(idRolGroup).ToList();

            foreach (SSO_GetAplicacionesXPerfilResultSet0 data in listaPermisosXUsuario)
            {
                SSO_Permissions_Cache permisosCache = new SSO_Permissions_Cache();

                permisosCache.UserId = int.Parse(hdfIdUsuario.Value);
                permisosCache.ApplicationId = int.Parse(data.idAplicacion.ToString());
                permisosCache.TargetType = 2;
                permisosCache.Target = data.target;
                permisosCache.Inherited = true;
                permisosCache.RoleId = 0;
                permisosCache.GroupId = idRolGroup;
                permisosCache.RoleDepthFromUser = 0;
                permisosCache.Allow = data.allow;
                permisosCache.Readonly = false;

                permisoNego.guardaPermisosCache(permisosCache);
            }
        }

        private void guardaRolGroupMember()
        {
            SSO_RoleGroups_Member rolGroupMember = new SSO_RoleGroups_Member();

            int idEfectorSeleccionado = int.Parse(ddlEfector.SelectedValue);
            int idPerfilSeleccionado = int.Parse(ddlPerfil.SelectedValue);

            int idRolGroup = rolesNego.devuelveIdRolGroup(idEfectorSeleccionado, idPerfilSeleccionado);

            if (validaRolGroupMember(idRolGroup))
            {
                List<int> lista = new List<int>();
                lista.Add(idEfectorSeleccionado);
                lista.Add(idPerfilSeleccionado);

                foreach (int data in lista)
                {
                    SSO_RoleGroups_Member ssorolGroupMember = new SSO_RoleGroups_Member();

                    ssorolGroupMember.GroupId = idRolGroup;
                    ssorolGroupMember.RoleId = data;

                    rolesNego.guardaRolGroupMember(ssorolGroupMember);
                }
            }
        }

        private bool validaRolGroupMember(int idRolGroup)
        {
            bool valida = false;

            var rolGroupMember = rolesNego.validaRolGroupMember(idRolGroup);

            if (rolGroupMember == null)
                valida = true;
            else
                valida = false;

            return valida;
        }
    }
}