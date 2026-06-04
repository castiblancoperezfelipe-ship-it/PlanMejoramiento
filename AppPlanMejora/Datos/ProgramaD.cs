using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Datos
{
    public class ProgramaD
    {
        public List<Programa> ListarProgramas()
        {
            List<Programa> lista = new List<Programa>();
            string query = "SELECT Id, CodigoPrograma, NombrePrograma, Version, NivelFormacion, Duracion, Estado FROM Programa";

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
                                lista.Add(new Programa
                                {
                                    Id = Convert.ToInt32(dr["Id"]),
                                    CodigoPrograma = dr["CodigoPrograma"].ToString(),
                                    NombrePrograma = dr["NombrePrograma"].ToString(),
                                    Version = dr["Version"].ToString(),
                                    NivelFormacion = dr["NivelFormacion"].ToString(),
                                    Duracion = Convert.ToInt32(dr["Duracion"]),
                                    Estado = dr["Estado"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error técnico al listar programas: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        // 2. REGISTRAR PROGRAMA
        public bool RegistrarPrograma(Programa prog)
        {
            string query = "INSERT INTO Programa (CodigoPrograma, NombrePrograma, Version, NivelFormacion, Duracion, Estado) " +
                           "VALUES (@Codigo, @Nombre, @Version, @Nivel, @Duracion, @Estado)";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", prog.CodigoPrograma);
                    cmd.Parameters.AddWithValue("@Nombre", prog.NombrePrograma);
                    cmd.Parameters.AddWithValue("@Version", prog.Version);
                    cmd.Parameters.AddWithValue("@Nivel", prog.NivelFormacion);
                    cmd.Parameters.AddWithValue("@Duracion", prog.Duracion);
                    cmd.Parameters.AddWithValue("@Estado", string.IsNullOrEmpty(prog.Estado) ? "Activo" : prog.Estado);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error técnico al registrar: " + ex.Message);
                    }
                }
            }
        }

        // 3. MODIFICAR PROGRAMA
        public bool ModificarPrograma(Programa prog)
        {
            string query = "UPDATE Programa SET CodigoPrograma = @Codigo, NombrePrograma = @Nombre, Version = @Version, " +
                           "NivelFormacion = @Nivel, Duracion = @Duracion, Estado = @Estado WHERE Id = @Id";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", prog.Id);
                    cmd.Parameters.AddWithValue("@Codigo", prog.CodigoPrograma);
                    cmd.Parameters.AddWithValue("@Nombre", prog.NombrePrograma);
                    cmd.Parameters.AddWithValue("@Version", prog.Version);
                    cmd.Parameters.AddWithValue("@Nivel", prog.NivelFormacion);
                    cmd.Parameters.AddWithValue("@Duracion", prog.Duracion);
                    cmd.Parameters.AddWithValue("@Estado", prog.Estado);

                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error técnico al modificar: " + ex.Message);
                    }
                }
            }
        }

        // 4. ELIMINAR PROGRAMA
        public bool EliminarPrograma(int id)
        {
            string query = "DELETE FROM Programa WHERE Id = @Id";

            using (SqlConnection con = ConexionDB.MtAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("No se puede eliminar. El programa está asociado a fichas o competencias activas. " + ex.Message);
                    }
                }
            }
        }
    }
}