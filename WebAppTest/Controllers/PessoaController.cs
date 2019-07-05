using Microsoft.AspNetCore.Mvc;
using WebAppTest.Models.Pessoas;
using WebAppTest.Services.Pessoas;

namespace WebAppTest.Controllers
{
	[Route("api/Pessoa")]
	[ApiController]
    public class PessoaController : ControllerBase
	{
		[HttpPost]
		public IActionResult Add([FromBody] Pessoa pessoa)
		{
			var addPessoa = new AddPessoa();
			addPessoa.Result(pessoa);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult FindById(int id)
		{
			var findPessoaById = new FindPessoaById();
			var pessoa = findPessoaById.Result(id);

			return Ok(pessoa);
		}

		[HttpGet]
		public IActionResult FindAll()
		{
			var findAllPessoa = new FindAllPessoa();
			var pessoas = findAllPessoa.Result();

			return Ok(pessoas);
		}		

		[HttpDelete("{id}")]
		public IActionResult Remove(int id)
		{
			var removePessoa = new RemovePessoa();
			removePessoa.Result(id);

			return Ok();
		}

		[HttpPut]
		public IActionResult Update([FromBody] Pessoa pessoa)
		{
			var updatePessoa = new UpdatePessoa();
			updatePessoa.Result(pessoa);

			return Ok();
		}
	}
}