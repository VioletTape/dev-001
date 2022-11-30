using System.Drawing;
using AutoMapper;
using TryOut.Flyweight.Refactored;

namespace TryOut.AbstractFactory.Refactored {
    public class Player {
        public IRace Race { get; set; }
    }

    public enum RaceType {
        Human,
        Zerg,
        Protos
    }

    public enum UnitType {
        Infantry,
        Rangers,
        LightVehicle,
        Tank,
        Helicopter
    }

    public interface IRace {
        RaceType RaceType { get; }
    }

    public class Human : IRace {
        public RaceType RaceType {
            get { return RaceType.Human; }
        }
    }

    public class Zerg : IRace {
        public RaceType RaceType {
            get { return RaceType.Zerg; }
        }
    }

    public class Protos : IRace {
        public RaceType RaceType {
            get { return RaceType.Protos; }
        }
    }

    public interface IInfantry : IUnit {
        Player Player { get; set; }
        int Armor { get; set; }
        int HP { get; set; }
        int Attack { get; set; }

        Point Point { get; set; }
        void Draw();

        IInfantry Clone();
    }

    public interface IUnit { }

    internal interface IBaseFactory {
       object Create(Player player);
    }

    internal interface IFactory<T> where T : IUnit{
        T Create(Player player);
    }

    public class InfantryFactory : IBaseFactory {
         static Dictionary<RaceType, IInfantry> prototypes
            = new Dictionary<RaceType, IInfantry> {
                {
                    RaceType.Human, new Infantry<Human> {
                        Armor = 10,
                        HP = 20,
                        Attack = 5
                    }
                }
                , {
                    RaceType.Zerg, new Infantry<Zerg> {
                        Armor = 5,
                        HP = 25,
                        Attack = 10
                    }
                }
                , {
                    RaceType.Protos, new Infantry<Protos> {
                        Armor = 25,
                        HP = 5,
                        Attack = 15
                    }
                },
            };

        public object Create(Player player) {
            var infantry = prototypes[player.Race.RaceType].Clone(); 
            infantry.Player = player;
            return infantry;
        }
    }

    public class Infantry<T> : IInfantry where T : IRace {
        public int Armor { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public Point Point { get; set; }
        public Player Player { get;  set; }

        public void Draw() {
            var format = string.Format("{0} {1} {2}", Player.Race, Point.X, Point.Y);
            Console.WriteLine(format);
        }

        public IInfantry Clone() {
            return new Infantry<T> {
                Armor = Armor, Attack = Attack, HP = HP
            };
        }
    }

    // Abstract Factory
    public class Factory {
       static Dictionary<Type, IBaseFactory> factories = new Dictionary<Type, IBaseFactory> {

            {typeof(IInfantry), new InfantryFactory()}, 
        };

       static Dictionary<UnitType, IBaseFactory> factoriesByTypes = new Dictionary<UnitType, IBaseFactory> {

           {UnitType.Infantry, new InfantryFactory()}, 
       };

       public T Create<T>(Player player)  where T : IUnit {
           var unit = (T)factories[typeof(T)].Create(player);
           return unit;
       }

       public object Create(Player player, UnitType type)  {
           return factoriesByTypes[type].Create(player);
       }
    }

   
}