using DTO.Objetos;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class RolesMapper
    {
        public static RolDTO ToDTO(Rol rol)
        {
            return new RolDTO()
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }

        public static Rol ToRol(RolDTO dto)
        {
            Rol rol = new Rol() { Id = dto.Id, Nombre = dto.Nombre };
            return rol;
        }

        public static IEnumerable<RolDTO> ToListaDTO(IEnumerable<Rol> roles)
        {
            List<RolDTO> dtos = new List<RolDTO>();

            foreach (Rol rol in roles)
            {
                dtos.Add(ToDTO(rol));
            }

            return dtos;

            //return roles.Select(r => ToDTO(r));
        }

    }
}
