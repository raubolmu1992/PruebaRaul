using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{

    public class estados
    {
        //Iniciamos la variable valestado en False;
        public static bool valestado = false;
        public static string valerror;

    }

    public class ProductoData
    {

     
        public static bool Modificar(Producto oEstudiantes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", oEstudiantes.IdProducto);
                cmd.Parameters.AddWithValue("@TipoProducto", oEstudiantes.TipoProducto);
                cmd.Parameters.AddWithValue("@CodigoUnico", oEstudiantes.CodigoUnico);
                cmd.Parameters.AddWithValue("@NombreProducto", oEstudiantes.NombreProducto);
                cmd.Parameters.AddWithValue("@Activo", oEstudiantes.Activo);
                cmd.Parameters.AddWithValue("@Cantidad", oEstudiantes.Cantidad);
                cmd.Parameters.AddWithValue("@Valor", oEstudiantes.Valor);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    // Validamos el estado de la ejecucion
                    estado.valestado = true;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return true;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return false;
                }
            }
        }

        public static List<Producto> Listar()
        {
            List<Producto> oListaUsuario = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                TipoProducto = dr["TipoProducto"].ToString(),
                                CodigoUnico = dr["CodigoUnico"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Activo = dr["Activo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Valor = dr["Valor"].ToString(),
                                
                            });
                        }

                    }

                    //// Validamos el estado de la ejecucion
                    //estado.valestado = true;
                    //// Llamamos al Metodo Logs
                    //Logs obj = new Logs();
                    //obj.GenraLogs();


                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }

        public static Producto Obtener(int idcliente)
        {
             Producto oListaUsuario = new Producto();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idcliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                TipoProducto = dr["TipoProducto"].ToString(),
                                CodigoUnico = dr["CodigoUnico"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Activo = dr["Activo"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                Valor = dr["Valor"].ToString(),

                            };
                        }

                    }



                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    estado.valerror = ex.Message;
                    // Validamos el estado de la ejecucion
                    estado.valestado = false;
                    // Llamamos al Metodo Logs
                    Logs obj = new Logs();
                    obj.GenraLogs();
                    return oListaUsuario;
                }
            }
        }
        

        

    }
}