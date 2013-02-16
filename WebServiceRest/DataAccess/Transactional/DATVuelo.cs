using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain.DTO;
using DataAccess.Interface;

namespace DataAccess.Transactional
{
    public class DATVuelo : IDATVuelo
    {

        public bool ActualizarVuelo(int iNuVuelo, int iQtSeleccionada)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            conn.Open();
            SqlCommand oCommand = new SqlCommand();
            bool BolResultado = false;
            try
            {
                int FilasAfectadas = 0;
                oCommand.Connection = conn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_ACTUALIZAR_VUELO";
                oCommand.Parameters.Add("iNuVuelo", SqlDbType.Int).Value = iNuVuelo;
                oCommand.Parameters.Add("iQtSeleccionada", SqlDbType.Int).Value = iQtSeleccionada;
                SqlTransaction oTransaction2 = conn.BeginTransaction();
                try
                {
                    oCommand.Transaction= oTransaction2;
                    if (oCommand.ExecuteNonQuery() == -1)
                    {
                        BolResultado = true;
                    }
                    if (BolResultado == true) {
                        FilasAfectadas +=1;
                    }
                    if (FilasAfectadas ==1){
                        oTransaction2.Commit();
                    }else{
                        oTransaction2.Rollback();
                    }
                    return BolResultado;
                }
                catch (Exception)
                {
                    oTransaction2.Rollback();
                    return BolResultado;
                }
            }
            catch (Exception)
            {
                return BolResultado;
            }
            finally
            {
                oCommand.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
