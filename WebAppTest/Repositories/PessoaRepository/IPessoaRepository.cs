using System.Collections.Generic;
using WebAppTest.Models.Pessoas;

namespace WebAppTest.Repositories.PessoaRepository
{
	interface IPessoaRepository
	{
		void Add(Pessoa pessoa);
		Pessoa Find(int id);
		IEnumerable<Pessoa> FindAll();
		void Remove(int id);
		void Update(Pessoa pessoa);
	}
}
