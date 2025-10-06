// importa a biblioteca para o padrão MVC do ASP.NET Core. Essencial para usar 'Controller' e 'IActionResult'
using Microsoft.AspNetCore.Mvc;
 
// importa o namespace do nosso modelo de dados
using lojabanco.Data;
 
// importa a ModelProduto
using lojabanco.Models;
 
namespace lojabanco.Controllers
{
    public class ProdutosController : Controller
    {
        // Declara uma instancia do nosso repositório de produtos.
        // O '_' no inicio do nome é uma convenção para campos privados.
 
        private ProdutoRepository _repo = new ProdutoRepository();
 
        public IActionResult Index()
        {
            var produtos = _repo.GetProdutos();
            return View(produtos);
        }
 
        public IActionResult Detalhes(int id)
        {
            var produto = _repo.GetProduto(id);
 
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
    }
}