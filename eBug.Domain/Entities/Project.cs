using System;
using System.Collections.Generic;
using eBug.Domain.Common;

namespace eBug.Domain.Entities
{
    public class Project : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<Bug> Bugs { get; set; }

        private Project()
        {
            Bugs = new List<Bug>();
        }

        public Project(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;

            Bugs = new List<Bug>();
        }
    }
}