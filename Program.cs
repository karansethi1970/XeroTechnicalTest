/*
    Welcome to the Xero technical excercise!
    ---------------------------------------------------------------------------------
    The test consists of a small invoice application that has a number of issues.

    Your job is to fix them and make sure you can perform the functions in each method below.

    Note your first job is to get the solution compiling! 
	
    Rules
    ---------------------------------------------------------------------------------
    * The entire solution must be written in C# (any version)
    * You can modify any of the code in this solution, split out classes, add projects etc
    * You can modify Invoice and InvoiceLine, rename and add methods, change property types (hint) 
    * Feel free to use any libraries or frameworks you like as long as they are .net based
    * Feel free to write tests (hint) 
    * Show off your skills! 

    Good luck :) 

    When you have finished the solution please zip it up and email it back to the recruiter or developer who sent it to you
*/

using log4net;
using SimpleInjector;
using System;
using XeroInvoicing.Operations;
using XeroInvoicing.Services;

namespace XeroTechnicalTest
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            bool endApp = false;
            var container = RegisterServices();
            var service = container.GetInstance<InvoiceService>();

            // Set up a simple configuration that logs on the console.
            //BasicConfigurator.Configure();

            Console.WriteLine("Welcome to Xero Tech Test!");

            try
            {
                while (!endApp)
                {
                    Console.WriteLine($"Please choose an operation (from the list below) to perform:{Environment.NewLine}" +
                    $"1. CreateInvoiceWithOneItem{Environment.NewLine}" +
                    $"2. CreateInvoiceWithMultipleItemsAndQuantities{Environment.NewLine}" +
                    $"3. RemoveItem{Environment.NewLine}" +
                    $"4. MergeInvoices{Environment.NewLine}" +
                    $"5. CloneInvoice{Environment.NewLine}" +
                    $"6. InvoiceToString{Environment.NewLine}" +
                    $"7. Exit Application");

                    var option = Console.ReadKey(true).Key;

                    switch (option)
                    {
                        case ConsoleKey.D1:
                            service.CreateInvoiceWithOneItem().Wait();
                            break;
                        case ConsoleKey.D2:
                            service.CreateInvoiceWithMultipleItemsAndQuantities().Wait();
                            break;
                        case ConsoleKey.D3:
                            service.RemoveItem().Wait();
                            break;
                        case ConsoleKey.D4:
                            service.MergeInvoices();
                            break;
                        case ConsoleKey.D5:
                            service.CloneInvoice().Wait();
                            break;
                        case ConsoleKey.D6:
                            service.InvoiceToString();
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }

                    Console.WriteLine("Press Enter to continue or Esc to exit the app");

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) endApp = true;

                    Console.Clear();
                }

                return;
            }
            catch (Exception ex)
            {
                log.Error($"{Environment.NewLine} Error: {ex.InnerException.Message}");
                Console.ReadLine();
            }
        }

        static Container RegisterServices()
        {
            // register loosely coupled classes
            var container = new Container();
            container.Register<IInvoiceOperations, InvoiceOperations>();
            container.Register<IInvoiceService, InvoiceService>();

            return container;
        }
    }
}
