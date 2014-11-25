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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            llenarListas();
            devuelveEfector();
        }


        private void llenarListas()
        {
            ddlAsignarPerfil.DataSource = rolesNego.listaRoles(Roles.parent, Roles.enable).ToList();
            ddlAsignarPerfil.DataBind();
            ddlAsignarPerfil.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        //Devuelve el efector donde está instalada el AdminSSO. Sacar el efector de la tabla config.
        //*******************Refactorizar*******************
        public string devuelveEfector()
        {
            //Session["efector"] = SSOHelper.CurrentIdentity.Name; //"Chos Malal";
            //Session["idEfector"] = IdEfector;//  //IdEfector de Chos Malal

            //string efector = Session["efector"].ToString();

            return SSOHelper.GetNombreEfectorRol(SSOHelper.CurrentIdentity.IdEfectorRol);
        }

        public string devuelveRolesJson()
        {
            string json = string.Empty;

            List<SSO_Role> listaRoles = rolesNego.listaRoles(Roles.parent, Roles.enable).ToList();

            return json = JsonConvert.SerializeObject(listaRoles);
        }

        //public string devuelveAplicacionesJson()
        //{
        //    string json = string.Empty;

        //    List<SSO_Role> listaAplicaciones = rolesNego.listaRoles(Applicacion.parent, Applicacion.enable).ToList();

        //    return json = JsonConvert.SerializeObject(listaAplicaciones);
        //}

        //public string devuelveEfectoresJson()
        //{
        //    string json = string.Empty;

        //    List<SSO_Role> listaEfectores = rolesNego.listaRoles(Efectores.parent, Efectores.enable).ToList();

        //    return json = JsonConvert.SerializeObject(listaEfectores);
        //}

        public string devuelveUsuariosJson()
        {
            string json = string.Empty;

            List<SSO_GetUsuariosXPerfilResultSet01> listaUsuario = usuarioNego.listaUsuariosXPerfil().ToList();

            return json = JsonConvert.SerializeObject(listaUsuario, Formatting.Indented);
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
                permisosCache.GroupId = data.source;
                permisosCache.RoleDepthFromUser = 0;
                permisosCache.Allow = data.allow;
                permisosCache.Readonly = false;

                permisoNego.guardaPermisosCache(permisosCache);
            }
        }

        [WebMethod(), ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void eliminarPerfil(int idUsuario)
        {
            Thread.Sleep(3000);

            AdminRoles ad = new AdminRoles();

            ad.borrarPerfil(idUsuario);
        }

        private void borrarPerfil(int idUsuario)
        {
            borrarUserRol(idUsuario);

            borrarPermisosCache(idUsuario);
        }
    }
}