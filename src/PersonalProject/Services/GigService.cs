using PersonalProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Services
{
    public class GigService
    {
        private IGenericRepository _repo;

        public GigService(IGenericRepository repo)
        {
            _repo = repo;
        }
        // this is where I write all the methods to be called in the controller and actually executed with repo methods.

    }
}
