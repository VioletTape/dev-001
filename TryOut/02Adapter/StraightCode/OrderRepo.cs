namespace TryOut.Adapter.StraightCode {
    public class OrderRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<OrderDto> table;

        public OrderRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<OrderDto>();
        }

        public List<Order> GetOrders(int top) {
            var result = dbAccessor.Select(table.Take(top));

            return result.Select(r => new Order(r)).ToList();
        }

        public List<Order> GetOrders(int top, Customer customer) {
            var query = table.Take(top).Where(o => o.Customer.Id == customer.Id);
            var result = dbAccessor.Select(query);

            return result.Select(r => new Order(r)).ToList();
        }
    }
}