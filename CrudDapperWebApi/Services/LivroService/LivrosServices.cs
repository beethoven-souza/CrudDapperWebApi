using CrudDapperWebApi.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudDapperWebApi.Services.LivroService
{
    public class LivrosServices : ILivroInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public LivrosServices(IConfiguration configuration) 
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Livro>> CreateLivro(Livro livro)
        {
            using (var connection = new SqlConnection(getConnection))
            {
                var sql = "insert into Livros (titulo, autor) values (@titulo, @autor)";
                await connection.ExecuteAsync(sql, livro);
                return await connection.QueryAsync<Livro>("select * from livros");
            }
        }

        public async Task<IEnumerable<Livro>> DeleteLivro(int id)
        {
            using (var connection = new SqlConnection(getConnection))
            {
                var sql = "delete from livros where id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });

                return await connection.QueryAsync<Livro>("select * from livros");
            }
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            using (var connection = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros";
                return await connection.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> GetLivroById(int id)
        {
            using (var connection = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros where id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Livro>(sql, new { Id = id} );
            }
        }

        public async Task<IEnumerable<Livro>> UpdateLivro(Livro livro)
        {
            using (var connection = new SqlConnection(getConnection))
            {
                var sql = "update livros set titulo = @titulo, autor = @autor where id = @id";
                await connection.ExecuteAsync(sql, livro);

                return await connection.QueryAsync<Livro>("select * from livros");
            }
        }
    }
}
