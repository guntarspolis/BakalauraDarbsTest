using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.cs
{
    public class Minion : Card
    {
        public Minion(int cardType, int manaCost, bool isGolden, int heroClass) : base (cardType, manaCost, isGolden, heroClass)
        {

        }

        public int BaseAttackValue { get; set; }
        public int AttackValue { get; set; }
        public int BaseHealthValue { get; set; }
        public int HealthValue { get; set; }

        public bool hasTount { get; set; }
        
        public bool hasCharge { get; set; }

        public bool hasWindfury { get; set; }


    }
}
