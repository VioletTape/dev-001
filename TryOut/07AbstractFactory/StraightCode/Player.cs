using System.Drawing;

namespace TryOut.AbstractFactory.StraightCode
{
    public class Player
    {
        public RaceType Race { get; set; }
    }

    public enum RaceType
    {
        Human,
        Zerg,
        Protos,
        Ork
    }

    public enum UnitType
    {
        Infantry,
        Rangers,
        LightVehicle,
        Tank,
        Helicopter
    }

    public interface IInfantry : IUnit
    {
    }

    public interface IRangers : IUnit
    {
    }

    public class HumanInfantry : IInfantry
    {
        public int Armor { get; }
        public int HP { get; set; }
        public int Attack { get; }
        public Player Player { get; }
        public Point Point { get; set; }

        public HumanInfantry(Player player, int armor, int hp, int attack)
        {
            Player = player;
            Armor = armor;
            HP = hp;
            Attack = attack;
        }
    }

    public class ZergInfantry : IInfantry
    {
        public int Armor { get; }
        public int HP { get; set; }
        public int Attack { get; }
        public Player Player { get; }
        public Point Point { get; set; }

        public ZergInfantry(Player player, int armor, int hp, int attack)
        {
            Player = player;
            Armor = armor;
            HP = hp;
            Attack = attack;
        }
    }

    public class ProtosInfantry : IInfantry
    {
        public int Armor { get; }
        public int HP { get; set; }
        public int Attack { get; }
        public Player Player { get; }
        public Point Point { get; set; }

        public ProtosInfantry(Player player, int armor, int hp, int attack)
        {
            Player = player;
            Armor = armor;
            HP = hp;
            Attack = attack;
        }
    }

    public interface IUnit
    {
        int Armor { get; }
        int HP { get; }
        int Attack { get; }
        Player Player { get; }
        Point Point { get; protected set; }

        void Draw()
        {
            var format = string.Format("{0} {1} {2}", Player.Race, Point.X, Point.Y);
            Console.WriteLine(format);
        }

        void SetLocation(int x, int y)
        {
            Point = new Point(x, y);
        }
    }
}