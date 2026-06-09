using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class PlanMejoramientoD
    {
        public List<PlanMejoramiento> ListarPlanes() // Asegúrate si se llama PlanMejoramiento o PlanesMejoramiento
        {
            List<PlanMejoramiento> lista = new List<PlanMejoramiento>();
            string query = "SELECT Id, TipoPlan, FechaAsignacion, FechaLimite, Observaciones, EstadoPlan, IdAprendiz, IdInstructor, IdPlanOrigen FROM PlanesMejoramiento";

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
                                PlanMejoramiento plan = new PlanMejoramiento();

                                plan.Id = Convert.ToInt32(dr["Id"]);
                                plan.TipoPlan = dr["TipoPlan"].ToString();
                                plan.FechaAsignacion = dr["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaAsignacion"]) : DateTime.Now;
                                plan.FechaLimite = Convert.ToDateTime(dr["FechaLimite"]);
                                plan.Observaciones = dr["Observaciones"].ToString();
                                plan.EstadoPlan = dr["EstadoPlan"].ToString();
                                plan.IdAprendiz = dr["IdAprendiz"] != DBNull.Value ? Convert.ToInt32(dr["IdAprendiz"]) : 0;
                                plan.IdInstructor = dr["IdInstructor"] != DBNull.Value ? Convert.ToInt32(dr["IdInstructor"]) : 0;
                                plan.IdPlanOrigen = dr["IdPlanOrigen"] != DBNull.Value ? Convert.ToInt32(dr["IdPlanOrigen"]) : 0;

                                lista.Add(plan);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error datos listar planes: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        public bool RegistrarPlan(PlanMejoramiento p)
        {
            string query = @"INSERT INTO PlanesMejoramiento (TipoPlan, FechaLimite, Observaciones, IdAprendiz, IdInstructor) 
                             VALUES (@Tipo, @Limite, @Obs, @Apren, @Inst)";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", p.TipoPlan ?? "Interno");
                    cmd.Parameters.AddWithValue("@Limite", p.FechaLimite);
                    cmd.Parameters.AddWithValue("@Obs", p.Observaciones ?? "");
                    cmd.Parameters.AddWithValue("@Apren", p.IdAprendiz > 0 ? (object)p.IdAprendiz : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Inst", p.IdInstructor > 0 ? (object)p.IdInstructor : DBNull.Value);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar plan: " + ex.Message);
                    }
                }
            }
        }
    }
}