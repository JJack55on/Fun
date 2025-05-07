using System;

namespace ConsoleApp1
{
    public class Fruits(string Name) : Market("")
    {
        public string FruitName { get; set; }

        public int Price { get; set; } // Цена за фрукт, шт

        public int Sold { get; set; } // Кол-во проданного товара

        public int Quantity { get; set; } // Кол-во товара на складе

        public void AddFruit(FruitType selectedFruit, int amount)
        {
            var vacancy = StoreSize - Quantity;

            if (amount > vacancy)
            {
                Console.WriteLine("Склад переполнен");
                return;
            }

            switch (selectedFruit)
            {
                case FruitType.Apples:
                    Quantity += amount;
                    break;
                case FruitType.Oranges:
                    Quantity += amount;
                    break;
            }

            Console.WriteLine("Фрукт добавлен на склад"); 
        }

        public void SoldFruits(FruitType selectedFruit, int amount)
        {
            if (amount > Quantity && selectedFruit == FruitType.Apples)
            {
                Console.WriteLine("Нельзя продать больше кол-ва на складе");
                return;
            }

            if (amount > Quantity && selectedFruit == FruitType.Oranges)
            {
                Console.WriteLine("Нельзя продать больше кол-ва на складе");
                return;
            }

            switch (selectedFruit)
            {
                case FruitType.Apples:
                    Sold += amount;
                    Quantity -= amount;
                    break;
                case FruitType.Oranges: 
                    Sold += amount;
                    Quantity -= amount;
                    break;
            }

            Console.WriteLine("Кол-во проданных фруктов");
        }

        public int Revenue()
        {
            return Sold * Price;
        }

        //public void RevenueDescending(Dictionary<string,int> marketRevenues) 
        //{
        //    var sortedMarket = marketRevenues.OrderByDescending(pair=>pair.Value);
        //}
    }

    public enum FruitType
    {
        Apples = 1,
        Oranges = 2
    }
}

