namespace TryOut.Adapter.StraightCode {
    public class ClientCode {
        public ClientCode() {
            /*
             * This code should remain as is same
             * Код должен остаться как есть в этой части
             */
            var customers = new CustomerRepo().GetCustomers(10);
            var orders = new OrderRepo().GetOrders(100, customers[0]);
        }
    }
}