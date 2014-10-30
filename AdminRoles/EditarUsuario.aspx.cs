using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Text;

namespace AdminRoles
{
    public partial class EditarUsuario : System.Web.UI.Page
    {
        UsuariosNego usuarioNego = new UsuariosNego();

        string clave = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            validaSoloNumeros();
            alerta.Visible = false;
            mostrarUsuario();
        }

        private void validaSoloNumeros()
        {
            txtDocumento.Attributes.Add("onkeypress",
      "return validarNumero(event,'" + btnGuardar.ClientID + "')");
        }

        private void mostrarUsuario()
        {
            int idUsuario = int.Parse(Request["idUsuario"].ToString());

            SSO_User ssoUsuario = new SSO_User();
            ssoUsuario = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario).FirstOrDefault();

            txtNombre.Text = ssoUsuario.Name;
            txtApellido.Text = ssoUsuario.Surname;
            txtUsuario.Text = ssoUsuario.Username;
            txtDocumento.Text = ssoUsuario.Documento.ToString();
            txtEmail.Text = ssoUsuario.Email;
            txtObservaciones.Text = ssoUsuario.Observacion;
            ViewState["Password"] = ssoUsuario.Password;
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
            int idUsuario = int.Parse(Request["idUsuario"].ToString());

            SSO_User ssoUsuario = new SSO_User();
            ssoUsuario = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario).FirstOrDefault();

            ssoUsuario.Password = HashSHA1("12345");

            usuarioNego.actualizarUsuario(ssoUsuario);
        }

    }
}