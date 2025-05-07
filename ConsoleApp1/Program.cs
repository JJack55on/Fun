using System;
using ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    { 
        if (File.Exists("///Users/evgenijzavalov/Downloads/Market.csv"))
        {
            List<Market>markets = new List<Market>()
            {
            new Market ("1.Фрукты и овощи"),
            new Market ("2.Витамины"),
            new Market ("3.Свежие фрукты"),
            new Market ("4.Своя грядка"),
            new Market ("5.У Палыча")
            }; 

            var fruits = new List<Fruits>();
            
            while (true)
            {
                Console.WriteLine("0. Прочитать файл");
                Console.WriteLine("\nВыберите магазин (1-5):");
                for (int i = 0; i < markets.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {markets[i].StoreName}");
                }
                int marketIndex;
                while (!int.TryParse(Console.ReadLine(), out marketIndex) || marketIndex < 1 || marketIndex > 5)
                {
                    Console.WriteLine("Неверный ввод. Введите число от 1 до 5:");
                }

                Console.WriteLine("1. Добавить товар в магазин");
                Console.WriteLine("2. Показать информацию о проданных товарах");
                Console.WriteLine("3. Показать выручку магазинов (по убыванию)");
                Console.WriteLine("4. Сохранить данные в файл");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        FileReader();
                        break;
                    case "1":
                        if(int.TryParse(Console.ReadLine(), out int amount)) 
                        {
                            Console.WriteLine("Склад переполнен");
                        }
                        markets[markets.Count - 0].fruitsList[4].Quantity += amount;
                        markets[markets.Count - 0].fruitsList[6].Quantity += amount;
                        break;
                    case "2":
                        if (int.TryParse(Console.ReadLine(), out int goods))
                        {
                            Console.WriteLine("Нельзя продать больше кол-ва на складе");
                        }
                        markets[markets.Count - 0].fruitsList[4].Quantity += goods;
                        markets[markets.Count - 0].fruitsList[5].Sold -= goods;

                        markets[markets.Count - 0].fruitsList[6].Quantity += goods;
                        markets[markets.Count - 0].fruitsList[7].Sold -= goods;
                        break;
                    case "3":
                        if (int.TryParse(Console.ReadLine(), out int r))
                        {
                            markets[markets.Count - 0].fruitsList[4].Price
                                = markets[markets.Count - 0].fruitsList[4].Sold * markets[markets.Count - 0].fruitsList[4].Price;
                        }
                        break;
                    case "4":
                        SaveToCsv();
                        break;
                }
            }

            //// var fileContent=string.Join('\n', markets);
            //// File.WriteAllText("market2.csv", fileContent);
        }
    }

    public static void FileReader() 
    {
        var markets = new List<Market>();

        StreamReader streamReader = File.OpenText("///Users/evgenijzavalov/Downloads/Market.csv");
        streamReader.ReadLine();
        while (!streamReader.EndOfStream)
        {
            var marketStock = streamReader.ReadLine().Split(',');

            var apples = new Fruits("")
            {
                FruitName = "Apple",
                Price = int.Parse(marketStock[2]),
                Sold = int.Parse(marketStock[5]),
                Quantity = int.Parse(marketStock[4]),
            };

            var oranges = new Fruits("")
            {
                FruitName = "Orange",
                Price = int.Parse(marketStock[3]),
                Sold = int.Parse(marketStock[7]),
                Quantity = int.Parse(marketStock[6]),
            };

            markets.Add(
                new Market("")
                {
                    StoreName = marketStock[0],
                    StoreSize = int.Parse(marketStock[1]),
                    fruitsList = new List<Fruits> { apples, oranges }
                });
        }
        streamReader.Close();
    }

    //public void UserInput() 
    //{

    //}
}