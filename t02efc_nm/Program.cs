using Microsoft.EntityFrameworkCore;

var db = new t02efc_nm.Data.MoviesDbContext();
var movies = db.Movies.Include(m => m.Roles)!.ThenInclude(r => r.Artist).ToList();
foreach (var movie in movies)
{
    Console.WriteLine($"Movie: {movie.Name}");
    if (movie.Roles != null)
    {
        foreach (var role in movie.Roles)
        {
            Console.WriteLine($"  Role: {role.RoleName}, Artist: {role.Artist?.FirstName} {role.Artist?.LastName}");
        }
    }
}