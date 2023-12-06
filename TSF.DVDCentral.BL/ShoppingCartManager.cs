using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSF.DVDCentral.BL.Models;

namespace TSF.DVDCentral.BL
{
    public class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Items.Add(movie); }
        }

        public static void Remove(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Items.Remove(movie); }
        }

        public static void Checkout(ShoppingCart cart)
        {
            // Make a new order
            // Set the Order fields as needed.

            // foreach(Movie item in cart.Items)
            //
            // Make a new orderitem
            // Set the orderitem fields from the item
            // order.OrderItems.Add(orderItem)

            // OrderManager.Insert(order)

            // Decrement the tblMovie.InStkQty appropriately

            cart = new ShoppingCart();

        }
    }
}
