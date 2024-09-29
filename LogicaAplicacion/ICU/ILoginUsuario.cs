using DTO.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICU
{
    public interface ILoginUsuario
    {
        ListadoUsuariosDTO Login(string email, string password);
    }
}
