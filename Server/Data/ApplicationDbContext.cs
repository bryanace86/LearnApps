using IdentityServer4.EntityFramework.Options;
using LearnApps.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnApps.Shared;

namespace LearnApps.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<Deck>().HasData(
                new Deck { Title = "Fry's First 100"},
                new Deck { Title = "Fry's 100 to 200" },
                new Deck { Title = "Fry's 200 to 300" }
            );
            */
        }

        public DbSet<Deck> Decks { get; set; } 
        //public DbSet<DeckFlashCard> DeckFlashCards { get; set; }
        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<GameRound> GameRounds { get; set; }

        public DbSet<GameRoundAttempt> GameRoundAttempts { get; set; }
        public DbSet<GameRoundResult> GameRoundResults { get; set; }
        public DbSet<GameRoundStatus> GameRoundStatuses { get; set; }
        public DbSet<GameTimer> GameTimers { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
    }
}
