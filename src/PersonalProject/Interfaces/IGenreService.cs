using System.Collections.Generic;
using PersonalProject.Models;

namespace PersonalProject.Interfaces
{
    public interface IGenreService
    {
        List<Genre> AllGenres();
        void AddGenre(Genre genre);
        void DeleteGenre(int id);
        Genre GetGenre(int id);
        void UpdateGenre(Genre genre);
        Genre GetGenreNoRemixes(int id);
    }
}