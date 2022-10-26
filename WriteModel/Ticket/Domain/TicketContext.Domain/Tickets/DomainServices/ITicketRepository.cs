using Framework.Core.Persistence;
using System.Linq.Expressions;
using TicketContext.Domain.Centers;

namespace TicketContext.Domain.Tickets.DomainServices
{
    public interface ITicketRepository : IRepository
    {
        void Add(Ticket ticket);
        void Delete(Ticket ticket);
        Ticket GetByID(Guid id);
        bool IsExist(Expression<Func<Ticket, bool>> expression);
        void Update(Ticket ticket);
    }
}
