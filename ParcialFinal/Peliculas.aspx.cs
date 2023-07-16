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
    public partial class Peliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PeliculasFunctions.CargarComboClasificacion(cbClasificacion);
            }
            if (Session["Usuario"] == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else PeliculasFunctions.CargarGridPeliculas(tablaPeliculas);

        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cbClasificacion.SelectedIndex = -1;

            PeliculasFunctions.CargarGridPeliculas(tablaPeliculas);
        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            PeliculasFunctions peliculas = new PeliculasFunctions();
            peliculas.codigo = txtCodigo.Text;
            peliculas.nombre = txtNombre.Text;
            peliculas.clasificacion = cbClasificacion.SelectedValue;
            if (!peliculas.ConsultarPelicula())
            {
                int numReg = peliculas.AgregarPelicula();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se agregó una nueva pelicula.";
                    Limpiar();
                }
                else
                {
                    if (peliculas.BdCodeError != 0)
                    {
                        lbMsg.Text = peliculas.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizo el registro.";
                }
            }
            else
            {
                lbMsg.Text = "Ya existe una pelicula con ese codigo";
            }
        }

        protected void eliminarBtn_Click(object sender, EventArgs e)
        {
            int numReg = 0;
            PeliculasFunctions peliculas = new PeliculasFunctions();
            peliculas.codigo = txtCodigo.Text;
            if (!peliculas.ConsultarPeliculaAsignada())
            {
                numReg = peliculas.EliminarPelicula();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se eliminó la película.";
                    Limpiar();
                }
                else
                {
                    if (peliculas.BdCodeError != 0)
                    {
                        lbMsg.Text = peliculas.BdMsgError;
                    }
                    else lbMsg.Text = "La película no existe o hubo un error.";
                }
            }
            else lbMsg.Text = "No se puede eliminar una pelicula asignada a una función.";
        }

        protected void actualizarBtn_Click(object sender, EventArgs e)
        {
            PeliculasFunctions peliculas = new PeliculasFunctions();
            peliculas.codigo = txtCodigo.Text;
            if (peliculas.ConsultarPelicula())
            {
                peliculas.nombre = txtNombre.Text;
                peliculas.clasificacion = cbClasificacion.SelectedValue;
                int numReg = peliculas.ActualizarPelicula();
                if (numReg > 0)
                {
                    lbMsg.Text = "Se actualizó la pelicula.";
                    Limpiar();
                }
                else
                {
                    if (peliculas.BdCodeError != 0)
                    {
                        lbMsg.Text = peliculas.BdMsgError;
                    }
                    else lbMsg.Text = "No se actualizó la pelicula.";
                }
            }
            else
            {
                lbMsg.Text = "Esa pelicula no está registrada.";
            }
        }

        protected void consultarBtn_Click(object sender, EventArgs e)
        {
            PeliculasFunctions peliculas = new PeliculasFunctions();
            peliculas.codigo = txtCodigo.Text;
            if (peliculas.ConsultarPelicula())
            {
                txtNombre.Text = peliculas.nombre;
                cbClasificacion.SelectedValue = peliculas.clasificacion;
            }
            else if (peliculas.BdCodeError != 0)
            {
                lbMsg.Text = peliculas.BdMsgError;
            }
            else
            {
                lbMsg.Text = "La pelicula consultada no existe.";
            }
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