// Importar bibloteca externar Permite o uso de classes para com o SQL Server
// Sem esta linha, o C# não saberia o que é um 'sqlConnect' ou 'sqlCommand'
using Microsoft.Data.SqlClient;
// Import so ProdutoModel
using lojabanco.Models;
// Permite o uso da coleções genéricas, como a 'List<>', 
using System.Collections.Generic;

namespace lojabanco.Data
{
    public class ProdutoRepository
    {
        private string connectionString = "Server = TIT0577572W11-1\\SQLEXPRESS;Database = LojaMvc;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true";
        public List<ProdutoModel> GetProdutos()
        {
            // Cria uma lista vazia para armazenar o ProdutomModel que serão lidos no banco
            var produtos = new List<ProdutoModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                //abre a conexão com o banco de dados.
                connection.Open();
                var Command = new SqlCommand("SELECT Id, Nome,Preco,Descricao from Produtos", connection);

                using (var reader = Command.ExecuteReader())
                {
                    // loop white executa enquanto houver linhas para ler no resultado da consulta.
                    // 'reader.Read()' move o curso do ponteiro para proxima linha e retorna true se houver uma. 
                    while (reader.Read())
                    {
                        produtos.Add(new ProdutoModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Descricao = reader.GetString(2),
                            Preco = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return produtos;
        }
    }
}