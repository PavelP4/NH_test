using CAppNH.Entities;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Data;
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
                x.LogSqlInConsole = true;
                x.IsolationLevel = IsolationLevel.RepeatableRead;
                x.Timeout = 10;
                x.BatchSize = 10;
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            //cfg.Cache(c => {
            //    c.UseMinimalPuts = true;
            //    c.UseQueryCache = true;
            //});
            //cfg.SessionFactory().Caching.Through<HashtableCacheProvider>()
            //   .WithDefaultExpiration(1440);


            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var fct = session.Load<Faculty>(4);
                    //var newFct = new Faculty()
                    //{
                    //    Name = "F_D"
                    //};

                    var newStudent = new Student()
                    {
                        FirstName = "Bobj",
                        LastName = "Iv",
                        Address = new Location
                        {
                            Street = "112 Street",
                            City = "Minsk",
                            Province = "M",
                            Country = "Belarus"
                        },
                        Faculty = fct
                    };

                    //fct.Students.Add(newStudent);

                    //newFct.Students.Add(newStudent);

                    session.Save(newStudent);

                    //var students = session.CreateCriteria<Student>().List<Student>();
                    //foreach (var student in students)
                    //{
                    //    Console.WriteLine("{0} \t{1} \t{2} \t{3}",
                    //       student.ID, student.FirstName, student.LastName, student.AcademicStanding);
                    //}

                    //var stdnt = session.Get<Student>(1);
                    //session.Delete(stdnt);
                    //Console.WriteLine("Retrieved by ID");
                    //Console.WriteLine("{0} \t{1} \t{2}", stdnt.ID, stdnt.FirstName, stdnt.LastName);


                    //var stdnt = session.Load<Student>(1);

                    //stdnt.Address = new Location
                    //{
                    //    Street = "123 Street",
                    //    City = "Lahore",
                    //    Province = "Punjab",
                    //    Country = "Pakistan"
                    //};
                    //session.Update(stdnt);

                    //var f = new Faculty() {
                    //    Name = "F_B"
                    //};
                    //session.Save(f);





                    tx.Commit();
                }

                Console.ReadLine();
            }            
        }
    }
}
