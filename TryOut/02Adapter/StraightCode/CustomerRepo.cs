using TryOut._02Adapter.StraightCode;

namespace TryOut.Adapter.StraightCode {
    public class CustomerRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<CustomerDto> table;
        private readonly CustomerAdapter customerAdapter;

        public CustomerRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<CustomerDto>();
            customerAdapter = new CustomerAdapter();
        }

        public List<Customer> GetCustomers(int top) {
            var result = dbAccessor.Select(table.Take(top));

           return result.Select(customerAdapter.Adapt).ToList();
        }

        public List<Customer> GetCustomers(int top, string nameStartsFrom) {
            var query = table.Take(top).Where(c => c.Name.StartsWith(nameStartsFrom));
            var result = dbAccessor.Select(query);

            return result.Select(customerAdapter.Adapt).ToList();
        }
    }
}