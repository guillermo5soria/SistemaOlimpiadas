using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Objetos
{
    public class AltaUsuarioDTO
    {
        [Required(ErrorMessage = "El mail es campo obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [Required(ErrorMessage = "La contraseña es campo obligatorio")]
        public string Contrasenia { get; set; }

        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        public DateTime Creado { get; set; }

        public int IdCreador { get; set; }

    }
}
