using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialFinal
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void btnSalas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salas.aspx");
        }

        protected void btnPeliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Peliculas.aspx");
        }

        protected void btnFunciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Funciones.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}