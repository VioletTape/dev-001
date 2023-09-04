

namespace TryOut.Commands.StraightCode {
    public class ProcessingController {
        readonly OrderService orderService;
        readonly BomService bomService;
        readonly NotificationService notifications;

        public ProcessingController(OrderService orderService, BomService bomService, NotificationService notifications) {
            this.orderService = orderService;
            this.bomService = bomService;
            this.notifications = notifications;
        }

        public async Task<object> PlaceOrder(Product product) {

            var materials = await bomService.GetMaterials(product);
            var order = await orderService.CreateOrder(product);

            await orderService.Evaluate(materials);

            notifications.Send(new Notification());

            return new object();
        }
    }
}