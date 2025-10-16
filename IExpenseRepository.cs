using System.Collections.Generic;

namespace MyExpenseTracker
{
    public interface IExpenseRepository
    {
        List<Expense> GetAllExpenses();
        Expense AddExpense(Expense expense);
        Expense? UpdateExpense(Expense expense);
        bool DeleteExpense(int id);
        Expense? GetExpenseById(int id);
        List<Expense> GetExpensesByCategory(string category);
        List<Expense> GetExpensesByDateRange(DateTime startDate, DateTime endDate);
        decimal GetTotalSpending();
        int GetExpenseCount();
        void SaveChanges();
    }
}
