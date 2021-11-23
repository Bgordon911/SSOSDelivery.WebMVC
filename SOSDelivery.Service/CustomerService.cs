

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
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId,
                    PhoneNumber = model.PhoneNumber,
                    Name = model.Name
                }; 
            using (var ctx = new ApplicationDbContext())
            {
                ctx.customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable <CustomerlistItem> GetCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .customers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CustomerlistItem
                        {
                            Name = e.Name,
                            PhoneNumber = e.PhoneNumber,
                            CustomerId = e.CustomerID
                            
                        }
                        );
                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .customers
                    .Single(e => e.CustomerID == id && e.OwnerId == _userId);
                return
                    new CustomerDetail
                    {
                       
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        Name = entity.Name
                    };
            }

            
            

            
           
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .customers
                    .Single(e => e.CustomerID == model.CustomerID && e.OwnerId == _userId);

                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Name = model.Name;
              
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .customers
                    .Single(e => e.CustomerID == customerid && e.OwnerId == _userId);

                ctx.customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        






    }


}
