using WebAppTest.Models.Pessoas;
using WebAppTest.Repositories.PessoaRepository;

namespace WebAppTest.Services.Pessoas
{
	public class AddPessoa
	{

		public void Result(Pessoa pessoa)
		{
			var repository = new PessoaRepository();
			repository.Add(pessoa);
		}
	}
}
