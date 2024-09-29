using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Objetos
{
    public class ListadoUsuariosDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        [Display(Name = "Rol")]
        public string Rol { get; set; }
    }
}
