using ReglaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialFinal
{
    public partial class PagAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else AdminFunctions.CargarGridUsuarios(tablaUsuarios);
        }

        private void Limpiar()
        {
            txtNombres.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtCorreo.Text = "";

            AdminFunctions.CargarGridUsuarios(tablaUsuarios);
        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            AdminFunctions admin = new AdminFunctions();
            admin.nombre = txtNombres.Text;
            admin.usuario = txtUsuario.Text.ToLower();
            admin.pass = txtPass.Text;
            admin.correo = txtCorreo.Text;
            if (!admin.ConsultarAdmin())
            {
                int numReg = admin.AgregarAdmin();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se agregó un nuevo usuario administrador.";
                    Limpiar();
                }
                else
                {
                    if (admin.BdCodeError != 0)
                    {
                        lbMsg.Text = admin.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizo el registro.";
                }
            }
            else lbMsg.Text = "Ya existe un administrador con ese usuario.";
        }

        protected void eliminarBtn_Click(object sender, EventArgs e)
        {
            int numReg = 0;
            AdminFunctions admin = new AdminFunctions();
            admin.usuario = txtUsuario.Text.ToLower();
            if (admin.usuario.ToLower().Equals("admin"))
            {
                lbMsg.Text = "No puedes eliminar el administrador principal";
            }
            else
            {
                if (admin.ConsultarAdmin())
                {
                    numReg = admin.EliminarAdmin();
                    if (numReg > 0)
                    {
                        lbMsg.Text = "Se eliminó el usuario.";
                        Limpiar();
                    }
                    else
                    {
                        if (admin.BdCodeError != 0)
                        {
                            lbMsg.Text = admin.BdMsgError;
                        }
                        else lbMsg.Text = "El admin no existe o hubo un error.";
                    }
                }
                else lbMsg.Text = "El admin no existe.";
            }
        }

        protected void actualizarBtn_Click(object sender, EventArgs e)
        {
            int numReg = 0;
            AdminFunctions admin = new AdminFunctions();
            admin.usuario = txtUsuario.Text.ToLower();
            if (admin.usuario.ToLower().Equals("admin"))
            {
                lbMsg.Text = "No puedes actualizar el administrador principal";
            }
            else if (admin.ConsultarAdmin())
            {
                admin.nombre = txtNombres.Text;
                admin.correo = txtCorreo.Text;
                numReg = admin.ActualizarAdmin();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se actualizó el usuario.";
                    Limpiar();
                }
                else
                {
                    if (admin.BdCodeError != 0)
                    {
                        lbMsg.Text = admin.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizó el usuario.";
                }
            }
            else lbMsg.Text = "Ese usuario no está registrado.";
        }

        protected void consultarBtn_Click(object sender, EventArgs e)
        {
            AdminFunctions admin = new AdminFunctions();
            admin.usuario = txtUsuario.Text.ToLower();
            if (admin.ConsultarAdmin())
            {
                txtNombres.Text = admin.nombre;
                txtCorreo.Text = admin.correo;
            }
            else if (admin.BdCodeError != 0)
            {
                lbMsg.Text = admin.BdMsgError;
            }
            else lbMsg.Text = "El admin consultado no existe.";
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void cerrarSesionBtn_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}