using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class UsuarioD
    {
            public Usuario ValidarAcceso(string correo, string contrasena)
            {
                Usuario usuario = null;

                // Consulta parametrizada para evitar inyección SQL
                string query = "SELECT Id, TipoDocumento, NumeroDocumento, Nombres, Apellidos, Correo, IdRol, IdCentroFormacion " +
                               "FROM Usuarios WHERE Correo = @Correo AND Contrasena = @Contrasena";

                // Usamos el método de tu clase ConexionDB mostrado en la captura
                using (SqlConnection con = ConexionDB.MtAbrirConexion())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        try
                        {
                            con.Open();
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    usuario = new Usuario
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        TipoDocumento = dr["TipoDocumento"].ToString(),
                                        NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                        Nombres = dr["Nombres"].ToString(),
                                        Apellidos = dr["Apellidos"].ToString(),
                                        Correo = dr["Correo"].ToString(),
                                        IdRol = dr["IdRol"] != DBNull.Value ? Convert.ToInt32(dr["IdRol"]) : 0,
                                        IdCentroFormacion = dr["IdCentroFormacion"] != DBNull.Value ? Convert.ToInt32(dr["IdCentroFormacion"]) : 0
                                    };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Manejo de excepciones técnico requerido
                            throw new Exception("Error en la consulta de autenticación: " + ex.Message);
                        }
                    }
                }
                return usuario;
            }
    }
}