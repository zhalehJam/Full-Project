using Framework.Core.Persistence;
using Framework.Persistence;
using System.Linq.Expressions;
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
            base.Remove(center);
        }

        public Center GetByID(Guid ID)
        {
            return base.GetById(ID);
        }

        public bool IsExist(Expression<Func<Center, bool>> expression)
        {
            return _dbContext.Set<Center>().Any(expression);
        }

        public void Update(Center center)
        {
            base.Update(center);
        }

        protected override IEnumerable<Expression<Func<Center, object>>> GetAggregateExpression()
        {
            yield return n => n.Parts;
        }
    }
}
