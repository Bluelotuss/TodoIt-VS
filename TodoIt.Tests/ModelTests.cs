using System;
using Xunit;

namespace TodoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        public void PersonConstructor()
        {
            //Arrange
            int personId = 202020;
            string firstName = "John";
            string lastName = "Doe";

            //Act
            Person result = new Person(personId, firstName, lastName);

            //Assert
            Assert.Contains(personId.ToString(), result.PersonInfomation());
            Assert.Contains(firstName, result.PersonInfomation());
            Assert.Contains(lastName, result.PersonInfomation());

        }

        [Theory]// replace Fact to test with many alternate values that are bad.
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        //[InlineData(" will fail ")]
        public void BadColorsConstructorCar(string firstName, string lastName)
        {
            //Arrange
            int personId = 20312420;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Person(personId, firstName, lastName));

        }

    }

    public class TodoTests
    {
        [Fact]
        public void TodoConstructor()
        {
            //Arrange
            int todoId = 24;
            string description = "nothing";
            //bool done = false;
            //Person assignee = new Person(34, "Jake", "Andersson");

            //Act
            Todo result = new Todo(todoId, description);

            //Assert
            Assert.Equal(todoId.ToString(), result.todoId.ToString());
            Assert.Equal(description, result.Description);
           
            //Assert.Equal(assignee, result.assignee);
        }
    }
}
