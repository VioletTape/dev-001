namespace TryOut.Commands.Refactored; 

public class BomService {
    readonly CommandHandler commandHandler;

    public BomService(CommandHandler commandHandler) {
        this.commandHandler = commandHandler;
    }

    public async Task Handle<T>(T command)
        where T : Command {

        switch (command) {
            case PlaceOrder c:
                await GetMaterials(c.Product);
                return;
        }
    }

    public async Task<object> GetMaterials(Product product) {
        Console.WriteLine("BomService.GetMaterials");
        commandHandler.Process(new EvaluateOrder(new object(), new object()));
        return default; 
    }
}
