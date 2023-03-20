using System;

namespace CapaPresentacion
{
    public partial class Usuario : System.Web.UI.Page
    {
        ServiceReferenceUsuario.UsuarioServiceClient objClient = new ServiceReferenceUsuario.UsuarioServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                labelError.Visible = false;
                txtId.Visible = false;
                txtId.Text = Request.QueryString["Id"];
                txtNombre.Text = Request.QueryString["Nombre"];
                ddlSexo.SelectedValue = Request.QueryString["Sexo"];
                return;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var respuesta = new ServiceReferenceUsuario.Respuesta();
            string Nombre = txtNombre.Text;
            DateTime? FechaNacimiento = calFechaNacimiento.SelectedDate;
            string Sexo = ddlSexo.SelectedValue;
            
            if(!ValidarCampos(Nombre, FechaNacimiento, Sexo))
            {
                return;
            }

            if (txtId.Text.Length == 0)
                respuesta = objClient.AgregarUsuario(Nombre, FechaNacimiento, Sexo);
            else
            {
                int id = int.Parse(txtId.Text);
                respuesta = objClient.ModificarUsuario(Nombre, FechaNacimiento, Sexo, id);
            }

            if (respuesta.esExitoso)
            {
                Response.Redirect($"UsuarioConsulta.aspx");
            }
            else
            {
                labelError.Text = respuesta.Error;
                labelError.Visible = true;
            }

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Response.Redirect($"UsuarioConsulta.aspx");
        }

        private bool ValidarCampos(string Nombre, DateTime? FechaNacimiento, string Sexo)
        {
            bool InformaconCorresta = true;
            if (Nombre.Length == 0 || Nombre.Length > 100)
            {
                labelError.Visible = true;
                labelError.Text += " El nombre de usuario es muy corto o muy largo.";
                InformaconCorresta = false;
            }
            if (Sexo.Length != 1)
            {
                labelError.Text += " El campo sexo es muy corto o muy largo.";
                labelError.Visible = true;
                InformaconCorresta = false;
            }
            if (FechaNacimiento.ToString() == "1/01/0001 12:00:00 a. m.")
            {
                labelError.Text += " El formato de la fecha de nacimiento es incorrecto.";
                labelError.Visible = true;
                InformaconCorresta = false;
            }
            return InformaconCorresta;
        }
        
    }
}