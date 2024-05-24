using CrudDapperWebApi.Models;

namespace CrudDapperWebApi.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int id);
        Task<IEnumerable<Livro>> CreateLivro(Livro livro);
        Task<IEnumerable<Livro>> UpdateLivro(Livro livro);
        Task<IEnumerable<Livro>> DeleteLivro(int id);
       
    }
}
