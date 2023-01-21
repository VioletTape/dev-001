namespace TryOut.Commands.Refactored;

public class PlaceOrder : Command {
    public Product Product { get; }

    public PlaceOrder(Product product) {
        Product = product;
    }
}

public class EvaluateOrder : Command {
    public object Order { get; }
    public object Materials { get; }

    public EvaluateOrder(object order, object materials) {
        Order = order;
        Materials = materials;
    }
}

public class OrderService {
    readonly CommandHandler commandHandler;

    public OrderService(CommandHandler commandHandler) {
        this.commandHandler = commandHandler;
    }

    public async Task Handle<T>(T command)
        where T : Command {
        switch (command) {
            case PlaceOrder c:
                await CreateOrder(c.Product);
                return;
            case EvaluateOrder c:
                await Evaluate(c.Materials);
                return;
        }
    }


    public async Task<object> CreateOrder(Product product) {
        Console.WriteLine("OrderService.CreateOrder");
        return new object();
    }

    public async Task Evaluate(object materials) {
        Console.WriteLine("OrderService.Evaluate");
        commandHandler.Process(new SendNotification("done"));
    }
}
