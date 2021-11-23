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
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    Price = model.Price,
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.products.Add(entity);
                return ctx.SaveChanges() ==1;
            }
        }
        
        public IEnumerable<ProductListItem> GetProducts()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .products
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                           ProductId = e.ProductId,
                           Name = e.Name,
                           Price = e.Price,
                        }
                        );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById( int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .products
                    .Single(e => e.ProductId == id && e.OwnerId == _userId);
                return
                new ProductDetail
                {
                    Price = (int)entity.Price,
                    Name = entity.Name


                };
               

                

            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .products
                    .Single(e => e.ProductId == model.ProductId && e.OwnerId == _userId);

                entity.Price = model.Price;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;


            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .products
                    .Single(e => e.ProductId == productId && e.OwnerId == _userId);

                ctx.products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
