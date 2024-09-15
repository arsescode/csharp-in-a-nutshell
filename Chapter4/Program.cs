// See https://aka.ms/new-console-template for more information
using Chapter4.Classes;

// Dictionary to store Enum and function mappings
var programFunctionsList = new Dictionary<ProgramFunctions, Action>
            {
                { ProgramFunctions.Exit , () => Environment.Exit(0)},
                { ProgramFunctions.Delegates, ProgramFunctionsExecutor.RunDelegates },
                { ProgramFunctions.GenericDelegateTypes, ProgramFunctionsExecutor.RunGenericDelegateTypes },
                { ProgramFunctions.FuncAndActionDelegates, ProgramFunctionsExecutor.RunFuncAndActionDelegates },
                { ProgramFunctions.DelegatesVersusInterfaces, ProgramFunctionsExecutor.RunDelegatesVersusInterfaces },
                { ProgramFunctions.Events, ProgramFunctionsExecutor.RunEvents },
                { ProgramFunctions.TryStatementsAndExceptions, ProgramFunctionsExecutor.TryStatementsAndExceptions }

            };
bool exit = false;

// Main loop to keep asking the user for input until they exit
while (!exit)
{
    // Show the menu
    ProgramFunctionsExecutor.ShowMenu(programFunctionsList);

    // Get user input
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        ProgramFunctions selectedFunction = (ProgramFunctions)choice;

        // Check if the selected function exists in the dictionary and execute it
        if (programFunctionsList.ContainsKey(selectedFunction))
        {
            if (selectedFunction == ProgramFunctions.Exit)
            {
                exit = true;
                programFunctionsList[selectedFunction].Invoke(); // Call Exit
            }
            else
            {
                programFunctionsList[selectedFunction].Invoke(); // Call the selected function
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }
}