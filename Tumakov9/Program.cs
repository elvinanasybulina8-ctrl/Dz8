using System;
using tumakov.BankTransaction;
using Tumakov9;

namespace Tumakov9
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 9.1 ");
            var myAccount = new BankAccount(1000m);
            var friendAccount = new BankAccount(500m, "Savings");
            myAccount.ShowAccountDetails();
            Console.WriteLine("");
            friendAccount.ShowAccountDetails();

            Console.WriteLine("Упражнение 9.2 ");
            BankTransactionAccount account = new BankTransactionAccount(1000);
            account.Deposit(500); // Пополняем 
            account.Withdraw(200);// Снимаем 
            account.Deposit(300); // Пополняем 
            account.ShowAllOperation();

            Console.WriteLine("Упражнение 9.3 ");
            var userBank = new BankAccount();
            userBank.AddOperation("Начальное пополнение: +10000 руб");
            userBank.AddOperation("Покупка товаров: -2500 руб.");
            userBank.AddOperation("Перевод другу: -1000 руб.");
            userBank.ShowAccountDetails();

            //Освобождаем ресурсы и сохраняем операции в файл
            userBank.Dispose();

            Console.WriteLine("Домашнее задание 9.1 ");
            Song song1 = new Song();
            Console.WriteLine(song1.Title());

            Song song2 = new Song("Название песни", "Исполнитель");
            Console.WriteLine(song2.Title());

            Song song3 = new Song("Название песни", "Исполнитель", song2);
            Console.WriteLine(song3.Title());

        }
    }
}