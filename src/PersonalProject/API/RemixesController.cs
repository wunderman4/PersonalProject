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
        
        //constructor
        public RemixesController(IRemixService rmx)
        {
            _rmx = rmx;
        }


        [HttpGet("public")] //----------------------------------------Done!
        public List<Remix> PublicGet()
        {
            return _rmx.ListRemixes(); // listremixes() ruturns great no issue. 
        }

        [HttpGet("public/{id}")] //-----------------------------------Done!
        public Remix PublicGet(int id)
        {
            return _rmx.GetRemix(id);
        }


        [HttpGet("{id}")] //------------------------------------------Done!
        [Authorize] 
        public Remix Get(int id)
        {
            return _rmx.GetRemix(id);
        }

        [HttpGet] //--------------------------------------------------Done!
        [Authorize]
        public List<Remix> Get()
        {
            
            _rmx.PassName(User.Identity.Name);
           return _rmx.ListRemixByUser();
           
        }
        
        [HttpPost] //-------------------------------------------------Done!
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
        
        [HttpDelete("{id}")] //---------------------------------------Done!
        [Authorize]
        public void Delete(int id)
        {
            _rmx.DeleteRemix(id);
        }

        // ----------------------------------- Admin get/post/delete ----------------------------------------------------

        [HttpGet("admin")] //-----------------------------------------Done!
        [Authorize(Policy = "AdminOnly")]
        public List<Remix> AdminGet()
        {
            return _rmx.AdminListRemixes();
        }
    }
}
