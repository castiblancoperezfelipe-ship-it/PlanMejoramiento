using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class PlanMejoramientoL
    {
        private PlanMejoramientoD _planD = new PlanMejoramientoD();

        public List<PlanMejoramiento> ListarPlanes()
        {
            return _planD.ListarPlanes();
        }

        public bool Registrar(PlanMejoramiento p)
        {
            if (p.IdAprendiz <= 0)
                throw new ArgumentException("Debe seleccionar un aprendiz válido.");

            if (p.IdInstructor <= 0)
                throw new ArgumentException("El plan debe tener un instructor asignado.");

            if (p.FechaLimite <= DateTime.Now)
                throw new ArgumentException("La fecha límite debe ser posterior a la fecha actual.");

            return _planD.RegistrarPlan(p);
        }
    }
}