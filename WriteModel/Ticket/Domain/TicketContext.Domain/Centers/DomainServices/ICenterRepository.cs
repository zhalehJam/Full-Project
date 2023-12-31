using Framework.Core.Persistence;
using System.Linq.Expressions;

namespace TicketContext.Domain.Centers.DomainServices
{
    public interface ICenterRepository:IRepository
    {
        void Add(Center center);
        void Delete(Center center);
        Center GetByID(Guid id);
        bool IsExist(Expression<Func<Center, bool>> expression);
        void Update(Center center);
    }
}
