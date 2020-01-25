using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Export;
using StudentsResult.DataBase;
using System.Collections.Generic;
using StudentsResult.Objects;
using StudentsResult.DataBase.Factory;
using StudentsResult.DataBase.ConcretControllers;

using System.IO;
using OfficeOpenXml;

using Statistic;

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
        public void TestUpdate()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Student st = new Student(5, "Olga", 0, new DateTime(2000, 3, 1), 1);

            Controller<Student> controller = new Controller<Student>(DBName, Login, Password);

            int count = controller.Update(st);

            bool actual = false, expected = true;
            if (count > 0 ) { actual = true; }

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestCreate()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Student st = new Student("Diana", 0, new DateTime(2000, 5, 3), 1);
            Exam ex = new Exam("GIM", 0);

            Controller<Student> controllerStudent = new Controller<Student>(DBName, Login, Password);
            Controller<Exam> controllerExam = new Controller<Exam>(DBName, Login, Password);

            int count = controllerStudent.Create(st);
            count += controllerExam.Create(ex);


            bool actual = false, expected = true;
            if (count > 1) { actual = true; }

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void TestExport()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Controller<Student> controller = new Controller<Student>(DBName, Login, Password);

            string[] columnsName;

            List<Student> datas = controller.Reed(out columnsName);


            //---------------EXPORT

            List<Object[]> objs = new List<object[]>();
            objs.Add(columnsName);

            foreach (Student s in datas)
            {
                objs.Add(s.ToObject());
            }

            //принимает первым значением листа имена таблицы, остальными- значения
            byte[] fileContents = ExcelExport.Export(objs);

            bool actual = false, expected = true;
            if (fileContents != null) { actual = true; }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestFactory()
        {
            FactoryControllers fc = new FactoryControllers();

            ExamController ExamC = (ExamController)fc.CreateController(ControllersFormat.Exam);
         
            int count = ExamC.Create(new Exam("History", 0));

            bool actual = false, expected = true;
            if (count > 0) { actual = true; }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestExportToFile()
        {
            string DBName = "studentsresults";
            string Login = "root";
            string Password = "1111";

            Controller<Student> controller = new Controller<Student>(DBName, Login, Password);

            string[] columnsName;

            List<Student> datas = controller.Reed(out columnsName);


            //---------------EXPORT

            List<Object[]> objs = new List<object[]>();
            objs.Add(columnsName);

            foreach (Student s in datas)
            {
                objs.Add(s.ToObject());
            }

            //принимает первым значением листа имена таблицы, остальными- значения
            byte[] Buffer = ExcelExport.Export(objs);

            ExcelPackage package;
            using (MemoryStream memStream = new MemoryStream(Buffer))
            {
                package = new ExcelPackage(memStream);
            }

            FileInfo fi = new FileInfo(@"E:\Epam\.Net_EpamTraining\6\1.xlsx");
            package.SaveAs(fi);

            bool actual = false, expected = true;
            if(package != null)
            {
                actual = true;
            }

            Assert.AreEqual(actual, expected);
        }


        [TestMethod]
        public void TestExportExpelledStudents()
        {
            StatisticSession ss = new StatisticSession();

            bool actual = ss.ExportExpelledStudents(5, @"E:\Epam\.Net_EpamTraining\6");
            bool expected = true;

            Assert.AreEqual(actual, expected);

        }



    }
}
