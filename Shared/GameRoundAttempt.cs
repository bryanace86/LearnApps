using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApps.Shared
{
    public class GameRoundAttempt : Entity
    {

        public string EnteredString { get; set; }

        public Guid GameRoundStatusId { get; set; }

        public GameRoundStatus Status { get; set; }

    }
}
