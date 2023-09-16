namespace TryOut.Adapter.StraightCode {
    public class ClientCode {
        public ClientCode() {
            /*
             * This code should remain as is same
             */
            var customers = new CustomerRepo().GetCustomers(10);
            var orders = new OrderRepo().GetOrders(100, customers[0]);
        }
    }
}