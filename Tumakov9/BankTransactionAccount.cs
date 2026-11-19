﻿using System.Collections;//Queue
using System.Collections.Generic;

namespace tumakov.BankTransaction
{
    public class BankTransactionAccount
    {
        private Queue<BankTransaction> operation = new Queue<BankTransaction>();
        private static long nextAccountNumber = 0;
        private readonly string accountNumber;
        private decimal balance;
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public BankTransactionAccount(decimal initialBalance)
        {
            accountNumber = GenerateAccountNumber();
            balance = initialBalance;
        }

        //Уникальный номер счета
        private string GenerateAccountNumber()
        {
            return nextAccountNumber++.ToString();
        }

        //Метод для пополнения счета
        public void Deposit(decimal amount)
        {
            if (amount <= 0m)
            {
                Console.WriteLine("Сумма пополнения должна быть положительной");
            }
            else
            {
                balance += amount;
                operation.Enqueue(new BankTransaction(amount)); //добавления нового элемента в конец очереди
            }
        }

        //Метод для снятия средств со счета
        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                operation.Enqueue(new BankTransaction(-amount));
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средств!");
                return false;
            }
        }

        //Вспомогательный метод для просмотра последней операции
        public void ShowLastOperation()
        {
            if (operation.Count > 0)
            {
                BankTransaction lastTransaction = (BankTransaction)operation.Dequeue();//извлекает первый элемент из очереди (Queue) и удаляет его оттуда
                Console.WriteLine($"Последний платеж: Дата - {lastTransaction.Time}, Сумма - {lastTransaction.Amount}");
            }
            else
            {
                Console.WriteLine("Операций пока нет.");
            }
        }

        //Дополнительный метод для отображения всей истории операций
        public void ShowAllOperation()
        {
            while (operation.Count > 0)
            {
                BankTransaction transaction = (BankTransaction)operation.Dequeue();
                Console.WriteLine($"Дата - {transaction.Time}, Сумма - {transaction.Amount}");
            }
        }
    }
}