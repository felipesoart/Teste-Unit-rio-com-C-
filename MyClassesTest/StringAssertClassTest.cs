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
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("FelipeS")]
        public void ContainsTest()
        {
            string str1 = "Felipe Souza";
            string str2 = "Souza";

           StringAssert.Contains(str1, str2);

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void StartsWithTest()
        {
            string str1 = "Todos Caixa Alta";
            string str2 = "Todos Caixa";

            StringAssert.StartsWith(str1, str2);

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void IsAllLowerCaseTest()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos caixa", regex);

        }

        [TestMethod]
        [Owner("FelipeS")]
        public void IsNotAllLowerCaseTest()
        {
            Regex regex = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos caixa", regex);// verifica se existe pelomenos um caracter maiusculo

        }

    }
}
