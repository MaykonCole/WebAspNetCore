using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWeb.Models;
using ProjetoWeb.Models.Enums;

namespace ProjetoWeb.Data
{
    public class SeedingService
    {
        private readonly ProjetoWebContext _context;
        
        // Injeção de Dependência
        public SeedingService(ProjetoWebContext context)
        {
            _context = context;
        }

        public void Enviar ()
        {
            // Avalia se já existe dados no banco, se sim não faz nada
            if (_context.Departament.Any() || 
                _context.Vendedor.Any() ||
                _context.Pedido.Any())
            {
                return; 
            }

            Departament d1 = new Departament(1, "Artes Gráficas");
            Departament d2 = new Departament(2, "Atendimento");
            Departament d3 = new Departament(3, "Malharia");
            Departament d4 = new Departament(4, "Administrativo");
            Departament d5 = new Departament(5, "Servicos Gerais");

            Vendedor v1 = new Vendedor(123, "Isabela", "Designer Gráfico", "bel@hotmail.com", 983602916, d1);
            Vendedor v2 = new Vendedor(456, "Camila", "Recepcionista", "camila@hotmail.com", 97654357, d2);
            Vendedor v3 = new Vendedor(789, "Joel", "Recortisa", "joel@hotmail.com", 97314357, d3);
            Vendedor v4 = new Vendedor(342, "Jether", "Gerente", "jether@hotmail.com", 97114357, d4);
            Vendedor v5 = new Vendedor(457, "Fabricio", "Estoquista", "fabricio@hotmail.com", 94454357, d5);

            Pedido p1 = new Pedido(1, new DateTime(2018, 10, 25), new DateTime(2018, 10, 30), 500.0, v1, StatusPedido.Finalizado, d1);
            Pedido p2 = new Pedido(2, new DateTime(2018, 11, 05), new DateTime(2018, 11, 12), 700.0, v1, StatusPedido.Finalizado, d1);
            Pedido p3 = new Pedido(3, new DateTime(2018, 11, 15), new DateTime(2018, 12, 01), 200.0, v1, StatusPedido.Finalizado, d1);
            Pedido p4 = new Pedido(4, new DateTime(2019, 01, 15), new DateTime(2019, 01, 30), 300.0, v2, StatusPedido.Finalizado, d2);
            Pedido p5 = new Pedido(5, new DateTime(2019, 01, 18), new DateTime(2019, 01, 31), 200.0, v2, StatusPedido.Finalizado, d2);
            Pedido p6 = new Pedido(6, new DateTime(2019, 02, 11), new DateTime(2019, 02, 18), 300.0, v2, StatusPedido.Finalizado, d2);
            Pedido p7 = new Pedido(7, new DateTime(2019, 02, 15), new DateTime(2019, 02, 27), 1300.0, v4, StatusPedido.Finalizado, d3);
            Pedido p8 = new Pedido(8, new DateTime(2019, 03, 15), new DateTime(2019, 03, 30), 100.0, v5, StatusPedido.Finalizado, d3);

            // Adicionar dados ao BD
            _context.AddRange(d1, d2, d3, d4, d5);
            _context.AddRange(v1, v2, v3, v4, v5);
            _context.AddRange(p1, p2, p3, p4, p5, p6, p7, p8);

            _context.SaveChanges();


        }

    }
}
