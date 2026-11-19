namespace tumakov.BankTransaction;
    public class BankTransaction
    {
        public readonly DateTime Time;// Текущая дата и время операции
        public readonly decimal Amount;// Сумма операции
        public BankTransaction(decimal amount)// Конструктор получает одну сумму
        {
            Time = DateTime.Now; //возвращает объект DateTime, который представляет текущую дату и время
            Amount = amount;
        }

    }
