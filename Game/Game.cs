using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;


namespace KeyboardMenu
{
    class Game
    {
        int wins = 0; // счетчик побед игрока
        int computer = 0; // счетчик побед компьютера
        int draw = 0; // счетчик 
        int gamesPlayed = 0; // счетчик сыгранных игр
        public void Start()
        {
            RunMainMenu(); // запускаем метод RunMainMenu
        }

        private void RunMainMenu()
        {
            
            string prompt = "  " +
                "_______     _______     _______     _______\r\n" +
                " |A      |   |A      |   |A      |   |A      |\r\n |       |   |       |   |       |   |       |\r\n" +
                " |   ♣   |   |   ♠   |   |   ♥   |   |   ♦   |\r\n |_______|   |_______|   |_______|   |_______|\r\n\n " +
                "\n Игра “Очко” или “21”(двадцать одно) – это русский вариант “Блэкджека”.\n " +
                "В отличие от “Блэкджека” в игре “Очко” значения карт валет, дама и король\n " +
                "не 10, а 2, 3 и 4 соответственно, чем частично восполняется отсутствие карт \n " +
                "от двойки до пятёрки. соответственно, чем частично восполняется отсутствие \n " +
                "карт от двойки до пятёрки. Но, так как количество карт, имеющих значение 10,\n " +
                "существенно меньше, чем в “Блэкджеке”, то игровой баланс сильно отличается.\n " +
                "Туз – 11. Король – 4. Дама – 3. Валет – 2. Остальные по нумерованию. \n\nEnter чтобы выбрать\n";

            string[] options = { "Играть", "Статистика", "Выход" }; // создаем массив
            Menu mainMenu = new Menu(prompt, options); // создаем обьект класса Menu
            int selectedIndex = mainMenu.Run(); // запускаем метод Run
            
            switch (selectedIndex) // делаем проверку 
            {
                case 0: // если selectedIndex = 0 то запускаем метод Play
                    Play();
                    break;
                case 1: // если selectedIndex = 1 то запускаем метод Stats
                    Stats(wins, computer, draw, gamesPlayed); // и передаем 4 аргумента
                    break;
                case 2: // если selectedIndex = 2 то запускаем метод ExitGame
                    ExitGame();
                    break;

            }
        }

        private void ExitGame()
        {
            Console.WriteLine("Для выхода нажмите любую клавишу");
            Console.ReadKey(true); // Нажатие клавиши
            Environment.Exit(0); // запуск метода Exit

        }
        private void Play()
        {

            Console.ForegroundColor = ConsoleColor.Yellow; // меняем цвет текста
            Console.Clear(); // очищаем консоль 
            Console.WriteLine("Добро пожаловать в игру 21 очко!\n");

            bool play = true; 
            

            while (play) // цикл работает пока play истинно
            {
                gamesPlayed++; // +1 после каждой сыгранной игры
              
     
                int playerScore = 0; // подсчет суммы карт игрока
                int computerScore = 0; // подсчет суммы карт компьютера


                while (true)
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Ваши карты: " + playerScore);
                    Console.WriteLine("---------------");
                    Console.WriteLine();
                    Console.WriteLine("Хотите взять еще карту? Нажмите клавишу ('Y' - да / 'N' - нет )\n");
                    
                    ConsoleKeyInfo key = Console.ReadKey(true); // считывание нажатой клавиши
             
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        Beep(); // вызов метода Beep
                        Console.ResetColor(); // сбрасываем цвета
                        RunMainMenu(); // вызов метода RunMainMenu
                      
                    }
                    if (key.Key == ConsoleKey.Y) // если нажатая клавиша равна Y
                    {

                        Beep(); // вызов метода Beep
                    
                        int card = GetRandomCard(); // присваивание случайного элемента в переменную card путём работы метода GetRandomCard
                        playerScore += card; // К сумме карт игрока прибавляем случайную карту

                    if (playerScore > 21) // если сумма карт игрока > 21
                    {
                        Console.WriteLine("Вы проиграли!");
                        computer += 1; // +1 к счетчику побед компьютера
                        break; // завершение программы
                    }
                    }
                    
                    else if (key.Key == ConsoleKey.N) // если нажатая клавиша равна N
                    {
                        Beep(); // вызов метода Beep
                        break; // завершение программы
                    }
                    else
                    {
                        Console.WriteLine("Нажмите Y или N");
                    }

                    
                }

