using BudgeManagementApp;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello to Budget App");
Console.WriteLine("Main Menu\n===================");
Console.WriteLine("Please select your need things:");
Console.WriteLine("1)Add an Expense\n2)View Expense\n3)Calculate Total Expense");

int selectWork = Convert.ToInt16(Console.ReadLine());
List<Expense> expenses = new List<Expense>();

switch (selectWork)
{
    case 1:
        do
        {
            Console.WriteLine("Enter your expense name");
            string exName = Console.ReadLine();

            Console.WriteLine("Enter your price amount expense name");
            double priceAmount;
            while (!double.TryParse(Console.ReadLine(), out priceAmount))
            {
                Console.WriteLine("Invalid double input, please try again");
            }

            AddExpense(exName, priceAmount);

            Console.WriteLine("Do you need more add expenses?\n1) Yes\n2) No");
        }
        while (Convert.ToInt16(Console.ReadLine()) == 1);
        break;

    case 2:
        ViewExpenses();
        break;

    case 3:
        TotalExpenses();
        break;
    default:
        Console.WriteLine("We are somethings wronge to your input");
        break;
}


// methods of budget app
void AddExpense(string exName, double priceAmount)
{
    Expense newExpense = new Expense();
    newExpense.Name = exName;
    newExpense.PriceAmount = priceAmount;
    newExpense.Date = DateTime.Now;
    expenses.Add(newExpense);
    Console.WriteLine("Saved");
}
void ViewExpenses()
{
    Console.WriteLine("There is list of all your expenses\n====================");
    foreach (var expense in expenses)
    {
        Console.WriteLine("Your name expense details are below\n" +
            "The Name is: {0}\n" +
            "The Price Amount is: {1}\n" +
            "The Date Recorded is: {3}\n"
            , expense.Name, expense.PriceAmount, expense.Date);
    }
    Console.WriteLine("==================\nEnd of your expenses list");
}
void TotalExpenses()
{
    double total = expenses.Sum(ex => ex.PriceAmount);
    Console.WriteLine("Total your expenses are:\n{0}", total);
}


