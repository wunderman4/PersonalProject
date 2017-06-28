using System.Collections.Generic;
using PersonalProject.Models;

namespace PersonalProject.Interfaces
{
    public interface IRemixService
    {
       // void PassName(string name);
        void AddRemix(Remix rmx);
        void DeleteRemix(int id);
        Remix GetRemix(int id);
        List<Remix> ListRemixes();
        List<Remix> AdminListRemixes();
        List<Remix> ListRemixByUser(string name);
        void UpdateRemix(Remix rmx);
    }
}