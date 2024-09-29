using LogicaAplicacion.ICU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class EliminarRol : IEliminarRol
    {
        public IRepositorioRoles Repo { get; set; }

        public EliminarRol(IRepositorioRoles repo)
        {
            Repo = repo;
        }
        public void Borrar(int id)
        {
            Repo.Remove(id);
        }
    }
}
