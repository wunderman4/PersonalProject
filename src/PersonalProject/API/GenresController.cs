using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.Models;
using PersonalProject.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalProject.API
{
    [Route("api/[controller]")]
    public class GenresController : Controller
    {

        private IGenreService _genre;

        public GenresController(IGenreService genre)
        {
            _genre = genre;
        }

        [HttpGet]
        public List<Genre> Get()
        {
            
           return _genre.AllGenres();
            
        }


        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            return _genre.GetGenre(id);
        }


        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            else if (genre.Id == 0)
            {
                _genre.AddGenre(genre);
                return Ok();
            }
            else
            {
                _genre.UpdateGenre(genre);
                return Ok();
            }

        }

        
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public void Delete(int id)
        {
            _genre.DeleteGenre(id);
        }
    }
}
