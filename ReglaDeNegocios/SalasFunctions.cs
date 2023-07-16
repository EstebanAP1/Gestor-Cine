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
    public class SalasFunctions
    {
        Conexion Conexion;
        public string codigo { get; set; }
        public int capacidad { get; set; }
        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public SalasFunctions(string codigo, int capacidad)
        {
            this.codigo = codigo;
            this.capacidad = capacidad;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public SalasFunctions()
        {
            this.codigo = String.Empty;
            this.capacidad = 0;

            BdCodeError = 0;
            BdMsgError = "";
            Conexion = new Conexion();
        }

        public static void CargarGridSalas(GridView pGrilla)
        {
            var sql = "SELECT [codigo] as 'Codigo', [capacidad] as 'Capacidad' FROM salas";
            Grilla grid = new Grilla();
            grid.Cargar(pGrilla, sql, CommandType.Text);
        }


        public int AgregarSala(string pCodigo, int pCapacidad)
        {
            int numReg = 0;
            string sql = "INSERT INTO salas([codigo],[capacidad]) VALUES (?,?)";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCapacidad);
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

        public int AgregarSala()
        {
            return AgregarSala(this.codigo, this.capacidad);
        }

        public int ActualizarSala(string pCodigo, int pCapacidad)
        {
            int numReg = 0;
            string sql = "UPDATE salas SET [capacidad]=? WHERE codigo=?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCapacidad);
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

        public int ActualizarSala()
        {
            return ActualizarSala(this.codigo, this.capacidad);
        }

        public int EliminarSala(string pCodigo)
        {
            int numReg = 0;
            string sql = "DELETE FROM salas WHERE codigo = ?";
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

        public int EliminarSala()
        {
            return EliminarSala(this.codigo);
        }

        public bool ConsultarSala(string pCodigo)
        {
            OleDbDataReader dr;
            string sql = "SELECT capacidad FROM salas WHERE codigo = ?";
            Conexion.Conectar();
            Conexion.CrearComando(sql, CommandType.Text);
            Conexion.AsignarParametro("?", OleDbType.VarChar, pCodigo);
            dr = Conexion.EjecutarConsultaReader();
            if (dr.Read())
            {
                this.capacidad = Convert.ToInt32(dr["capacidad"]);
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
        public bool ConsultarSala()
        {
            return ConsultarSala(this.codigo);
        }

        public bool ConsultarSalaAsignada(string pCodigo)
        {
            OleDbDataReader dr;
            string sql = "SELECT s.[codigo] FROM salas s INNER JOIN funciones f ON f.codigoSala = s.codigo WHERE s.codigo = ?";
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
        public bool ConsultarSalaAsignada()
        {
            return ConsultarSalaAsignada(this.codigo);
        }
    }
}

