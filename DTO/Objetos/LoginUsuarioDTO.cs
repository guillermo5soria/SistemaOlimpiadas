using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Objetos
{
    public class LoginUsuarioDTO
    {
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
    }
}
