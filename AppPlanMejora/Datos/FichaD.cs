using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class FichaD
    {
        public List<Ficha> ListarFichas()
        {
            List<Ficha> lista = new List<Ficha>();
            // Usamos un JOIN para traer el nombre del programa y no solo el ID
            string query = @"SELECT f.*, p.NombrePrograma 
                             FROM Ficha f 
                             INNER JOIN Programa p ON f.IdPrograma = p.Id";

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
                                lista.Add(new Ficha
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    NumeroFicha = dr["NumeroFicha"].ToString(),
                                    Jornada = dr["Jornada"].ToString(),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                                    FechaFinalizacion = Convert.ToDateTime(dr["FechaFinalizacion"]),
                                    Estado = dr["Estado"].ToString(),
                                    IdPrograma = Convert.ToInt32(dr["IdPrograma"])
                                    // Podrías agregar una propiedad 'NombrePrograma' en tu modelo Ficha para mostrarlo
                                });
                            }
                        }
                    }
                    catch (Exception ex) { throw new Exception("Error datos ficha: " + ex.Message); }
                }
            }
            return lista;
        }

        public bool RegistrarFicha(Ficha f)
        {
            string query = @"INSERT INTO Ficha (NumeroFicha, Jornada, FechaInicio, FechaFinalizacion, Descripcion, Estado, IdPrograma) 
                             VALUES (@Num, @Jor, @Ini, @Fin, @Des, @Est, @Prog)";
            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Num", f.NumeroFicha);
                    cmd.Parameters.AddWithValue("@Jor", f.Jornada);
                    cmd.Parameters.AddWithValue("@Ini", f.FechaInicio);
                    cmd.Parameters.AddWithValue("@Fin", f.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("@Des", f.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@Est", f.Estado);
                    cmd.Parameters.AddWithValue("@Prog", f.IdPrograma);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}