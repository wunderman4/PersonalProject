using PersonalProject.Interfaces;
using PersonalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Services
{
    public class StateService
    {
        private IGenericRepository _repo;

        public StateService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<State> AllStates()
        {
            List<State> getStates = (from s in _repo.Query<State>()
                                     select new State
                                     {
                                         Id = s.Id,
                                         StateName = s.StateName,
                                         Gigs = s.Gigs
                                     }).ToList();
            return getStates;
        }

        public State GetState(int id)
        {
            State getState = (from s in _repo.Query<State>()
                              where s.Id == id
                              select new State
                              {
                                  Id = s.Id,
                                  StateName = s.StateName,
                                  Gigs = s.Gigs
                              }).FirstOrDefault();
            return getState;
        }

        public void AddState(State state)
        {
            _repo.Add(state);
        }

        public void UpdateState(State state)
        {
            _repo.Update(state);
        }

        public void DeleteState(int id)
        {
            State stateToDelete = GetState(id);
            _repo.Delete(stateToDelete);
        }

        public State GetStateNoGigs(int id) // im pretty sure I need to change this to New State and exclude the gigs to avoid a loop.
        {
            State getIt = (from g in _repo.Query<State>()
                           where g.Id == id
                           select g).FirstOrDefault();
            return getIt;
        }
    }
}
