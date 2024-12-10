using System.Diagnostics.CodeAnalysis;
using PersonalFinanceTracker.Models;

namespace PersonalFinanceTracker.Services;

public class ReportService
{
    public static void GenerateReport(List<Transaction> transactions)
    {
        var grouped = transactions.GroupBy(t => t.DateOfTransaction.ToString("yyyy-MM")).Select(g => new
        {
            MonthAndYear = g.Key, Total = g.Sum(t => t.Amount)
        });
        Console.WriteLine("Monthly Report:");
        foreach (var monthandyear in grouped)
        {
            Console.WriteLine($"{monthandyear.MonthAndYear} : {monthandyear.Total:C}");
        }
    }
}