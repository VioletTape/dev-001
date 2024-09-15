namespace TryOut._02Adapter.RefactoredWithSpec {
    public class ClientCode {
        public ClientCode() {
            var customers = new CustomerRepo().Get(new TopSpecification<Customer>(10));
            var orders = new OrderRepo().Get(new TopSpecification<Order>(10) & new OrderForCustomer(customers[0]));
        }
    }
    // пример использования фасада для спецификации. 
    // фасад должен знать как и что потом делать

    // public class DataFacade {
    //     private Dictionary<T, IAdapter<T>> adapters = new Dictionary<T, IAdapter<T>> {
    //         typeof(Customer, new CustomerAdapter())
    //     }
    //
    //     List<T> Get(Specification<T> spec) {
    //        return adapters[typeof(T)].Get(spec);
    //     }
    //
    //     public void Commit(IUnitOfWork uow) {
    //
    //     }
    // }
}