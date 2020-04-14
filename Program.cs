using System;
using TestDataGeneratorLibrary;
using System.Collections.Generic;
using System.Linq;

namespace LINQPractise
{
    class Program
    {
        static void Main(string[] args)
        {

            TestDataGenerator tdg = new TestDataGenerator();
            List<Person> people = tdg.GetListOfRandomPersons(100);

            List<Person> queryResult = new List<Person>();
            //Get all from certain age range.
            //queryResult = people.FindAll(x => x.age >= 50 && x.age <= 60);

            //using lambda expression
            //Get with certain age and all females. 
                    //queryResult = people.FindAll(x => x.age >= 50 && x.age <= 60 && x.sex == Person.Sex.Female);

            //Same using LINQ
            //var result = from person in people 
            //             where person.age >= 50 && person.age <= 60 && person.sex is Person.Sex.Female 
            //             select person;

            //Same query with order by AND ToList method
            //var resultList = (from person in people 
            //             orderby person.lastName
            //             where person.age >= 50 && person.age <= 60 && person.sex is Person.Sex.Female
            //             select person).ToList<Person>();

            //Sort by age - descending
            //var resultList = (from person in people
            //                  orderby person.age descending
            //                  where person.age >= 50 && person.age <= 60 && person.sex is Person.Sex.Female
            //                  select person).ToList<Person>();
            //PrintPersons(resultList);

            //sort result by using lastname            
            //var result = from person in queryResult orderby person.lastName ascending select person;

            //Get all the people that have "B" in their first name
            var result = from person in people where person.firstName.Contains("B") select person;

            //Note! Notice how adding a Person to people list behaves. 
            //Added person is included in the query even when query is not executed again.
            PrintPersons(result.ToList<Person>());

            Person newPerson = tdg.GenerateRandomPerson(firstName: "Bertil");
            people.Add(newPerson);

            PrintPersons(result.ToList<Person>());

            //Get all the people that have number 5 in their age.
            //var result = from person in people where person.age.ToString().Contains("5") select person;

            //Get firsnames with f and create new Person object from that
            //var result = from person in people where person.firstName.Contains("B") select person;
            //PrintPersons(result.ToList());
            //var newPeople = from person in result.ToList() select tdg.GenerateRandomPerson(firstName: person.firstName, age: 66);
            //PrintPersons(newPeople.ToList());

            //List< Person > inOrder = new List<Person>();
            //inOrder.AddRange(result);

            //PrintPersons(queryResult);
            //PrintPersons(inOrder);
            //PrintPersons(resultList);

        }

        public static void PrintPersons(List<Person> people)
        {
            int i = 0;
            foreach (Person person in people)
            {
                PrintPerson(person);
                i++;
            }

            Console.WriteLine($"\nThere was {i} people.\n");
        }

        public static void PrintPerson(Person person)
        {
            Console.WriteLine($"{person.firstName} {person.lastName}\tage:{person.age}\tsex:{person.sex}");
        }
    }
}
