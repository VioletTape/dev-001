namespace TryOut.Commands.StraightCode {

        public class Client {
            public Client() {
                var notifications = new NotificationService();
                var orderService = new OrderService();
                var bomService = new BomService(); // BOM - Bill of materials
                var processing = new ProcessingController(orderService, bomService, notifications);

                var order = processing.PlaceOrder(new Product());
            }
        }

        public class NotificationService {
            public void Send(Notification notification) {
                Console.WriteLine("NotificationService - done");
            }
        }

        public class OrderService {
            public async Task<object> CreateOrder(Product product) {
                Console.WriteLine("OrderService.CreateOrder");

                return new object();
            }

            public async Task Evaluate(object materials) {
                Console.WriteLine("OrderService.Evaluate");
            }
        }

        public class BomService {
            public async Task<object> GetMaterials(Product product) {
                Console.WriteLine("BomService.GetMaterials");
                return default;
            }
        }

        public class Notification { }

        public class Product { }
    
}