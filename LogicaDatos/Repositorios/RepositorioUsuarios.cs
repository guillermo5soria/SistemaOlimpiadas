using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        public OlimpiadasContext Contexto { get; set; }

        public RepositorioUsuarios(OlimpiadasContext ctx)
        {
            Contexto = ctx;
        }


        public void Add(Usuario obj)
        {
            if (obj != null)
            {
                //obj.Validar();
                //OTRAS VALIDACIONES (POR EJ. QUE NO SE REPITA EL EMAIL)
                Contexto.Usuarios.Add(obj);
                Contexto.SaveChanges();
            }
            else
            {
                //PENDIENTE
            }

        }

        public IEnumerable<Usuario> FindAll()
        {
            //AGREGAMOS EL INCLUDE PARA QUE EF TRAIGA EL OBJETO ROL RELACIONADO CON CADA USUARIO
            //DE LO CONTRARIO NO LO TRAERÍA POR DEFECTO Y SERÍA NULL
            return Contexto.Usuarios.Include(usu => usu.Rol).ToList();
        }

        public Usuario FindById(int id)
        {
            //ESTO TRAERÍA EL USUARIO SIN SU ROL
            //return Contexto.Usuarios.Find(id);

            //ESTA CONSULTA LINQ, TRAE EL USUARIO CON SU ROL
            return Contexto.Usuarios
                    .Include(usu => usu.Rol)
                    .Where(usu => usu.Id == id)
                    .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Usuario buscado = Contexto.Usuarios.Find(id);
            if (buscado != null)
            {
                Contexto.Usuarios.Remove(buscado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioInvalidoException("El usuario con el id " + id + " no existe");
            }
        }

        public void Update(Usuario obj)
        {
            if (obj != null)
            {
                obj.Validar();
                Contexto.Usuarios.Update(obj);
                Contexto.SaveChanges();
            }
            else
            {
                //ERROR
            }
        }
    }
}
