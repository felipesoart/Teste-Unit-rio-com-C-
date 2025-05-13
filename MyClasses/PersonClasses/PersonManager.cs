using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Felipe", LastName = "Souza" });
            people.Add(new Person() { FirstName = "Josy", LastName = "Frota" });
            people.Add(new Person() { FirstName = "Malu", LastName = "Vasc" });

            return people;
        }

        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employee();
                
                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Felipe", "Souza", true));
            people.Add(CreatePerson("Josy", "Frota", true));
            people.Add(CreatePerson("Malu", "Vasc", true));

            return people;
        }
    }
}
