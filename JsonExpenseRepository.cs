using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MyExpenseTracker
{
    public class JsonExpenseRepository : IExpenseRepository
    {
        private readonly string _filePath;
        private List<Expense> _expenses;
        private int _nextId;

        public JsonExpenseRepository(string filePath = "expenses.json")
        {
            _filePath = filePath;
            _expenses = new List<Expense>();
            _nextId = 1;
            LoadExpenses();
        }

        public List<Expense> GetAllExpenses()
        {
            return _expenses.ToList();
        }

        public Expense AddExpense(Expense expense)
        {
            // Assign ID and add to list
            expense.Id = _nextId++;
            _expenses.Add(expense);
            
            // Save to file
            SaveExpenses();
            
            return expense;
        }

        public Expense? UpdateExpense(Expense expense)
        {
            var existingExpense = _expenses.FirstOrDefault(e => e.Id == expense.Id);
            if (existingExpense == null)
                return null;

            // Update properties
            existingExpense.Amount = expense.Amount;
            existingExpense.Description = expense.Description;
            existingExpense.Category = expense.Category;
            existingExpense.Date = expense.Date;

            SaveExpenses();
            return existingExpense;
        }

        public bool DeleteExpense(int id)
        {
            var expense = _expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return false;

            _expenses.Remove(expense);
            SaveExpenses();
            return true;
        }

        public Expense? GetExpenseById(int id)
        {
            return _expenses.FirstOrDefault(e => e.Id == id);
        }

        public List<Expense> GetExpensesByCategory(string category)
        {
            return _expenses.Where(e => 
                string.Equals(e.Category, category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Expense> GetExpensesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _expenses.Where(e => 
                e.Date.Date >= startDate.Date && e.Date.Date <= endDate.Date).ToList();
        }

        public decimal GetTotalSpending()
        {
            return _expenses.Sum(e => e.Amount);
        }

        public int GetExpenseCount()
        {
            return _expenses.Count;
        }

        public void SaveChanges()
        {
            SaveExpenses();
        }

        private void LoadExpenses()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    _expenses = new List<Expense>();
                    return;
                }

                string json = File.ReadAllText(_filePath);
                
                if (string.IsNullOrWhiteSpace(json))
                {
                    _expenses = new List<Expense>();
                    return;
                }

                _expenses = JsonConvert.DeserializeObject<List<Expense>>(json) ?? new List<Expense>();
                
                // Set next ID to be higher than any existing ID
                _nextId = _expenses.Count > 0 ? _expenses.Max(e => e.Id) + 1 : 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading expenses: {ex.Message}");
                _expenses = new List<Expense>();
                _nextId = 1;
            }
        }

        private void SaveExpenses()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_expenses, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving expenses: {ex.Message}");
                throw;
            }
        }
    }
}
