using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Infrastructure.Centers
{
    public class CenterRepository : RepositoryBase<Center>, ICenterRepository
    {
        public CenterRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Center center)
        {
            base.Create(center);
        }

        public void Delete(Center center)
        {
            //throw new NotImplementedException();
        }

        public Center GetByID(Guid ID)
        {
            return base.GetById(ID);
        }

        public bool IsExist(Expression<Func<Center, bool>> expression)
        { 
                return _dbContext.Set<Center>().Any(expression);
        }

        protected override IEnumerable<Expression<Func<Center, object>>> GetAggregateExpression()
        {
            throw new NotImplementedException();
        }
    }
}
