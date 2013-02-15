using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Domain.DTO;
using DataAccess.Interface;
namespace DataAccess.NoTransactional
{
    public class DANTVuelo:IDANTVuelo<Vuelo> 
    {
        public List<Domain.DTO.Vuelo> CargarVueloAll() {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            conn.Open();
            List<Vuelo> oVuelo = null ;
            SqlCommand oCommand = new SqlCommand();
            try 
	        {
                oCommand.Connection = conn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_CARGAR_VUELO_ALL";
                using(SqlDataReader oDataReader = oCommand.ExecuteReader()) {
                    int NuVuelo = oDataReader.GetOrdinal("NuVuelo");
                    int CoAerolinea = oDataReader.GetOrdinal("CoAerolinea");
                    int CoCiudadOri = oDataReader.GetOrdinal("CoCiudadOri");
                    int CoCiudadDes = oDataReader.GetOrdinal("CoCiudadDes");
                    int SsCosto = oDataReader.GetOrdinal("SsCosto");
                    int FeSalida = oDataReader.GetOrdinal("FeSalida");
                    int FeRetorno = oDataReader.GetOrdinal("FeRetorno");
                    int HrSalida = oDataReader.GetOrdinal("HrSalida");
                    int HrRetorno = oDataReader.GetOrdinal("HrRetorno");
                    int QtDisponible = oDataReader.GetOrdinal("QtDisponible");
                    int NoRazonSocialAerolina = oDataReader.GetOrdinal("NoRazonSocialAerolina");
                    int NoCiudadDescripcionOri = oDataReader.GetOrdinal("NoCiudadDescripcionOri");
                    int NoCiudadDescripcionDes = oDataReader.GetOrdinal("NoCiudadDescripcionDes");
                    Object[] Valores = new Object[oDataReader.FieldCount];
 
                    if(oDataReader.HasRows){
                        oVuelo = new List<Vuelo>() ;
                        while( oDataReader.Read()){
                            Vuelo oENVuelo = new Vuelo();
                            oDataReader.GetValues(Valores);
                            oENVuelo.NuVuelo = Int32.Parse(Valores[NuVuelo].ToString());
                            oENVuelo.CoAerolinea = !String.IsNullOrEmpty(Valores[CoAerolinea].ToString()) ? Valores[CoAerolinea].ToString() :String.Empty;
                            oENVuelo.CoCiudadOri = !String.IsNullOrEmpty(Valores[CoCiudadOri].ToString()) ? Valores[CoCiudadOri].ToString() : String.Empty;
                            oENVuelo.CoCiudadDes = !String.IsNullOrEmpty(Valores[CoCiudadDes].ToString()) ? Valores[CoCiudadDes].ToString() : String.Empty;
                            oENVuelo.SsCosto = Decimal.Parse(Valores[SsCosto].ToString());
                            oENVuelo.FeSalida = DateTime.Parse(Valores[FeSalida].ToString());
                            oENVuelo.FeRetorno = DateTime.Parse(Valores[FeRetorno].ToString());
                            oENVuelo.HrSalida = DateTime.Parse(Valores[HrSalida].ToString());
                            oENVuelo.HrRetorno = DateTime.Parse(Valores[HrRetorno].ToString());
                            oENVuelo.QtDisponible = Int32.Parse(Valores[QtDisponible].ToString());
                            oENVuelo.NoRazonSocialAerolina = !String.IsNullOrEmpty(Valores[NoRazonSocialAerolina].ToString()) ? Valores[NoRazonSocialAerolina].ToString() : String.Empty;
                            oENVuelo.NoCiudadDescripcionOri = !String.IsNullOrEmpty(Valores[NoCiudadDescripcionOri].ToString()) ? Valores[NoCiudadDescripcionOri].ToString() : String.Empty;
                            oENVuelo.NoCiudadDescripcionDes = !String.IsNullOrEmpty(Valores[NoCiudadDescripcionDes].ToString()) ? Valores[NoCiudadDescripcionDes].ToString() : String.Empty;
                            oVuelo.Add(oENVuelo);
                        }
                    }
                }
                return oVuelo;
	        }
	        catch (Exception)
	        {
		        throw;
	        }finally{
                oCommand.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }


        public List<Vuelo> CargarVueloFind(string FechaPartida, string FechaRegreso, string LugarOrigen, string LugarDestino)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            conn.Open();
            List<Vuelo> oVuelo = null;
            SqlCommand oCommand = new SqlCommand();
            try
            {
                oCommand.Connection = conn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_CARGAR_VUELO_FIND";
                oCommand.Parameters.Add("sFechaPartida",SqlDbType.VarChar).Value=FechaPartida;
                oCommand.Parameters.Add("sFechaRegreso", SqlDbType.VarChar).Value = FechaRegreso;
                oCommand.Parameters.Add("sLugarOrigen", SqlDbType.Char).Value = LugarOrigen;
                oCommand.Parameters.Add("sLugarDestino", SqlDbType.Char).Value = LugarDestino;

                using (SqlDataReader oDataReader = oCommand.ExecuteReader())
                {
                    int NuVuelo = oDataReader.GetOrdinal("NuVuelo");
                    int CoAerolinea = oDataReader.GetOrdinal("CoAerolinea");
                    int CoCiudadOri = oDataReader.GetOrdinal("CoCiudadOri");
                    int CoCiudadDes = oDataReader.GetOrdinal("CoCiudadDes");
                    int SsCosto = oDataReader.GetOrdinal("SsCosto");
                    int FeSalida = oDataReader.GetOrdinal("FeSalida");
                    int FeRetorno = oDataReader.GetOrdinal("FeRetorno");
                    int HrSalida = oDataReader.GetOrdinal("HrSalida");
                    int HrRetorno = oDataReader.GetOrdinal("HrRetorno");
                    int QtDisponible = oDataReader.GetOrdinal("QtDisponible");
                    int NoRazonSocialAerolina = oDataReader.GetOrdinal("NoRazonSocialAerolina");
                    int NoCiudadDescripcionOri = oDataReader.GetOrdinal("NoCiudadDescripcionOri");
                    int NoCiudadDescripcionDes = oDataReader.GetOrdinal("NoCiudadDescripcionDes");
                    Object[] Valores = new Object[oDataReader.FieldCount];

                    if (oDataReader.HasRows)
                    {
                        oVuelo = new List<Vuelo>();
                        while (oDataReader.Read())
                        {
                            Vuelo oENVuelo = new Vuelo();
                            oDataReader.GetValues(Valores);
                            oENVuelo.NuVuelo = Int32.Parse(Valores[NuVuelo].ToString());
                            oENVuelo.CoAerolinea = !String.IsNullOrEmpty(Valores[CoAerolinea].ToString()) ? Valores[CoAerolinea].ToString() : String.Empty;
                            oENVuelo.CoCiudadOri = !String.IsNullOrEmpty(Valores[CoCiudadOri].ToString()) ? Valores[CoCiudadOri].ToString() : String.Empty;
                            oENVuelo.CoCiudadDes = !String.IsNullOrEmpty(Valores[CoCiudadDes].ToString()) ? Valores[CoCiudadDes].ToString() : String.Empty;
                            oENVuelo.SsCosto = Decimal.Parse(Valores[SsCosto].ToString());
                            oENVuelo.FeSalida = DateTime.Parse(Valores[FeSalida].ToString());
                            oENVuelo.FeRetorno = DateTime.Parse(Valores[FeRetorno].ToString());
                            oENVuelo.HrSalida = DateTime.Parse(Valores[HrSalida].ToString());
                            oENVuelo.HrRetorno = DateTime.Parse(Valores[HrRetorno].ToString());
                            oENVuelo.QtDisponible = Int32.Parse(Valores[QtDisponible].ToString());
                            oENVuelo.NoRazonSocialAerolina = !String.IsNullOrEmpty(Valores[NoRazonSocialAerolina].ToString()) ? Valores[NoRazonSocialAerolina].ToString() : String.Empty;
                            oENVuelo.NoCiudadDescripcionOri = !String.IsNullOrEmpty(Valores[NoCiudadDescripcionOri].ToString()) ? Valores[NoCiudadDescripcionOri].ToString() : String.Empty;
                            oENVuelo.NoCiudadDescripcionDes = !String.IsNullOrEmpty(Valores[NoCiudadDescripcionDes].ToString()) ? Valores[NoCiudadDescripcionDes].ToString() : String.Empty;
                            oVuelo.Add(oENVuelo);
                        }
                    }
                }
                return oVuelo;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oCommand.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public List<Vuelo> CargarVueloOne(int iNuVuelo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            conn.Open();
            List<Vuelo> oVuelo = null;
            SqlCommand oCommand = new SqlCommand();
            try
            {
                oCommand.Connection = conn;
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.CommandText = "SP_CARGAR_VUELO_ONE";
                oCommand.Parameters.Add("iNuVuelo", SqlDbType.Int).Value = iNuVuelo;

                using (SqlDataReader oDataReader = oCommand.ExecuteReader())
                {
                    int NuVuelo = oDataReader.GetOrdinal("NuVuelo");
                    int CoAerolinea = oDataReader.GetOrdinal("CoAerolinea");
                    int CoCiudadOri = oDataReader.GetOrdinal("CoCiudadOri");
                    int CoCiudadDes = oDataReader.GetOrdinal("CoCiudadDes");
                    int SsCosto = oDataReader.GetOrdinal("SsCosto");
                    int FeSalida = oDataReader.GetOrdinal("FeSalida");
                    int FeRetorno = oDataReader.GetOrdinal("FeRetorno");
                    int HrSalida = oDataReader.GetOrdinal("HrSalida");
                    int HrRetorno = oDataReader.GetOrdinal("HrRetorno");
                    int QtDisponible = oDataReader.GetOrdinal("QtDisponible");
                    int NoRazonSocialAerolina = oDataReader.GetOrdinal("NoRazonSocialAerolina");
                    int NoCiudadDescripcionOri = oDataReader.GetOrdinal("NoCiudadDescripcionOri");
                    int NoCiudadDescripcionDes = oDataReader.GetOrdinal("NoCiudadDescripcionDes");
                    Object[] Valores = new Object[oDataReader.FieldCount];

                    if (oDataReader.HasRows)
                    {
                        oVuelo = new List<Vuelo>();
                        while (oDataReader.Read())
                        {
                            Vuelo oENVuelo = new Vuelo();
                            oDataReader.GetValues(Valores);
                            oENVuelo.NuVuelo = Int32.Parse(Valores[NuVuelo].ToString());
                            oENVuelo.CoAerolinea = !String.IsNullOrEmpty(Valores[CoAerolinea].ToString()) ? Valores[CoAerolinea].ToString() : String.Empty;
                            oENVuelo.CoCiudadOri = !String.IsNullOrEmpty(Valores[CoCiudadOri].ToString()) ? Valores[CoCiudadOri].ToString() : String.Empty;
                            oENVuelo.CoCiudadDes = !String.IsNullOrEmpty(Valores[CoCiudadDes].ToString()) ? Valores[CoCiudadDes].ToString() : String.Empty;
                            oENVuelo.SsCosto = Decimal.Parse(Valores[SsCosto].ToString());
                            oENVuelo.FeSalida = DateTime.Parse(Valores[FeSalida].ToString());
                            oENVuelo.FeRetorno = DateTime.Parse(Valores[FeRetorno].ToString());
                            oENVuelo.HrSalida = DateTime.Parse(Valores[HrSalida].ToString());
                            oENVuelo.HrRetorno = DateTime.Parse(Valores[HrRetorno].ToString());
                            oENVuelo.QtDisponible = Int32.Parse(Valores[QtDisponible].ToString());
                            oENVuelo.NoRazonSocialAerolina = !String.IsNullOrEmpty(Valores[NoRazonSocialAerolina].ToString()) ? Valores[NoRazonSocialAerolina].ToString() : String.Empty;
                            oENVuelo.NoCiudadDescripcionOri = !String.IsNullOrEmpty(Valores[NoCiudadDescripcionOri].ToString()) ? Valores[NoCiudadDescripcionOri].ToString() : String.Empty;
                            oENVuelo.NoCiudadDescripcionDes = !String.IsNullOrEmpty(Valores[NoCiudadDescripcionDes].ToString()) ? Valores[NoCiudadDescripcionDes].ToString() : String.Empty;
                            oVuelo.Add(oENVuelo);
                        }
                    }
                }
                return oVuelo;
            }
            catch (Exception)
            {
                throw;
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


