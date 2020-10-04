﻿using System;

namespace TodoIt
{
    public class TodoItems
    {
        // a.Have a private static Todo array declared and instantiated as empty and not null (new Todo[0]).
        private static Todo[] tasks = new Todo[0];

        // b.Add a method public int Size() that return the length of the array.
        public int Size()
        {
            return tasks.Length;
        }

        // c. Add a method public Todo[] FindAll() that return the Todo array.
        public Todo[] FindAll()
        {
            return tasks;
        }

        // d.Add a method public Todo FindById(int todoId) that return the todo that has a
        // matching todoId as the passed in parameter.

        public Todo FindById(int todoId)
        {
            for (var i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].TodoId == todoId)  //Why TodoId?
                {
                    return tasks[i];
                }
            }
            throw new InvalidOperationException("Did not find expected value.");
        }

       

        // e. Add a method that creates a new Todo, adds the newly created object in the array and
        //then return the created object. You have to “expand” the Todo array. (tip: send in
        //parameters needed to create the Todo object and use the TodoSequencer to give a unique todoId)

        public Todo NewTodo(string description)
        {
            int todoId = TodoSequencer.NextTodoId();
            Todo todo = new Todo(todoId, description);

            Array.Resize(ref tasks, Size() + 1);

            tasks[Size() - 1] = todo;

            return todo;

        }

        // f.Add a method public void Clear() that clears all Person objects from the Person array.

        public void Clear()
        {
            tasks = new Todo[0];
        }

        // a. public Todo[] FindByDoneStatus(bool doneStatus) – Returns array with objects that has
        // a matching done status.

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] newArray = new Todo[0];
            for (var i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Done == doneStatus) 
                {
                    Array.Resize(ref newArray, newArray.Length + 1);

                    newArray[newArray.Length - 1] = tasks[i];

                    //return newArray;
                }
            }
            return newArray;
        }

        // b. public Todo[] FindByAssignee(int personId) – Returns array with objects that has an
        // assignee with a personId matching.

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] newArray = new Todo[0];
            for (var i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Assignee.PersonId == personId)
                {
                    Array.Resize(ref newArray, newArray.Length + 1);

                    newArray[newArray.Length - 1] = tasks[i];
                }
            }
            return newArray;
        }

        // c. public Todo[] FindByAssignee(Person assignee) – Returns array with objects that has
        // sent in Person.

        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] newArray = new Todo[0];
            for (var i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Assignee != null )
                {
                    Array.Resize(ref newArray, newArray.Length + 1);

                    newArray[newArray.Length - 1] = tasks[i];
                }
            }
            return newArray;
        }

        // d. public Todo[] FindUnassignedTodoItems() – Returns an array of objects that does not
        // have an assignee set.

        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] newArray = new Todo[0];
            for (var i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Assignee == null)
                {
                    Array.Resize(ref newArray, newArray.Length + 1);

                    newArray[newArray.Length - 1] = tasks[i];
                }
            }
            return newArray;
        }
    }
}
