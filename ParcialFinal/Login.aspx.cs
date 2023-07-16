using ReglaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialFinal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            LoginFunctions login = new LoginFunctions();
            login.usuario = txtUsuario.Text;
            login.password = txtPassword.Text;
            bool sw = login.IniciarSesion();
            if (sw)
            {
                Session["Usuario"] = login.usuario;
                FormsAuthentication.RedirectFromLoginPage(login.usuario, true);
                Response.Redirect("Menu.aspx");
            }
            else
            {
                txtPassword.Text = "";
                lbMsg.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}