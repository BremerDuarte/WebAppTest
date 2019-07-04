using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebAppTest.Models.Pessoas;

namespace WebAppTest.Repositories.PessoaRepository
{
	public class PessoaRepository : IPessoaRepository		
	{
		private string connectionString = @"Data Source=BREMER-PC\LOCALDB;Initial Catalog=WebAPITest;Integrated Security=True;";

		public void Add(Pessoa pessoa)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				var query = @"INSERT INTO
					 		         Pessoas(nome, sobrenome, idade, sexo, email)
							         VALUES(@nome, @sobrenome, @idade, @sexo, @email)";

				var cmd = new SqlCommand(query, conn);
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.AddWithValue("nome", pessoa.Nome);
				cmd.Parameters.AddWithValue("sobrenome", pessoa.Sobrenome);
				cmd.Parameters.AddWithValue("idade", pessoa.Idade);
				cmd.Parameters.AddWithValue("sexo", pessoa.Sexo);
				cmd.Parameters.AddWithValue("email", pessoa.Email);

				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
				} catch (Exception e)
				{
					throw e;
				} finally
				{
					conn.Close();
				}
			}
		}

		public Pessoa Find(int id)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				var query = @"SELECT * 
								     FROM Pessoas 
                                     WHERE id = @ID";
				var cmd = new SqlCommand(query, conn);
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.AddWithValue("ID", id);
				var pessoa = new Pessoa();

				try
				{
					conn.Open();
					var result = cmd.ExecuteReader();
					
					while (result.Read())
					{
						pessoa.Id = Convert.ToInt32(result["id"]);
						pessoa.Nome = result["nome"].ToString();
						pessoa.Sobrenome = result["sobrenome"].ToString();
						pessoa.Email = result["email"].ToString();
						pessoa.Sexo = result["sexo"].ToString();
						pessoa.Idade = Convert.ToInt32(result["idade"]);
					}
				} catch (Exception e)
				{
					throw e;
				} finally
				{
					conn.Close();
				}

				return pessoa;
			}
		}

		public IEnumerable<Pessoa> FindAll()
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				var query = @"SELECT * 
								     FROM Pessoas";
				var cmd = new SqlCommand(query, conn);
				cmd.CommandType = CommandType.Text;
				
				var pessoas = new List<Pessoa>();

				try
				{
					conn.Open();
					var result = cmd.ExecuteReader();

					while (result.Read())
					{
						var pessoa = new Pessoa
						{
							Id = Convert.ToInt32(result["id"]),
							Nome = result["nome"].ToString(),
							Sobrenome = result["sobrenome"].ToString(),
							Email = result["email"].ToString(),
							Sexo = result["sexo"].ToString(),
							Idade = Convert.ToInt32(result["idade"])
						};

						pessoas.Add(pessoa);
					}
				}
				catch (Exception e)
				{
					throw e;
				}
				finally
				{
					conn.Close();
				}

				return pessoas;
			}
		}

		public void Remove(int id)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				var query = @"DELETE
								     FROM Pessoas
									 WHERE id = @ID";

				var cmd = new SqlCommand(query, conn);
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.AddWithValue("ID", id);

				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					throw e;
				}
				finally
				{
					conn.Close();
				}
			}
		}

		public void Update(Pessoa pessoa)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				var query = @"UPDATE Pessoas
								     SET nome = @NOME, sobrenome = @SOBRENOME, email = @EMAIL, idade = @IDADE, sexo = @SEXO
									 WHERE id = @ID";

				var cmd = new SqlCommand(query, conn);
				cmd.CommandType = CommandType.Text;

				cmd.Parameters.AddWithValue("NOME", pessoa.Nome);
				cmd.Parameters.AddWithValue("SOBRENOME", pessoa.Sobrenome);
				cmd.Parameters.AddWithValue("IDADE", pessoa.Idade);
				cmd.Parameters.AddWithValue("SEXO", pessoa.Sexo);
				cmd.Parameters.AddWithValue("EMAIL", pessoa.Email);
				cmd.Parameters.AddWithValue("ID", pessoa.Id);

				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					throw e;
				}
				finally
				{
					conn.Close();
				}
			}
		}
	}
}
