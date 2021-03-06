﻿using System;

namespace ManicOceanic.DOMAIN.Entities.Sales
{
    public class Order
  {
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public Guid CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public EPayment PaymentType { get; set; }
    public Shipping Shipping { get; set; }
    public int ShippingId { get; set; }
    public decimal Tax { get; set; }
    public decimal TotalCost { get; set; }
  }

}
