using CrudDapperWebApi.Models;
using CrudDapperWebApi.Services.LivroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface) 
        {
            _livroInterface = livroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAllLivros()
        {
            IEnumerable<Livro> livros = await _livroInterface.GetAllLivros();

            if(!livros.Any())
            {
                return NotFound("Nenhum registro localizado.");
            }

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivroById(int id)
        {
            Livro livro = await _livroInterface.GetLivroById(id);

            if(livro == null)
            {
                return NotFound("Registro não encontrado.");
            }

            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Livro>>> CreateLivro(Livro livro)
        {
            IEnumerable<Livro> livros = await _livroInterface.CreateLivro(livro);

            return Ok(livros);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Livro>>> UpdateLivro(Livro livro)
        {
            Livro registro = await _livroInterface.GetLivroById(livro.Id);

            if(registro == null)
            {
                return NotFound("Registro não localizado.");
            }

            IEnumerable<Livro> livros = await _livroInterface.UpdateLivro(livro);

            return Ok(livros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Livro>>> DeleteLivro(int id)
        {
            Livro registro = await _livroInterface.GetLivroById(id);

            if(registro == null)
            {
                return NotFound("Registro não localizado.");
            }

            IEnumerable<Livro> livro = await _livroInterface.DeleteLivro(id);

            return Ok(livro);
        }
    }
}
