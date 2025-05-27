using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Models
{
    public class VotingContext : DbContext
    {
        public DbSet<VotingResult> VotingResults { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public VotingContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("VotingInMemory");
        }
    }
}