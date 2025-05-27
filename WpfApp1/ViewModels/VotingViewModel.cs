using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Models;

namespace VotingApp.ViewModels
{
    public class VotingViewModel
    {
        private VotingResult _currentResult;

        public VotingViewModel(VotingResult vRes)
        {
            _currentResult = vRes;
        }

        public int ForVotes => _currentResult.Votes.Count(v => v.Type == VoteType.For);
        public int AgainstVotes => _currentResult.Votes.Count(v => v.Type == VoteType.Against);
        public int AbstainVotes => _currentResult.Votes.Count(v => v.Type == VoteType.Abstain);

        public DateTime Deadline => _currentResult.VotingDeadline;


        // 🔧 Примерна функция за добавяне на глас
        private void SubmitVote(VoteType voteType, int votingResultId)
        {
            using (var context = new VotingContext())
            {
                var vote = new Vote
                {
                    Type = voteType,
                    VotingResultId = votingResultId
                };

                context.Votes.Add(vote);
                context.SaveChanges();
            }
        }
    }
}