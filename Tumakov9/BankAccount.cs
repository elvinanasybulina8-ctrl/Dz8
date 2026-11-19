using System.Transactions;
using System.Text;
using System.Collections.Generic;

namespace Tumakov9
{
    public class BankAccount
    {
        private static long nextAccountNumber = 0;
        private string accountNumber;
        private decimal balance;
        private string ownerName;
        private string accountType;
        private Queue<string> operations = new(); // новая очередь строк 9.3
        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        public string AccountType
        {
            get { return accountType; }
        }


        //Конструктор по умолчанию
        public BankAccount()
        {
            accountNumber = GenerateAccountNumber();
            balance = 0m;
            ownerName = "";
            accountType = "Default";
        }

        //Конструктор с балансом
        public BankAccount(decimal balanceAccount)
        {
            accountNumber = GenerateAccountNumber();
            balance = balanceAccount;
            ownerName = "";
            accountType = "Default";
        }

        //Конструктор с типом счета
        public BankAccount(string typeOfAccount)
        {
            accountNumber = GenerateAccountNumber();
            balance = 0m;
            ownerName = "";
            accountType = typeOfAccount;
        }

        //Конструктор с балансом и типом счета
        public BankAccount(decimal initialBalance, string typeOfAccount)
        {
            accountNumber = GenerateAccountNumber();
            balance = initialBalance; // начальный баланс
            ownerName = "";
            accountType = typeOfAccount;
        }

        //Метод для генерации уникального номера счета
        public string GenerateAccountNumber()
        {
            return nextAccountNumber++.ToString();
        }

        //Метод для отображения деталей счета
        public void ShowAccountDetails()
        {
            Console.WriteLine($"Номер счёта: {accountNumber}");
            Console.WriteLine($"Тип счёта: {accountType}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Имя владельца: {ownerName}");
        }

        //Для упр 9.3

        // Метод для добавления элементов в очередь
        public void AddOperation(string operationDetail)
        {
            operations.Enqueue(operationDetail);
        }

        //Метод для сохранения элементов в файл и освобождения
        public void Dispose()
        {
            if (operations.Count > 0)
            {
                using (var writer = File.AppendText(@"..\..\..\Упр 9.3.txt")) //  AppendText для дописывания в конец файла
                {
                    foreach (var operation in operations)
                    {
                        writer.WriteLine(operation);
                    }
                }

                operations.Clear(); // Очищаем очередь после записи
            }
            GC.SuppressFinalize(this);
        }
    }
}