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
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _repo.GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public IActionResult Editar(ProdutoModel produto)
        {
            // 'ModelState.IsValid' verifica se os dados enviados pelo formulario correspondem as regras de validação que definimos no ProdutoModel usando "Data annotarions" (como [Requided] e [Range])
            if (ModelState.IsValid)
            {
                // se os dados for valido, chama o método do repositorio para atualizar o produto no banco de dados
                bool sucesso = _repo.UpdateProduto(produto);

                if (sucesso)
                {
                    // se a atualização for bem-sucedida, redireciona para apágina de detalhes do produto
                    //'RedirectToAction' evita o problema de re-submit do formulario

                    return RedirectToAction("Detalhes", new { id = produto.Id });
                }

                // se a atualização falhou (por exemplo, um erro de banco de dados), adiciona um mensagem de erro ao 'ModelState' para que seja exibida ne view
                ModelState.AddModelError("", "Ocorreu um erro ao salvar as alterações");
            }
            return View(produto);

        }
    }
}