using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class EvaluacionesL
    {
        private EvaluacionesD _evaluacionesD = new EvaluacionesD();

        public bool RegistrarEvaluacion(Evaluacion e)
        {
            if (e.IdPlan <= 0)
                throw new System.ArgumentException("La evaluación debe estar vinculada a un plan de mejoramiento.");

            return _evaluacionesD.RegistrarEvaluacionFinal(e);
        }
    }
}