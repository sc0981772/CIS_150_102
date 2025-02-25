using Newtonsoft.Json;
using System;

namespace JSONguidedlab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "John Doe", Age = 30 },
                new Person { Name = "Jane Smith", Age = 25 },
                new Person { Name = "Mike Johnson", Age = 40 }
            };

            try
            {
                string json = JsonConvert.SerializeObject(people);
                Console.WriteLine("Serialized JSON: " + json);

                List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(json);
                Console.WriteLine("Deserialized People:");
                foreach (Person person in deserializedPeople)
                {
                    Console.WriteLine("Name - " + person.Name + ", Age - " + person.Age);
                }
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine("An error occurred while processing JSON: " + jsonEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            //string json = JsonConvert.SerializeObject(person);
            //Console.WriteLine("Serialized JSON: " + json);

            //Person deserializedPerson = JsonConvert.DeserializeObject<Person>(json);
            //Console.WriteLine("Deserialized Person: Name - " + deserializedPerson.Name + ", Age - " + deserializedPerson.Age);
        }
    }
}
