using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuckyFishExercise.Models
{
    public class Conf
    {
        [Key]
        public int _confID { get; set; }

        [Display(Name = "Bet")]
        [Range(1, int.MaxValue, ErrorMessage = "Players can bet only 1 coin or more!")]
        public int _bet { get; set; } //amount of coins the player bet

        [Display(Name = "Number of scratch cards")]
        [Range(1, int.MaxValue, ErrorMessage = "Players can play with 1 card at least!")]
        public int _numScratchcards { get; set; } //The appearance amount of the scratch card

        [Display(Name = "Number of signs on the wheel")]
        [Range(2, int.MaxValue, ErrorMessage = "2 is the minimum signs on the wheel!")]
        public int _numSignOnWheel { get; set; } //The appearance amount of the signs on the wheel

        [Display(Name = "Number of sign on scratch cards")]
        [Range(1, int.MaxValue, ErrorMessage = "1 is the minimum signs on a scratch card!")]
        public int _numSignOnScratchcards { get; set; } //The appearance amount of the signs on the scratch card

        [Display(Name = "Play with repeats on scratch card")]
        public bool _repeat { get; set; } //with repeat=true ,without repeat=false

        [Display(Name = "Random selected sign")]
        [Range(1, int.MaxValue, ErrorMessage = "Selected Signs must be more then 1!")]
        public int _numSelectedSigns { get; set; } //how mach signs can be choosen by the spin button

        [Display(Name = "Play with jokers")]
        public bool _withJoker { get; set; } //A joker can appear on a scratch card=true ,cant appear on scratch=false

        public Conf()
        {
            this._bet = 3;
            this._numScratchcards = 1;
            this._numSignOnWheel = 12;
            this._numSelectedSigns = 3;
            this._numSignOnScratchcards = 4;
            this._repeat = true;
            this._withJoker = false;

        }

    }
}