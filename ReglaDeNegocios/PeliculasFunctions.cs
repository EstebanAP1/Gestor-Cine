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
    public class PeliculasFunctions
    {
        Conexion Conexion;
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string clasificacion { get; set; }
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public PeliculasFunctions(string codigo, string nombre, string clasificacion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.clasificacion = clasificacion;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public PeliculasFunctions()
        {
            this.codigo = String.Empty;
            this.nombre = String.Empty;
            this.clasificacion = String.Empty;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public static void CargarComboClasificacion(DropDownList pCombo)
        {
            var sql = "SELECT [nombre] FROM clasificaciones";
            Combos combos = new Combos();
            combos.Cargar(pCombo, sql, CommandType.Text, "nombre", "nombre");
        }

        public static void CargarGridPeliculas(GridView pGrilla)
        {
            var sql = "SELECT [codigo] as 'Codigo', [nombre] as 'Nombre', [clasificacion] as 'Clasificación' FROM peliculas";
            Grilla grid = new Grilla();
            grid.Cargar(pGrilla, sql, CommandType.Text);
        }

        public int AgregarPelicula(string pCodigo, string pNombre, string pClasificacion)
        {
            int numReg = 0;
            string sql = "INSERT INTO peliculas([codigo],[nombre],[clasificacion]) VALUES (?,?,?)";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pNombre);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pClasificacion);
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

        public int AgregarPelicula()
        {
            return AgregarPelicula(this.codigo, this.nombre, this.clasificacion);
        }

        public int ActualizarPelicula(string pCodigo, string pNombre, string pClasificacion)
        {
            int numReg = 0;
            string sql = "UPDATE peliculas SET nombre=?,clasificacion=? WHERE codigo=?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pNombre);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pClasificacion);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
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

        public int ActualizarPelicula()
        {
            return ActualizarPelicula(this.codigo, this.nombre, this.clasificacion);
        }

        public int EliminarPelicula(string pCodigo)
        {
            int numReg = 0;
            string sql = "DELETE FROM peliculas WHERE codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
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

        public int EliminarPelicula()
        {
            return EliminarPelicula(this.codigo);
        }

        public bool ConsultarPelicula(string pCodigo)
        {
            OleDbDataReader dr;
            string sql = "SELECT nombre, clasificacion FROM peliculas WHERE codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
            dr = Conexion.EjecutarConsultaReader();
            if (dr.Read())
            {
                this.nombre = dr["nombre"].ToString();
                this.clasificacion = dr["clasificacion"].ToString();
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

        public bool ConsultarPelicula()
        {
            return ConsultarPelicula(this.codigo);
        }

        public bool ConsultarPeliculaAsignada(string pCodigo)
        {
            OleDbDataReader dr;
            string sql = "SELECT p.[codigo] FROM peliculas p INNER JOIN funciones f ON f.codigoPelicula = p.codigo WHERE p.codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
            dr = Conexion.EjecutarConsultaReader();
            if (dr.Read())
            {
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

        public bool ConsultarPeliculaAsignada()
        {
            return ConsultarPeliculaAsignada(this.codigo);
        }
    }
}
