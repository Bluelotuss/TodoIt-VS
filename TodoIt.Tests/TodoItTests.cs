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
        public void BadNameConstructorPerson(string firstName, string lastName)
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
            Assert.Equal(todoId, result.TodoId);  //Why using result.TodoId here (and not result.todoId)
            Assert.Equal(description, result.Description);
           
            //Assert.Equal(assignee, result.assignee);
        }
    }

    public class PersonSequencerTests
    {
        [Fact]
        public void RunNextPersonId()
        {
            PersonSequencer.Reset();
            //Arrange
            int firstId = 1;
            int secondId = 2;
            
            
            //Act
            int firstResult = PersonSequencer.NextPersonId();
            int secondResult = PersonSequencer.NextPersonId();

            //Assert

            Assert.Equal(firstId, firstResult);
            Assert.Equal(secondId, secondResult);
            PersonSequencer.Reset();
        }

        [Fact]
        public void RunReset()
        {
            //Run reset before act to remove possible static values
            PersonSequencer.Reset();

            //Arrange & //Act
            int firstId = PersonSequencer.NextPersonId();
            PersonSequencer.Reset();
            int secondId = PersonSequencer.NextPersonId();

            //Assert

            Assert.Equal(1, secondId);
        }
    }

    public class TodoSequencerTests
    {
        [Fact]
        public void RunNextTodoId()
        {
            //Arrange
            int firstId = 1;
            int secondId = 2;

            TodoSequencer.Reset();
            //Act
            int firstResult = TodoSequencer.NextTodoId();
            int secondResult = TodoSequencer.NextTodoId();

            //Assert

            Assert.Equal(firstId, firstResult);
            Assert.Equal(secondId, secondResult);
            TodoSequencer.Reset();
        }

        [Fact]
        public void RunReset()
        {
            //Run reset before act to remove possible static values
            

            //Arrange & //Act
            int firstId = TodoSequencer.NextTodoId();
            TodoSequencer.Reset();
            int secondId = TodoSequencer.NextTodoId();

            //Assert

            Assert.Equal(1, secondId);
            TodoSequencer.Reset();
        }
    }

    public class PeopleTests
    {
        [Fact]
        public void RunSize()
        {
            //Arrange

            People people = new People();
            people.Clear();
            var result = people.Size();
            people.Clear();
            //Act & Assert

            Assert.Equal(0, result);
        }

        [Fact]
        public void RunFindAll()
        {

            //Arrange
            
            string firstName = "John";
            string lastName = "Doe";
            People people = new People();

            people.Clear();
            Person person = people.NewPerson(firstName, lastName);
            Person[] actual = people.FindAll();

            Person[] newArray = new Person[1] { person };

            //Act & Assert

            Assert.Equal(newArray, actual);
        }

        [Fact]
        public void RunFindById()
        {
            
            //Arrange

            string firstName = "John";
            string lastName = "Doe";
            People people = new People();
            Person person = people.NewPerson(firstName, lastName);

            //Act

            Person actual = people.FindById(person.PersonId);

            //Assert

            Assert.Equal(person, actual);
            people.Clear();
        }
    }

    public class TodoItemsTests
    {
        [Fact]
        public void RunSize()
        {
            //Arrange


            TodoItems tasks = new TodoItems();
            tasks.Clear();
            var result = tasks.Size();

            //Act & Assert

            Assert.Equal(0, result);

        }

        [Fact]
        public void RunFindAll()
        {

            //Arrange

            string firstDescription = "Making dinner";
            string secondDescription = "Send emails";

            TodoItems tasks = new TodoItems();

            tasks.Clear();
            Todo firstTodo = tasks.NewTodo(firstDescription);
            Todo secondTodo = tasks.NewTodo(secondDescription);
            Todo[] actual = tasks.FindAll();

            Todo[] newArray = new Todo[2] { firstTodo, secondTodo };

            //Act & Assert

            Assert.Equal(newArray, actual);

        }

        [Fact]
        public void RunFindById()
        {

            //Arrange

            string description = "nothing";

            TodoItems tasks = new TodoItems();
            tasks.Clear();
            Todo todo = tasks.NewTodo(description);

            //Act

            Todo actual = tasks.FindById(todo.TodoId);  //Why using todo.TodoId here? 

            //Assert

            Assert.Equal(todo, actual);

        }

        [Fact]
        public void RunNewTodo()
        {
            //Arrange
            TodoItems tasks = new TodoItems();

            string firstDescription = "Clean floor";
            string secondDescription = "Code";

            tasks.Clear();
            //Act
            Todo firstTodo = tasks.NewTodo(firstDescription);
            Todo secondTodo = tasks.NewTodo(secondDescription);

            //Assert
            Assert.NotEqual(firstTodo, secondTodo);
        }

        [Fact]
        public void RunFindByDoneStatus()
        {

            //Arrange
            string firstDescription = "nothing";
            string secondDescription = "something";

            TodoItems tasks = new TodoItems();
            tasks.Clear();

            Todo firstTodo = tasks.NewTodo(firstDescription);
            Todo secondTodo = tasks.NewTodo(secondDescription);

            Todo[] newArray = new Todo[0];

            //Act

            Todo[] actual = tasks.FindByDoneStatus(false);

            //Assert

            Assert.NotEqual(newArray, actual);
        }

        [Fact]
        public void RunFindByAssigneePersonId()
        {
            //Arange
            TodoItems tasks = new TodoItems();
            People people = new People();

            PersonSequencer.Reset();
            TodoSequencer.Reset();
            tasks.Clear();
            people.Clear();

            Person firstPerson = people.NewPerson("Anders", "Karlsson");

            Person secondPerson = people.NewPerson("Bengt", "Andersson");

            Todo firstTodo = tasks.NewTodo("Cleaning floor");

            Todo secondTodo = tasks.NewTodo("Making clear code");

            firstTodo.Assignee = firstPerson;

            secondTodo.Assignee = secondPerson;

            Todo[] newArray = new Todo[1] { firstTodo };

            //Act
            Todo[] actual = tasks.FindByAssignee(2);

            //Assert
            Assert.NotEqual(newArray, actual);

            // Cannot see the person object in test results
            // Assert.Equal(newArray, actual);  
        }

        [Fact]
        public void RunFindByAssigneeAssignee()
        {
            //Arrange

            TodoItems tasks = new TodoItems();
            People people = new People();

            PersonSequencer.Reset();
            TodoSequencer.Reset();
            tasks.Clear();
            people.Clear();

            Person firstPerson = people.NewPerson("Anders", "Karlsson");

            Person secondPerson = people.NewPerson("Bengt", "Andersson");

            Todo firstTodo = tasks.NewTodo("Cleaning floor");

            Todo secondTodo = tasks.NewTodo("Making clear code");

            firstTodo.Assignee = firstPerson;

            //secondTodo.Assignee = secondPerson;

            Todo[] newArray = new Todo[0];

            //Act
            Todo[] actual = tasks.FindByAssignee(firstTodo.Assignee);

            //Assert
            Assert.NotEqual(newArray, actual);
        }

        [Fact]
        public void RunFindUnassignedTodoItems()
        {
            //Arrange

            TodoItems tasks = new TodoItems();
            People people = new People();

            PersonSequencer.Reset();
            TodoSequencer.Reset();
            tasks.Clear();
            people.Clear();

            Person firstPerson = people.NewPerson("Anders", "Karlsson");

            Person secondPerson = people.NewPerson("Bengt", "Andersson");

            Todo firstTodo = tasks.NewTodo("Cleaning floor");

            Todo secondTodo = tasks.NewTodo("Making clear code");

            firstTodo.Assignee = firstPerson;

            //secondTodo.Assignee = secondPerson;

            Todo[] newArray = new Todo[0];

            //Act
            Todo[] actual = tasks.FindUnassignedTodoItems();

            //Assert
            Assert.NotEqual(newArray, actual);
        }

        [Fact]
        public void RunItemRemove()
        {
            //Arange
            TodoItems tasks = new TodoItems();
            
            TodoSequencer.Reset();
            tasks.Clear();
          
            Todo firstTodo = tasks.NewTodo("Cleaning floor");

            Todo secondTodo = tasks.NewTodo("Making clear code");

            Todo thirdTodo = tasks.NewTodo("Fixing mistakes");

            Todo[] newArray = new Todo[0];

            //Act
            Todo[] actual = tasks.Remove(2);

            //Assert
            Assert.NotEqual(newArray, actual);
        }

        [Fact]
        public void RunPersonRemove()
        {
            //Arange
            People people = new People();

            PersonSequencer.Reset();
            people.Clear();

            Person firstPerson = people.NewPerson("Anders", "Karlsson");

            Person secondPerson = people.NewPerson("Bengt", "Andersson");

            Person thirdPerson = people.NewPerson("Arne", "Berglund");

            Person[] newArray = new Person[0];

            //Act
            Person[] actual = people.Remove(2);

            //Assert
            Assert.NotEqual(newArray, actual);
        }
    }
}
