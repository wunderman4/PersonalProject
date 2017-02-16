using PersonalProject.Interfaces;
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

        // add services to link to controller. 
    }
}
