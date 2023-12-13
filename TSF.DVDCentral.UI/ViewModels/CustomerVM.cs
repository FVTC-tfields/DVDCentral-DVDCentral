using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.UI.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }

        public List<Customer> Customers { get; set; }
        public int UserId { get; set; }
        public ShoppingCart Cart { get; set; }


    }
}
