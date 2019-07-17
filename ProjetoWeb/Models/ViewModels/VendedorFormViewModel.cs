using System;
using System.Collections.Generic;
using ProjetoWeb.Models;


namespace ProjetoWeb.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        // Precisa de um vendedor
        public Vendedor Vendedor { get; set; }
        // Lista de Departamentos
        public ICollection<Departament> Departaments { get; set; }
    }
}
