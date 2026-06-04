using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppPlanMejora.Logica;
using AppPlanMejora.Modelo;

namespace AppPlanMejora.Vista
{
    public partial class Programa : System.Web.UI.Page
    {
        private ProgramasL oProgramasL = new ProgramasL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolId"] == null || Convert.ToInt32(Session["RolId"]) != 1)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarTablaProgramas();
            }
        }

        private void CargarTablaProgramas()
        {
            try
            {
                gvProgramas.DataSource = oProgramasL.Listar();
                gvProgramas.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar programas: " + ex.Message, true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.Programa oPrograma = new Modelo.Programa
                {
                    CodigoPrograma = txtCodigo.Text.Trim(),
                    NombrePrograma = txtNombre.Text.Trim(),
                    Version = txtVersion.Text.Trim(),
                    NivelFormacion = ddlNivel.SelectedValue,
                    Duracion = string.IsNullOrEmpty(txtDuracion.Text) ? 0 : Convert.ToInt32(txtDuracion.Text),
                    Estado = ddlEstado.SelectedValue
                };

                bool resultado;

                if (!string.IsNullOrEmpty(hfIdPrograma.Value))
                {
                    oPrograma.Id = Convert.ToInt32(hfIdPrograma.Value);
                    resultado = oProgramasL.Modificar(oPrograma);
                    MostrarMensaje("Programa modificado exitosamente.", false);
                }
                else
                {
                    resultado = oProgramasL.Registrar(oPrograma);
                    MostrarMensaje("Programa registrado exitosamente.", false);
                }

                if (resultado)
                {
                    LimpiarFormulario();
                    CargarTablaProgramas();
                }
            }
            catch (ArgumentException argEx)
            {
                MostrarMensaje(argEx.Message, true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Ocurrió un inconveniente técnico: " + ex.Message, true);
            }
        }

        protected void gvProgramas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow fila = gvProgramas.Rows[index];

                hfIdPrograma.Value = gvProgramas.DataKeys[index].Value.ToString();
                txtCodigo.Text = fila.Cells[0].Text;
                txtNombre.Text = Server.HtmlDecode(fila.Cells[1].Text);
                txtVersion.Text = fila.Cells[2].Text;
                ddlNivel.SelectedValue = fila.Cells[3].Text;
                txtDuracion.Text = fila.Cells[4].Text;
                ddlEstado.SelectedValue = fila.Cells[5].Text;

                btnGuardar.Text = "Actualizar Programa";
                btnGuardar.CssClass = "btn btn-warning btn-sm fw-bold text-dark";
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    if (oProgramasL.Eliminar(id))
                    {
                        MostrarMensaje("Programa eliminado correctamente de la base de datos.", false);
                        CargarTablaProgramas();
                    }
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message, true);
                }
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        private void LimpiarFormulario()
        {
            hfIdPrograma.Value = string.Empty;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtVersion.Text = string.Empty;
            txtDuracion.Text = string.Empty;
            ddlNivel.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;
            btnGuardar.Text = "Guardar Programa";
            btnGuardar.CssClass = "btn btn-success btn-sm fw-bold";
        }
        private void MostrarMensaje(string texto, bool esError)
        {
            lblMensaje.Text = texto;
            lblMensaje.CssClass = esError ? "alert alert-danger d-block p-2 text-center" : "alert alert-success d-block p-2 text-center";
        }
    }
}