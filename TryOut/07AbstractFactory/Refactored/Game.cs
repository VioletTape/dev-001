using System.Drawing;

namespace TryOut.AbstractFactory.Refactored {
    public class Game {
        public Game() {
            var player = new Player {
                           Race = new Human()
                       };  
            var player2 = new Player {
                           Race = new Zerg()
                       };

            var factory = new Factory();


            var infantry1 = factory.Create<IInfantry>(player);
            infantry1.Point = new Point(1,1);

            var infantry2 = (IInfantry)factory.Create(player2, UnitType.Infantry);

            infantry1.Draw();
            infantry2.Draw();
        }
    }
}