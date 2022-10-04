using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.ApplicationService
{
   public abstract class Command
    {
        protected Command()
        {
            ExecuteDateTime=DateTime.Now;
        }

        public DateTime ExecuteDateTime { get;  }
    }
}
