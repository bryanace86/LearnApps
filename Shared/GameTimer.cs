using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApps.Shared
{
    public class GameTimer : Entity
    {
        public int AllowedTotalTime { get; set; }
        public int RemainingTotalTime { get; set; }
        public int ElapsedTotalTime { get; set; }
        public int AllowedCardTime { get; set; }
        public int RemainingCardTime { get; set; }
        public int ElapsedCardTime { get; set; }
    }
}
