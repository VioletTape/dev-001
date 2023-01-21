
namespace TryOut.Commands.Refactored {
    public class Client {
        CommandHandler commandHandler;

        public Client() {
            RegisterDependencies();

            commandHandler.Process(new PlaceOrder(new Product()));

        }

        private void RegisterDependencies() {
            commandHandler = new CommandHandler();

            var notifications = new NotificationService(commandHandler);
            commandHandler.RegisterHandler<SendNotification>(notifications.Handle);

            var orderService = new OrderService(commandHandler);
            commandHandler.RegisterHandler<PlaceOrder>(orderService.Handle);
            commandHandler.RegisterHandler<EvaluateOrder>(orderService.Handle);

            var bomService = new BomService(commandHandler); // BOM - Bill of materials
            commandHandler.RegisterHandler<PlaceOrder>(bomService.Handle);
        }
    }







    public class Product { }
}