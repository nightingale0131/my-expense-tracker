# My Expense Tracker

A simple C# console application for tracking expenses.

## Prerequisites

To run this project, you need to have the .NET SDK installed:

### Install .NET SDK

**Option 1 - Using Snap (Recommended):**
```bash
sudo snap install dotnet-sdk --classic
```

**Option 2 - Using APT:**
```bash
sudo apt update
sudo apt install -y dotnet-sdk-8.0
```

## How to Run

1. Navigate to the project directory:
   ```bash
   cd ~/dev/my-expense-tracker
   ```

2. Restore packages:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

## Project Structure

- `Program.cs` - Main application entry point
- `MyExpenseTracker.csproj` - Project configuration file
- `README.md` - This documentation file

## Future Extension Ideas

- Data persistence
- Convert into app
- Budget management
- Reporting features

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
