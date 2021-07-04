using System;
using eBug.Domain.Common;

namespace eBug.Domain.Entities
{
    /// <summary>
    /// A domain entity represents a Bug 
    /// </summary>
    public class Bug : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set;}
        public string Description { get; private set; }
        public DateTime RaisedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public BugStatus CurrentStatus { get; private set; }

        public Guid ProjectId { get; private set; }
        public Project Project { get; set; }

        private Bug()
        {
        }

        public Bug(string title, string description, Guid projectId)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if(projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            RaisedDate = DateTime.UtcNow;
            CurrentStatus = BugStatus.Active;
            ProjectId = projectId;
        }

        public void ChangeStatus(BugStatus bugStatus)
        {
            CurrentStatus = bugStatus; 
        }

        public void SetDescription(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            Description = description;
        }

        public void MoveToAnotherProject(Guid projectId)
        {
            if(projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }

            ProjectId = projectId;
        }
    }
}