// importa a biblioteca para o padrão MVC do ASP.NET Core. Essencial para usar 'Controller' e 'IActionResult'
using Microsoft.AspNetCore.Mvc;
 
// importa o namespace do nosso modelo de dados
using lojabanco.Data;

// importa a ModelProduto
using lojabanco.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Threading.Tasks;
// using System.Runtime.CompilerServices;
// using System.Drawing;

namespace lojabanco.Controllers
{
    public class ProdutosController : Controller
    {
        // Declara uma instancia do nosso repositório de produtos.
        // O '_' no inicio do nome é uma convenção para campos privados.
        private readonly ProdutoRepository _repo;

        // O IWebHostEnvironment é injetado para acessar informações do ambiente,
        // como o caminho da pasta wwwroot, onde salvaremos as imagens.
        private readonly IWebHostEnvironment _webHostEnvironment;
        // O construtor é o ponto de injeção de dependência.
        // O ASP.NET Core cria uma instância de IWebHostEnvironment e a fornece aqui.
        public ProdutosController(IWebHostEnvironment webHostEnvironment)
        {
            _repo = new ProdutoRepository();
            _webHostEnvironment = webHostEnvironment;
        }
        // Ação para listar todos os produtos. Responde a requisições GET para /Produtos/Index.
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
        public async Task<IActionResult> Editar(ProdutoModel produto, IFormFile? imagemFile)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o usuário enviou um novo arquivo de imagem.
                if (imagemFile != null)
                {
                    string pastaDestino = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    if (!Directory.Exists(pastaDestino))
                    {
                        Directory.CreateDirectory(pastaDestino);
                    }
                    string nomeArquivoUnico = Guid.NewGuid().ToString() + "_" + imagemFile.FileName;
                    string caminhoCompletoArquivo = Path.Combine(pastaDestino, nomeArquivoUnico);
                    using (var fileStream = new FileStream(caminhoCompletoArquivo, FileMode.Create))
                    {
                        await imagemFile.CopyToAsync(fileStream);
                    }
                    produto.ImagemUrl = nomeArquivoUnico;
                }
                bool sucesso = _repo.UpdateProduto(produto);
                if (sucesso)
                {
                    return RedirectToAction("Detalhes", new { id = produto.Id });
                }
                ModelState.AddModelError("", "Ocorreu um erro ao salvar as alterações.");
            }
            return View(produto);
        }
        // Ação para deletar um produto. Usa [HttpPost] e [ValidateAntiForgeryToken] para segurança.
        [HttpPost, ActionName("Deleter")]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            bool sucesso = _repo.DeleteProduto(id);

            if (sucesso)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        // Ação para processar os dados do formulário de criação. Responde a requisições POST.
        [HttpPost]
         // formato assincrono ou seja pode ser executado sem bloquear continue executando outras tarefas em processo de produção.
        public async Task<IActionResult> Criar(ProdutoModel produto, IFormFile? imagemFile)
        {
            if (ModelState.IsValid)
            {
                if (imagemFile != null)
                {
                    string pastaDestino = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    if (!Directory.Exists(pastaDestino))
                    {
                        Directory.CreateDirectory(pastaDestino);
                    }
                    string nomeArquivoUnico = Guid.NewGuid().ToString() + "_" + imagemFile.FileName;
                    string caminhoCompletoArquivo = Path.Combine(pastaDestino, nomeArquivoUnico);
                    using (var fileStream = new FileStream
                    (caminhoCompletoArquivo, FileMode.Create))
                    {
                        await imagemFile.CopyToAsync(fileStream);
                    }
                    // Salva o nome do arquivo no modelo para ser persistido no banco de dados.
                    produto.ImagemUrl = nomeArquivoUnico;
                }
                bool sucesso = _repo.CreateProduto(produto);
                if (sucesso)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Ocorreu um erro ao salvar o novo produto.");
            }
            return View(produto);
        }
    }
}