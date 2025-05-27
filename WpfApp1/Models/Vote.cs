using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public enum VoteType
    {
        For,
        Against,
        Abstain
    }

    public class Vote
    {
        public int VoteId { get; set; }
        public VoteType Type { get; set; }

        public int VotingResultId { get; set; }
        public VotingResult VotingResult { get; set; }
    }
}