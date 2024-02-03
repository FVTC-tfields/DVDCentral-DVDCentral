using System.Xml.Linq;

namespace TSF.DVDCentral.BL
{
    public static class OrderItemManager
    {
        public static int Insert(Guid orderid,
                                 Guid id,
                                 int quantity,
                                 Guid movieid,
                                 int cost,
                                 bool rollback = false)
        {
            try
            {
                OrderItem orderitem = new OrderItem
                {
                    OrderId = orderid,
                    Quantity = quantity,
                    MovieId = movieid,
                    Cost = cost
                };

                int results = Insert(orderitem, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = orderitem.Id; ;

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(OrderItem orderitem, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrderItem entity = new tblOrderItem();

                    //if(dc.tblOrderItems.Any())
                    //{
                    //    entity.Id = dc.tblOrderItems.Max(s => s.Id) + 1;
                    //}
                    //else
                    //{
                    //    entity.Id = 1;
                    //}

                    entity.Id = Guid.NewGuid();
                    entity.Quantity = orderitem.Quantity;
                    entity.MovieId = orderitem.MovieId;
                    entity.Cost = orderitem.Cost;


                    // IMPORTANT - BACK FILL THE ID
                    orderitem.Id = entity.Id;

                    dc.tblOrderItems.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(OrderItem orderitem, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == orderitem.Id);

                    if (entity != null)
                    {
                        entity.Quantity = orderitem.Quantity;
                        entity.MovieId = orderitem.MovieId;
                        entity.Cost = orderitem.Cost;
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        dc.tblOrderItems.Remove(entity);
                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static OrderItem LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new OrderItem
                        {
                            Id = entity.Id,
                            Quantity = entity.Quantity,
                            MovieId = entity.MovieId,
                            Cost = (float)entity.Cost

                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<OrderItem> LoadByOrderId(Guid orderId)
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblOrderItems
                     where s.OrderId == orderId           
          select new
                     {
                         s.Id,
                         s.Quantity,
                         s.MovieId,
                         s.Cost,
                         s.OrderId
                     })
                     .ToList()
                    .ForEach(orderitem => list.Add(new OrderItem
                    {
                        Id = orderitem.Id,
                        Quantity = orderitem.Quantity,
                        MovieId = orderitem.MovieId,
                        Cost = (float)orderitem.Cost,
                        OrderId = orderitem.OrderId
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<OrderItem> Load()
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblOrderItems
                     select new
                     {
                         s.Id,
                         s.Quantity,
                         s.MovieId,
                         s.Cost,
                         s.OrderId
                     })
                     .ToList()
                    .ForEach(orderitem => list.Add(new OrderItem
                    {
                        Id = orderitem.Id,
                        Quantity = orderitem.Quantity,
                        MovieId = orderitem.MovieId,
                        Cost = (float)orderitem.Cost,
                        OrderId = orderitem.OrderId
                    }));
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
