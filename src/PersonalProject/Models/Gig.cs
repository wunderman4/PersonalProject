using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LengthOfSet { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string AdminNote { get; set; }
        public string UserNote { get; set; }
        public State State { get; set; }
        public ApplicationUser UserTable { get; set; }


    }
}
