using System.Collections.Generic;
using PersonalProject.Models;

namespace PersonalProject.Interfaces
{
    public interface IStateService
    {
        void AddState(State state);
        List<State> AllStates();
        void DeleteState(int id);
        State GetState(int id);
        void UpdateState(State state);
        State GetStateNoGigs(int id);
    }
}