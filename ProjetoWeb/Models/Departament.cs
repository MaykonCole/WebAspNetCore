using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace ProjetoWeb.Models
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departament()
        {

        }

        public Departament(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

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
            return Vendedores.Sum(v => v.TotalVendas(i, f));
        }
    }
}
