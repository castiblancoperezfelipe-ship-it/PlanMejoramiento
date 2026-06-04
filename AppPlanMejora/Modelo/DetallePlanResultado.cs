using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Modelo
{
    public class DetallePlanResultado
    {
        public int IdPlan { get; set; }
        public int IdResultado { get; set; }
        public string CodigoRAP { get; set; }
        public string DescripcionRAP { get; set; }
    }
}