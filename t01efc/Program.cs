using Microsoft.EntityFrameworkCore;
using t01efc.Data;
using t01efc.Models;

var db = new GamesDbContext(@"Data Source=games.sqlite"); // připojení k databázi SQLite

db.Games.Add(new Game { Name = "Diablo IV", GenreId = 1 }); // vytvoří strukturu v paměti
db.Games.Add(new Game { Name = "Cyberpunk 2077", GenreId = 2 });
db.Games.Add(new Game { Name = "The Witcher 3", GenreId = 2 });
db.Games.Add(new Game { Name = "The Last of Us", GenreId = 1 });
db.SaveChanges(); // uloží změny do databáze

foreach (var g in db.Games.Include(g => g.Genre)) // načte všechny záznamy z tabulky Games
{
    Console.WriteLine($"GameId: {g.GameId}, Name: {g.Name}, Genre: {g.Genre.Text}"); // a vypíše je
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
Console.WriteLine("------");
foreach (var gn in db.Genres.Include(g => g.Games)) // načte všechny záznamy z tabulky Genres včetně jejich her
{
    Console.WriteLine($"GenreId: {gn.GenreId}, Text: {gn.Text}");
    foreach (var g in gn.Games)
    {
        Console.WriteLine($"\tGameId: {g.GameId}, Name: {g.Name}");
    }
}
// Include je metoda, která umožňuje načíst související data z jiné tabulky. V tomto případě se načítají hry (Games) pro každý žánr (Genre).
// Takto je vhodné ji použít pro seznamy
// jinak se použije explicit loading, kdy se načítají související data až při jejich použití, například:
var genre = db.Genres.First();
db.Entry(genre).Collection(g => g.Games).Load();
foreach (var g in genre.Games)
{
    Console.WriteLine($"GameId: {g.GameId}, Name: {g.Name}");
};
// typicky detailní informace o položce se načítají explicitně, protože se předpokládá, že se budou používat jen zřídka, zatímco seznamy se načítají eager loadingem, protože se předpokládá, že se budou používat často.