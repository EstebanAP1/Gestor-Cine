using ReglaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialFinal
{
    public partial class Salas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else SalasFunctions.CargarGridSalas(tablaSalas);
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtCapacidad.Text = "";

            SalasFunctions.CargarGridSalas(tablaSalas);
        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            SalasFunctions salas = new SalasFunctions();
            salas.codigo = txtCodigo.Text;
            salas.capacidad = Convert.ToInt32(txtCapacidad.Text);
            if (salas.ConsultarSala())
            {
                int numReg = salas.AgregarSala();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se agregó una nueva sala.";
                    Limpiar();
                }
                else
                {
                    if (salas.BdCodeError != 0)
                    {
                        lbMsg.Text = salas.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizo el registro.";
                }
            }
            else
            {
                lbMsg.Text = "Ya existe una sala con ese código";
            }
        }

        protected void eliminarBtn_Click(object sender, EventArgs e)
        {
            int numReg = 0;
            SalasFunctions salas = new SalasFunctions();
            salas.codigo = txtCodigo.Text;
            if (!salas.ConsultarSalaAsignada())
            {
                numReg = salas.EliminarSala();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se eliminó la sala.";
                    Limpiar();
                }
                else
                {
                    if (salas.BdCodeError != 0)
                    {
                        lbMsg.Text = salas.BdMsgError;
                    }
                    else lbMsg.Text = "La sala no existe o hubo un error.";
                }
            }
            else lbMsg.Text = "No se puede eliminar una sala asignada a una función.";
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void actualizarBtn_Click(object sender, EventArgs e)
        {
            SalasFunctions salas = new SalasFunctions();
            salas.codigo = txtCodigo.Text;
            if (salas.ConsultarSala())
            {
                salas.capacidad = Convert.ToInt32(txtCapacidad.Text);
                int numReg = salas.ActualizarSala();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se actualizó la sala.";
                    Limpiar();
                }
                else
                {
                    if (salas.BdCodeError != 0)
                    {
                        lbMsg.Text = salas.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizó la sala.";
                }
            }
            else
            {
                lbMsg.Text = "Esa sala no está registrada.";
            }
        }

        protected void consultarBtn_Click(object sender, EventArgs e)
        {
            SalasFunctions salas = new SalasFunctions();
            salas.codigo = txtCodigo.Text;
            if (salas.ConsultarSala())
            {
                txtCapacidad.Text = salas.capacidad.ToString();
            }
            else if (salas.BdCodeError != 0)
            {
                lbMsg.Text = salas.BdMsgError;
            }
            else
            {
                lbMsg.Text = "La sala consultada no existe.";
            }
        }

        protected void cerrarSesionBtn_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}