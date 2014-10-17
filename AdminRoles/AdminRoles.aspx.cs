using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Newtonsoft.Json;

namespace AdminRoles
{
    public partial class AdminRoles : System.Web.UI.Page
    {
        RolesNego rolesNego = new RolesNego();
        UsuariosNego usuarioNego = new UsuariosNego();
        PermisosNego permisoNego = new PermisosNego();

        #region helperUsuario

        public class helperUsuario
        {
            private int idUsuario;

            public int IdUsuario
            {
                get { return idUsuario; }
                set { idUsuario = value; }
            }

            private string documento;

            public string Documento
            {
                get { return documento; }
                set { documento = value; }
            }

            private string nombre;

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            private string apellido;

            public string Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }

            private string usuario;

            public string Usuario
            {
                get { return usuario; }
                set { usuario = value; }
            }

            private bool perfil;

            public bool Perfil
            {
                get { return perfil; }
                set { perfil = value; }
            }

        }
        #endregion

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

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarListas();

            if (IsPostBack) return;

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

            Session["efector"] = "Chos Malal";
            Session["idEfector"] = 693; //IdEfector de Chos Malal

            string efector = Session["efector"].ToString();

            return efector;
        }

        public string devuelveRolesJson()
        {
            string json = string.Empty;

            List<SSO_Role> listaRoles = rolesNego.listaRoles(Roles.parent, Roles.enable).ToList();

            return json = JsonConvert.SerializeObject(listaRoles);
        }

        public string devuelveAplicacionesJson()
        {
            string json = string.Empty;

            List<SSO_Role> listaAplicaciones = rolesNego.listaRoles(Applicacion.parent, Applicacion.enable).ToList();

            return json = JsonConvert.SerializeObject(listaAplicaciones);
        }

        public string devuelveEfectoresJson()
        {
            string json = string.Empty;

            List<SSO_Role> listaEfectores = rolesNego.listaRoles(Efectores.parent, Efectores.enable).ToList();

            return json = JsonConvert.SerializeObject(listaEfectores);
        }

        public string devuelveUsuariosJson()
        {
            string json = string.Empty;

            List<SSO_User> listaUsuario = usuarioNego.listaUsuarios().ToList();
            List<SSO_Users_Role> listaUserRol = usuarioNego.listaUserRol().ToList();

            List<helperUsuario> lista = new List<helperUsuario>();

            foreach (SSO_User data in listaUsuario)
            {
                helperUsuario helper = new helperUsuario();

                helper.IdUsuario = data.Id;
                helper.Documento = data.Documento.ToString();
                helper.Nombre = data.Name;
                helper.Apellido = data.Surname;
                helper.Usuario = data.Username;

                if (listaUserRol.Any(c => c.UserId == helper.IdUsuario))
                {
                    helper.Perfil = true;
                }
                else
                {
                    helper.Perfil = false;
                }

                lista.Add(helper);
            }

            return json = JsonConvert.SerializeObject(lista, Formatting.Indented);
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

                txtRol.Text = "";

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
            guardaSSOUserRol();

            borrarPermisosCache();

            guardarPermisosCache();
        }

        private void guardaSSOUserRol()
        {
            SSO_Users_Role userRol = new SSO_Users_Role();

            userRol.UserId = int.Parse(hdfIdUsuario.Value);
            userRol.RoleId = int.Parse(ddlAsignarPerfil.SelectedValue);

            usuarioNego.guardaSSOUserRol(userRol);

            SSO_Users_Role userRol1 = new SSO_Users_Role();

            userRol1.UserId = int.Parse(hdfIdUsuario.Value);
            userRol1.RoleId = int.Parse(Session["idEfector"].ToString());

            usuarioNego.guardaSSOUserRol(userRol1);
        }

        private void borrarPermisosCache()
        {
            int idUsuario = int.Parse(hdfIdUsuario.Value);

            permisoNego.borrarPermisosCache(idUsuario);
        }

        private void guardarPermisosCache()
        {
            int idUsuario = int.Parse(hdfIdUsuario.Value);
            int idPerfil = int.Parse(ddlAsignarPerfil.SelectedValue);
            int idEfector = int.Parse(Session["idEfector"].ToString());

            IList<SSO_GetPermisosXUsuarioResultSet0> listaPermisosXUsuario = permisoNego.listaPermisosXUsuario(idPerfil, idEfector).ToList();

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
    }
}