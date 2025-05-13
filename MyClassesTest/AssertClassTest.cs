using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    /* DUVIDAS
     
    como usar o visual studio communitem com o "Analyze code Coverage" pois o mesmo so tem no visual studio inter pliser
     
    ORDEM DOS VIDEOIS 
    https://www.youtube.com/watch?v=iiu4iPYG1Is&list=PLWNaqtzH6CWRUd0iIEJotRrpwtXXnFROE&index=30

    1-18
    28 E 29
    19-21
    23 E 22
    24-27
    30

    CREATE TABLE FileProcessTest
    (
    FileName varchar(255) NULL,
    ExpectedValue [bit] not NULL,
    CausesException [bit] not NULL,
    )
    go

    insert into FileProcessTest
    values ('C:\Windows\Regedit.ext', 1, 0),
    ('C:\NotExist.txt', 0, 0),
    (null, 0, 1)


     */

    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests

        
        [TestMethod]
        [Owner("FelipeS")]
        public void AreEqualTest()
        {
            string str1 = "Felipe";
            string str2 = "Felipe";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("FelipeS")]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Felipe";
            string str2 = "felipe";

            Assert.AreEqual(str1, str2, true);
        }

        [TestMethod]
        [Owner("FelipeS")]
        public void AreNotEqualTest()
        {
            string str1 = "Felipe";
            string str2 = "Josy";

            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region AreSame/AreNotSame Tests


        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);

        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);

        }

        #endregion

        #region IsInstanceOfType Test
        [TestMethod]
        [Owner("FelipeS")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person person;

            person = mgr.CreatePerson("Felipe", "Souza", true);

            Assert.IsInstanceOfType(person, typeof(Supervisor));

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person person;

            person = mgr.CreatePerson("", "Souza", true);

            Assert.IsNull(person);

        }

        #endregion
    }
}
