using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class Remix
    {
        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string youtubeUrl { get; set; }
        public string Status { get; set; }
        public string AdminNote { get; set; }
        public string UserNote { get; set; }
        public Genre RequestedGenre { get; set; }
        public ApplicationUser UserTable { get; set; }

        public void ConsolePrinter(int num)
        {
            Console.WriteLine(num.ToString());
        }

    }
}
