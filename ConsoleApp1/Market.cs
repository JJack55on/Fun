using System;

namespace ConsoleApp1
{
    public class Market (string Name)
    {
        public string StoreName { get; set; } // Название магазина

        public int StoreSize { get; set; } // Размер склада

        public List <Fruits> fruitsList { get; set; } = [];

        public void WriteName() 
        {
            Console.WriteLine($"{StoreName}");
        }
    }
}
