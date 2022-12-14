namespace TryOut._02Adapter.Refactored {
    public class OrderRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<OrderDto> table;
        OrderAdapter orderAdapter;

        public OrderRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<OrderDto>();
            orderAdapter = new OrderAdapter();
        }

        public List<Order> GetOrders(int top, Customer customer) {
            var result = dbAccessor.Select(table.Take(top));

            return result.Select(r => orderAdapter.Adapt(r, customer)).ToList();
        }
    }

    public class OrderAdapter {
        public Order Adapt(OrderDto dto, Customer c) {
            return new Order() {
                Id = dto.Id, Customer = c
            };
        }
    }
}