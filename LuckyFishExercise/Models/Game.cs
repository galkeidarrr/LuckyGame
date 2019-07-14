using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyFishExercise.Models
{
    public class Game
    {
        //TODO: try to change the wheel and scratch to hashMap/hashSet
        public virtual IList<Sign> _WheelSigns { get; set; }
        public virtual IList<IList<Sign>> _ScratchCards { get; set; }

        public virtual IList<Sign> _selectedSigns { get; set; }

        public int playerBet { get; set; }
        public int playerNumOfScratch { get; set; }

        public int prize { get; set; }
        public int numOfMatch { get; set; }

        public Game()
        {
            this._ScratchCards = new List<IList<Sign>>();
            prize = 0;
            numOfMatch = 0;
        }

    }
}