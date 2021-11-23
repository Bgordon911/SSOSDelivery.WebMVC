using SOSDelivery.Data;
using SSOSDelivery.Data;
using SSOSDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSDelivery.Service
{

    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    OwnerId = _userId,
                    ProductId = model.ProductId,
                    OrderID = model.OrderID,
                    CustomerID = model.CustomerID
      

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .orders
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new OrderListItem
                        {
                           OrderID = e.OrderID,
                            ProductId = e.ProductId
                        }
                        );
                return query.ToArray();
            }
        }

        public OrderDetail GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .orders
                    .Single(e => e.OrderID == id && e.OwnerId == _userId);
                return
                new OrderDetail
                {
                    ProductId = entity.ProductId
                };
            }





        }

        public bool UpdateOrder(OrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .orders
                    .Single(e => e.OrderID == model.OrderID && e.OwnerId == _userId);

                entity.ProductId = model.ProductId;

                return ctx.SaveChanges() == 1;
            }


        }

        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .orders
                    .Single(e => e.OrderID == orderId && e.OwnerId == _userId);

                ctx.orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}



