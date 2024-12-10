namespace PersonalFinanceTracker.Models;

public class Transaction
{
    public int Id { get; set; }
    public DateTime DateOfTransaction { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}