                // Ход компьютера
                if (playerScore <= 21) // если сумма карт <= 21
                {
                    
                    while (computerScore < 17) // пока у компьютера сумма карт < 17 цикл работает
                    {
                        int card = GetRandomCard(); // присваивание случайного элемента в переменную card путём работы метода GetRandomCard
                        computerScore += card; // К сумме карт компьютера прибавляем случайную карту
                    }

                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Карты компьютера: " + computerScore);
                    Console.WriteLine("-----------------------");

                    if (computerScore > 21 || playerScore > computerScore) // проверка условия если у компьюетра > 21 или у игрока > компьютера
                    {
                        Console.WriteLine("Вы выиграли!");
                        wins++; // +1 к счетчику побед игрока
                    }
                    else if (playerScore == computerScore) // проверка условия если сумма карт игрока и компьютера равна
                    {
                        Console.WriteLine("Ничья!");
                        draw += 1; // +1 к счетчику ничьей
                    }
                    else
                    {
                        Console.WriteLine("Вы проиграли!");
                        computer += 1; // +1 к счетчику побед компьютера
                    }
                }

                bool gameAgain = true;
                while(gameAgain) // цикл работает пока gameAgain истинно
                    {
                    Console.WriteLine();
                    Console.WriteLine("Хотите сыграть еще раз? ('Y' - да / 'Backspace' - выйти в главное меню)");
                    ConsoleKeyInfo playAgain = Console.ReadKey(true); // считывание нажатой клавиши
                    if (playAgain.Key == ConsoleKey.Backspace) // если клавиша равна Backspace
                    {
                        Beep(); // вызов метода Beep
                        Console.ResetColor(); // сбрасываем цвета
                        RunMainMenu(); // вызов метода RunMainMenu
                        break;
                    }
                    else if (playAgain.Key == ConsoleKey.Y) // если клавиша равна Y
                    {
                        Beep(); // вызов метода Beep
                        gameAgain = false; // изменение переменной на ложную
                        Console.Clear(); // очистика консоли
                    }
                    else
                    {
                        Console.WriteLine("Нажмите 'Y' чтобы начать заново или 'Backspace' чтобы выйти в главное меню ");
                    }
                }
               
        }
    }

        private int GetRandomCard() // метод возвращающий случайный элемент из массива
        {
            Random random = new Random(); // инициализация класса рандом в переменную random
            int[] cards = { 2, 3, 4, 6, 7, 8, 9, 10, 11 }; // создание массива
            int index = random.Next(cards.Length); // выбираем случайное число от 0 до длины массива cards
            return cards[index]; // возвращаем случайный элемент из массива
        }

        public void Beep()
        {
            Console.Beep(494, 120);
        }
        private void Stats(int wins, int computer, int draw, int games) // метод с 4 параметрами
        {
            Console.ForegroundColor = ConsoleColor.Green; // меняем цвет текста

            PrintStats(wins, computer, draw, games); // метод который будет выводить статистику
            void PrintStats(int wins, int computer, int draw, int games)
            {
                Console.Clear();
                Console.WriteLine("Статистика\n");
                Console.WriteLine("----------------------");
                Console.WriteLine($"Побед игрока: {wins}");
                Console.WriteLine($"Побед компьютера: {computer}");
                Console.WriteLine($"Ничья: {draw}");
                Console.WriteLine($"Сыгранных игр: {games}");
                Console.WriteLine("----------------------");
                Console.WriteLine();
                Console.WriteLine("Нажмите клавишу 'Backspace' для возврата в меню");
                Console.WriteLine("Клавиша 'Delete' - стереть статистику");
            }
            
            
     
            bool stat = true;
            while (stat) // цикл работает пока stat истинно
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // нажатая клавиша сохраненная в key

                if (key.Key == ConsoleKey.Backspace) // цикл будет работать если key = клавише Backspace
                {
                    Beep();
                    stat = false; // меняем значение переменной на ложь
                    Console.ResetColor(); // сбрасываем цвета 
                    RunMainMenu(); // вызов метода RunMainMenu
                }
                else if (key.Key == ConsoleKey.Delete) // цикл будет работать если key = клавише Delete
                {
                    Beep(); // вызов метода Beep
                    this.wins = 0; // обнуляем счетчики
                    this.computer = 0; // обнуляем счетчики
                    this.draw = 0; // обнуляем счетчики
                    this.gamesPlayed = 0; // обнуляем счетчики
                    PrintStats(this.wins, this.computer, this.draw, this.gamesPlayed); // вызываем метод PrintStats с обновленными данными
                }
                else
                {
                    Console.WriteLine("Нажмите 'Backspace' для возврата в меню или 'Delete' чтобы стереть статистику");
                }
            }
           
        }

   
        
    }
    
}
