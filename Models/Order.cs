﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoMarket.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public bool IsFinaly { get; set;}

        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
