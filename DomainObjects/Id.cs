using System;
using System.ComponentModel;

namespace DomainDrivenDesign.DomainObjects
{
    public class Id<T> : PrimaryKey<T> where T : Entity<T>
    {
        private readonly Guid _guid;

        public static Id<T> New() => new Id<T>(Guid.NewGuid());

        public static Id<T> Create(Guid id) => new Id<T>(id);

        private Id() : base(Guid.NewGuid()) { }

        private Id(Guid guid) : base(guid) 
        {
            _guid = guid;
        }

        public Guid ToGuid() => _guid;
    }

    public class Id<T, TType> : PrimaryKey<T> where T : Entity<T>
    {
        protected Id(TType id) : base(id) { }
    }
}
