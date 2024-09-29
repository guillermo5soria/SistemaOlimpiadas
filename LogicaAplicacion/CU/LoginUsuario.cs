using DTO.Mappers;
using DTO.Objetos;
using LogicaAplicacion.ICU;
using LogicaDatos.Repositorios;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }

        public LoginUsuario(IRepositorioUsuarios repo)
        {
            RepoUsuarios = repo;
        }

        public ListadoUsuariosDTO Login(string email, string password)
        {
            Usuario usu = RepositorioUsuarios.Login(email, password);
            return UsuariosMapper.ToDTO(usu);
        }
    }
}
