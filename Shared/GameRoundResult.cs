using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApps.Shared
{
    public class GameRoundResult : Entity
    {

        public Guid GameRoundId { get; set; }

        public GameRound GameRound { get; set; }

        public Guid FlashCardId { get; set; }

        public FlashCard FlashCard { get; set; }

        public int ElapsedCardTime { get; set; }



    }
}
