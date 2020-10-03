using System;

namespace TodoIt
{
    public class People
    {
        // a.Have a private static Person array declared and instantiated as empty and not null (new Person[0]).
        private static Person[] people = new Person[0];
        
        // b.Add a method public int Size() that return the length of the array.
        public int Size()
        {
            return people.Length;
        }

        // c. Add a method public Person[] FindAll() that return the Person array.
        public Person[] FindAll()
        {
            return people;
        }

        // d.Add a method public Person FindById(int personId) that return the person that has a
        // matching personId as the passed in parameter.

        public Person FindById(int personId)
        {
            for(var i = 0; i < people.Length; i++)
            {
                if(people[i].PersonId == personId)
                {
                    return people[i];
                }
            }
            throw new InvalidOperationException("Did not find value expected.");
        }

        // e. Add a method that creates a new Person, adds the newly created object in the array and
        //then return the created object. You have to “expand” the Person array. (tip: send in
        //parameters needed to create the Person object and use the PersonSequencer to give a unique personId)

        public Person NewPerson(string firstName, string lastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Person person = new Person(personId, firstName, lastName);

            Array.Resize(ref people, Size() + 1);

            people[Size() - 1] = person;

            return person;

        }

        // f.Add a method public void Clear() that clears all Person objects from the Person array.

        public void Clear()
        {
            people = new Person[0];
        }
    }
}
