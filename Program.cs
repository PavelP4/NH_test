using CAppNH.Entities;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Reflection;

namespace CAppNH
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();

            //String DataSource = "sc0895";
            //String InitialCatalog = "NH_test";
            //String IntegratedSecurity = "True";
            //String ConnectTimeout = "15";
            //String Encrypt = "False";
            //String TrustServerCertificate = "False";
            //String ApplicationIntent = "ReadWrite";
            //String MultiSubnetFailover = "False";
            //cfg.Configure();

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Data Source=sc0895;Initial Catalog=NH_test;Persist Security Info=True;User ID=sa;Password=@dmin2016";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());            

            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    //var newStudent = new Student() {
                    //    FirstName = "Ivan",
                    //    LastName = "Ivanov"
                    //};
                    //session.Save(newStudent);

                    var students = session.CreateCriteria<Student>().List<Student>();

                    foreach (var student in students)
                    {
                        Console.WriteLine("{0} \t{1} \t{2} \t{3}",
                           student.ID, student.FirstName, student.LastName, student.AcademicStanding);
                    }

                    var stdnt = session.Get<Student>(1);
                    //Console.WriteLine("Retrieved by ID");
                    //Console.WriteLine("{0} \t{1} \t{2}", stdnt.ID, stdnt.FirstName, stdnt.LastName);

                    //stdnt.AcademicStanding = StudentAcademicStanding.Good;
                    //session.Update(stdnt);

                    tx.Commit();
                }

                Console.ReadLine();
            }
        }       
    }
}
