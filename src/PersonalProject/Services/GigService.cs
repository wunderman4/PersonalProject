using PersonalProject.Interfaces;
using PersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Services
{
    public class GigService
    {
        private IGenericRepository _repo;
        private IStateService _state;
        private ApplicationUser _user;

        public GigService(IGenericRepository repo, IStateService state)
        {
            _repo = repo;
            _state = state;
        }

        public void PassName(string name)
        {
            _user = (from u in _repo.Query<ApplicationUser>()
                     where u.UserName == name
                     select u).FirstOrDefault();
        }

        public List<Gig> ListGigs()
        {
            List<Gig> gigs = (from g in _repo.Query<Gig>()
                                   select new Gig
                                   {
                                       Id = g.Id,
                                       Status = g.Status,
                                       Date = g.Date,
                                       LengthOfSet = g.LengthOfSet,
                                       UserNote = g.UserNote,
                                       AdminNote = g.AdminNote,
                                       UserTable = g.UserTable,
                                       City = g.City,
                                       State = g.State
                                   }).ToList();
            return gigs;
        }
        
        public List<Gig> ListGigsByUser()
        {
            List<Gig> gigsByUser = (from g in _repo.Query<Gig>()
                                     where g.UserTable == _user
                                     select new Gig //-----------------------Pay Attention to this! No circular ref!
                                     {
                                         Id = g.Id,
                                         Status = g.Status,
                                         Date = g.Date,
                                         LengthOfSet = g.LengthOfSet,
                                         UserNote = g.UserNote,
                                         AdminNote = g.AdminNote,
                                         UserTable = g.UserTable,
                                         City = g.City,
                                         State = g.State
                                     }).ToList();
            return gigsByUser;
        }


        public Gig GetGig(int id)
        {
            Gig single = (from g in _repo.Query<Gig>()
                            where g.Id == id
                            select new Gig
                            {
                                Id = g.Id,
                                Status = g.Status,
                                Date = g.Date,
                                LengthOfSet = g.LengthOfSet,
                                UserNote = g.UserNote,
                                AdminNote = g.AdminNote,
                                UserTable = g.UserTable,
                                City = g.City,
                                State = g.State
                            }).FirstOrDefault();
            return single;
        }

        public void AddGig(Gig gig)
        {
            State stateLink = _state.GetStateNoGigs(gig.State.Id);
            gig.UserTable = _user;
            gig.State = stateLink;

            _repo.Add(gig);
        }

        public void UpdateGig(Gig gig)
        {
            State stateLink = _state.GetStateNoGigs(gig.State.Id);
            gig.State = stateLink;

            _repo.Update(gig);
        }

        public void DeleteGig(int id)
        {
            Gig toDelete = GetGig(id);
            _repo.Delete(toDelete);
        }

    }
}
