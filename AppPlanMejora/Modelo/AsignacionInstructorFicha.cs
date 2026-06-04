using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Modelo
{
    public class AsignacionInstructorFicha
    {
        public int IdInstructor { get; set; }
        public int IdFicha { get; set; }
        public string NombreInstructor { get; set; }
        public string NumeroFicha { get; set; }
    }
}