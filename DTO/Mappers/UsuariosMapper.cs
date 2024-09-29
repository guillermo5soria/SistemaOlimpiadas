using DTO.Objetos;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class UsuariosMapper
    {
        public static ListadoUsuariosDTO ToDTO(Usuario usu)
        {
            //ListadoUsuariosDTO dto = new ListadoUsuariosDTO();
            //dto.Nombre = usu.Nombre;
            //dto.Email = usu.Email;
            //dto.Rol = usu.Rol;

            //ESTO ES LO MISMO QUE LO ANTERIOR
            ListadoUsuariosDTO dto = new ListadoUsuariosDTO()
            {
                Id = usu.Id,
                Email = usu.Email.Valor,
                Rol = usu.Rol.Nombre
            };
            return dto;
        }

        public static IEnumerable<ListadoUsuariosDTO> FromUsuarios(IEnumerable<Usuario> usuarios)
        {
            List<ListadoUsuariosDTO> dtos = new List<ListadoUsuariosDTO>();

            foreach (Usuario usu in usuarios)
            {
                dtos.Add(ToDTO(usu));
            }

            return dtos;
        }

        public static Usuario ToUsuario(AltaUsuarioDTO dto)
        {
            Email mail = new Email(dto.Email);
            Contrasenia pass = new Contrasenia(dto.Contrasenia);
              public DateTime Creado { get; set; }
        public Usuario Creador { get; set; }
        public Rol Rol { get; set; } //Entidad de dominio
        public int IdRol { get; set; }

            return new Usuario(mail, pass, null, dto.Nombre);
        }

        //public static Usuario FromDTO(AltaUsuarioDTO dto)
        //{
        //    if (dto != null)
        //    {
        //        Email mail = new Email(dto.Email);
        //        Contrasenia pass = new Contrasenia(dto.Contrasenia);
        //        Usuario usu = new Usuario(mail, pass, dto.IdRol, DateTime.Today, null);
        //        return usu;
        //    }

        //    return null;
        //}

        //public static ListadoUsuariosDTO FromUsuario(Usuario usu)
        //{
        //    ListadoUsuariosDTO dto = new ListadoUsuariosDTO()
        //    {
        //        Email = usu.Email.Valor,
        //        NombreRol = usu.Rol.Nombre
        //    };

        //    return dto;
        //}


    }
}
