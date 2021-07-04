using eBug.Domain.Entities;
using System;

namespace eBug.Domain.UnitTests
{
    public static class DomainObjectFactory
    {
        public static Bug CreateBug(string title, string desc, Guid projectId)
        {
            return new Bug(title, desc, projectId);
        }

        public static Project CreateProject(string title)
        {
            return new Project(title);
        }
    }
}
