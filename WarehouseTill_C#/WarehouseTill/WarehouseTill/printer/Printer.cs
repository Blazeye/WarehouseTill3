using System;
using System.Collections.Generic;
using WarehouseTill.model;

namespace WarehouseTill.printer
{
    class Printer
    {

        public Dictionary<string, OrdersProduct> CheckoutDict = new Dictionary<string, OrdersProduct>();

        public void PrintItemList(Dictionary<string, OrdersProduct> dict)
        {
            Console.WriteLine("================ PRINTING: ===============");
            foreach(string item in dict.Keys)
            {
                switch (item)
                {
                    case "1234":
                        PrintButter(dict[item].Amount);
                        break;
                    case "9902":
                        PrintCheese(dict[item].Amount);
                        break;
                    case "3568":
                        PrintMilk(dict[item].Amount);
                        break;
                    case "7324":
                        PrintEggs(dict[item].Amount);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("==========================================\n");
        }

        public void PrintButter(int amount)
        {
            Console.Out.WriteLine("|                                         |");
            Console.Out.WriteLine($"|    _________________________  AMOUNT: {amount} |");
            Console.Out.WriteLine("|   /                        /|           |");
            Console.Out.WriteLine("|  /     /3onko-/3oter      / |           |");
            Console.Out.WriteLine("| /_______________________ /  :           |");
            Console.Out.WriteLine("| |                        |  /           |");
            Console.Out.WriteLine("| |                        | /            |");
            Console.Out.WriteLine("| |________________________|/             |");
            Console.Out.WriteLine("|                                         |");
        }

        public void PrintEggs(int amount)
        {
        Console.Out.WriteLine("|                .-~-.                    |");
        Console.Out.WriteLine($"|              .\'     \'.        AMOUNT: {amount} |");
        Console.Out.WriteLine("|             /         \\                 |");
        Console.Out.WriteLine("|     .-~-.  :           ;                |");
        Console.Out.WriteLine("|   .\'     \'.|           |                |");
        Console.Out.WriteLine("|  /         \\           :                |");
        Console.Out.WriteLine("| :           ; .-~\"\"~-,/                 |"); 
        Console.Out.WriteLine("| |           /`        `\'.               |");
        Console.Out.WriteLine("| :          |             \\              |"); 
        Console.Out.WriteLine("|  \\         |             /              |");
        Console.Out.WriteLine("|   `.     .\' \\          .\'               |");
        Console.Out.WriteLine("|     `~~~`    \'-.____.-\'                 |");
        Console.Out.WriteLine("|                                         |");
        }
        public void PrintCheese(int amount)
        {
        Console.Out.WriteLine("|     _--\"-.                              |");
        Console.Out.WriteLine($"|  .-\"      \"-.                 AMOUNT: {amount} |");
        Console.Out.WriteLine("| | \"\"--..      \'-.                       |");
        Console.Out.WriteLine("| |       \"\"--..  \'-.                     |");
        Console.Out.WriteLine("| |.-.  .-\".   \"\"--..\".                   |");
        Console.Out.WriteLine("| |'./  -_ \' .-.      |                   |");
        Console.Out.WriteLine("| |      .-. \'.-\'   .-\'                   |");
        Console.Out.WriteLine("| '--..  \'.\'    .-  -.                    |");
        Console.Out.WriteLine("|     \"\"--..    \'_\'   :                   |");
        Console.Out.WriteLine("|          \"\"--..     |                   |");
        Console.Out.WriteLine("|                \"\" - \'                   |");
        Console.Out.WriteLine("|                                         |");

        }
        public void PrintMilk(int amount)
        {
        Console.Out.WriteLine("|     ________                            |");
        Console.Out.WriteLine($"|    j________j                 AMOUNT: {amount} |");
        Console.Out.WriteLine("|   /________/_\\                          |");
        Console.Out.WriteLine("|  |         |  |                         |");
        Console.Out.WriteLine("|  | |\\/|ELK |  |                         |");
        Console.Out.WriteLine("|  |         |  |                         |");
        Console.Out.WriteLine("|  |  _(~)_  |  |                         |");
        Console.Out.WriteLine("|  |   )\"(   |  |                         |");
        Console.Out.WriteLine("|  |  (@_@)  |  |                         |");
        Console.Out.WriteLine("|  |         |  |                         |");
        Console.Out.WriteLine("|  | _______ |,/\'                         |");
        Console.Out.WriteLine("|                                         |");
        }

        public void HandlePrintItems(object s, OrdersListEventArgs e)
        {
            CheckoutDict = e.OrderList;
            PrintItemList(CheckoutDict);
        }
    }
}
