using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Classe que cria a entidade Vendedor

namespace ProjetoWeb.Models
{
    // Atributos da Classe
    public class Vendedor
    {

        
        [Key]
        public int Cpf { get; set; }
        [Display(Name = "Vendedor")]

        [Required (ErrorMessage = "Nome é obrigatório")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} não está dentro do padrão entre {2} e {1} caracteres.")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Cargo é obrigatório")]
        public String Cargo { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Digite um email válido.")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Celular é obrigatório")]
        public int Celular { get; set; }
        
        public Departament Departamento { get; set;}

        public int DepartamentId { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        // Construtor Vazio
        public Vendedor()
        {

        }

        // Construtor com Argumentos
        public Vendedor(int cpf, string nome, string cargo, string email, int celular, Departament dep)
        {
            Cpf = cpf;
            Nome = nome;
            Cargo = cargo;
            Email = email;
            Celular = celular;
            Departamento = dep;
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
