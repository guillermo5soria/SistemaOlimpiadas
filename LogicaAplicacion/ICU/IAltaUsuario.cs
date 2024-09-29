using DTO.Objetos;
using LogicaAplicacion.CU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICU
{
    public interface IAltaUsuario
    {
        void Alta(AltaUsuarioDTO nuevo);

    }
}
