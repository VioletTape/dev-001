namespace TryOut.Adapter.StraightCode {
    public class Customer {
        public Customer(CustomerDto customerDto) {
                Id = customerDto.Id;
                Name = customerDto.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Order {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }

        public Order(OrderDto dto) {
            Id = dto.Id;
            Customer = new Customer(dto.Customer);
        }
    }
}