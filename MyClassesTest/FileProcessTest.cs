using System;
using System.Configuration;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\Regedit.exe";
        private const string FILE_NAME = @"FileToDeploy.txt";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
                SetGoodFileName();
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Texto");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
                SetGoodFileName();
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion


     

        [TestMethod]
        [Timeout(2000)]
        [Ignore]
        public void SimulaterTimeout()
        {
            System.Threading.Thread.Sleep(3000);
        }


        [TestMethod]
        [Owner("FelipeS")]
        [DataSource("System.Data.SqlClient",
        @"Data Source=DESKTOP-3F4V64M\SQLDEV2022;Initial Catalog=TesteUnitario;Persist Security Info=True;User ID=sa;Password=123456",
        "FileProcessTest", DataAccessMethod.Sequential)]
        public void FileExistsTestFromDB()
        {
           FileProcess fp = new FileProcess();
            string fileName;
            bool expectedValue, causesException, fromCall;

            fileName = TestContext.DataRow["FileName"].ToString();
            expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            try
            {
                fromCall = fp.FileExists(fileName);
                Assert.AreEqual(expectedValue, fromCall,
                    $"File: {fileName} has failed, Method: FileExistsTestFromDB");
            }
            catch (ArgumentException)
            {
                Assert.IsTrue( causesException );
            }

        }

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("FelipeS")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"TesTing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);          

            Assert.IsTrue(fromCall);
        }    

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void FileNameDoesExistsSimpleMessage()
        {
            FileProcess fp = new FileProcess();
          
            bool fromCall;
       
            TestContext.WriteLine($"Testing File: {_GoodFileName}");

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does Not Exist.");
        }

        [TestMethod]
        public void FileNameDoesExistsSimpleMessageFormatting()
        {
            FileProcess fp = new FileProcess();

            bool fromCall;

            TestContext.WriteLine($"Testing File: {_GoodFileName}");

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File '{0}' Does Not Exist.", _GoodFileName);
        }


        // PARA QUE SERVE ISSO NÃO ENTENDE 
        [TestMethod]
        [Owner("FelipeS")]
        [DeploymentItem(FILE_NAME)]
        [Ignore]
        public void FileNameDoesNotExistsUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine($"Checking File: {fileName}");

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }


        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("FelipeS")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]   
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("ThiagoS")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //TODO;
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Owner("Marcos")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            //TODO;
            FileProcess fp = new FileProcess();


            try
            {
                fp.FileExists("");
            }
            catch (Exception)
            {
                //isso foi um sucesso.
                return;
            }

            Assert.Fail("Faill expected");
        }
    }
}
