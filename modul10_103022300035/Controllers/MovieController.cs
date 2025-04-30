using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300035.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        public static List<Movie> movieList = new List<Movie>
        {
            new Movie { title = "The Shawshank Redemption", director = "Frank Darabont", stars = new List<string> {"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie { title = "The Godfather", director = "Francis Ford Coppola", stars = new List<string> {"Marlon Brando", "Al Pacino", "James Caan"}, description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."},
            new Movie { title = "The Dark Knight", director = "Cristopher Nolan", stars = new List<string> {"Christian Bale", "Heath Ledger", "Aaron Eckhart"}, description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."}
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            return Ok(movieList);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            if (id < 0 || id >= movieList.Count)
            {
                return NotFound("ID tidak ditemukan");
            }
            return Ok(movieList[id]);
        }

        [HttpPost]
        public ActionResult<List<Movie>> AddMovie(Movie mv)
        {
            movieList.Add(mv);
            return Ok(movieList);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Movie>> DeleteMovie(int id)
        {
            if (id < 0 || id >= movieList.Count)
                return NotFound("ID tidak ditemukan");

            movieList.RemoveAt(id);
            return Ok(movieList);
        }
    }
}
