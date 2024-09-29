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
    public class BuscarRolPorId : IBuscarRolPorId
    {
        public IRepositorioRoles Repo { get; set; }

        public BuscarRolPorId(IRepositorioRoles repo)
        {
            Repo = repo;
        }

        public RolDTO Buscar(int id)
        {
            return RolesMapper.ToDTO(Repo.FindById(id));
        }
    }
}
