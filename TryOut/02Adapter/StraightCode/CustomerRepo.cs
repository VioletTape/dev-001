namespace TryOut.Adapter.StraightCode {
    public class CustomerRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<CustomerDto> table;

        public CustomerRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<CustomerDto>();
        }

        public List<Customer> GetCustomers(int top) {
            var result = dbAccessor.Select(table.Take(top));

           return result.Select(r => new Customer(r)).ToList();

            
        }

        public List<Customer> GetCustomers(int top, string nameStartsFrom) {
            var query = table.Take(top).Where(c => c.Name.StartsWith(nameStartsFrom));
            var result = dbAccessor.Select(query);

            return result.Select(r => new Customer(r)).ToList();
        }
    }
}