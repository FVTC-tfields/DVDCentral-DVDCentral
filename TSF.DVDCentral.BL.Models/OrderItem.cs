using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.DVDCentral.BL.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        [DisplayName("Order Id")]
        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        [DisplayName("Movie Id")]
        public Guid MovieId { get; set; }

        public float Cost { get; set; }
        
        public string? ImagePath { get; set; }

        public string? Description { get; set; }

        public string? Title { get; set; }

    }
}
