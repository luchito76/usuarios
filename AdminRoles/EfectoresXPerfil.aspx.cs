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
        ConfigNego configNego = new ConfigNego();

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
            HashSet<string> listaResultado;

            List<SSO_AllowedAppsByEfectorCentralResultSet0> listaEfectoresXPerfil = permisoNego.listaEfectoresXPerfil(IdUsuario, IdPerfil).ToList();

            var result = (List<SSO_Role>)null;

            foreach (SSO_AllowedAppsByEfectorCentralResultSet0 data in listaEfectoresXPerfil)
            {
                if (data.id != null)
                {
                    listaResultado = new HashSet<string>(listaEfectoresXPerfil.Select(s => s.id.ToString()));

                    List<SSO_Role> listaEfectores = rolesNego.listaEfectores().ToList();

                    result = listaEfectores.Where(s => !listaResultado.Contains(s.Id.ToString())).ToList();
                }
            }

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
            guardaRoleGroups();

            guardaRolGroupMember();

            guardaSSOUserRol();

            guardarPermisosCache();
        }


        private void guardaRoleGroups()
        {
            int idEfectorSeleccionado = int.Parse(ddlAgregarEfector.SelectedValue);

            if (rolesNego.esAplicacionEnRoleGroup(idEfectorSeleccionado, IdPerfil))
            {
                SSO_RoleGroup rolGroup = new SSO_RoleGroup();

                rolGroup.Name = nombreRolGroup();
                rolGroup.IdEfector = idEfectorSeleccionado;
                rolGroup.IdPerfil = IdPerfil;
                rolGroup.AutomaticName = true;

                rolesNego.guardaRoleGroup(rolGroup);
            }
        }

        private void guardaRolGroupMember()
        {
            SSO_RoleGroups_Member rolGroupMember = new SSO_RoleGroups_Member();

            int idEfectorSeleccionado = int.Parse(ddlAgregarEfector.SelectedValue);
            int idRolGroup = rolesNego.devuelveIdRolGroup(idEfectorSeleccionado, IdPerfil);

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
        private string nombreRolGroup()
        {
            string nombre = string.Empty;
            int idEfectorSeleccionado = 0;

            if (IdHospital == "0")
                idEfectorSeleccionado = int.Parse(ddlAgregarEfector.SelectedValue);
            else
                idEfectorSeleccionado = SSOHelper.CurrentIdentity.IdEfectorRol;

            string nombreEfector = rolesNego.listaRoles(494, true).Where(c => c.Id == idEfectorSeleccionado).FirstOrDefault().Name;
            string nombrePerfil = devuelveNombrePerfil();

            return nombre = nombreEfector + " + " + nombrePerfil;
        }

        private void guardaSSOUserRol()
        {
            SSO_Users_Role userRol = new SSO_Users_Role();

            int idEfector = int.Parse(ddlAgregarEfector.SelectedValue);

            //int idEfectorSeleccionado = rolesNego.validaEfectorXUserRol(IdUsuario, idEfector);
            int idPerfilSeleccionado = rolesNego.validaPerfilXUserRol(IdUsuario, IdPerfil);

            if (idPerfilSeleccionado == 0)
            {
                userRol.UserId = IdUsuario;
                userRol.RoleId = int.Parse(ddlAgregarEfector.SelectedValue);

                usuarioNego.guardaSSOUserRol(userRol);
            }
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