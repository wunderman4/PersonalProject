using PersonalProject.Interfaces;
using PersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Services
{
    public class RemixService: IRemixService
    {
        private IGenericRepository _repo;
        private IGenreService _genre;

        public RemixService(IGenericRepository repo, IGenreService genre)
        {
            _repo = repo;
            _genre = genre;
        }

        public List<Remix> ListRemixes()
        {
            List<Remix> remixes = (from r in _repo.Query<Remix>()
                                  select new Remix
                                  {
                                      Id = r.Id,
                                      OriginalName = r.OriginalName,
                                      youtubeUrl = r.youtubeUrl,
                                      RequestedGenre = r.RequestedGenre,
                                      UserNote = r.UserNote,
                                      Status = r.Status,
                                      AdminNote = r.AdminNote
                                  }).ToList();
            return remixes;
        }

        public Remix GetRemix(int id)
        {
            Remix single = (from r in _repo.Query<Remix>()
                            where r.Id == id
                            select new Remix
                            {
                                Id = r.Id,
                                OriginalName = r.OriginalName,
                                youtubeUrl = r.youtubeUrl,
                                RequestedGenre = r.RequestedGenre,
                                UserNote = r.UserNote,
                                Status = r.Status,
                                AdminNote = r.AdminNote
                            }).FirstOrDefault();
            return single;
        }

        public void AddRemix(Remix rmx)
        {
            Genre genrelink = _genre.GetGenreNoRemixes(rmx.RequestedGenre.Id);
            rmx.RequestedGenre = genrelink;

            _repo.Add(rmx);
        }

        public void UpdateRemix(Remix rmx)
        {
            Genre genreLink = _genre.GetGenreNoRemixes(rmx.RequestedGenre.Id);
            rmx.RequestedGenre = genreLink;

            _repo.Update(rmx);
        }

        public void DeleteRemix(int id)
        {
            Remix toDelete = GetRemix(id);
            _repo.Delete(toDelete);
        }

    }
}
