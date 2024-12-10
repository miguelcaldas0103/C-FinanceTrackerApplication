using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Services;

public class TransactionService
{
    private readonly List<Transaction> _transactions = new();

    public void AddTransaction(Transaction transaction)
    {
        transaction.Id = _transactions.Count + 1;
        _transactions.Add(transaction);
    }

    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }

    public List<Transaction> GetTransactionsByDate(DateTime date)
    {
        return _transactions.Where(t => t.DateOfTransaction == date).ToList();
    }

    public List<Transaction> GetTransactionsByCategory(string category)
    {
        return _transactions.Where(t => t.Category == category).ToList();
    }

    public decimal GetBalance()
    {
        return _transactions.Sum(t => t.Amount);
    }
}