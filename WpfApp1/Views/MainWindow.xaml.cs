using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VotingApp.Models;
using VotingApp.ViewModels;

namespace VotingApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new VotingContext())
            {
                // Seed voting result if it doesn't exist
                if (!context.VotingResults.Any())
                {
                    var result = new VotingResult
                    {
                        VotingDeadline = DateTime.Now.AddHours(1),
                        Votes = new List<Vote> {
                new Vote { Type = VoteType.For },
                new Vote { Type = VoteType.Against },
                new Vote { Type = VoteType.For },
                new Vote { Type = VoteType.Abstain }
            }
                    };
                    context.VotingResults.Add(result);
                    context.SaveChanges();
                }

                var votingResult = context.VotingResults
                    .Include(v => v.Votes)
                    .FirstOrDefault();

                if (votingResult != null)
                {
                    this.DataContext = new VotingViewModel(votingResult);
                }
            }
        }

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