using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoWeb.Models
{
    public class ProjetoWebContext : DbContext
    {
        public ProjetoWebContext (DbContextOptions<ProjetoWebContext> options)
            : base(options)
        {
        }

        // Classes precisam ser Adicionadas no DBContext para serem reconhecidas pelo Entity FrameWork

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }

}
