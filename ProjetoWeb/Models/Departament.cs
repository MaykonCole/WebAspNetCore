using System;
using System.Collections.Generic;


namespace ProjetoWeb.Models
{
    public class Departament
    {
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
    }
}
