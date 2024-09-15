namespace TryOut._02Adapter.Refactored {
    public class CustomerRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<CustomerDto> table;
        CustomerAdapter customerAdapter;

        public CustomerRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<CustomerDto>();
            customerAdapter = new CustomerAdapter();
        }

        public List<Customer> GetCustomers(int top) {
            var result = dbAccessor.Select(table.Take(top));

            // используем адаптер
            return result.Select(r => customerAdapter.Adapt(r)).ToList();

            
        }

        public List<Customer> GetCustomers(int top, string nameStartsFrom) {
            var query = table.Take(top).Where(c => c.Name.StartsWith(nameStartsFrom));
            var result = dbAccessor.Select(query);

            // используем адаптер
            return result.Select(r => customerAdapter.Adapt(r)).ToList();
        }
    }

    public class CustomerAdapter {
        public Customer Adapt(CustomerDto dto) {
            return new Customer {
                Id = dto.Id, Name = dto.Name
            };
        }
    }
}