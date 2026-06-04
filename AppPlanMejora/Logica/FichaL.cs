using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class FichaL
    {
        private FichaD _fichaD = new FichaD();

        // Obtener todas las fichas
        public List<Ficha> Listar()
        {
            return _fichaD.ListarFichas();
        }

        // Validar y Guardar
        public bool Guardar(Ficha ficha)
        {
            // VALIDACIONES DE NEGOCIO OBLIGATORIAS
            if (string.IsNullOrWhiteSpace(ficha.NumeroFicha))
                throw new ArgumentException("El número de ficha es un campo obligatorio.");

            if (ficha.IdPrograma <= 0)
                throw new ArgumentException("Debe seleccionar un programa de formación válido.");

            if (string.IsNullOrWhiteSpace(ficha.Jornada))
                throw new ArgumentException("Debe seleccionar una jornada.");

            // Regla lógica: La fecha final no puede ser anterior o igual a la de inicio
            if (ficha.FechaFinalizacion <= ficha.FechaInicio)
                throw new ArgumentException("La fecha de finalización debe ser posterior a la fecha de inicio.");

            // Si pasa todo, la capa de datos procesa el insert
            return _fichaD.RegistrarFicha(ficha);
        }
    }
}