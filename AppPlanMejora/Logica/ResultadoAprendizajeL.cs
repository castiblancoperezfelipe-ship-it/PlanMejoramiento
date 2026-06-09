using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class ResultadoAprendizajeL
    {
        private ResultadoAprendizajeD _rapD = new ResultadoAprendizajeD();

        public List<ResultadoAprendizaje> ListarPorCompetencia(int idCompetencia)
        {
            if (idCompetencia <= 0)
                return new List<ResultadoAprendizaje>();

            return _rapD.ListarPorCompetencia(idCompetencia);
        }
    }
}