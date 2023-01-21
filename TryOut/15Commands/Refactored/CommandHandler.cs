namespace TryOut.Commands.Refactored;

public class CommandHandler {
    readonly Dictionary<Type, List<Func<Command, Task>>> register;

    public CommandHandler() {
        register = new Dictionary<Type, List<Func<Command, Task>>>();
    }

    public void RegisterHandler<T>(Func<Command, Task> handle)
        where T: Command {
        var type = typeof(T);
        if (!register.ContainsKey(type)) {
            register.Add(type, new List<Func<Command, Task>>());
        }

        register[type].Add(handle);
    }

    public void Process<T>(T command) where T : Command{
        if (register.TryGetValue(typeof(T), out var handlers)) {
            handlers.ForEach(h => h.Invoke(command));
        }
    }
}
