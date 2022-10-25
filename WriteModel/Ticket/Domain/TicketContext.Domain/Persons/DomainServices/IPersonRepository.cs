using Framework.Core.Persistence;
using System.Linq.Expressions;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersonRepository : IRepository
    {
        void Add(Person person);
        void Delete(Person person);
        Person GetByID(Guid id);
        Person GetByPersonID(Expression<Func<Person, bool>> expression);
        bool IsExist(Expression<Func<Person, bool>> expression);
        void Update(Person person);
    }
    
}
