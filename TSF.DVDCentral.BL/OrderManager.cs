﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TSF.DVDCentral.BL.Models;
using TSF.DVDCentral.PL;

namespace TSF.DVDCentral.BL
{
    public static class OrderManager
    {
        public static int Insert(int orderid,
                                 int userid,
                                 ref int id,
                                 bool rollback = false)
        {
            try
            {
                Order order = new Order
                {
                    CustomerId = orderid,
                    OrderDate = DateTime.Now,
                    ShipDate = DateTime.Now,
                    UserId = userid
                };

                int results = Insert(order, rollback);

                // IMPORTANT - BACKFILL THE REFERENCE ID
                id = order.Id; ;

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder entity = new tblOrder();
                    entity.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(s => s.Id) + 1 : 1;
                    entity.CustomerId = order.CustomerId;
                    entity.OrderDate = DateTime.Now;
                    entity.ShipDate = DateTime.Now;
                    entity.UserId = order.UserId;
                    dc.tblOrders.Add(entity);

                    var orderItemId = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(s => s.Id) + 1 : 1;
                    foreach (var orderItem in order.OrderItems) 
                    { 
                        tblOrderItem entityItem = new tblOrderItem();
                        entityItem.Id = orderItemId;
                        entityItem.OrderId = entity.Id;
                        entityItem.MovieId = orderItem.MovieId;
                        entityItem.Quantity = orderItem.Quantity;
                        entityItem.Cost = orderItem.Cost;
                        dc.tblOrderItems.Add(entityItem);

                        orderItem.OrderId = entity.Id;
                        orderItemId++;
                    }

                    // IMPORTANT - BACK FILL THE ID
                    order.Id = entity.Id;

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

        public static int Update(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == order.Id);

                    if (entity != null)
                    {
                        entity.CustomerId = order.CustomerId;
                        entity.OrderDate = DateTime.Now;
                        entity.ShipDate = DateTime.Now;
                        entity.UserId = order.UserId;
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

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        dc.tblOrders.Remove(entity);
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

        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);

                    if (entity != null)
                    {
                        return new Order
                        {
                            Id = entity.Id,
                            CustomerId = entity.CustomerId,
                            OrderDate = entity.OrderDate,
                            ShipDate = entity.ShipDate,
                            UserId = entity.UserId,
                            OrderItems = OrderItemManager.LoadByOrderId(id)
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

        public static List<Order> Load(int? customerId = null)
        {
            try
            {
                List<Order> list = new List<Order>();

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblOrders
                     where s.CustomerId == customerId || customerId == null
                     select new
                     {
                         s.Id,
                         s.CustomerId,
                         s.OrderDate,
                         s.ShipDate,
                         s.UserId
                     })
                     .ToList()
                    .ForEach(order => list.Add(new Order
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        ShipDate = order.ShipDate,
                        UserId = order.UserId
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
