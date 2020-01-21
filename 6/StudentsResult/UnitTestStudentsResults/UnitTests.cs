using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Export;
using StudentsResult.DataBase;
using System.Collections.Generic;

namespace UnitTestStudentsResults
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestExport()
        {
            string DBName = "StudentsResults";
            string Login = "root";
            string Password = "1111";
            Controller<Object> controller = new Controller<Object>(DBName, Login, Password);

            List<Object[]> data = controller.Reed();
            byte[] fileContents = ExcelExport.Export(data);

            //if (fileContents == null)
            //{
            //    return NotFound();
            //}

            //return File(
            //    fileContents: fileContents,
            //    contentType: ExcelExport.ContentType,
            //    fileDownloadName: ExcelExport.FileDownloadName
            //    );

            Assert.AreEqual(fileContents, null);

        }
    }
}
