using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class Vendedor
    {
        [Key]
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

        public void AdicionarPedido(Pedido p)
        {
            Pedidos.Add(p);
        }

        public void RemovePedido (Pedido p )
        {
            Pedidos.Remove(p);
        }
         
        // Calcula o total de vendas de um vendedor de acordo um determinado periodo
        public double TotalVendas (DateTime i, DateTime f)
        {
            return Pedidos.Where(p => p.DataInicio >= i && p.DataFim <= f).Sum(p => p.Valor);
        }
    }
}
