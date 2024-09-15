using System.Drawing;

namespace TryOut.AbstractFactory.StraightCode {
    public class Game {
        public Game() {

            /*
             * задача - создавать объекты для заданной заранее иерархии
             */
            var player = new Player {
                           Race = RaceType.Human
                       };

            // на самом деле так делать не надо. Класс игрока знает слишком много в этот момент.
            var infantry = player.CreateInfantry();
            infantry.Point = new Point(1,1);

            var infantry1 = player.CreateInfantry();
            infantry1.Point = new Point(2,3);

            infantry.Draw();
            infantry1.Draw();

        }

        public void Turn(Player player) {

        }
    }
}