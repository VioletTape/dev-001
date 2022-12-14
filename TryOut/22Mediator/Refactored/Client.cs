namespace TryOut.Mediator.Refactored;

public class Client {
    public Client() {
        var m1 = new User("m1");
        var m2 = new User("m2");
        var m3 = new User("m3");
        var m4 = new User("m4");
        var m5 = new User("m5");

        var messenger = new Messenger();
        messenger.Register(m1);
        messenger.Register(m2);
        messenger.Register(m3);
        messenger.Register(m4);
        messenger.Register(m5);

        messenger.Send("hello", "m1", "m2", "m3");

        messenger.Send("personal message", "m1");
    }
}

public class User : IReciever {
    public string Name { get; init; }

    public User(string name) {
        Name = name;
    }

    public void Accept<T>(T message) {
        Console.WriteLine(Name + " > " + message);
    }
}

public class Messenger : ISender {
    readonly Dictionary<string, IReciever> recievers = new();


    public void Register(IReciever user) {
        recievers.Add(user.Name, user);
    }

    public void Send<T>(T message, params string[]  name) {
        name.ToList().ForEach(n => recievers[n].Accept(message));
    }

}

public interface ISender {
    void Send<T>(T message, params string[] name);
}

public interface IReciever {
    string Name { get; }
    void Accept<T>(T message);
}