using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using AppPlanMejora.Logica;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppPlanMejora.Vista
{
    public partial class Login : System.Web.UI.Page
    {
        private UsuarioL oUsuarioLogica = new UsuarioL();

        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string correo = txtCorreo.Text.Trim();
                string contrasena = txtContrasena.Text.Trim();

                // Llamada directa a la capa lógica
                Usuario usuarioValidado = oUsuarioLogica.AutenticarUsuario(correo, contrasena);

                if (usuarioValidado != null)
                {
                    // Asignación de variables de sesión para el manejo de roles
                    Session["UsuarioId"] = usuarioValidado.Id;
                    Session["NombreCompleto"] = usuarioValidado.Nombres + " " + usuarioValidado.Apellidos;
                    Session["RolId"] = usuarioValidado.IdRol;

                    // Redirección condicionada por el rol en el sistema
                    switch (usuarioValidado.IdRol)
                    {
                        case 1: // Administrador de Centro
                            Response.Redirect("Modulos/Admin/Dashboard.aspx");
                            break;
                        case 2: // Instructor
                            Response.Redirect("Modulos/Instructor/Planes.aspx");
                            break;
                        case 3: // Aprendiz
                            Response.Redirect("Modulos/Aprendiz/Estado.aspx");
                            break;
                        default:
                            lblMensajeError.Text = "El usuario no cuenta con un rol asignado válido.";
                            break;
                    }
                }
                else
                {
                    lblMensajeError.Text = "Credenciales incorrectas. Verifique correo y contraseña.";
                }
            }
            catch (ArgumentException argEx)
            {
                // Muestra los errores de validación de negocio controlados
                lblMensajeError.Text = argEx.Message;
            }
            catch (Exception ex)
            {
                // Muestra errores técnicos generales capturados
                lblMensajeError.Text = "Ocurrió un inconveniente técnico: " + ex.Message;
            }
        }
    }
}