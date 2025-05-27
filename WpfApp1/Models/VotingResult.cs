using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Models;

namespace VotingApp.Models
{
    public class VotingResult
    {
        public int VotingResultId { get; set; }
        public DateTime VotingDeadline { get; set; }

        // 🔧 Връзка към индивидуалните гласове
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
