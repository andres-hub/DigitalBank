using System;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class UsuarioConsulta : System.Web.UI.Page
    {
        ServiceReferenceUsuario.UsuarioServiceClient objClient = new ServiceReferenceUsuario.UsuarioServiceClient();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            labelError.Visible = false;
            CargarDatos();
        }

        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            int id = int.Parse(grdUsuarios.DataKeys[index].Value.ToString());
            if (e.CommandName == "Deleting")
            {
                objClient.EliminarUsuario(id);
                CargarDatos();
            }

            if (e.CommandName == "Modificar")
            {
                string nombre = grdUsuarios.Rows[index].Cells[0].Text;
                string sexo = grdUsuarios.Rows[index].Cells[2].Text;
                string fecha = grdUsuarios.Rows[index].Cells[1].Text;
                Response.Redirect($"Usuario.aspx?Id={id}&Nombre={nombre}&Sexo={sexo}&Fecha={fecha}");
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Usuario.aspx");
        }

        protected void CargarDatos()
        {
            
             var respuesta = objClient.ConsultarUsuarios();
            if (respuesta.esExitoso)
            {
                grdUsuarios.DataSource = respuesta.Usuarios;
                grdUsuarios.DataBind();
            }
            else
            {
                labelError.Text = respuesta.Error;
                labelError.Visible = true;
            }
        }
        
    }
}