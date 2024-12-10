using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class Menu
    {
        private List<String> elements = new List<String>();

        public void Setup(List<String> menuElements)
        {
            if (menuElements != null)
            {
                elements = menuElements;
            }
        }
        public int Open()
        {
            Console.CursorVisible = false;
            var max = 0;
            Console.CursorVisible = false;
            var chosen = 0;
            ConsoleKeyInfo key;

            do
            {
                for (var i = 0; i < elements.Count; i++)
                {

                    for (var j = 0; j < elements.Count; j++)
                    {

                        if (elements[j].Length > max)
                        {
                            max = elements[j].Length;
                        }
                    }

                    if (i == chosen)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 5, (Console.WindowHeight / 2) + i);
                    Console.WriteLine(elements[i].PadRight(max));

                }

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && chosen > 0)
                {
                    chosen--;
                }
                else if (key.Key == ConsoleKey.DownArrow && chosen < elements.Count - 1)
                {
                    chosen++;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    chosen = -1;
                }

            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            Console.CursorVisible = true;
            Console.ResetColor();
            return chosen;
        }

    }
}
