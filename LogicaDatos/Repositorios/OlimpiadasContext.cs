using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class OlimpiadasContext : DbContext 
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string strCon = "Server=NB-NMORENO\\SQLEXPRESS; Database=SistemaOlimpiadas; Integrated Security=SSPI"; //Cambiar para la base de cada uno 
            optionsBuilder.UseSqlServer(strCon);
        }
    }
}
