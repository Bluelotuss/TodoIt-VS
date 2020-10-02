using System;
namespace TodoIt
{
    public class TodoSequencer
    {
        static int todoId;

        public static int NextTodoId()
        {
            return ++todoId;
        }

        public static void Reset()
        {
            todoId = 0;
        }
    }
}
