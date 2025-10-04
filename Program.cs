using System;
using System.Collections.Generic;

namespace MyExpenseTracker
{
    public class Expense
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Expense(decimal amount, string description, string category)
        {
            Amount = amount;
            Description = description;
            Category = category;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Date:MM/dd/yyyy HH:mm:ss} - {Category} - ${Amount:F2} - {Description}";
        }
    }

    class Program
    {
        private static List<Expense> expenses = new List<Expense>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Expense Tracker!");
            
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddExpense();
                        break;
                    case "2":
                        ViewAllExpenses();
                        break;
                    case "3":
                        ShowTotalSpending();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Thank you for using My Expense Tracker!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Yes please try again.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n--- Expense Tracker Menu ---");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View All Expenses");
            Console.WriteLine("3. Show Total Spending");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
        }

        static void AddExpense()
        {
            Console.WriteLine("\n--- Add New Expense ---");
            
            // Get amount
            decimal amount;
            while (true)
            {
                Console.Write("Enter amount: $");
                if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
                    break;
                Console.WriteLine("Please enter a valid positive number.");
            }

            // Get description
            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            // Get category
            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            // Create and add expense
            Expense expense = new Expense(amount, description, category);
            expenses.Add(expense);

            Console.WriteLine($"\nExpense added successfully! ${amount:F2} for {description}");
        }

        static void ViewAllExpenses()
        {
            Console.WriteLine("\n--- All Expenses ---");
            
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded yet.");
                return;
            }

            foreach (var expense in expenses)
            {
                Console.WriteLine(expense);
            }
        }

        static void ShowTotalSpending()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("\nNo expenses recorded yet. Total: $0.00");
                return;
            }

            decimal total = 0;
            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }

            Console.WriteLine($"\nTotal Spending: ${total:F2}");
            Console.WriteLine($"Number of expenses: {expenses.Count}");
        }
    }
}
