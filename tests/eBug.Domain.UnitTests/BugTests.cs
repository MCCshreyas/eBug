using eBug.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace eBug.Domain.UnitTests
{
    public class BugTests
    {
        [Fact]
        public void Should_CreateBug_WhenCorrectParametersPassed()
        {
            // Arrange 
            string title = "bug_title";
            string description = "bug_description";
            Guid projectId = Guid.NewGuid();

            // Act 
            var testBug = DomainObjectFactory.CreateBug(title, description, projectId);

            // Asset
            testBug.Title.Should().BeEquivalentTo(title);
            testBug.Description.Should().BeEquivalentTo(description);
            testBug.Id.Should().NotBeEmpty();
            testBug.CurrentStatus.Should().Be(BugStatus.Active);
            testBug.ProjectId.Should().Be(projectId);
        }

        [Fact]
        public void Should_ThrowException_WhenParametersAreNull()
        {
            // Arrange
            string title = null;
            string description = null;

            string anotherTitle = "";
            string anotherDescription = "";

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new Bug(title, description, Guid.Empty));
            Assert.Throws<ArgumentNullException>(() => new Bug(anotherTitle, anotherDescription, Guid.Empty));
        }

        [Fact]
        public void Should_ChangeStatus_WhenCorrectStatusPassed()
        {
            string title = "bug_title";
            string description = "bug_desc";

            var bug = DomainObjectFactory.CreateBug(title, description, Guid.NewGuid());

            bug.CurrentStatus.Should().Be(BugStatus.Active);
            bug.ChangeStatus(BugStatus.Resolved);
            bug.CurrentStatus.Should().Be(BugStatus.Resolved);
        }


        [Fact]
        public void Should_ChangeDescription_WhenPassed()
        {
            string title = "bug_title";
            string description = "bug_description";
            Guid projectId = Guid.NewGuid();

            string newDescription = "new_desc";

            var bug = DomainObjectFactory.CreateBug(title, description, projectId);
            bug.Description.Should().BeEquivalentTo(description);

            bug.SetDescription(newDescription);
            bug.Description.Should().BeEquivalentTo(newDescription);
        }

        [Fact]
        public void Should_ChangeProject_WhenPassed()
        {
            var projectId = Guid.NewGuid();
            var anotherProject = Guid.NewGuid();

            var bug = DomainObjectFactory.CreateBug("bug", "desc", projectId);
            bug.ProjectId.Should().Be(projectId);

            bug.MoveToAnotherProject(anotherProject);
            bug.ProjectId.Should().Be(anotherProject);
        }
    }
}
