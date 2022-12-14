namespace TryOut._02Adapter.Refactored {
    public class ClientCode {
        public ClientCode() {
            var customers = new CustomerRepo().GetCustomers(10);
            var orders = new OrderRepo().GetOrders(100, customers[0]);
        }
    }
}