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
    public partial class Funciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarCombos();
            }

            if (Session["Usuario"] == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else FuncionesFunctions.CargarGridFunciones(tablaFunciones);
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtFecha.Text = "";
            cbCodPelicula.SelectedIndex = -1;
            cbCodSala.SelectedIndex = -1;

            FuncionesFunctions.CargarGridFunciones(tablaFunciones);
        }

        private void CargarCombos()
        {
            FuncionesFunctions.CargarComboPelicula(cbCodPelicula);
            FuncionesFunctions.CargarComboSala(cbCodSala);
        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            FuncionesFunctions funciones = new FuncionesFunctions();
            funciones.codigo = txtCodigo.Text;
            funciones.fecha = txtFecha.Text;
            funciones.codigoPelicula = cbCodPelicula.SelectedValue;
            funciones.codigoSala = cbCodSala.SelectedValue;
            if (!funciones.ConsultarFuncion())
            {
                int numReg = funciones.AgregarFuncion();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se creó una nueva función.";
                    Limpiar();
                }
                else
                {
                    if (funciones.BdCodeError != 0)
                    {
                        lbMsg.Text = funciones.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizo el registro.";
                }
            }
            else lbMsg.Text = "Ya existe una función con ese código.";
        }


        protected void eliminarBtn_Click(object sender, EventArgs e)
        {
            int numReg = 0;
            FuncionesFunctions funciones = new FuncionesFunctions();
            funciones.codigo = txtCodigo.Text;
            if (funciones.ConsultarFuncion())
            {
                numReg = funciones.EliminarFuncion();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se eliminó la función.";
                    Limpiar();
                }
                else
                {
                    if (funciones.BdCodeError != 0)
                    {
                        lbMsg.Text = funciones.BdMsgError;
                    }
                    else lbMsg.Text = "La función no existe o hubo un error.";
                }
            }
            else lbMsg.Text = "La función no existe.";
        }

        protected void actualizarBtn_Click(object sender, EventArgs e)
        {
            int numReg = 0;
            FuncionesFunctions funciones = new FuncionesFunctions();
            funciones.codigo = txtCodigo.Text;
            if (funciones.ConsultarFuncion())
            {
                funciones.fecha = txtFecha.Text;
                funciones.codigoPelicula = cbCodPelicula.SelectedValue;
                funciones.codigoSala = cbCodSala.SelectedValue;
                numReg = funciones.ActualizarFunciones();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se actualizó la función.";
                    Limpiar();
                }
                else
                {
                    if (funciones.BdCodeError != 0)
                    {
                        lbMsg.Text = funciones.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizó la función.";
                }
            }
            else lbMsg.Text = "La función no está registrado.";
        }

        protected void consultarBtn_Click(object sender, EventArgs e)
        {
            FuncionesFunctions funciones = new FuncionesFunctions();
            funciones.codigo = txtCodigo.Text;
            if (funciones.ConsultarFuncion())
            {
                txtFecha.Text = funciones.fecha;
                cbCodPelicula.SelectedValue = funciones.codigoPelicula;
                cbCodSala.SelectedValue = funciones.codigoSala;
            }
            else if (funciones.BdCodeError != 0)
            {
                lbMsg.Text = funciones.BdMsgError;
            }
            else lbMsg.Text = "La función consultada no existe.";
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