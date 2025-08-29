using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pll_ProductRepository.AccesoDatos
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _conexion;

        private DataHelper()
        {
            _conexion = new SqlConnection("Data Source=NOTEBOOKLUCI\\SQLEXPRESS02;Initial Catalog=db_almacen;Integrated Security=True;Trust Server Certificate=True");
        }

        public static DataHelper GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DataHelper();
            }
            return _instancia;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParametroSP>? parametro = null)
        {
            DataTable dt = new DataTable();
            try
            {
                _conexion.Open();
                var cmd = new SqlCommand(sp, _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                if (parametro != null)
                {
                    foreach (ParametroSP p in parametro)
                    {
                        cmd.Parameters.AddWithValue(p.nombre, p.valor);
                    }
                }
                dt.Load(cmd.ExecuteReader());


            }
            catch (SqlException)
            {
                //En caso de error devolvemos null
                dt = null;
            }
            finally
            {
                _conexion.Close();
            }
            return dt;
        }
    } 
}