// Importa a Biblioteca para o padrão MVC do ASP.NET Core. Essencial para usar 'Controller' e 'IActionResult'
using Microsoft.AspNetCore.Mvc;
// pasta de criação Importa o namespace do nosso modelo de dados
using lojabanco.Data;

// Importa a MOdelProduto
using lojabanco.Models;

namespace lojabanco.Controllers
{
    public class ProdutosController : Controller
    {
        //ProdutoRepository estamos estanciando os valores dentro o ProdutoRepository
        private ProdutoRepository _repo = new ProdutoRepository();
        public IActionResult Index()
        {
            var produtos = _repo.GetProdutos;
            return View(produtos);
            
        }
    }
}