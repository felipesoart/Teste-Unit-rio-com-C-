using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("FelipeS")]
        public void AreClollectionEqualFailsBecauseNoComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName= "Felipe", LastName = "Souza" });
            peopleExpected.Add(new Person() { FirstName= "Josy", LastName = "Frota" });
            peopleExpected.Add(new Person() { FirstName= "Malu", LastName = "Vasc" });

            //you shall not pass!
            peopleActual = personManager.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void AreClollectionEqualWithComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Felipe", LastName = "Souza" });
            peopleExpected.Add(new Person() { FirstName = "Josy", LastName = "Frota" });
            peopleExpected.Add(new Person() { FirstName = "Malu", LastName = "Vasc" });

            //you shall not pass!
            peopleActual = personManager.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x , y) => 
                    x.FirstName == y.FirstName && x.LastName == y.LastName? 0 : 1));

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void AreClollectionEquivalentTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

           
            peopleActual = personManager.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void IsClollectionOfTypeTest()
        {
            PersonManager personManager = new PersonManager();
          
            List<Person> peopleActual = new List<Person>();

            peopleActual = personManager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));

        }

    }
}
