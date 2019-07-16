using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Services
{
    public class VendedorService
    {

        // Dependencia com o DBContext
        // ReadOnly siginifica que esta dependência não poderá ser alterada
        private readonly ProjetoWebContext _context;

        // Criado o construtor para que a injeção de dependência ocorra
        public VendedorService (ProjetoWebContext c)
        {
            _context = c;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
    }
}
