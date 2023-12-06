using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TSF.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        // Movie application specific - Movie Cost
        const double ITEM_COST = 5;

        public List<Movie> Items { get; set; } = new List<Movie>();
        public int NumberOfItems { get { return Items.Count; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double SubTotal { get { return Items.Count * ITEM_COST; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return SubTotal * .055; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return SubTotal + Tax; } }
    }
}
