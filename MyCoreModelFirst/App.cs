using Microsoft.EntityFrameworkCore;
using System;

namespace MyCoreModelFirst
{
    public class App
    {
        private String _debugRelease;
        public String Version { get; set; } = "0.0.0.0";


        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
#if DEBUG
            _debugRelease = "Debug";
#else
            _debugRelease = "Release";
#endif
        }

        /// <summary>
        /// Run
        /// Run the program
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int Run(string[] args)
        {
            Console.WriteLine(String.Format("Program MyCoreModelFirst {0} Version {1}", _debugRelease, Version));

            // use Add-Migration/Remove-Migration... in Paket-Manager-Konsole:
            //Add-Migration -Name InitialCreate -Context EFDbContext
            //Remove-Migration

            using (EFDbContext context = new EFDbContext())
            {
                try
                {
                    // uncomment this to update/create DB after running Add-Migration in Paket-Manager-Konsole:
                    //context.Database.Migrate();

                    // uncomment this to delete tables
                    //DeleteTables(context);

                    // uncomment this to insert test data:
                    //InsertTestData(context, 10);
                }
                catch (Exception ex)
                {
                    // A short hint, if ex.ToString() is used we get the complied output of
                    // the Exception inclusive the Inner Exception.
                    Console.WriteLine(String.Format("We have an exeption:\n{0}\n",ex.ToString()));
                }
            }

            Console.WriteLine(String.Format("press any key to exit."));
            Console.ReadKey();
            return 0;
        }

        /// <summary>
        /// InsertTestData
        /// </summary>
        /// <param name="context"></param>
        /// <param name="anzRecords"></param>
        static void InsertTestData(EFDbContext context, int anzRecords)
        {
            for (int i = 1; i <= anzRecords; i++)
                InsertRecords(context, String.Format("Name{0}",i));
        }

        /// <summary>
        /// InsertRecords
        /// </summary>
        /// <param name="context"></param>
        /// <param name="iinterface"></param>
        /// <param name="fileName"></param>
        /// <param name="asJson"></param>
        static void InsertRecords(EFDbContext context, string name)
        {
            EFName rec = new EFName() { Name = name };
            context.Names.Add(rec);
            context.SaveChanges();
        }

        /// <summary>
        /// DeleteTables
        /// </summary>
        /// <param name="context"></param>
        private static void DeleteTables(EFDbContext context)
        {
            var itemsToDelete1 = context.Set<EFName>();
            context.Names.RemoveRange(itemsToDelete1);
            context.SaveChanges();
        }

    }
}
