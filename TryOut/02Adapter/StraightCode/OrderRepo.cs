using TryOut._02Adapter.StraightCode;

namespace TryOut.Adapter.StraightCode {
    public class OrderRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<OrderDto> table;
        private readonly OrderAdapter orderAdapter;

        public OrderRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<OrderDto>();
            orderAdapter = new OrderAdapter();
        }

        public List<Order> GetOrders(int top) {
            var result = dbAccessor.Select(table.Take(top));

            return result.Select(orderAdapter.Adapt).ToList();
        }

        public List<Order> GetOrders(int top, Guid customerId) {
            var query = table.Take(top).Where(o => o.Customer.Id == customerId);
            var result = dbAccessor.Select(query);

            return result.Select(orderAdapter.Adapt).ToList();
        }
    }
}