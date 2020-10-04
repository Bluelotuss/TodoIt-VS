using System;
namespace TodoIt
{
    public class Todo
    {
        readonly int todoId;
        public int TodoId { get { return todoId; } }
        string description;

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description");
                }
                else
                {
                    description = value;
                }
            }
        }
        bool done;
        public bool Done { get { return done; } set { done = value; } }
        Person assignee;
        public Person Assignee { get { return assignee; } set { assignee = value; } }

        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            Description = description;
        }

        public Todo(int todoId, string description, bool done)
            : this(todoId, description)
        {
            this.done = done;
        }

        public Todo(int todoId, string description, Person assignee)
            : this(todoId, description)
        {
            this.assignee = assignee;
        }
    }
}
