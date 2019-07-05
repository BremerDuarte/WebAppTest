using System.Collections.Generic;
using WebAppTest.Models.Pessoas;
using WebAppTest.Repositories.PessoaRepository;

namespace WebAppTest.Services.Pessoas
{
	public class FindAllPessoa
	{
		public IEnumerable<Pessoa> Result()
		{
			var repository = new PessoaRepository();
			var pessoas = repository.FindAll();
			return pessoas;
		}
	}
}
