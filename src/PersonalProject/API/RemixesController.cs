using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PersonalProject.Models;
using PersonalProject.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalProject.API
{
    [Route("api/[controller]")]
    public class RemixesController : Controller
    {
        private IRemixService _rmx;

        public RemixesController(IRemixService rmx)
        {
            _rmx = rmx;
        }

        
        [HttpGet]
        //[Authorize]
        public List<Remix> Get()
        {
            return _rmx.ListRemixes();
        }

        
        [HttpGet("{id}")]
        public Remix Get(int id)
        {
            return _rmx.GetRemix(id);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody]Remix rmx)
        {
            if (rmx == null)
            {
                return BadRequest();
            }
            else if (rmx.Id == 0)
            {
                _rmx.AddRemix(rmx);
                return Ok();
            }
            else
            {
                _rmx.UpdateRemix(rmx);
                return Ok();
            }
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rmx.DeleteRemix(id);
        }
    }
}
