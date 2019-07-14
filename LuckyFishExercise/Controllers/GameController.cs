using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LuckyFishExercise.Models;

namespace LuckyFishExercise.Controllers
{
    [RoutePrefix("game")]
    public class GameController : ApiController
    {
        private gameDBContext db = new gameDBContext();
        private Game game = new Game();
        private Conf conf;
        Random r = new Random();
        
        

        public GameController()
        {
            if (db._Configuration.ToList().Count > 0)
            {
                this.conf = db._Configuration.ToList().ElementAt(0);
            }
            else
            {
                this.conf = new Conf();
            }
            this.game._WheelSigns = db._Signs.ToList().GetRange(0, this.conf._numSignOnWheel);
            this.game.playerBet = this.conf._bet;
            this.game.playerNumOfScratch = this.conf._numScratchcards;
            
        }


        [HttpGet]
        [Route("spin")]
        public IHttpActionResult spin()
        {
            IEnumerable<KeyValuePair<string, string>> queryString = this.Request.GetQueryNameValuePairs();
            this.game.playerBet = Convert.ToInt32(queryString.Where(nv => nv.Key == "bet").Select(nv => nv.Value).FirstOrDefault());
            this.game.playerNumOfScratch = Convert.ToInt32(queryString.Where(nv => nv.Key == "cards").Select(nv => nv.Value).FirstOrDefault());
            IList<Sign> scratch;
            this.game._selectedSigns = generateRandomSigns(this.game._WheelSigns, this.conf._numSelectedSigns, false, false);
            for (int i = 0; i < this.game.playerNumOfScratch; ++i)
            {
                scratch = generateRandomSigns(game._WheelSigns, this.conf._numSignOnScratchcards, this.conf._repeat, this.conf._withJoker);
                this.game._ScratchCards.Add(scratch);
                this.game.prize += getPrize(this.game._selectedSigns, scratch, this.game.playerBet);
            }
            
            return Json(this.game);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult getGame()
        {
            return Json(this.game);
        }

        // A function that generate Random signs
        public IList<Sign> generateRandomSigns(IList<Sign> domain, int size, bool repeat, bool withJokers)
        {
            IList<Sign> randomSigns = new List<Sign>();

            if (domain.Count < size)
            {
                size = domain.Count;
            }

            while (randomSigns.Count < size)
            {
                int randomIndex = r.Next(0, domain.Count - 1);
                Sign randomElement = domain.ElementAt(randomIndex);
                if (!repeat)
                {
                    if (!randomSigns.Any(item => item._SignID == randomElement._SignID))
                    {
                        randomSigns.Add(randomElement);
                    }
                }
                else
                {
                    randomSigns.Add(randomElement);
                }
            }
            //A 30% chance of Joker's appearance
            if (withJokers && r.NextDouble() <= 0.3)
            {
                int indexToReplace = r.Next(0, size - 1);
                randomSigns.RemoveAt(indexToReplace);
                randomSigns.Insert(indexToReplace, new Models.Sign() { _SignName = "Joker", _SignJoker = true });
            }
            return randomSigns;

        }

        public int getPrize(IList<Sign> wheelSelected, IList<Sign> scratch, int bet)
        {
            int prize = 0;
            //we choose the scratch size because the joker is there
            for (int i = 0; i < scratch.Count; ++i)
            {
                    if (wheelSelected.Contains(scratch.ElementAt(i)) || scratch.ElementAt(i)._SignJoker)
                    {
                       prize += (1 + (++this.game.numOfMatch));
                    }
            }
            if (this.game.numOfMatch == 0) { return 0; }

            return prize*bet;

        }
    }
}
