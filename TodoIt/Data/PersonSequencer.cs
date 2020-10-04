using System;

namespace TodoIt
{
    public class PersonSequencer
    { 
            static int personId;

            public static int NextPersonId()
            {
                return ++personId;
            }

            public static void Reset()
            {
                personId = 0;
            }
        
    }
}
