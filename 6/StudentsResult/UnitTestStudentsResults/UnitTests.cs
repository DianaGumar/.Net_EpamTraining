using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Export;
using StudentsResult.DataBase;
using System.Collections.Generic;
using StudentsResult;

namespace UnitTestStudentsResults
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestReed()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Student st = new Student("Olga", 0, new DateTime(2000, 3, 1), 1);

            Controller<Student> controller = new Controller<Student>(DBName, Login, Password);

            string[] columnsName;

            List<Student> data = controller.Reed(out columnsName);

            bool actual = false, expected = true;
            if (data != null) { actual = true; }

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestReedByID()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Student st = new Student("Olga", 0, new DateTime(2000, 3, 1), 1);

            Controller<Student> controller = new Controller<Student>(DBName, Login, Password);

            Student data = controller.Reed(10);

            bool actual = false, expected = true;
            if (data != null) { actual = true; }

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestExport()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Student st = new Student("Olga", 0, new DateTime(2000, 3, 1), 1);

            Controller<Student> controller = new Controller<Student>(DBName, Login, Password);

            string[] columnsName;

            List<Student> data = controller.Reed(out columnsName);


            //---------------EXPORT

            List<Object[]> objs = new List<object[]>();
            objs.Add(columnsName);

            foreach (Student s in data)
            {
                objs.Add(s.ToObject());
            }

            //принимает первым значением листа имена таблицы, остальными- значения
            byte[] fileContents = ExcelExport.Export(objs);

            //if (fileContents == null)
            //{
            //    return NotFound();
            //}

            //return File(
            //    fileContents: fileContents,
            //    contentType: ExcelExport.ContentType,
            //    fileDownloadName: ExcelExport.FileDownloadName
            //    );

            bool actual = false, expected = true;
            if (fileContents != null) { actual = true; }

            Assert.AreEqual(actual, expected);
        }

    }
}
