using EscolaEF.Models;
using EscolaEF.Repositories;
using Microsoft.EntityFrameworkCore; 

var repo = new EstudanteRepository();

Console.WriteLine("=== INSERINDO ESTUDANTE ===");
repo.Adicionar(new Estudante { Nome = "João Silva", Idade = 22 });
Console.WriteLine("Inserido com sucesso.\n");

Console.WriteLine("=== LISTANDO ESTUDANTES ===");
foreach (var e in repo.Listar())
    Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");
Console.WriteLine();

Console.WriteLine("=== BUSCANDO POR ID ===");
var encontrado = repo.BuscarPorId(1);
if (encontrado != null)
    Console.WriteLine($"Encontrado: {encontrado.Nome} - {encontrado.Idade} anos");
else
    Console.WriteLine("Não encontrado.");
Console.WriteLine();

Console.WriteLine("=== ATUALIZANDO ===");
repo.Atualizar(new Estudante { Id = 1, Nome = "Maria Oliveira", Idade = 25 });
Console.WriteLine("Atualizado.\n");

Console.WriteLine("=== LISTA APÓS ATUALIZAÇÃO ===");
foreach (var e in repo.Listar())
    Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");
Console.WriteLine();

Console.WriteLine("=== REMOVENDO ===");
repo.Remover(1);
Console.WriteLine("Removido.\n");

Console.WriteLine("=== LISTA FINAL ===");
foreach (var e in repo.Listar())
    Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");

Console.WriteLine("\n=== FIM ===");

var repoProduto = new ProdutoRepository();

Console.WriteLine("\n=== INSERINDO 3 PRODUTOS ===");
repoProduto.Adicionar(new Produto { Nome = "Notebook",    Preco = 3500.00 });
repoProduto.Adicionar(new Produto { Nome = "Mouse",       Preco = 150.00  });
repoProduto.Adicionar(new Produto { Nome = "Teclado",     Preco = 250.00  });

Console.WriteLine("=== LISTANDO PRODUTOS ===");
foreach (var p in repoProduto.Listar())
    Console.WriteLine($"{p.Id} - {p.Nome} - R${p.Preco:F2}");

Console.WriteLine("\n=== PRODUTOS ACIMA DE R$200 ===");
foreach (var p in repoProduto.ListarAcimaDePreco(200))
    Console.WriteLine($"{p.Nome} - R${p.Preco:F2}");

// ── ATIVIDADE 2: Cliente ───────────────────────────
var repoCliente = new ClienteRepository();

Console.WriteLine("\n=== INSERINDO CLIENTES ===");
repoCliente.Adicionar(new Cliente { Nome = "Ana Silva",  Email = "ana@email.com"  });
repoCliente.Adicionar(new Cliente { Nome = "Bruno",      Email = "brunoSemArroba" }); // inválido
repoCliente.Adicionar(new Cliente { Nome = "Carla Lima", Email = "carla@loja.com" });

Console.WriteLine("\n=== LISTANDO CLIENTES ===");
foreach (var c in repoCliente.Listar())
    Console.WriteLine($"{c.Id} - {c.Nome} - {c.Email}");

Console.WriteLine("\n=== BUSCA POR E-MAIL ===");
var clienteEncontrado = repoCliente.BuscarPorEmail("ana@email.com");
if (clienteEncontrado != null)
    Console.WriteLine($"Encontrado: {clienteEncontrado.Nome}");

// ── ATIVIDADE 3: Curso ─────────────────────────────
var repoCurso = new CursoRepository();

