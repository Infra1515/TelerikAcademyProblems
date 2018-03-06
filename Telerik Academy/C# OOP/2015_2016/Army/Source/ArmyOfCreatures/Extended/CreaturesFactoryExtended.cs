using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended
{
    class CreaturesFactoryExtended : CreaturesFactory, ICreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {

                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "CyclopsKing":
                    return new CyclopsKing();
                case "Goblin":
                    return new Goblin();
                case "Griffin":
                    return new Griffin();
                case "WolfRaider":
                    return new WolfRaider();
                default:
                    return base.CreateCreature(name);
            }
        }
    }
}
