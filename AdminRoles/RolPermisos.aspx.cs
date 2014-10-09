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
                int idAplicacion = int.Parse(ddlAplicaciones.SelectedValue);

                guardaRoleGroups(idAplicacion);

                //Trae el último idRolGroup insertado.
                //int IdRolGroup = ultimoIdRolGroup();

                // guardaRolGroupMembers(IdRolGroup);

                guardaSSOPermissions(idAplicacion);

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

        //devuelve el último idRolGroup insertado en la tabla SSO_RoleGroups.
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

            borrarPermisos(idRoleGroup);
            borrarRoleGroups(idRoleGroup);            
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