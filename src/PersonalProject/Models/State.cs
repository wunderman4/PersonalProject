using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<Gig> Gigs { get; set; }

    }
}
