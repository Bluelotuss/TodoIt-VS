﻿using System;
namespace TodoIt
{
    public class Todo
    {
        public int todoId { get; set; }
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
        public bool done { get; set; }
        public Person assignee { get; set; }

        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            Description = description;
            //this.done = done;
            //this.assignee = assignee;
        }

    }
}
