using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class ResultadoAprendizajeD
    {
        public List<ResultadoAprendizaje> ListarPorCompetencia(int idCompetencia)
        {
            List<ResultadoAprendizaje> lista = new List<ResultadoAprendizaje>();
            string query = "SELECT Id, CodigoRAP, Descripcion, IdCompetencia FROM ResultadoAprendizaje WHERE IdCompetencia = @IdComp";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdComp", idCompetencia);
                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new ResultadoAprendizaje
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    CodigoRAP = dr["CodigoRAP"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    IdCompetencia = dr["IdCompetencia"] != DBNull.Value ? Convert.ToInt32(dr["IdCompetencia"]) : 0
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error datos resultado aprendizaje: " + ex.Message);
                    }
                }
            }
            return lista;
        }
    }
}