using Framework.Core.Persistence;
using Framework.Persistence;
using System.Linq.Expressions;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Infrastructure.Persons
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Person person)
        {
            base.Create(person);
        }

        public void Delete(Person person)
        {
            base.Remove(person);
        }

        public Person GetByID(Guid id)
        {
            return base.GetById(id);
        }
        public Person GetByPersonID(Expression<Func<Person, bool>> expression)
        {
             return _dbContext.Set<Person>().Where(expression).Select(n=>n).FirstOrDefault();
        }

        public bool IsExist(Expression<Func<Person, bool>> expression)
        {
            return _dbContext.Set<Person>().Any(expression);

        }

        protected override IEnumerable<Expression<Func<Person, object>>> GetAggregateExpression()
        {
            return null; 
        }
    }
}
    