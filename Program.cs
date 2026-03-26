using AulaPOO.Models;
using AulaPOO.Services;

var biblioteca = new BibliotecaService();

var livro1 = new Livro("Clean Code", "Robert C. Martin", "9780132350884", 2008, 464);
var livro2 = new Livro("Domain-Driven Design", "Eric Evans", "9780321125217", 2003, 560);
var livro3 = new Livro("Clean Architecture", "Robert C. Martin", "9780134494166", 2017, 432);

var usuario1 = new Usuario("Ana", 24, "ana@email.com");
var usuarioPremium = new UsuarioPremium("Bruno", 31, "bruno@email.com", 0.15m);

biblioteca.AdicionarLivro(livro1);
biblioteca.AdicionarLivro(livro2);
biblioteca.AdicionarLivro(livro3);
biblioteca.AdicionarUsuario(usuario1);
biblioteca.AdicionarUsuario(usuarioPremium);

Console.WriteLine("\n=== TESTE DE VALIDACAO DE DATA DE DEVOLUCAO ===");
biblioteca.RealizarEmprestimo("9780321125217", "Bruno", DateTime.Today);

Console.WriteLine("\n=== EMPRESTIMO E DEVOLUCAO COM MULTA ===");
biblioteca.RealizarEmprestimo("9780132350884", "Ana", DateTime.Today.AddDays(7));
biblioteca.RealizarDevolucao("9780132350884", "Ana", DateTime.Today.AddDays(10));

Console.WriteLine("\n=== BUSCA DE LIVROS POR AUTOR ===");
var livrosDoRobert = biblioteca.BuscarLivrosPorAutor("Robert C. Martin");
foreach (var livro in livrosDoRobert)
{
	Console.WriteLine($"- {livro.Titulo} ({livro.Autor})");
}

Console.WriteLine("\n=== TESTE DE ITENS EMPRESTAVEIS (REVISTA E DVD) ===");
var revista = new Revista("InfoTech", 42, 2026);
var dvd = new Dvd("Interestelar", "Christopher Nolan", 169);

revista.Emprestar(usuarioPremium);
revista.ExibirInformacoes();
revista.Devolver(usuarioPremium);

dvd.Emprestar(usuario1);
dvd.ExibirInformacoes();
dvd.Devolver(usuario1);

biblioteca.ListarTodosLivros();
biblioteca.ListarUsuarios();
var bibliotecaRelatorio = new BibliotecaRelatorio(biblioteca);
bibliotecaRelatorio.ExibirResumoEstatistico();