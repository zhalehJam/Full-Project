using Framework.Core.Persistence;
using System.Linq.Expressions;

namespace TicketContext.Domain.Programs.DomainServices
{
    public interface IProgramRepository:IRepository
    {
        void Add(Program program);
        Program GetById(Guid id);
        bool IsExist(Expression<Func<Program, bool>> expression);
        void Update(Program program);
    }
}
