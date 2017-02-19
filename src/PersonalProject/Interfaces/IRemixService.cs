using System.Collections.Generic;
using PersonalProject.Models;

namespace PersonalProject.Interfaces
{
    public interface IRemixService
    {
        void PassName(string name);
        void AddRemix(Remix rmx);
        void DeleteRemix(int id);
        Remix GetRemix(int id);
        List<Remix> ListRemixes();
        List<Remix> ListRemixByUser();
        void UpdateRemix(Remix rmx);
    }
}