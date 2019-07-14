using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuckyFishExercise.Models
{
    public class Sign
    {
        [Key]
        public int _SignID { get; set; }
        public string _SignName { get; set; }
        public bool _SignJoker { get; set; }
    }
}