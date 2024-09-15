using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chapter4.Util;

namespace Chapter4.Classes
{
    public enum ProgramFunctions
    {
        Exit = 0,
        Delegates = 1,
        GenericDelegateTypes,
        FuncAndActionDelegates,
        DelegatesVersusInterfaces,
        Events,
        TryStatementsAndExceptions
    }

    // Utility class containing methods for each region
    public static class ProgramFunctionsExecutor
    {
        #region Delegates
        public static void RunDelegates()
        {
            PrintTitle("Running Delegates");
            ProgressReporter p = WriteProgressToConsole;
            p += WriteProgressToFile;
            Util.HardWork(p);
        }
        #endregion

        #region Generic Delegate Types
        public static void RunGenericDelegateTypes()
        {
            PrintTitle("Running Generic Delegate Types");
            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square); // Hook in Square
            foreach (int i in values)
                Console.WriteLine(i + " ");
            int Square(int x) => x * x;
        }

        #endregion

        #region  Func and Action Delegates
        public static void RunFuncAndActionDelegates()
        {
            PrintTitle("Running Func and Action Delegates");
            Func<int, int> square = x => x * x;
            Action<int> printResult = result => Console.WriteLine($"The result is: {result}");
            int number = 7;
            int squared = square(number);
            printResult(squared);
        }
        #endregion


        #region  Delegates Versus Interfaces
        public static void RunDelegatesVersusInterfaces()
        {
            PrintTitle("Running Delegates Versus Interfaces");
            int[] values = { 1, 2, 3 };
            Util.TransformAll(values, new Cuber()); // Using Cuber for demonstration
            foreach (int i in values)
                Console.WriteLine(i);
        }
        #endregion

        #region  Events
        public static void RunEvents()
        {
            PrintTitle("Running Events");
            Stock stock = new Stock("MSFT", 120.00m);
            StockDisplay display = new StockDisplay();
            display.Subscribe(stock);

            stock.Price = 125.50m;
            stock.Price = 130.75m;

            display.UnSubscribe(stock);
            stock.Price = 132.00m;
        }
        #endregion

        #region  Try Statements And Exceptions
        public static void TryStatementsAndExceptions()
        {
            PrintTitle("Try Statements and Exceptions");

            try
            {
                // Simulating an operation that may throw an exception
                Console.WriteLine("Enter a number:");
                string input = Console.ReadLine();
                int number = int.Parse(input); // May throw FormatException if input is not valid

                // Simulating a potential divide by zero
                Console.WriteLine("Enter a divisor:");
                string divisorInput = Console.ReadLine();
                int divisor = int.Parse(divisorInput);

                int result = number / divisor; // May throw DivideByZeroException
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format Exception: {ex.Message}. Please enter a valid number.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Divide By Zero Exception: {ex.Message}. Divisor cannot be zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution complete. This will run regardless of success or exception.");
            }
        }
        #endregion


        #region Menu
        public static void ShowMenu(Dictionary<ProgramFunctions, Action> programFunctionsList)
        {
            PrintTitle("Select a function to run:");
            foreach (var func in programFunctionsList)
            {
                Console.WriteLine($"{(int)func.Key}. {func.Key}");
            }
        }
        #endregion
    }
}
