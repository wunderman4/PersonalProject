using PersonalProject.Interfaces;
using PersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PersonalProject.Services
{
    public class RemixService : IRemixService
    {
        private IGenericRepository _repo;
        private IGenreService _genre;
        private ApplicationUser _user;

        public RemixService(IGenericRepository repo, IGenreService genre)
        {
            _repo = repo;
            _genre = genre;
        }

        public void PassName(string name)
        {
            _user = (from u in _repo.Query<ApplicationUser>()
                     where u.UserName == name
                     select u).FirstOrDefault();
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
                                       AdminNote = r.AdminNote,
                                       UserTable = r.UserTable

                                   }).ToList();
            return remixes;
        }

        public List<Remix> ListRemixByUser()
        {
            List<Remix> rmxByUser = (from r in _repo.Query<Remix>()
                                     where r.UserTable == _user
                                     select new Remix //-----------------------Pay Attention to this! No circular ref!
                                     {
                                         Id = r.Id,
                                         OriginalName = r.OriginalName,
                                         youtubeUrl = r.youtubeUrl,
                                         RequestedGenre = r.RequestedGenre,
                                         UserNote = r.UserNote,
                                         Status = r.Status,
                                         AdminNote = r.AdminNote,
                                         UserTable = r.UserTable
                                     }).ToList();
            return rmxByUser;
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
            rmx.UserTable = _user;
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
