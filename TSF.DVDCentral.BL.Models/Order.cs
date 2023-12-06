using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.DVDCentral.BL.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DisplayName("Customer Id")]

        public int CustomerId { get; set; }

        [DisplayName("Order Date")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime OrderDate { get; set; }

        [DisplayName("Ship Date")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime ShipDate { get; set; }

        [DisplayName("User Id")]

        public int UserId { get; set; }

        public List<OrderItem> OrderItems { get; set;} = new List<OrderItem>();


    }
}
