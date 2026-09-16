using t01efc.Data;
using t01efc.Models;

var db = new GamesDbContext(@"Data Source=games.sqlite"); // připojení k databázi SQLite

db.Games.Add(new Game { Name = "Diablo IV" }); // vytvoří strukturu v paměti
db.Games.Add(new Game { Name = "Cyberpunk 2077" });
db.Games.Add(new Game { Name = "The Witcher 3" });
db.Games.Add(new Game { Name = "The Last of Us" });
db.SaveChanges(); // uloží změny do databáze

foreach (var g in db.Games) // načte všechny záznamy z tabulky Games
{
    Console.WriteLine($"GameId: {g.GameId}, Name: {g.Name}"); // a vypíše je
}
Console.WriteLine("------");
foreach (var g in db.Games.OrderBy(g => g.Name)) // načte všechny záznamy z tabulky Games seřazené podle názvu
{
    Console.WriteLine($"GameId: {g.GameId}, Name: {g.Name}"); // a vypíše je
}
Console.WriteLine("------");
foreach (var g in db.Games.Where(g => g.Name.Contains("The"))) // načte všechny záznamy z tabulky Games obsahující frázi "The"
{
    Console.WriteLine($"GameId: {g.GameId}, Name: {g.Name}"); // a vypíše je
}