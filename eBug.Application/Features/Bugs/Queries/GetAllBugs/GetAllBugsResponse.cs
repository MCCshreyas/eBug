using System;
using eBug.Domain.Entities;

namespace eBug.Application.Features.Bugs.Queries.GetAllBugs
{
    public class GetAllBugsResponse
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime ResolvedDate { get; set; }
        public BugStatus CurrentStatus { get; set; }
        
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}