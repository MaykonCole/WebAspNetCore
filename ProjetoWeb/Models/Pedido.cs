using System;
using System.ComponentModel.DataAnnotations;
using ProjetoWeb.Models.Enums;

//Classe que cria a entidade Pedido

namespace ProjetoWeb.Models
{
    public class Pedido
    {
        // Atributos da Classe
        [Key]
        public int IdPedido { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double Valor { get; set; }
        public Vendedor Funcionario { get; set; }
        public StatusPedido StatusOS { get; set; }
        public Departament Departament { get; set; }

        // Construtor vazio
        public Pedido()
        {

        }

        // Construtor com argumentos
        public Pedido(int idPedido, DateTime dataInicio, DateTime dataFim, double valor, Vendedor funcionario, StatusPedido statusOS, Departament departament)
        {
            IdPedido = idPedido;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Valor = valor;
            Funcionario = funcionario;
            StatusOS = statusOS;
            Departament = departament;
        }
    }

    
}
