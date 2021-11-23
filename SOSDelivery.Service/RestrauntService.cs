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
    public class RestrauntService
    {
        private readonly Guid _userId;

        public RestrauntService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRestraunt(RestrauntCreate model)
        {
            var entity =
                new Restraunt()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.restraunts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RestrauntListItem> GetRestraunt()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .restraunts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                          new RestrauntListItem
                          {

                              RestrauntId = e.RestrauntId,
                              PhoneNumber = e.PhoneNumber,
                              Name = e.Name
                          }
                          );
                return query.ToArray();
            }
        }

        public RestrauntDetail GetRestrauntById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .restraunts
                    .Single(e => e.RestrauntId == id && e.OwnerId == _userId);
                return
                    new RestrauntDetail
                    {
                        RestrauntId = entity.RestrauntId,
                        Phonenumber = entity.PhoneNumber,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateRestraunt(RestrauntEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .restraunts
                    .Single(e => e.RestrauntId == model.RestrauntId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRestraunt(int RestrauntId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .restraunts
                    .Single(e => e.RestrauntId == RestrauntId && e.OwnerId == _userId);

                ctx.restraunts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
