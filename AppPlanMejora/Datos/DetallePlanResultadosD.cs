using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class DetallePlanResultadosD
    {
        public bool RegistrarResultadoAsociadoAPlan(int idPlan, int idResultado)
        {
            string query = "INSERT INTO DetallePlanResultados (IdPlan, IdResultado) VALUES (@IdPlan, @IdRes)";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdPlan", idPlan);
                    cmd.Parameters.AddWithValue("@IdRes", idResultado);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al asociar resultado al plan: " + ex.Message);
                    }
                }
            }
        }
    }
}