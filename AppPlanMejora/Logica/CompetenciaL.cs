using AppPlanMejora.Datos;
using AppPlanMejora.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class CompetenciaL
    {
        private CompetenciaD _competenciaD = new CompetenciaD();

        public List<Competencia> ListarCompetencias()
        {
            return _competenciaD.ListarCompetencias();
        }

        public bool Registrar(Competencia c)
        {
            // Validaciones básicas de negocio
            if (string.IsNullOrWhiteSpace(c.CodigoCompetencia))
                throw new System.ArgumentException("El código de la competencia es obligatorio.");

            if (string.IsNullOrWhiteSpace(c.Denominacion))
                throw new System.ArgumentException("La denominación no puede estar vacía.");

            return _competenciaD.RegistrarCompetencia(c);
        }
    }
}