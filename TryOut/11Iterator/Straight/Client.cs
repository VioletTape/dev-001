
namespace TryOut._11Iterator.Straight; 

public class Client {
    public Client() {
        var car = CreateCarByBuilder();
        var carParts = car.GetParts();

        var leafElementsPrice = 0m;
        foreach (var part in carParts) {
            if (part is Node) {
                leafElementsPrice += part.Price;
            }

            foreach (var p1 in part.GetParts()) {
                if (p1 is Node) {
                    leafElementsPrice += part.Price;
                }

                foreach (var p2 in p1.GetParts()) {
                    if (p2 is Node) {
                        leafElementsPrice += part.Price;
                    }

                    //...
                }
            }
        }
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
