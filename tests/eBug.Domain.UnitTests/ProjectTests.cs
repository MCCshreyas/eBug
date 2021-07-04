using eBug.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace eBug.Domain.UnitTests
{
    public class ProjectTests
    {
        [Fact]
        public void Should_CreateProject_WhenCorrectParametersPassed()
        {
            //Arrange
            var name = "project_name";
            
            //Act
            var project = DomainObjectFactory.CreateProject(name);

            //Assert
            project.Id.Should().NotBeEmpty();
            project.Name.Should().BeEquivalentTo(name);
            project.Bugs.Count.Should().Be(0);  
        }

        [Fact]
        public void Should_ThrowException_WhenParametersAreNull()
        {
            // Arrange
            string title = null;
            string anotherTitle = "";

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new Project(title));
            Assert.Throws<ArgumentNullException>(() => new Project(anotherTitle));
        }
    }
}
