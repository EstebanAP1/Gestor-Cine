using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using BaseDeDatos;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace ReglaDeNegocios
{
    public class Combos
    {
        Conexion Conexion;

        public Combos()
        {
            Conexion = new Conexion();
        }

        public void Preparar(string pComando, CommandType pTipo)
        {
            Conexion.Conectar();
            Conexion.CrearComando(pComando, pTipo);
        }

        public void AsignarParametro(string pNombre, OleDbType pTipo, object pValor)
        {
            Conexion.AsignarParametro(pNombre, pTipo, pValor);
        }

        public void Cargar(DropDownList pCombo, string pValueField, string pTextField)
        {
            DataTable dt = new DataTable();
            dt = Conexion.EjecutarConsultaDT();
            Conexion.Desconectar();
            pCombo.DataSource = dt;
            pCombo.DataValueField = pValueField;
            pCombo.DataTextField = pTextField;
            pCombo.DataBind();
        }

        public void Cargar(DropDownList pCombo, string pComando, CommandType pTipo, string pValueField, string pTextField)
        {
            Preparar(pComando, pTipo);
            Cargar(pCombo, pValueField, pTextField);
        }
    }
}
