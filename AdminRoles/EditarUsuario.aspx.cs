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
        ConfigNego configNego = new ConfigNego();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            if (Request["idUsuario"] != null)
            {
                Session["idUsuario"] = Request["idUsuario"].ToString();
                mostrarUsuario();
                capaHabilitado.Visible = true;
            }
            else
            {
                selectUsuarios.Visible = true;
                capaTrabajaEnGuardia.Visible = false;
            }

            llenarListas();
            validaSoloNumeros();
            alerta.Visible = false;
            muestraTrabajaEnGuardia();
            muestraDatosSolicitadoXUsuario();
        }

        //Muestra el Efector y el Perfil solicitado por el usuario.
        private void muestraDatosSolicitadoXUsuario()
        {
            int idUsuario = int.Parse(Request["idUsuario"].ToString());

            txtEfectorSolicitado.Text = usuarioNego.devuelveEfectorSolicitadoXUsuario(idUsuario);
            txtPerfilSolicitado.Text = usuarioNego.devuelvePerfilSolicitadoXUsuario(idUsuario);
        }

        //Si se ingresa por el Nivel Central se oculta el checkbox de "Trabaja en Guardia". 
        private void muestraTrabajaEnGuardia()
        {
            if (IdHospital == "0")
                capaTrabajaEnGuardia.Visible = false;
            else
                capaTrabajaEnGuardia.Visible = true;
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

            ddlUsuarios.DataSource = usuarioNego.listaUsuarios().ToList();
            ddlUsuarios.DataBind();
            ddlUsuarios.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void mostrarUsuario()
        {
            SSO_User ssoUsuario = new SSO_User();
            ssoUsuario = usuarioNego.devuelveUsuarioXIdUsuario(IdUsuario);

            txtNombre.Text = ssoUsuario.Name;
            txtApellido.Text = ssoUsuario.Surname;
            txtUsuario.Text = ssoUsuario.Username;
            txtDocumento.Text = ssoUsuario.Documento.ToString();
            txtEmail.Text = ssoUsuario.Email;
            txtObservaciones.Text = ssoUsuario.Observacion;
            txtProfesional.Value = devuelveProfesionalVinculado();

            if (devuelveIdProfesional() != 0)
                ddlProfesional.Text = devuelveIdProfesional().ToString();
        }

        private int devuelveIdProfesional()
        {
            int idProfesional = 0;

            if (Session["idUsuario"] != null)
            {
                SSO_StoredVariable storedVariable = new SSO_StoredVariable();
                storedVariable = profesionalNego.devuelveProfesionalXUsuario(int.Parse(Session["idUsuario"].ToString()));

                SSO_GetProfesionalXIdResultSet0 nombreProfesional = new SSO_GetProfesionalXIdResultSet0();

                if (storedVariable != null)
                {
                    nombreProfesional = profesionalNego.listaProfesionalXIdProfesional(int.Parse(storedVariable.Value.ToString())).FirstOrDefault();

                    if (nombreProfesional != null)
                        idProfesional = nombreProfesional.Codigo;
                }
            }

            return idProfesional;
        }

        private string devuelveProfesionalVinculado()
        {
            string profesional = string.Empty;

            SSO_StoredVariable storedVariable = new SSO_StoredVariable();
            storedVariable = profesionalNego.devuelveProfesionalXUsuario(IdUsuario);

            SSO_GetProfesionalXIdResultSet0 nombreProfesional = new SSO_GetProfesionalXIdResultSet0();

            if (storedVariable != null)
            {
                nombreProfesional = profesionalNego.listaProfesionalXIdProfesional(int.Parse(storedVariable.Value.ToString())).FirstOrDefault();

                if (nombreProfesional != null)
                    profesional = nombreProfesional.Nombre;
            }

            return profesional;
        }

        private void actualizarUsuario()
        {
            SSO_User ssousuario = new SSO_User();
            ssousuario = usuarioNego.devuelveUsuarioXIdUsuario(int.Parse(Session["idUsuario"].ToString()));

            ssousuario.Id = ssousuario.Id;
            ssousuario.Name = txtNombre.Text.ToUpper();
            ssousuario.Surname = txtApellido.Text.ToUpper();
            ssousuario.Username = txtUsuario.Text;
            ssousuario.Password = ssousuario.Password;
            ssousuario.Documento = int.Parse(txtDocumento.Text);
            ssousuario.Email = txtEmail.Text.ToUpper();
            ssousuario.Observacion = txtObservaciones.Text.ToUpper();

            usuarioNego.actualizarUsuario(ssousuario);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                actualizarUsuario();

                alerta.Visible = true;

                if (Request["idUsuario"] != null)
                {
                    string script = @"<script type='text/javascript'>function r() { location.href='AdminRoles.aspx' } setTimeout ('r()', 2000);</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
                }
                else
                {
                    Session.Clear();

                    string script = @"<script type='text/javascript'>function r() { location.href='EditarUsuario.aspx' } setTimeout ('r()', 2000);</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "r()", script, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnResetClave_Click(object sender, EventArgs e)
        {
            try
            {
                SSO_User ssoUsuario = new SSO_User();
                ssoUsuario = usuarioNego.devuelveUsuarioXIdUsuario(int.Parse(Session["idUsuario"].ToString()));

                ssoUsuario.Password = HashSHA1("12345");

                usuarioNego.actualizarUsuario(ssoUsuario);

                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
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
            EditarUsuario editarUsuario = new EditarUsuario();

            if (editarUsuario.IdHospital != "0")
            {
                ProfesionaNego profesionalNego = new ProfesionaNego();

                bool trabajaEnGuardia = estado;
                int idProfesional = editarUsuario.devuelveIdProfesional();

                profesionalNego.guardaProfesionalEnGuardia(idProfesional, estado);
            }
        }

        public string trabajaEnGuardia()
        {
            string esGuardia = string.Empty;

            if (IdHospital != "0")
            {
                int idProfesional = devuelveIdProfesional();

                IList<SSO_GetProfesionalesXGuardiaResultSet0> lista = profesionalNego.listaProfesionalesEnGuardiaXIdProfesional(idProfesional).ToList();

                if (lista.Count == 0)
                    esGuardia = "false";
                else
                    esGuardia = "true";
            }

            return esGuardia.ToString().ToLower();
        }

        [ScriptMethod(), WebMethod()]
        public static void habilitarUsuario(bool estado)
        {
            UsuariosNego usuarioNego = new UsuariosNego();

            SSO_User usuario = new SSO_User();
            usuario = usuarioNego.devuelveUsuarioXIdUsuario(int.Parse(HttpContext.Current.Session["idUsuario"].ToString()));

            usuario.Enabled = estado;

            usuarioNego.actualizarUsuario(usuario);
        }

        public string esusuarioHabilitado(int idUsuario)
        {
            string estado = string.Empty;

            if (idUsuario != 0)
            {
                SSO_User usuario = new SSO_User();
                usuario = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario);

                estado = usuario.Enabled.ToString().ToLower();
            }

            return estado;
        }

        [ScriptMethod(), WebMethod()]
        public static void desbloquearUsuario(bool estado)
        {
            EditarUsuario editarUsuario = new EditarUsuario();
            UsuariosNego usuarioNego = new UsuariosNego();

            SSO_User usuario = new SSO_User();
            usuario = usuarioNego.devuelveUsuarioXIdUsuario(int.Parse(HttpContext.Current.Session["idUsuario"].ToString()));

            if (estado == true)
                estado = false;
            else if (estado == false)
                estado = true;

            usuario.Id = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());
            usuario.Locked = estado;

            usuarioNego.actualizarUsuario(usuario);
        }

        public string esusuarioBloqueado(int idUsuario)
        {
            string estado = string.Empty;

            if (idUsuario != 0)
            {
                SSO_User usuario = new SSO_User();
                usuario = usuarioNego.devuelveUsuarioXIdUsuario(idUsuario);

                if (usuario.Locked == true)
                    estado = "false";
                else
                    estado = "true";
            }

            return estado.ToString().ToLower();
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdUsuario = int.Parse(ddlUsuarios.SelectedValue.ToString());

            Session["idUsuario"] = IdUsuario;
            mostrarUsuario();

            capaHabilitado.Visible = true;
        }
    }
}