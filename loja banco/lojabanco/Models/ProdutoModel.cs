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

        [Display(nameof = "Nome")]
        [Required(ErrorMessage = "O campo NOme é obrigaroeio.")]

        // SEU CÓDIGO ATUAL (provavelmente):
        // public string Nome { get; set; } = null!;
        // public string Descricao { get; set; } = null!;

        // O CÓDIGO CORRIGIDO (o que você precisa fazer):
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public decimal Preco { get; set; }
    }
 }