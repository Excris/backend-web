using Microsoft.Data.SqlClient;
using lojabanco.Models;
using System.Collections.Generic;
// using System.Reflection.Metadata.Ecma335; // Esta linha não é necessária e pode ser removida

namespace lojabanco.Data
{
    public class ProdutoRepository
    {
        // private string connectionString = "Server=DESKTOP-VCBMM31;Database=LojaMvc;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true";
        // Conexão SQL SENACSP 
        private string connectionString = "Server=TIT0577572W11-1\\SQLEXPRESS;Database=LojaMvc;TrustServerCertificate=true;Trusted_Connection=true;MultipleActiveResultSets=true";

        // --- MÉTODO GetProdutos CORRIGIDO ---
        public List<ProdutoModel> GetProdutos()
        {
            var produtos = new List<ProdutoModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // A ordem no SELECT deve corresponder à ordem da leitura abaixo
                var command = new SqlCommand("SELECT Id, Nome, Descricao, Preco FROM Produtos", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new ProdutoModel
                        {
                            // Coluna 0 = Id
                            Id = reader.GetInt32(0),
                            // Coluna 1 = Nome
                            Nome = reader.GetString(1),
                            // Coluna 2 = Descricao
                            Descricao = reader.GetString(2),
                            // Coluna 3 = Preco
                            Preco = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return produtos;
        }

        // --- MÉTODO GetProduto CORRIGIDO ---
        public ProdutoModel? GetProduto(int id)
        {
            ProdutoModel produto = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Id, Nome, Descricao, Preco FROM Produtos WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // CORREÇÃO: Criar um novo objeto ProdutoModel e preenchê-lo
                        produto = new ProdutoModel
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Descricao = reader.GetString(2),
                            Preco = reader.GetDecimal(3)
                        };
                    }
                }
            }
            return produto;
        }
        public bool UpdateProduto(ProdutoModel produto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Mudando nome da variável para demonstrar que o comportamento é o mesmo
                    string sql = "UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco WHERE Id = @Id";

                    var command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Preco", produto.Preco);
                    command.Parameters.AddWithValue("@Id",produto.Id);

                    // ExecuteNonQuery é usado para comandos que não retorna dados (update, delete e insert)
                    // Ele retorna o número de linha afetadas
                    int linhaAfetadas = command.ExecuteNonQuery();
                    return linhaAfetadas > 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}