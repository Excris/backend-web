// importando a bibilioteca 'System.ComponentModel. DataAnnotations'
// Esta Biblioteca Fornece atributos que permite adicionar regras de validações e metadados de exibição (Como nome de campos) às propriedade da classe

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace lojabanco.Models
{
    // ProdutoMOdel serve como a 'ponte' entre a aplicação e a banoc de dados
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public decimal Preco { get; set; }

    }
 }