﻿namespace TryOut.Adapter.Refactored {
    public class ClientCode {
        public ClientCode() {
            var customers = new CustomerRepo().Get(new TopSpecification<Customer>(10));
            var orders = new OrderRepo().Get(new TopSpecification<Order>(10) & new OrderForCustomer(customers[0]));
        }
    }

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