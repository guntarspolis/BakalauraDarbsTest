using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.cs
{
    public class Spell : Card
    {
        public Spell(int cardType, int manaCost, bool isGolden, int heroClass) : base (cardType, manaCost, isGolden, heroClass)
        {

        }
        public int Damage { get; set; }

        public bool canTarget { get; set; }

        bool canTargetHero { get; set; }

        bool TargetType { get; set; }
        
    }
}
