namespace TryOut.Adapter.Refactored {
    // public class CustomerDto
    // {
    //     public Guid Id { get; set; }
    //     public string FullName { get; set; }
    // }

    public class Customer {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        // public string FirstName { get; set; }

        // List<Phone> Phones = new List<Phone>();
        //
        // public Customer(Guid id) {
        //     Id = id;
        // }
        //
        // AddNewPhone(...) {
        //     // validate number
        //     // check dups 
        //     Phones.Add();
        // }
    }



    public class Order {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
    }
}