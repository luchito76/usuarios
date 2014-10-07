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
    public partial class RolPermisos : System.Web.UI.Page
    {
        RolesNego roleNego = new RolesNego();
        AplicacionesNego aplicacionesNego = new AplicacionesNego();
        ModulosNego moduloNego = new ModulosNego();
        PermisosNego permisoNego = new PermisosNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            llenarListas();
        }

        private void llenarListas()
        {
            ddlAplicaciones.DataSource = aplicacionesNego.listaAplicaciones();
            ddlAplicaciones.DataBind();
            ddlAplicaciones.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        public int devuelveNombreIdRol()
        {
            int rolId = int.Parse(Request["rolId"].ToString());

            return rolId;
        }

        public string devuelveNombreDeRol()
        {
            string rol = Request["rolName"].ToString();

            return rol;
        }

        public string devuelveAppXRolJson()
        {
            string json = string.Empty;

            int idRol = devuelveNombreIdRol();
            int idEfector = int.Parse(Session["idEfector"].ToString());

            List<SSO_GetAppByRolResultSet0> listaAppXRol = roleNego.listaRolesXAplicacion(idRol, idEfector).ToList();

            return json = JsonConvert.SerializeObject(listaAppXRol);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                guardaRoleGroups();

                //Trae el último idRolGroup insertado.
                int IdRolGroup = ultimoIdRolGroup();

                guardaRolGroupMembers(IdRolGroup);

                int idAplicacion = int.Parse(ddlAplicaciones.SelectedValue);

                guardaSSOPermissions(idAplicacion);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void guardaRoleGroups()
        {
            string rol = Request["rolName"].ToString();
            string efector = Session["efector"].ToString();

            SSO_RoleGroup rolGroup = new SSO_RoleGroup();

            rolGroup.Name = rol + " + " + efector;
            rolGroup.AutomaticName = true;

            roleNego.guardaRoleGroup(rolGroup);
        }

        //devuelve el último idRolGroup insertado en la tabla SSO_RoleGroups.
        private int ultimoIdRolGroup()
        {
            int idRolGroup = roleNego.obtieneUltimoIdRolGroup().Id;

            return idRolGroup;
        }

        private void guardaRolGroupMembers(int ultimoIdRolGroup)
        {
            string rol = Request["rolName"].ToString();
            int rolId = int.Parse(Request["rolId"].ToString());

            int idEfector = int.Parse(Session["idEfector"].ToString());

            SSO_RoleGroups_Member rolGroupMember = new SSO_RoleGroups_Member();

            rolGroupMember.GroupId = ultimoIdRolGroup;
            rolGroupMember.RoleId = rolId;

            roleNego.guardarRolGroupMember(rolGroupMember);

            SSO_RoleGroups_Member rolGroupMember1 = new SSO_RoleGroups_Member();

            rolGroupMember1.GroupId = ultimoIdRolGroup;
            rolGroupMember1.RoleId = idEfector;

            roleNego.guardarRolGroupMember(rolGroupMember1);
        }

        private void guardaSSOPermissions(int idAplicacion)
        {
            List<SSO_Module> listaModulosXAplicacion = moduloNego.listaModulosXIdAplicacion(idAplicacion).ToList();

            foreach (SSO_Module data in listaModulosXAplicacion)
            {
                SSO_Permission ssoPermission = new SSO_Permission();

                ssoPermission.SourceType = 3;
                ssoPermission.Source = ultimoIdRolGroup();
                ssoPermission.TargetType = 2;
                ssoPermission.Target = data.Id;
                ssoPermission.Allow = true;
                ssoPermission.Readonly = false;

                permisoNego.guardarPermisos(ssoPermission);
            }
        }
    }
}