Console.WriteLine("\n=== INSERINDO 5 CURSOS ===");
repoCurso.Adicionar(new Curso { Nome = "C# Básico",        CargaHoraria = 40, ProfessorId = null });
repoCurso.Adicionar(new Curso { Nome = "Entity Framework", CargaHoraria = 30, ProfessorId = null });
repoCurso.Adicionar(new Curso { Nome = "SQL para Devs",    CargaHoraria = 20, ProfessorId = null });
repoCurso.Adicionar(new Curso { Nome = "ASP.NET Core",     CargaHoraria = 60, ProfessorId = null });
repoCurso.Adicionar(new Curso { Nome = "Docker Básico",    CargaHoraria = 15, ProfessorId = null });
Console.WriteLine("=== CURSOS ORDENADOS POR NOME ===");
foreach (var c in repoCurso.ListarOrdenadoPorNome())
    Console.WriteLine($"{c.Nome} - {c.CargaHoraria}h");

Console.WriteLine("\n=== CURSOS COM CARGA >= 30H ===");
foreach (var c in repoCurso.FiltrarPorCargaHoraria(30))
    Console.WriteLine($"{c.Nome} - {c.CargaHoraria}h");

// ── ATIVIDADE 4: Estoque ───────────────────────────
var repoEstoque = new EstoqueRepository();

Console.WriteLine("\n=== INSERINDO ITENS DE ESTOQUE ===");
repoEstoque.Adicionar(new ItemEstoque { Nome = "Cabo USB",  Quantidade = 10 });
repoEstoque.Adicionar(new ItemEstoque { Nome = "Adaptador", Quantidade = 3  });
repoEstoque.Adicionar(new ItemEstoque { Nome = "Case HD",   Quantidade = 7  });

Console.WriteLine("=== DANDO BAIXA (5 unid. de Cabo USB) ===");
repoEstoque.DarBaixa(1, 5);

Console.WriteLine("=== TENTANDO BAIXA QUE DEIXARIA NEGATIVO ===");
repoEstoque.DarBaixa(2, 10); 
Console.WriteLine("\n=== ESTOQUE BAIXO (<=5) ===");
foreach (var i in repoEstoque.ListarEstoqueBaixo(5))
    Console.WriteLine($"{i.Nome} - {i.Quantidade} unid.");

// ── ATIVIDADE 5: Professor e Cursos ───────────────


var repoProfessor = new ProfessorRepository();

Console.WriteLine("\n=== INSERINDO PROFESSOR COM CURSOS ===");
repoProfessor.Adicionar(new Professor
{
    Nome = "Carlos Silva",
    Cursos = new List<Curso>
    {
        new Curso { Nome = "C# Básico",        CargaHoraria = 40 },
        new Curso { Nome = "Entity Framework", CargaHoraria = 30 },
    }
});

Console.WriteLine("=== LISTANDO PROFESSORES COM SEUS CURSOS ===");
foreach (var prof in repoProfessor.ListarComCursos())
{
    Console.WriteLine($"Prof: {prof.Nome}");
    foreach (var c in prof.Cursos!)
        Console.WriteLine($"  → {c.Nome} ({c.CargaHoraria}h)");
}

// ── ATIVIDADE 6: Pedido e Itens ────────────────────
var repoPedido = new PedidoRepository();

Console.WriteLine("\n=== INSERINDO PEDIDO COM ITENS ===");
repoPedido.Adicionar(new Pedido
{
    Data  = DateTime.Now,
    Itens = new List<ItemPedido>
    {
        new ItemPedido { Produto = "Notebook", Quantidade = 1 },
        new ItemPedido { Produto = "Mouse",    Quantidade = 2 },
        new ItemPedido { Produto = "Teclado",  Quantidade = 1 },
    }
});

Console.WriteLine("=== LISTANDO PEDIDOS COM ITENS ===");
foreach (var pedido in repoPedido.ListarComItens())
{
    Console.WriteLine($"Pedido #{pedido.Id} - {pedido.Data:dd/MM/yyyy}");
    foreach (var item in pedido.Itens!)
        Console.WriteLine($"  → {item.Produto} x{item.Quantidade}");

    // DESAFIO: total de unidades do pedido
    var total = repoPedido.TotalItens(pedido.Id);
    Console.WriteLine($"  Total de itens: {total} unidade(s)");
}
