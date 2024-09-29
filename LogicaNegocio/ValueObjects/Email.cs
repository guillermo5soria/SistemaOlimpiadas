using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    //ESTA CLASE EMAIL ES UN VALUE OBJECT
    [Owned]
    public class Email : IEquatable<Email>
    {
        //NO TIENE UN IDENTIFICADOR, TIENE UN VALOR (PUEDEN SER VARIOS ATRIBUTOS)
        public string Valor { get; private set; } //ES INMUTABLE

        public Email(string correo) //SOLAMENTE PUEDO SETEAR EL VALOR AL CONSTRUIRLO
        {
            Valor = correo;
            Validar(); //SE AUTOVALIDA
        }

        protected Email() //PARA EF
        {
        }

        private void Validar()
        {
            //Valido solamente que el email tenga una @ para el ejemplo...
            if (Valor != null && !Valor.Contains("@"))
            {
                throw new UsuarioInvalidoException("El email debe contener un @");
            }
        }

        public bool Equals(Email? other)
        {
            if (other != null)
            {
                return this.Valor == other.Valor; //COMPARA ESTADO PORQUE NO TIENE IDENTIDAD
            }

            return false;
        }
    }
}

