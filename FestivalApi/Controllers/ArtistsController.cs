using Microsoft.AspNetCore.Mvc;
using FestivaLApi.Models;

namespace FestivalApi.Controllers

{

    
[ApiController]
[Route("api/artists")]
public class ArtistsController : ControllerBase
{

    List<Artist> artists = new List<Artist>
    {
        new Artist { Id = 1, Name = "Veronica Maggio" },
        new Artist { Id = 2, Name = "Hooja" },
        new Artist { Id = 3, Name = "Molly Sandén" },
        new Artist { Id = 4, Name = "Victor Leksell" },
        new Artist { Id = 5, Name = "Darin" },
        new Artist { Id = 6, Name = "Laleh" },
        new Artist { Id = 7, Name = "Markus Krunegård" },
        new Artist { Id = 8, Name = "Estraden" },
        new Artist { Id = 9, Name = "Miriam Bryant" },
        new Artist { Id = 10, Name = "Oskar Linnros" }
    };

    [HttpGet]
    public ActionResult<List<Artist>> GetAllArtists()
        {
            if (artists == null || !artists.Any() )
            {
                return NotFound();
            }

            return Ok(artists.Select(a => a.Name));
        }

    [HttpGet("{id:int}")]
    public ActionResult<Artist> GetArtistById([FromRoute]int id)
        {
            var artist = artists.FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist.Name);
            
        }
}

}