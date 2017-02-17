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


        [HttpGet("public")]
        
        public List<Remix> PublicGet()
        {
            return _rmx.ListRemixes();
        }


        [HttpGet("{id}")]
        public Remix Get(int id)
        {
            return _rmx.GetRemix(id);
        }
        [HttpGet]
        [Authorize]
        public List<Remix> Get()
        {
            
            List<Remix> remixes = (from u in _rmx.ListRemixes()
                                        where u.UserTable.Id == User.Identity.Name
                                        select u).ToList();
            return remixes;
        }
        [HttpGet("public/" + "{id}")]
        public Remix PublicGet(int id) {
            Remix remix = (from r in _rmx.ListRemixes()
                           where r.UserTable.Id == User.Identity.Name
                           && r.Id == id
                           select r).FirstOrDefault();
            return remix;
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Remix rmx)
        {
            if (rmx == null)
            {
                return BadRequest();
            }
            else if (rmx.Id == 0)
            {
                
                
                _rmx.PassName(User.Identity.Name);
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
