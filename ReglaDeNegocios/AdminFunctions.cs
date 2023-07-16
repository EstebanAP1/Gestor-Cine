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
    public class AdminFunctions
    {
        Conexion Conexion;
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string correo { get; set; }
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public AdminFunctions(string nombre, string usuario, string pass, string correo)
        {
            this.nombre = nombre;
            this.usuario = usuario;
            this.pass = pass;
            this.correo = correo;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public AdminFunctions()
        {
            this.nombre = String.Empty;
            this.usuario = String.Empty;
            this.pass = String.Empty;
            this.correo = String.Empty;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public static void CargarGridUsuarios(GridView pGrilla)
        {
            var sql = "SELECT [usuario] as 'Nombre de usuario', [nombre] as 'Nombres', [pass] as 'Contraseña', [correo] as 'Correo' FROM usuarios";
            Grilla grid = new Grilla();
            grid.Cargar(pGrilla, sql, CommandType.Text);
        }

        public int AgregarAdmin(string nombre, string usuario, string pass, string correo)
        {
            int numReg = 0;
            string sql = "INSERT INTO usuarios([nombre],[usuario],[pass],[correo]) VALUES (?,?,?,?)";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, nombre);
            Conexion.AsignarParametro("?", OleDbType.VarChar, usuario);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pass);
            Conexion.AsignarParametro("?", OleDbType.VarChar, correo);
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

        public int AgregarAdmin()
        {
            return AgregarAdmin(this.nombre, this.usuario, this.pass, this.correo);
        }

        public int ActualizarAdmin(string nombre, string usuario, string pass, string correo)
        {
            int numReg = 0;
            string sql = "UPDATE usuarios SET nombre = ?, correo = ? WHERE usuario = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, nombre);
            Conexion.AsignarParametro("?", OleDbType.VarChar, correo);
            Conexion.AsignarParametro("?", OleDbType.VarChar, usuario);
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

        public int ActualizarAdmin()
        {
            return ActualizarAdmin(this.nombre, this.usuario, this.pass, this.correo);
        }

        public int EliminarAdmin(string pUsuario)
        {
            int numReg = 0;
            string sql = "DELETE FROM usuarios WHERE usuario = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pUsuario);
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

        public int EliminarAdmin()
        {
            return EliminarAdmin(this.usuario);
        }

        public bool ConsultarAdmin(string usuario)
        {
            OleDbDataReader dr;
            string sql = "SELECT nombre, pass, correo FROM usuarios WHERE usuario = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, usuario);
            dr = Conexion.EjecutarConsultaReader();
            if (dr.Read())
            {
                this.nombre = dr["nombre"].ToString();
                this.pass = dr["pass"].ToString();
                this.correo = dr["correo"].ToString();
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

        public bool ConsultarAdmin()
        {
            return ConsultarAdmin(this.usuario);
        }
    }
}
