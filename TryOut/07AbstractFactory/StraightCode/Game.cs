using System.Drawing;
using TryOut._07AbstractFactory.StraightCode;

namespace TryOut.AbstractFactory.StraightCode
{
    public class Game
    {
        public Game()
        {
            var player = new Player
            {
                Race = RaceType.Human
            };

            UnitsAbstractFactory unitsAbstractFactory = new(player);

            var infantry = unitsAbstractFactory.CreateInfantry();
            infantry.SetLocation(1, 1);

            var rangers = unitsAbstractFactory.CreateRangers();
            rangers.SetLocation(2, 3);

            infantry.Draw();
            rangers.Draw();
        }

        public void Turn(Player player)
        {

        }
    }
}