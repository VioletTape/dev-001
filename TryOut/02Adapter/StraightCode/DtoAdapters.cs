using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryOut.Adapter.StraightCode;

namespace TryOut._02Adapter.StraightCode
{
    internal class CustomerAdapter
    {
        public Customer Adapt(CustomerDto dto)
        {
            return new Customer { Id = dto.Id, Name = dto.Name };
        }
    }

    internal class OrderAdapter
    {
        private static  readonly CustomerAdapter Adapter = new ();

        public Order Adapt(OrderDto dto)
        {
            return new Order { Id = dto.Id, Customer = Adapter.Adapt(dto.Customer) };
        }
    }
}
