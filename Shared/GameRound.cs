using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApps.Shared
{
    public class GameRound: Entity
    {
        public Guid GameTypeId { get; set; }

        public GameType GameType { get; set; }

        public Guid GameTimerId { get; set; }

        public GameTimer GameTimer { get; set; }

        
    }
}
