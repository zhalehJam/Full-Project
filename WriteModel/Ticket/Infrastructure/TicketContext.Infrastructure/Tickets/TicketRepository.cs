using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Tickets;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Infrastructure.Tickets
{
    public class TicketRepository : RepositoryBase<Ticket>,ITicketRepository
    {
        public TicketRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Ticket ticket)
        {
            _dbContext.Add(ticket);
        }

        public void Delete(Ticket ticket)
        {
            _dbContext.Remove(ticket);
        }

        public Center GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Expression<Func<Ticket, bool>> expression)
        {
            return _dbContext.Set<Ticket>().Any(expression);
        }

        public void Update(Ticket ticket)
        {
            _dbContext.Update(ticket);
        }

        protected override IEnumerable<Expression<Func<Ticket, object>>> GetAggregateExpression()
        {
            return null;   
        }
    }
}
