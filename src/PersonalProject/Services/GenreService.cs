using PersonalProject.Interfaces;
using PersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Services
{
    public class GenreService: IGenreService
    {
        private IGenericRepository _repo;

        public GenreService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Genre> AllGenres()
        {
            List<Genre> getUm = (from g in _repo.Query<Genre>()
                           select new Genre
                           {
                               Id = g.Id,
                               Name = g.Name,
                               Remixes = g.Remixes
                           }).ToList();
            return getUm;
        }

        public Genre GetGenre(int id)
        {
            Genre getUm = (from g in _repo.Query<Genre>()
                           where g.Id == id
                           select new Genre
                           {
                               Id = g.Id,
                               Name = g.Name,
                               Remixes = g.Remixes
                           }).FirstOrDefault();
            return getUm;
        }

        public void AddGenre(Genre genre)
        {
            _repo.Add(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            _repo.Update(genre);
        }

        public void DeleteGenre(int id)
        {
            Genre toDelete = GetGenre(id);
            _repo.Delete(toDelete);

        }

        public Genre GetGenreNoRemixes(int id)
        {
            Genre getIt = (from g in _repo.Query<Genre>()
                           where g.Id == id
                           select g).FirstOrDefault();
            return getIt;
        }

    }
}
