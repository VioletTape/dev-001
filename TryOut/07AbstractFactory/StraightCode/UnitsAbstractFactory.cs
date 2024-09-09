using TryOut.AbstractFactory.StraightCode;

namespace TryOut._07AbstractFactory.StraightCode
{
    internal class UnitsAbstractFactory
    {
        private readonly Player player;
        public UnitsAbstractFactory(Player player)
        {
            this.player = player;
        }

        public IInfantry CreateInfantry()
        {
            {
                switch (player.Race)
                {
                    case RaceType.Human:
                        return new HumanInfantry(player, 10, 20, 5);
                    case RaceType.Protos:
                        return new ProtosInfantry(player, 25, 5, 15);
                    case RaceType.Zerg:
                        return new ZergInfantry(player, 5, 25, 10);
                }

                throw new Exception();
            }
        }

        public IRangers CreateRangers()
        {
            switch (player.Race)
            {
                case RaceType.Human:
                case RaceType.Protos:
                case RaceType.Zerg:
                    break;
            }

            throw new Exception();
        }
    }
}
