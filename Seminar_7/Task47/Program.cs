// Задача 47. Домашнее задание.
// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами. Округлить до 4 цифр после запятой.
//Random * 100
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9
// * При выводе матрицы показывать каждую цифру разного цвета(цветов всего 16)
//т.е. каждый элемент матрицы надо будет перевести в строку и каждый элемент строки напечатать random-цветом

//массив 16 цветов консоли. глобальный.
ConsoleColor[] consoleColors = new ConsoleColor[]{ConsoleColor.Black,ConsoleColor.Blue,ConsoleColor.Cyan,
                                   ConsoleColor.DarkBlue,ConsoleColor.DarkCyan,ConsoleColor.DarkGray,
                                   ConsoleColor.DarkGreen,ConsoleColor.DarkMagenta,ConsoleColor.DarkRed,
                                   ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.Green,
                                   ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.White,
                                   ConsoleColor.Yellow};

/// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. Принимает bool - необходимость выполнения проверки знака числа.
// для проверки использует метод TryParse
int GetDataTryParse(bool signControl)
{
    bool testDigits = false;
    int result = 0;
    while (!testDigits)
    {
        string? inputString = Console.ReadLine();
        //если введено число и контроль знака пройден, то парсим его и возвращаем
        if ((int.TryParse(inputString, out int data)) && ((data > 0) || (!signControl)))
        {
            testDigits = true;
            result = data;
        }
        //если введено не число или контроль знака не пройден (при необходимости его проведения), то выводим предупреждение и предлагаем пользователю выбор
        else
        {
            // Console.Clear();
            Console.WriteLine("Не корректный ввод!!!");
            Console.WriteLine("Для завершения программы нажмите клавишу Esc.");
            Console.WriteLine("Для повторного ввода нажмите любую другую клавишу.");
            //ждём нажатия клавиши (клавиша не отображается, т.к. true), если Esc, то завершаем выполнение программы
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                //Завершает этот процесс и возвращает код выхода операционной системе
                Environment.Exit(0);
            else
                Console.Write("Повторите ввод: ");
        }
    }
    return result;
}

//заполнение матрицы вещественными числами от -100 до 100, размерность row строк, col столбцов
double[,] FillMatrix(int row, int col)
{
    int sign;
    System.Random numberSintezator = new Random();
    double[,] matrix = new double[row, col];
    for (int i = 0; i < row; i++)
        for (int j = 0; j < col; j++)
        {
            //при помощи Random получаем знак
            if (numberSintezator.Next(2) == 0)
                sign = 1;
            else sign = (-1);
            matrix[i, j] = Math.Round(numberSintezator.NextDouble() * 100 * sign, 4);
        }
    return matrix;
}

//печать double матрицы
void PrintMatrix(double[,] matrix)
{
    //GetLength(0) - кол-во строк, GetLength(1) - кол-во столбцов. Для двумерного массива. Далее GetLength(2) и т.д.
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

//печать цветной double матрицы (перебор матрицы и вызов метода печати цветной строки)
void PrintColorMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            PrintColorString(matrix[i, j]);
        Console.WriteLine();
    }
}

//печать разноцветного double-числа (каждая цифра/символ random цвета). через преобразование в строку и изменение цвета шрифта консоли
void PrintColorString(double number)
{
    string numberString = Convert.ToString(number);
    //приведение строки к "красивому виду". 8 символов, т.к. знак, 2 цифры, запятая, 4 цифры после запятой
    while (numberString.Length < 8)
        numberString += " ";
    for (int i = 0; i < 8; i++)
    {
        Console.ForegroundColor = consoleColors[new System.Random().Next(0, 16)];
        Console.Write(numberString[i]);
    }
    Console.Write("  ");
    Console.ResetColor();
}


Console.Clear();

Console.Write("Введите количество строк m ");
int m = GetDataTryParse(true);
Console.Write("Введите количество столбцов n ");
int n = GetDataTryParse(true);
double[,] matrix = FillMatrix(m, n);
PrintMatrix(matrix);

Console.WriteLine("Для отображения решения задачи со * нажмите любую клавишу.");
//ждём нажатия клавиши клавиатуры (её не печатаем, т.к. true)
ConsoleKeyInfo key = Console.ReadKey(true);
PrintColorMatrix(matrix);

