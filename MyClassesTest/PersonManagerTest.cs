using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("FelipeS")]
        public void CreatePerson_ofTypeEmployeeTest()
        {
            PersonManager PerMgr = new PersonManager();
            Person per;

            per = PerMgr.CreatePerson("Felipe", "Souza", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        [Owner("FelipeS")]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();
            super.Employees = new List<Employee>();
            super.Employees.Add(new Employee()
            {
                FirstName = "Felipe",
                LastName = "Souza"
            });

          

            Assert.IsTrue(super.Employees.Count > 0);
        }

    }
}
