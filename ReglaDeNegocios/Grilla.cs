using BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ReglaDeNegocios
{
    public class Grilla
    {
        Conexion Conexion;

        public Grilla()
        {
            Conexion = new Conexion();
        }

        public void Preparar(string pComando, CommandType Ptipo)
        {
            Conexion.Conectar();
            Conexion.CrearComando(pComando, Ptipo);
        }

        public void AsignarParam(string nombre, OleDbType Ptipo, object Pvalor)
        {
            Conexion.AsignarParametro(nombre, Ptipo, Pvalor);
        }
        public void Cargar(GridView pGrilla)
        {
            var dt = new DataTable();
            dt = Conexion.EjecutarConsultaDT();
            Conexion.Desconectar();
            pGrilla.DataSource = dt;
            pGrilla.DataBind();
        }
        public void Cargar(GridView pGrilla, string pComando, CommandType pTipo)
        {
            Preparar(pComando, pTipo);
            Cargar(pGrilla);
        }
    }
}
