using System;
using eBug.Domain.Entities;

namespace eBug.Application.Contracts.Bugs
{
    public record GetAllBugsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public BugStatus CurrentStatus { get; set; }
        
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}