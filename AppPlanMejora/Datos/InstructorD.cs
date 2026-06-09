using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class InstructorD
    {
        public List<Instructor> ListarInstructores()
        {
            List<Instructor> lista = new List<Instructor>();
            string query = @"SELECT i.Id, i.Especialidad, i.IdUsuario, u.Nombres, u.Apellidos 
                             FROM Instructor i
                             INNER JOIN Usuarios u ON i.IdUsuario = u.Id";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new Instructor
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Especialidad = dr["Especialidad"].ToString(),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar instructores: " + ex.Message);
                    }
                }
            }
            return lista;
        }
    }
}