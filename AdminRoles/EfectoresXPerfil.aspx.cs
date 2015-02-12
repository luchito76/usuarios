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
using System.Web.Services;
using System.Web.Script.Services;

namespace AdminRoles
{
    public partial class EfectoresXPerfil : System.Web.UI.Page
    {
        PermisosNego permisoNego = new PermisosNego();
        RolesNego rolesNego = new RolesNego();
        UsuariosNego usuarioNego = new UsuariosNego();
        AplicacionesNego aplicacionesNego = new AplicacionesNego();

        #region propiedades

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

        private int idPerfil;

        public int IdPerfil
        {
            get
            {
                idPerfil = int.Parse(Request["idPerfil"]);
                return idPerfil;
            }
            set { idPerfil = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SSOHelper.Authenticate();

            if (IsPostBack) return;

            llenarListas();
        }

        private void llenarListas()
        {
            var results = quitarEfectoresDuplicados();

            ddlAgregarEfector.DataSource = results;
            ddlAgregarEfector.DataBind();
            ddlAgregarEfector.Items.Insert(0, new ListItem("--Seleccione--", "0"));            
        }

        private List<SSO_Role> quitarEfectoresDuplicados()
        {
            HashSet<int> listaResultado;

            List<SSO_AllowedAppsByEfectorCentralResultSet0> listaEfectoresXPerfil = permisoNego.listaEfectoresXPerfil(IdUsuario, IdPerfil).ToList();
            listaResultado = new HashSet<int>(listaEfectoresXPerfil.Select(s => int.Parse(s.id.ToString())));

            List<SSO_Role> listaEfectores = rolesNego.listaEfectores().ToList();

            var result = listaEfectores.Where(s => !listaResultado.Contains(s.Id)).ToList();

            return result;
        }

        public string devuelveEfectores()
        {
            string json = string.Empty;

            List<SSO_AllowedAppsByEfectorCentralResultSet0> listaEfectoresXPErfil = permisoNego.listaEfectoresXPerfil(IdUsuario, IdPerfil).ToList();

            return json = JsonConvert.SerializeObject(listaEfectoresXPErfil, Formatting.Indented);
        }

        public string devuelveNombreUsuario()
        {
            string nombreUsuario = Request["nombreUsuario"].ToString();

            return nombreUsuario;
        }

        public string devuelveNombrePerfil()
        {
            string nombrePerfil = rolesNego.listaRolesXId(IdPerfil).Name;
            // nombrePerfil.InnerText = rolesNego.listaRolesXId(IdPerfil).Name;

            return nombrePerfil.ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            asignarPerfilAUsuario();

        }

        private void asignarPerfilAUsuario()
        {
            guardaSSOUserRol();

            guardarPermisosCache();
        }

        private void guardaSSOUserRol()
        {
            SSO_Users_Role userRol = new SSO_Users_Role();

            userRol.UserId = IdUsuario;
            userRol.RoleId = int.Parse(ddlAgregarEfector.SelectedValue);

            usuarioNego.guardaSSOUserRol(userRol);
        }

        private void guardarPermisosCache()
        {
            int idEfector = int.Parse(ddlAgregarEfector.SelectedValue);

            int idRolGroup = rolesNego.devuelveIdRolGroup(idEfector, IdPerfil);

            IList<SSO_GetAplicacionesXPerfilResultSet0> listaPermisosXUsuario = aplicacionesNego.listaAplicacionesXPerfil(idRolGroup).ToList();

            foreach (SSO_GetAplicacionesXPerfilResultSet0 data in listaPermisosXUsuario)
            {
                SSO_Permissions_Cache permisosCache = new SSO_Permissions_Cache();

                permisosCache.UserId = IdUsuario;
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
    }
}