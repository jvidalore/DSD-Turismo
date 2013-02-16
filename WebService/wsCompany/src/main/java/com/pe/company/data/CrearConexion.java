/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package com.pe.company.data;
import java.sql.*;

/**
 *
 * @author HectorLindley
 */
public class CrearConexion {
    
    static String strUsuario = "alaspepe_root";

    static String strPassword = "6tp5Y1kEh9";
    static String strBaseDatos ="alaspepe_dsd";

    static String strHost = "mssql2008r2.ukdns.biz";

     public CrearConexion()
//String usr,String pw, String bd,String srvr
    {
/*
        strUsuario = usr;
        strPassword = pw;
        strBaseDatos =bd;
        strHost = srvr;
*/
        try

        {

            //Cargar el driver

            Class.forName("net.sourceforge.jtds.jdbc.Driver");     

        } catch ( ClassNotFoundException e )

        {

            System.out.println("ERROR: Error al cargar la clase del Driver\n");

        }

    }

public static Connection getConnection() throws SQLException

    {

        //a continuacion vamos a formar la cadena de conexion, pero...

        //OJO aca debes poner el nombre de la instancia de SQL Server que vas a usar

        String url = "jdbc:jtds:sqlserver://"+strHost+"/"+strBaseDatos+";instance=SQLSERVEREXPRESS;";

        return DriverManager.getConnection(url,strUsuario,strPassword);

    }
     

//Cierra objeto Resultset

    public static void cerrar(ResultSet rs)

    {  

        try

        {

            rs.close();

        }

        catch(Exception ex)

        {}

    }

     

    //Cierra objeto Statement

    public static void cerrar(Statement st)

    {

        try

        {

            st.close();

        }

        catch(Exception ex)

        {}

    }

     

    //Cierra objeto Connection

    public static void cerrar(Connection con)

    {  

        try

        {

            con.close();

        }

        catch(Exception ex)

        {}

    }

      



}
