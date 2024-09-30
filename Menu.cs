using System;

namespace PROJECT.BlackJack
{
    internal class Menu
    {
        private string[] menuOptions = { "Начать игру", "Правила игры", "О разработчике" };
        private int currentSelection = 0;  // Текущий выбранный пункт меню

        public void DisplayMenu()
        {
            Console.Clear();  // Очищаем экран
            Console.Title = "Black Jack Game";  // Устанавливаем заголовок консоли
            DrawTitle();  // Отображаем заголовок "BLACK JACK"
            ShowOptions();  // Показываем пункты меню
        }

        // Метод для отображения заголовка
        private void DrawTitle()
        {
            string title = "====BLACK JACK====";
            int screenWidth = Console.WindowWidth;
            int titlePosition = (screenWidth / 2) - (title.Length / 2);

            Console.SetCursorPosition(titlePosition, 2);  // Ставим текст по центру сверху
            Console.WriteLine(title);
        }

        // Метод для отображения пунктов меню
        private void ShowOptions()
        {
            int screenWidth = Console.WindowWidth;

            for (int i = 0; i < menuOptions.Length; i++)
            {
                int optionPosition = (screenWidth / 2) - (menuOptions[i].Length / 2);
                Console.SetCursorPosition(optionPosition, 5 + i * 2);  // Размещаем каждый пункт меню

                // Выделяем текущий выбор
                if (i == currentSelection)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;  // Цвет фона для выделения
                    Console.ForegroundColor = ConsoleColor.Black;  // Цвет текста
                }

                Console.WriteLine(menuOptions[i]);

                // Сбрасываем цвет фона и текста
                Console.ResetColor();
            }

            // Вывод подсказки для выбора
            Console.SetCursorPosition((screenWidth / 2) - 12, 5 + menuOptions.Length * 2);
            Console.WriteLine("Используйте стрелки вверх/вниз и нажмите Enter");
        }

        // Метод для запуска меню
        public void StartMenu()
        {
            while (true)
            {
                DisplayMenu();  // Отображаем меню

                // Читаем нажатие клавиши
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection--;  // Переход вверх по меню
                        if (currentSelection < 0)
                            currentSelection = menuOptions.Length - 1;  // Зацикливаем на последнем пункте
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection++;  // Переход вниз по меню
                        if (currentSelection >= menuOptions.Length)
                            currentSelection = 0;  // Зацикливаем на первом пункте
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (currentSelection)
                        {
                            case 0:
                                Console.WriteLine("Начинаем игру...");
                                Game game = new Game();
                                game.Start();
                                break;
                            case 1:
                                ShowRules();
                                break;
                            case 2:
                                ShowAbout();
                                break;
                        }
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                Console.ReadKey();
            }
        }

        // Метод для отображения правил игры
        private void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила игры:");
            Console.WriteLine("1. Цель игры — набрать 21 очко или как можно ближе к этой сумме");
            Console.WriteLine("2. Карты валет, дама и король 10 очков. Туз 11 очков. Остальные карты согласно их номиналу");
            Console.WriteLine("3. Игрок играет против дилера");
            Console.WriteLine("4. Если сумма очков превышает 21, игрок или дилер проигрывают");
        }

        // Метод для отображения информации о разработчике
        private void ShowAbout()
        {
            Console.Clear();
            Console.WriteLine("О разработчике:");
            Console.WriteLine("Разработчик: Беноева Малика П26");
        }
    }
}
