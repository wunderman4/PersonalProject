using System.Collections.Generic;
using PersonalProject.Models;

namespace PersonalProject.Interfaces
{
    public interface IRemixService
    {
        void AddRemix(Remix rmx);
        void DeleteRemix(int id);
        Remix GetRemix(int id);
        List<Remix> ListRemixes();
        void UpdateRemix(Remix rmx);
    }
}