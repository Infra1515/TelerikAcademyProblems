using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Specialties
{
    class DoubleDamage : Specialty
    {
        private int rounds;
        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }
        public int Rounds
        {
            get
            {
                return this.rounds;
            }
            set
            {
                if (value < 0 || value >= 10)
                {
                    throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0" +
                        " and less then 10");

                }
                this.rounds = value;
            }
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }
            this.Rounds--;
            return currentDamage * 2;

        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
