using WebAppTest.Models.Pessoas;
using WebAppTest.Repositories.PessoaRepository;

namespace WebAppTest.Services.Pessoas
{
	public class FindPessoaById
	{

		public Pessoa Result(int id)
		{
			var repository = new PessoaRepository();
			var pessoa = repository.Find(id);
			return pessoa;
		}
	}
}
