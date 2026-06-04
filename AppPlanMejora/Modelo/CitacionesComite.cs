using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Modelo
{
    public class CitacionesComite
    {
        public int Id { get; set; }
        public DateTime FechaComite { get; set; }
        public string Lugar { get; set; }
        public string EstadoComite { get; set; }
        public int? IdPlan { get; set; }
    }
}