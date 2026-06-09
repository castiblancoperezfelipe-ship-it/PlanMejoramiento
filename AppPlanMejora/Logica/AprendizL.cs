using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class AprendizL
    {
        private AprendizD _aprendizD = new AprendizD();

        public List<Aprendiz> ListarPorFicha(int idFicha)
        {
            if (idFicha <= 0)
                return new List<Aprendiz>();

            return _aprendizD.ListarAprendicesPorFicha(idFicha);
        }
    }
}