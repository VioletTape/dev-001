using TryOut.Builder.Refactored;

namespace TryOut._09Builder.Refactored.Classical;

public class Director {
    Dictionary<Type, IBuilder> builders = new Dictionary<Type, IBuilder> {
                                                                             {typeof(SportCarBuilder), new SportCarBuilder()}
                                                                           , {typeof(TruckBuilder), new TruckBuilder()}
                                                                         };

    // тут могут подаваться доп зависимости, например 
    // сервис регистрации VIN номеров
    public Director() { }

    public Car Build(IBuilder builder) {
        return builders[builder.GetType()].Result();
    }

    public Car Build<T>() where T : IBuilder {
        return builders[typeof(T)].Result();
    }
}

public interface IBuilder {
    public Car Result();
}

public class SportCarBuilder : IBuilder {
    public Car Result() {
        var car = new Car();
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Body()); // тут может быть вариативность кабин

        // ... 

        return car;
    }
}

public class TruckBuilder :IBuilder{
    public Car Result() {
        var car = new Car();
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Wheel());
        car.Add(new Body()); // тут может быть вариативность кабин

        // ... 

        return car;
    }
}
