using EscolaEF.Models;
using EscolaEF.Repositories;

var repo = new EstudanteRepository();

// ── INSERT ─────────────────────────────────────────
Console.WriteLine("=== INSERINDO ESTUDANTE ===");
repo.Adicionar(new Estudante { Nome = "João Silva", Idade = 22 });
Console.WriteLine("Inserido com sucesso.\n");

// ── LIST ───────────────────────────────────────────
Console.WriteLine("=== LISTANDO ESTUDANTES ===");
foreach (var e in repo.Listar())
    Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");
Console.WriteLine();

// ── FIND BY ID ─────────────────────────────────────
Console.WriteLine("=== BUSCANDO POR ID ===");
var encontrado = repo.BuscarPorId(1);
if (encontrado != null)
    Console.WriteLine($"Encontrado: {encontrado.Nome} - {encontrado.Idade} anos");
else
    Console.WriteLine("Não encontrado.");
Console.WriteLine();

// ── UPDATE ─────────────────────────────────────────
Console.WriteLine("=== ATUALIZANDO ===");
repo.Atualizar(new Estudante { Id = 1, Nome = "Maria Oliveira", Idade = 25 });
Console.WriteLine("Atualizado.\n");

// ── LIST AFTER UPDATE ──────────────────────────────
Console.WriteLine("=== LISTA APÓS ATUALIZAÇÃO ===");
foreach (var e in repo.Listar())
    Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");
Console.WriteLine();

// ── DELETE ─────────────────────────────────────────
Console.WriteLine("=== REMOVENDO ===");
repo.Remover(1);
Console.WriteLine("Removido.\n");

// ── FINAL LIST ─────────────────────────────────────
Console.WriteLine("=== LISTA FINAL ===");
foreach (var e in repo.Listar())
    Console.WriteLine($"{e.Id} - {e.Nome} - {e.Idade} anos");

Console.WriteLine("\n=== FIM ===");