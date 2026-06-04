using AppPlanMejora.Modelo;
using AppPlanMejora.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPlanMejora.Logica
{
    public class UsuarioL
    {
        private UsuarioD oUsuarioDatos = new UsuarioD();

        public Usuario AutenticarUsuario(string correo, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo electrónico es un campo requerido.");

            if (string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("La contraseña es un campo requerido.");

            if (!correo.Contains("@"))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            return oUsuarioDatos.ValidarAcceso(correo, contrasena);
        }
    }
}