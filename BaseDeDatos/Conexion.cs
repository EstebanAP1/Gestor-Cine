using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public class Conexion
    {
        string CadConex;
        OleDbConnection conexion;
        OleDbCommand comand;

        public int BdCodeError { get; set; }
        public string BdMsgError { get; set; }

        public Conexion()
        {
            BdCodeError = 0;
            BdMsgError = "";
            CadConex = "provider='MSOLEDBSQL'; data source='ESTEBAN\\SQLEXPRESS';initial catalog='cine';user id='sa';password='1234' ";
        }

        public void Conectar()
        {
            conexion = new OleDbConnection(CadConex);
            conexion.Open();
        }

        public void Desconectar() => conexion.Close();

        public void CrearComando(string comando, CommandType tipo)
        {
            comand = new OleDbCommand(comando, conexion);
            comand.CommandType = tipo;
        }

        public void AsignarParametro(string pNombre, OleDbType pTipo, object pValor)
        {
            comand.Parameters.Add(pNombre, pTipo).Value = pValor;
        }

        public int EjecutarComando()
        {
            int numReg = 0;
            try
            {
                numReg = comand.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                BdCodeError = ex.ErrorCode;
                BdMsgError = ex.Message;
            }
            finally
            {
                if (BdCodeError != 0)
                {
                    comand.Dispose();
                    conexion.Close();
                }
            }
            return numReg;
        }

        public OleDbDataReader EjecutarConsultaReader() => comand.ExecuteReader();

        public DataTable EjecutarConsultaDT()
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(comand);
            da.Fill(dt);
            return dt;
        }
    }
}
