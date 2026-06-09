using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class ActividadesPlanD
    {
        public List<ActividadesPlan> ListarActividadesPorPlan(int idPlan)
        {
            List<ActividadesPlan> lista = new List<ActividadesPlan>();
            string query = "SELECT Id, DescripcionActividad, EstadoActividad, IdPlan FROM ActividadesPlan WHERE IdPlan = @IdPlan";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdPlan", idPlan);
                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new ActividadesPlan
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    DescripcionActividad = dr["DescripcionActividad"].ToString(),
                                    EstadoActividad = dr["EstadoActividad"].ToString(),
                                    IdPlan = dr["IdPlan"] != DBNull.Value ? Convert.ToInt32(dr["IdPlan"]) : 0
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error datos actividades del plan: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        public bool RegistrarActividad(ActividadesPlan act)
        {
            string query = "INSERT INTO ActividadesPlan (DescripcionActividad, IdPlan) VALUES (@Desc, @IdPlan)";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Desc", act.DescripcionActividad);
                    cmd.Parameters.AddWithValue("@IdPlan", act.IdPlan > 0 ? (object)act.IdPlan : DBNull.Value);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar actividad: " + ex.Message);
                    }
                }
            }
        }
    }
}