using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioRoles : IRepositorio<Rol>
    {
        public void Add(Rol obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> FindAll()
        {
            throw new NotImplementedException();
        }

        public Rol FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol obj)
        {
            throw new NotImplementedException();
        }
    }
}
