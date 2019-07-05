using WebAppTest.Repositories.PessoaRepository;

namespace WebAppTest.Services.Pessoas
{
	public class RemovePessoa
	{

		public void Result(int id)
		{
			var repository = new PessoaRepository();
			repository.Remove(id);
		}
	}
}
