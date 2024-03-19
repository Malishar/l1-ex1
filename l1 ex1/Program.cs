using System;
using System.Collections;
using LibraryClass;

namespace lab11_ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < 3; i++)
            {
                BankCard b = new BankCard();
                al.Add(b);
                b.RandomInit();
            }
            for (int i = 3; i < 6; i++)
            {
                DebitCard d = new DebitCard();
                al.Add(d);
                d.RandomInit();
            }
            for (int i = 6; i < 9; i++)
            {
                CreditCard c = new CreditCard();
                al.Add(c);
                c.RandomInit();
            }
            for (int i = 9; i < 12; i++)
            {
                YouthCard y = new YouthCard();
                al.Add(y);
                y.RandomInit();
            }
            foreach (BankCard item in al)
            {
                item.Show();
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            // Добавление элемента
            BankCard newBankCard = new BankCard();
            newBankCard.RandomInit(); // Инициализация новой карты
            al.Add(newBankCard); // Добавление новой карты в ArrayList
            foreach (BankCard item in al)
            {
                item.Show();
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            //Удаление
            int indexToRemove = al.IndexOf(newBankCard); // Поиск индекса карты
            if (indexToRemove != -1)
            {
                al.RemoveAt(indexToRemove); // Удаление карты по найденному индексу
            }
            foreach (BankCard item in al)
            {
                item.Show();
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            //Запросы
            // 1. Общий баланс всех дебетовых карт.
            double totalDebitBalance = 0;
            foreach (var item in al)
            {
                if (item is DebitCard debitCard)
                {
                    totalDebitBalance += debitCard.Balance;
                }
            }
            Console.WriteLine($"Общий баланс всех дебетовых карт: {totalDebitBalance}");
            Console.WriteLine("------------------------------------------------------------------------------");

            // 2. Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
            int count = 0;
            double sum = 0;

            foreach (var card in al)
            {
                if (card is CreditCard creditCard && creditCard.RepaymentTerm > 0)
                {
                    sum += creditCard.Limit / creditCard.RepaymentTerm;
                    count++;
                }
            }
            Console.WriteLine($"Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт: {sum}");
            Console.WriteLine("------------------------------------------------------------------------------");

            // 3. Общая сумма возможного кешбека по всем действующим молодёжным картам.
            double totalYouthCashback = 0;//присваивание сумме 0
            foreach (var card in al)
            {
                if (card is YouthCard youthCard)
                {
                    totalYouthCashback += youthCard.Cashback;//просматриваем весь массив и складываем кэшбек по всем молодёжным картам  
                }
            }
            Console.WriteLine($"Общая сумма возможного кешбека по всем действующим молодёжным картам: {totalYouthCashback}");
            Console.WriteLine("------------------------------------------------------------------------------");

            // Клонирование коллекции
            ArrayList clonedList = (ArrayList)al.Clone();
            Console.WriteLine("Клонирование коллекции:");
            foreach (BankCard item in clonedList)
            {
                item.Show();
            }
            Console.WriteLine("------------------------------------------------------------------------------");

            //Сортировка коллекции (если не отсортирована) и поиск заданного элемента
            // Проверка на отсортированность коллекции
            if (!(al is IComparable))
            {
                // Если коллекция не отсортирована, сортируем ее
                al.Sort();
                Console.WriteLine($"Коллекция отсортирована:");
                foreach (BankCard item in al)
                {
                    item.Show();
                }
                Console.WriteLine("------------------------------------------------------------------------------");
            }

            // Поиск заданного элемента в коллекции
            Console.WriteLine("Введите номер карты, который вы хотите найти в коллекции:");
            string cardNumberToFind = Console.ReadLine(); // Запрос ввода пользователя

            int index = -1; // Инициализируем переменную индекса

            // Поиск карты с указанным номером
            foreach (BankCard card in al)
            {
                index++;
                if (card.Number == cardNumberToFind) // Предполагается, что у класса BankCard есть свойство CardNumber
                {
                    Console.WriteLine($"Карта с номером {cardNumberToFind} найдена на позиции {index + 1}.");
                    break;
                }
            }

            if (index == -1 || index >= al.Count)
            {
                Console.WriteLine($"Карта с номером {cardNumberToFind} не найдена.");
            }
            Console.WriteLine("------------------------------------------------------------------------------");


            // Выводим количество элементов после удаления
            Console.WriteLine($"Количество элементов в коллекции после удаления: {al.Count}");
            Console.WriteLine($"Коллекция может содержать {al.Capacity} элементов");
        }
    }
}
