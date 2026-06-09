using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class CompetenciaD
    {
        public List<Competencia> ListarCompetencias()
        {
            List<Competencia> lista = new List<Competencia>();
            string query = "SELECT Id, CodigoCompetencia, Denominacion, IdPrograma FROM Competencia";

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
                                lista.Add(new Competencia
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    CodigoCompetencia = dr["CodigoCompetencia"].ToString(),
                                    Denominacion = dr["Denominacion"].ToString(),
                                    IdPrograma = dr["IdPrograma"] != DBNull.Value ? Convert.ToInt32(dr["IdPrograma"]) : 0
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error datos competencia: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        public bool RegistrarCompetencia(Competencia c)
        {
            string query = "INSERT INTO Competencia (CodigoCompetencia, Denominacion, IdPrograma) VALUES (@Cod, @Den, @Prog)";
            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cod", c.CodigoCompetencia);
                    cmd.Parameters.AddWithValue("@Den", c.Denominacion);
                    cmd.Parameters.AddWithValue("@Prog", c.IdPrograma > 0 ? (object)c.IdPrograma : DBNull.Value);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}