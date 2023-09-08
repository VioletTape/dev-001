
namespace TryOut._11Iterator.Refactored; 

public class Client {
    public Client() {
        var car = CreateCarByBuilder();

        var leafPartPrice = new LeafPartEnumerator(car).Sum(x => x.Price);
        
        var tires = new LeafPartEnumerator(car).OfType<Tire>();
    }

    private Car CreateCarByBuilder() {
        return new CarBuilder(1)
              .AddBody(1)
              .WithColor(1)
              .WithSalon(1,1,1)
              .Build()
              .AddEngine(1)
              .WithTurbo(1)
              .Build()
              .AddWheels(4,1)
              .WithDisk(1)
              .WithTire(1)
              .Build()
              .Build();
    }
}
