using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace KeyboardMenu
{
    class Menu
    {
        private int SelectedIndex; // обьявляем переменные
        private string[] Options; // обьявляем переменную - массив
        private string Prompt; // обьявляем переменные
        Game game = new Game();
        public Menu(string propmpt, string[] option) // Menu конструктор класса
        {
            Prompt = propmpt;  // строка
            Options = option; // массив
            SelectedIndex = 0; // устанавливаем начальное значение 0
        }

        private void DisplayOptions() 
        {
            Console.WriteLine(Prompt);

            Console.WriteLine("----------------\n");
            for (int i = 0; i < Options.Length; i++) // цикл по массиву Options
            {
                string currentOption = Options[i]; // 
                string prefix; // обьявление переменной

                if(i == SelectedIndex) // если i = SelectedIndex
                {
                    prefix = ">";
                    Console.ForegroundColor = ConsoleColor.Yellow; // меняем цвет текста в консоли
                    Console.BackgroundColor = ConsoleColor.Red; // меняем цвет заднего фона в консоли
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White; // меняем цвет текста в консоли
                    Console.BackgroundColor = ConsoleColor.Black; // меняем цвет заднего фона в консоли
                }
                Console.WriteLine($"{prefix} {currentOption}\n");
    

            }

            Console.ResetColor();
            Console.WriteLine("----------------");
        }


        public int Run()
        {

            ConsoleKey keyPressed; // обьявляем переменную 
            do
            {
                Console.Clear(); // очистика консоли
                DisplayOptions(); // вызов метода DisplayOptions
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // запись нажатой клавиши в переменную keyInfo
                keyPressed = keyInfo.Key;  // присваиваем переменной keyPressed значение нажатой клавиши 
                if (keyPressed == ConsoleKey.UpArrow) // если keyPressed = нажатой стрелке вверх
                {
                    game.Beep(); // вызов метода Beep из класса Game
                    SelectedIndex--; // уменьшаем выбранный индекс
                    if (SelectedIndex == -1) // проверка если выйти за границы
                    {
                        SelectedIndex = Options.Length - 1; // то присваиваем выбранному индексу значение последнее из массива Options
                    }
                }
                if (keyPressed == ConsoleKey.Enter)
                {
                    game.Beep(); // вызов метода Beep из класса Game
                }
                else if (keyPressed == ConsoleKey.DownArrow) // если нажата клавиша стрелка вниз
                {
                    game.Beep(); // вызов метода Beep из класса Game
                    SelectedIndex++; // увеличиваем выбранный индекс
                    if (SelectedIndex == Options.Length) // проверка если выйти за границы
                    { 
                        SelectedIndex = 0; // то присвиваем выбранному индексу значение 0
                    } 
                }


            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex; // возвращаем выбранный индекс
        }

    }
    
}
