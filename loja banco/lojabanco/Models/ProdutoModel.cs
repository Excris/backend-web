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

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public string? ImagemUrl { get; set;}
    }
 }