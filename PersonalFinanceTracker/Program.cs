using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Services;

Console.WriteLine("Welcome to the personal finance tracker!");


var transactionService = new TransactionService();

while (true)
{
    Console.WriteLine("1. Add transaction");
    Console.WriteLine("2. Get transactions");
    Console.WriteLine("3. Get transaction by Category");
    Console.WriteLine("4. Get account balance");
    Console.WriteLine("5. Generate Monthly Report");
    Console.Write("Select an option: ");
    
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("Enter transaction date: ");
            var date = Console.ReadLine();
            Console.WriteLine("Enter transaction amount: ");
            var amount = Console.ReadLine();
            Console.WriteLine("Enter transaction description: ");
            var description = Console.ReadLine();
            Console.WriteLine("Enter category: ");
            var category = Console.ReadLine();
            
            transactionService.AddTransaction(new Transaction
                {
                    DateOfTransaction = DateTime.Parse(date),
                    Amount = decimal.Parse(amount),
                    Description = description,
                    Category = category
                }
                );
            Console.WriteLine("Transaction successfully added!");
            break;
        case "2":
            var transactions = transactionService.GetTransactions();
            Console.WriteLine("Transactions list:");
            foreach (var transactioon in transactions)
            {
                Console.WriteLine($"Date{transactioon.DateOfTransaction}, Amount{transactioon.Amount}, Category{transactioon.Category}");
            }
            break;
        case "3":
            Console.WriteLine("Enter category: ");
            var categoryToFilter = Console.ReadLine();
            var transactionsByCategory = transactionService.GetTransactionsByCategory(categoryToFilter);
            Console.WriteLine("Transactions list:");
            foreach (var t in transactionsByCategory)
            {
                Console.WriteLine($"Transactions of type: {categoryToFilter}");
                Console.WriteLine($"Date{t.DateOfTransaction}, Amount{t.Amount}");
            }
            break;
        case "4":
            var balance = transactionService.GetBalance();
            if (balance > 0)
            {
                Console.WriteLine($"Current balance: {balance}");
            }
            else
            {
                Console.WriteLine("Balance is 0€!");
            }
            break;
        case "5":
            ReportService.GenerateReport(transactionService.GetTransactions());
            break;
        case "quit":
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option, please try again!");
            break;
    }
}