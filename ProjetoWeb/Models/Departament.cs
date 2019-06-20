using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

//Classe que cria a entidade Departament
namespace ProjetoWeb.Models
{
    public class Departament
    {
        // Atributos da Classe
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        // Construtor vazio
        public Departament()
        {

        }

        // Construtor com argumentos
        public Departament(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Classes personalizadas
        public void AdcionarVendedor(Vendedor v)
        {
            Vendedores.Add(v);
        }

        public void RemoveVendedor(Vendedor v)
        {
            Vendedores.Remove(v);
        }

        public double VendasDepartamento (DateTime i, DateTime f)
        {
            // Expressao LINQ que retorna a quantidadade de vendas de um Departamento em um periodo especifico
            return Vendedores.Sum(v => v.TotalVendas(i, f));
        }
    }
}
