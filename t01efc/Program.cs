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
foreach (var g in db.Games.Where(g => g.Name.Contains("The")).OrderBy(g => g.Name).Take(2).ToList()) // načte všechny záznamy z tabulky Games obsahující frázi "The"
{
    Console.WriteLine($"GameId: {g.GameId}, Name: {g.Name}"); // a vypíše je
}
Console.WriteLine("------");
foreach (var gn in db.Genres.Include(g => g.Games).ToList()) // načte všechny záznamy z tabulky Genres včetně jejich her
{
    Console.WriteLine($"GenreId: {gn.GenreId}, Text: {gn.Text}");
    foreach (var g in gn.Games)
    {
        Console.WriteLine($"\tGameId: {g.GameId}, Name: {g.Name}");
    }
}
Console.WriteLine("------");
foreach (var g in db.Games.GroupBy(g => g.Genre).ToList()) // načte všechny záznamy z tabulky Games a seskupí je podle žánru
{
    Console.WriteLine($"GenreId: {g.Key.GenreId}, Text: {g.Key.Text}, Count: {g.Count()}");
}
// Include je metoda, která umožňuje načíst související data z jiné tabulky. V tomto případě se načítají hry (Games) pro každý žánr (Genre).
// Takto je vhodné ji použít pro seznamy
// jinak se použije explicit loading, kdy se načítají související data až při jejich použití, například:
try
{
    var game = db.Games.Single(); // načte jedinou položku odpovídající požadavku (v tomto případě první položku z tabulky Games)
    db.Entry(game).Reference(g => g.Genre).Load();
    Console.WriteLine($"GameId: {game.GameId}, Name: {game.Name}, Genre: {game.Genre.Text}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
// typicky detailní informace o položce se načítají explicitně, protože se předpokládá, že se budou používat jen zřídka, zatímco seznamy se načítají eager loadingem, protože se předpokládá, že se budou používat často.

// https://pslib.sharepoint.com/sites/studium/it/csharp/SitePages/EntityFramework.aspx
// https://pslib.sharepoint.com/sites/studium/it/csharp/SitePages/EFCTableLoading.aspx

try
{
    var cdproject = db.Developers.Where(d => d.DeveloperId == 1).First();
    cdproject?.Games?.Add(db.Games.Where(g => g.Name == "Cyberpunk 2077").First());
    db.SaveChanges();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

foreach (var d in db.Developers.Include(d => d.Games).ToList())
{
    Console.WriteLine($"DeveloperId: {d.DeveloperId}, Name: {d.Name}");
    if (d.Games != null && d.Games.Any())
    {
        foreach (var g in d.Games)
        {
            Console.WriteLine($"\tGameId: {g.GameId}, Name: {g.Name}");
        }
    }
}