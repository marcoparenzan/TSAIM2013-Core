using ITS.IoC.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.IoT.Domain.EntityFramework
{
    public class MyEntityEntityFrameworkRepository
        : IMyEntityRepository
    {
        IoC.Domain.Entities.MyEntity IRepository<IoC.Domain.Entities.MyEntity>.GetById(string id)
        {
            var dbContext = new IoCDbContext();

            var myEntities = dbContext.MyEntities;
            var query = myEntities.AsQueryable();
            query = query.Where(xx => xx.Id == id);
            var result = query.ToList();
            var entity = result.SingleOrDefault();
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Id not found");
            }
        }
    }
}
