using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class Vendedor
    {
        public int Cpf { get; set; }
        public String Nome { get; set; }
        public String Cargo { get; set; }
        public String Email { get; set; }
        public int Celular { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public Vendedor()
        {

        }

        public Vendedor(int cpf, string nome, string cargo, string email, int celular)
        {
            Cpf = cpf;
            Nome = nome;
            Cargo = cargo;
            Email = email;
            Celular = celular;
        }
    }
}
