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
    public class FuncionesFunctions
    {
        Conexion Conexion;
        public string codigo { get; set; }
        public string fecha { get; set; }
        public string codigoPelicula { get; set; }
        public string codigoSala { get; set; }
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public FuncionesFunctions(string codigo, string fecha, string codigoPelicula, string codigoSala)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.codigoPelicula = codigoPelicula;
            this.codigoSala = codigoSala;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public FuncionesFunctions()
        {
            this.codigo = String.Empty;
            this.fecha = String.Empty;
            this.codigoPelicula = String.Empty;
            this.codigoSala = String.Empty;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public static void CargarComboPelicula(DropDownList pCombo)
        {
            var sql = "SELECT [codigo], [nombre] FROM peliculas";
            Combos combos = new Combos();
            combos.Cargar(pCombo, sql, CommandType.Text, "codigo", "nombre");
        }

        public static void CargarComboSala(DropDownList pCombo)
        {
            var sql = "SELECT [codigo] FROM salas";
            Combos combos = new Combos();
            combos.Cargar(pCombo, sql, CommandType.Text, "codigo", "codigo");
        }

        public static void CargarGridFunciones(GridView pGrilla)
        {
            var sql = "SELECT f.codigo as 'Código función', f.fecha as 'Fecha', p.nombre as 'Película', p.codigo as 'Código película',s.codigo as 'Código sala', s.capacidad as 'Capacidad de sala', p.clasificacion as 'Clasificación' FROM funciones f" +
                " INNER JOIN peliculas p ON p.codigo = f.codigoPelicula" +
                " INNER JOIN salas s ON s.codigo = f.codigoSala";
            Grilla grid = new Grilla();
            grid.Cargar(pGrilla, sql, CommandType.Text);
        }

        public int AgregarFuncion(string codigo, string fecha, string codigoPelicula, string codigoSala)
        {
            int numReg = 0;
            string sql = "INSERT INTO funciones([codigo],[fecha],[codigoPelicula],[codigoSala]) VALUES (?,?,?,?)";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigo);
            Conexion.AsignarParametro("?", OleDbType.VarChar, fecha);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigoPelicula);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigoSala);
            numReg = Conexion.EjecutarComando();
            if (numReg <= 0)
            {
                if (Conexion.BdCodeError != 0)
                {
                    BdCodeError = Conexion.BdCodeError;
                    BdMsgError = Conexion.BdMsgError;
                }
            }
            return numReg;
        }

        public int AgregarFuncion()
        {
            return AgregarFuncion(this.codigo, this.fecha, this.codigoPelicula, this.codigoSala);
        }

        public int ActualizarFunciones(string codigo, string fecha, string codigoPelicula, string codigoSala)
        {
            int numReg = 0;
            string sql = "UPDATE funciones SET fecha = ?, codigoPelicula = ?, codigoSala = ? WHERE codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, fecha);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigoPelicula);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigoSala);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigo);
            numReg = Conexion.EjecutarComando();
            if (numReg <= 0)
            {
                if (Conexion.BdCodeError != 0)
                {
                    BdCodeError = Conexion.BdCodeError;
                    BdMsgError = Conexion.BdMsgError;
                }
            }
            return numReg;
        }

        public int ActualizarFunciones()
        {
            return ActualizarFunciones(this.codigo, this.fecha, this.codigoPelicula, this.codigoSala);
        }

        public int EliminarFuncion(string codigo)
        {
            int numReg = 0;
            string sql = "DELETE FROM funciones WHERE codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigo);
            numReg = Conexion.EjecutarComando();
            Conexion.Desconectar();
            if (numReg <= 0)
            {
                if (Conexion.BdCodeError != 0)
                {
                    BdCodeError = Conexion.BdCodeError;
                    BdMsgError = Conexion.BdMsgError;
                }
            }
            return numReg;
        }

        public int EliminarFuncion()
        {
            return EliminarFuncion(this.codigo);
        }

        public bool ConsultarFuncion(string codigo)
        {
            OleDbDataReader dr;
            string sql = "SELECT fecha, codigoPelicula, codigoSala FROM funciones WHERE codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, codigo);
            dr = Conexion.EjecutarConsultaReader();
            if (dr.Read())
            {
                this.fecha = dr["fecha"].ToString();
                this.codigoPelicula = dr["codigoPelicula"].ToString();
                this.codigoSala = dr["codigoSala"].ToString();
                Conexion.Desconectar();
                return true;
            }
            else
            {
                if (Conexion.BdCodeError != 0)
                {
                    BdCodeError = Conexion.BdCodeError;
                    BdMsgError = Conexion.BdMsgError;
                }
                Conexion.Desconectar();
                return false;
            }
        }

        public bool ConsultarFuncion()
        {
            return ConsultarFuncion(this.codigo);
        }
    }
}
