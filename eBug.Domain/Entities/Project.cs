using System.Collections.Generic;
using eBug.Domain.Common;

namespace eBug.Domain.Entities
{
    public class Project : AuditableEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
        
        public IReadOnlyList<Bug> Bugs { get; set; }
    }
}