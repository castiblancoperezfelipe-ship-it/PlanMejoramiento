using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppPlanMejora.Vista
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Control de seguridad global de la Master Page
            if (!IsPostBack)
            {
                if (Session["RolId"] != null)
                {
                    int idRol = Convert.ToInt32(Session["RolId"]);

                    // Encender el contenedor visual correspondiente al rol logueado
                    switch (idRol)
                    {
                        case 1: // Administrador de Centro
                            phAdmin.Visible = true;
                            break;
                        case 2: // Instructor
                            phInstructor.Visible = true;
                            break;
                        case 3: // Estudiante / Aprendiz
                            phEstudiante.Visible = true;
                            break;
                        default:
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/Login.aspx");
                            break;
                    }
                }
                else
                {
                    // Si el usuario no ha iniciado sesión, se redirige directo al Login
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Vista/Login.aspx");
            }
    }
}