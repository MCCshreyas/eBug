using System;
using eBug.Domain.Common;

namespace eBug.Domain.Entities
{
    public class Bug : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public BugStatus CurrentStatus { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}