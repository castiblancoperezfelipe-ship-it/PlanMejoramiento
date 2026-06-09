using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class AprendizD
    {
        public List<Aprendiz> ListarAprendicesPorFicha(int idFicha)
        {
            List<Aprendiz> lista = new List<Aprendiz>();
            // JOIN para traer el nombre completo desde la tabla Usuarios
            string query = @"SELECT a.Id, a.Estado, a.ImagenUrl, a.IdFicha, a.IdUsuario, 
                                    u.Nombres, u.Apellidos, u.NumeroDocumento
                             FROM Aprendiz a
                             INNER JOIN Usuarios u ON a.IdUsuario = u.Id
                             WHERE a.IdFicha = @IdFicha";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFicha", idFicha);
                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Aprendiz
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Estado = dr["Estado"].ToString(),
                                    ImagenUrl = dr["ImagenUrl"].ToString(),
                                    IdFicha = Convert.ToInt32(dr["IdFicha"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                    // Si agregaste propiedades extendidas en tu modelo Aprendiz, las mapeas aquí:
                                    // NombreCompleto = dr["Nombres"].ToString() + " " + dr["Apellidos"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar aprendices: " + ex.Message);
                    }
                }
            }
            return lista;
        }
    }
}