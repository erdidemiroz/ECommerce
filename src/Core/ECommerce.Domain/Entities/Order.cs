using ECommerce.Domain.Common;
using ECommerce.Domain.Enums;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities
{
    public class Order(Guid customerId, Address shippingAddress) : BaseEntity
    {
        public Guid CustomerId { get; private set; } = customerId;
        public Address ShippingAddress { get; private set; } = shippingAddress;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    }
}