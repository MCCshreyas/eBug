using System;

namespace eBug.Domain.Common
{
    /// <summary>
    /// A abstract class for auditing.
    /// </summary>
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}