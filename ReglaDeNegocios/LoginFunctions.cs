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

namespace ReglaDeNegocios
{
    public class LoginFunctions
    {
        Conexion Conexion;
        public string usuario { get; set; }
        public string password { get; set; }
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public LoginFunctions(string usuario, string pass)
        {
            this.usuario = usuario;
            this.password = pass;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public LoginFunctions()
        {
            usuario = String.Empty;
            password = String.Empty;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public bool IniciarSesion(string pUsuario, string pPassword)
        {
            OleDbDataReader dr;
            string sql = "SELECT usuario FROM usuarios WHERE usuario = ? AND pass = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pUsuario);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pPassword);
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
        public bool IniciarSesion()
        {
            return IniciarSesion(this.usuario, this.password);
        }
    }
}
