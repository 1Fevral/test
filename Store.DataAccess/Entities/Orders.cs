﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int PaymentId { get; set; }

        [ForeignKey(nameof(PaymentId))]
        [InverseProperty(nameof(Payments.Orders))]
        public virtual Payments Payment { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Orders))]
        public virtual Users User { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
