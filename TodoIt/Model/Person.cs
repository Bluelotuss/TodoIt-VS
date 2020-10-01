using System;


namespace TodoIt
{
    public class Person
    {
        //fields
        public int personId { get; set; }
        string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        //constructor
        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }

        public string PersonInfomation()
        {
            return $"Person id:{personId} | First name: {firstName}\nLast name: {lastName}\n\n";
        }

    }
}
