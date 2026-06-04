using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class ProgramasL
    {
        private ProgramaD _programaD = new ProgramaD();

        public List<Programa> Listar()
        {
            return _programaD.ListarProgramas();
        }

        public bool Registrar(Programa prog)
        {
            // Validaciones requeridas
            if (string.IsNullOrWhiteSpace(prog.CodigoPrograma))
                throw new ArgumentException("El código del programa no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(prog.NombrePrograma))
                throw new ArgumentException("El nombre del programa es obligatorio.");

            if (prog.Duracion <= 0)
                throw new ArgumentException("La duración del programa debe ser mayor a 0 meses.");

            return _programaD.RegistrarPrograma(prog);
        }

        public bool Modificar(Programa prog)
        {
            if (prog.Id <= 0)
                throw new ArgumentException("ID de programa no válido.");

            if (string.IsNullOrWhiteSpace(prog.NombrePrograma))
                throw new ArgumentException("El nombre no puede quedar vacío al modificar.");

            return _programaD.ModificarPrograma(prog);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID no válido para eliminación.");

            return _programaD.EliminarPrograma(id);
        }
    }
}