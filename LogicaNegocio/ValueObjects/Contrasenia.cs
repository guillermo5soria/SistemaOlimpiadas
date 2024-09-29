using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Contrasenia : IEquatable<Contrasenia>
    {
        public string Valor { get; private set; }

        public Contrasenia(string pass)
        {
            Valor = pass;
            Validar();
        }
        protected Contrasenia()
        {
        }

        private void Validar()
        {
            //VALIDACIÓN SIMPLE PARA EL EJEMPLO...
            if (Valor == null || Valor.Length < 8)
            {
                throw new UsuarioInvalidoException("La contraseña debe tener al menos 8 caracteres");
            }
        }

        public bool Equals(Contrasenia? other)
        {
            if (other != null)
            {
                return Valor.Equals(other.Valor);
            }

            return false;
        }
    }
}
