using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task<Vendedor> FindByIdAsync(int cpf)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Cpf == cpf);
        }
    }
}
