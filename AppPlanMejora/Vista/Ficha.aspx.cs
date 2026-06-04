using AppPlanMejora.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using AppPlanMejora.Datos;
using System.Web.UI.WebControls;

namespace AppPlanMejora.Vista
{
    public partial class Ficha : System.Web.UI.Page
    {
        private FichaL _fichaL = new FichaL();
        private ProgramasL _programasL = new ProgramasL(); // Requerido para llenar el combo de programas

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolId"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarProgramasCombo();
                CargarTablaFichas();
            }
        }

        private void CargarProgramasCombo()
        {
            try
            {
                ddlProgramas.DataSource = _programasL.Listar();
                ddlProgramas.DataTextField = "NombrePrograma"; // Lo que el usuario lee en pantalla
                ddlProgramas.DataValueField = "Id";             // El ID real que se guardará en la FK de Ficha
                ddlProgramas.DataBind();

                // Añadimos una opción por defecto al inicio
                ddlProgramas.Items.Insert(0, new ListItem("-- Seleccione un Programa --", "0"));
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar los programas en el combo: " + ex.Message, true);
            }
        }

        private void CargarTablaFichas()
        {
            try
            {
                gvFichas.DataSource = _fichaL.Listar();
                gvFichas.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al listar las fichas: " + ex.Message, true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Construimos la entidad Ficha con los datos del formulario
                AppPlanMejora.Modelo.Ficha oFicha = new AppPlanMejora.Modelo.Ficha
                {
                    NumeroFicha = txtNumeroFicha.Text.Trim(),
                    IdPrograma = Convert.ToInt32(ddlProgramas.SelectedValue),
                    Jornada = ddlJornada.SelectedValue,
                    FechaInicio = string.IsNullOrEmpty(txtFechaInicio.Text) ? DateTime.Now : Convert.ToDateTime(txtFechaInicio.Text),
                    FechaFinalizacion = string.IsNullOrEmpty(txtFechaFin.Text) ? DateTime.Now : Convert.ToDateTime(txtFechaFin.Text),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = ddlEstado.SelectedValue
                };

                // Enviamos a la capa lógica para su procesamiento y validación
                if (_fichaL.Guardar(oFicha))
                {
                    MostrarMensaje("Ficha registrada con total éxito.", false);
                    LimpiarFormulario();
                    CargarTablaFichas();
                }
            }
            catch (ArgumentException argEx)
            {
                MostrarMensaje(argEx.Message, true);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error técnico: " + ex.Message, true);
            }
        }

        private void LimpiarFormulario()
        {
            txtNumeroFicha.Text = string.Empty;
            ddlProgramas.SelectedIndex = 0;
            ddlJornada.SelectedIndex = 0;
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlEstado.SelectedIndex = 0;
        }

        private void MostrarMensaje(string texto, bool esError)
        {
            lblMensaje.Text = texto;
            lblMensaje.CssClass = esError ? "alert alert-danger d-block p-2 text-center" : "alert alert-success d-block p-2 text-center";
        }
    }
}
