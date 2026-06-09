using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class EvaluacionesD
    {
        public bool RegistrarEvaluacionFinal(Evaluacion e)
        {
            string query = @"INSERT INTO Evaluaciones (EvalProducto, EvalConocimiento, EvalDesempeño, FechaEvaluacion, IdPlan) 
                             VALUES (@Prod, @Conoc, @Desemp, @Fecha, @IdPlan)";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Prod", e.EvalProducto ?? "No Aprueba");
                    cmd.Parameters.AddWithValue("@Conoc", e.EvalConocimiento ?? "No Aprueba");
                    cmd.Parameters.AddWithValue("@Desemp", e.EvalDesempeño ?? "No Aprueba");
                    cmd.Parameters.AddWithValue("@Fecha", e.FechaEvaluacion == DateTime.MinValue ? DateTime.Now : e.FechaEvaluacion);
                    cmd.Parameters.AddWithValue("@IdPlan", e.IdPlan);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar la evaluación: " + ex.Message);
                    }
                }
            }
        }
    }
}