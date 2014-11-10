using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;

namespace AdminRoles
{
    public partial class EditarUsuario : System.Web.UI.Page
    {
        UsuariosNego usuarioNego = new UsuariosNego();
        ProfesionaNego profesionalNego = new ProfesionaNego();
                

        //string clave = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["idUsuario"] = Request["idUsuario"].ToString();

            if (IsPostBack) return;

            validaSoloNumeros();
            alerta.Visible = false;
            mostrarUsuario();
            llenarListas();           
        }

        private void validaSoloNumeros()
        {
            txtDocumento.Attributes.Add("onkeypress",
      "return validarNumero(event,'" + btnGuardar.ClientID + "')");
        }

        private void llenarListas()
        {
            ddlProfesional.DataSource = profesionalNego.listaProfesionales().ToList();
            ddlProfesional.DataBind();
            ddlProfesional.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void mostrarUsuario()
        {
            int idUsuario =  int.Parse(Session["idUsuario"].ToString());//int.Parse(Request["idUsuario"].ToString());

            //Idusuario = int.Parse(Request["idUsuario"].ToString());

            SSO_User ssoUsuario = new SSO_User();
            ssoUsuario = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario).FirstOrDefault();

            txtNombre.Text = ssoUsuario.Name;
            txtApellido.Text = ssoUsuario.Surname;
            txtUsuario.Text = ssoUsuario.Username;
            txtDocumento.Text = ssoUsuario.Documento.ToString();
            txtEmail.Text = ssoUsuario.Email;
            txtObservaciones.Text = ssoUsuario.Observacion;
            //ViewState["Password"] = ssoUsuario.Password;

            txtProfesional.Value = devuelveProfesionalVinculado();

            if (devuelveIdProfesional() != 0)
                ddlProfesional.Text = devuelveIdProfesional().ToString();
        }

        public string trabajaEnGuardia()
        {
            string esGuardia = string.Empty;
            int idProfesional = devuelveIdProfesional();

            IList<SSO_GetProfesionalesXGuardiaResultSet0> lista = profesionalNego.listaProfesionalesEnGuardiaXIdProfesional(idProfesional).ToList();

            if (lista.Count == 0)
                esGuardia = "false";
            else
                esGuardia = "true";

            return esGuardia.ToString().ToLower();
        }

        private int devuelveIdProfesional()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());  //int.Parse(Request["idUsuario"].ToString());
            int idProfesional = 0;

            SSO_StoredVariable storedVariable = new SSO_StoredVariable();
            storedVariable = profesionalNego.devuelveProfesionalXUsuario(idUsuario).FirstOrDefault();

            SSO_GetProfesionalXIdResultSet0 nombreProfesional = new SSO_GetProfesionalXIdResultSet0();

            if (storedVariable != null)
            {
                nombreProfesional = profesionalNego.listaProfesionalXIdProfesional(int.Parse(storedVariable.Value.ToString())).FirstOrDefault();
                idProfesional = nombreProfesional.Codigo;
            }

            return idProfesional;
        }

        private string devuelveProfesionalVinculado()
        {
            string profesional = string.Empty;
            int idUsuario = int.Parse(Request["idUsuario"].ToString());

            SSO_StoredVariable storedVariable = new SSO_StoredVariable();
            storedVariable = profesionalNego.devuelveProfesionalXUsuario(idUsuario).FirstOrDefault();

            SSO_GetProfesionalXIdResultSet0 nombreProfesional = new SSO_GetProfesionalXIdResultSet0();

            if (storedVariable != null)
            {
                nombreProfesional = profesionalNego.listaProfesionalXIdProfesional(int.Parse(storedVariable.Value.ToString())).FirstOrDefault();
                profesional = nombreProfesional.Nombre + " " + nombreProfesional.Nombre;
            }

            return profesional;
        }

        private void actualizarUsuario()
        {
            SSO_User ssousuario = new SSO_User();

            ssousuario.Id = int.Parse(Request["idUsuario"].ToString());
            ssousuario.Name = txtNombre.Text.ToUpper();
            ssousuario.Surname = txtApellido.Text.ToUpper();
            ssousuario.Username = txtUsuario.Text;
            ssousuario.Password = ViewState["Password"].ToString();
            ssousuario.Documento = int.Parse(txtDocumento.Text);
            ssousuario.Email = txtEmail.Text.ToUpper();
            ssousuario.Observacion = txtObservaciones.Text.ToUpper();

            usuarioNego.actualizarUsuario(ssousuario);
        }

        private static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarUsuario();

                alerta.Visible = true;

                string script = @"<script type='text/javascript'>function r() { location.href='AdminRoles.aspx' } setTimeout ('r()', 2000);</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnResetClave_Click(object sender, EventArgs e)
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());

            SSO_User ssoUsuario = new SSO_User();
            ssoUsuario = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario).FirstOrDefault();

            ssoUsuario.Password = HashSHA1("12345");

            usuarioNego.actualizarUsuario(ssoUsuario);
        }

        private void vincularProfesional()
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());

            SSO_StoredVariable vincularProfesional = new SSO_StoredVariable();

            vincularProfesional.Name = "Common_Medicos";
            vincularProfesional.TargetType = 3;
            vincularProfesional.Target = idUsuario;
            vincularProfesional.Value = ddlProfesional.SelectedValue;

            profesionalNego.vincularProfesional(vincularProfesional);
        }

        protected void btnGuardarProfesionalVinculado_ServerClick(object sender, EventArgs e)
        {
            vincularProfesional();                     

            txtProfesional.Value = ddlProfesional.SelectedItem.ToString();
        }

        [ScriptMethod(), WebMethod()]
        public static void trabajaEnGuardia(bool estado)
        {
            ProfesionaNego profesionalNego = new ProfesionaNego();
            EditarUsuario editarUsuario = new EditarUsuario();

            bool trabajaEnGuardia = estado;
            int idProfesional = editarUsuario.devuelveIdProfesional();//  int.Parse(HttpContext.Current.Session["idProfesional"].ToString());

            profesionalNego.guardaProfesionalEnGuardia(idProfesional, estado);
        }
    }
}