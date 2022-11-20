using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.Infrastructure.Programs
{
    public class ProgramRepository : RepositoryBase<Program>, IProgramRepository
    {
        public ProgramRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Program program)
        {
            base.Create(program);
        }
        public void Update(Program program)
        {
            base.Update(program);
        }

        public bool IsExist(Expression<Func<Program, bool>> expression)
        {
            return _dbContext.Set<Program>().Any(expression);
        }

        protected override IEnumerable<Expression<Func<Program, object>>> GetAggregateExpression()
        {
            yield return n => n.ProgramSupporters;
        }

        Program IProgramRepository.GetById(Guid id)
        {
            return base.GetById(id);
        }

        public void Delete(Program program)
        {
            base.Remove(program);
        }
    }
}
