﻿using CQRS.Domain.SeedWork;

namespace CQRS.Domain.Customers.Orders.Events
{
    public class OrderChangedEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public OrderChangedEvent(OrderId orderId)
        {
            OrderId = orderId;
        }
    }
}