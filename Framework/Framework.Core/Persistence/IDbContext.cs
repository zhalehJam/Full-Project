using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Persistence
{
    public  interface IDbContext:IDisposable
    {
        int SaveChanges();
        void Migrate();
    }
}
