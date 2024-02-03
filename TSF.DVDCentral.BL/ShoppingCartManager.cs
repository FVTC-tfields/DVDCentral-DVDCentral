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

        public static void Checkout(ShoppingCart cart, Guid userId, Guid customerId)
        {
            try
            {
                if (cart.Items.Count > 0)
                {
                    Order order = new Order();
                    order.UserId = userId;
                    order.OrderDate = DateTime.Now;
                    order.ShipDate = DateTime.Now.AddDays(3);
                    order.CustomerId = customerId;

                    foreach (Movie item in cart.Items)
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.MovieId = item.Id;
                        orderItem.OrderId = order.Id;
                        orderItem.Quantity = 1;
                        orderItem.Cost = item.Cost;

                        order.OrderItems.Add(orderItem);
                    }

                    OrderManager.Insert(order);

                    cart.Items = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            // Make a new order
            // Set the Order fields as needed.

            // foreach(Movie item in cart.Items)

            // Make a new orderitem
            // Set the orderitem fields from the item
            // order.OrderItems.Add(orderItem)

            // OrderManager.Insert(order)

            // Decrement the tblMovie.InStkQty appropriately

            cart = new ShoppingCart();

        }
    }
}
