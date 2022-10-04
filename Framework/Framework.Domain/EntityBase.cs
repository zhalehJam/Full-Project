using System;


namespace Framework.Domain
{
     public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get;private set; }
    }
}
