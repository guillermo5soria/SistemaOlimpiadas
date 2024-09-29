using DTO.Mappers;
using DTO.Objetos;
using LogicaAplicacion.ICU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class ListadoRoles : IListadoRoles
    {
        public IRepositorioRoles Repo { get; set; }

        public ListadoRoles(IRepositorioRoles repo)
        {
            Repo = repo;
        }
        public IEnumerable<RolDTO> ObtenerListado()
        {
            return RolesMapper.ToListaDTO(Repo.FindAll());
        }
    }
}
