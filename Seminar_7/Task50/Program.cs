// Задача 50. Домашнее задание.
// №50 Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

//НЕОБХОДИМО УТОЧНЕНИЕ ЗАДАНИЯ. ЧТО ПРИНИМАЕТСЯ НА ВХОД? НОМЕР ПОЗИЦИИ ИЛИ ЗНАЧЕНИЕ ЭЛЕМЕНТА? ЧТО ВОЗВРАЩАЕТСЯ? ЗНАЧЕНИЕ ЭЛЕМЕНТА (ПО ПОЗИЦИИ) ИЛИ НОМЕР ПОЗИЦИИ?
//судя по видеозаписи семинара, задание выглядит следующим образом:
//Напишите программу, которая на вход принимает ЗНАЧЕНИЕ элемента в двумерном массиве, 
//и возвращает ПОЗИЦИЮ этого элемента или же указание, что такого элемента нет.

//заполнить int матрицу
//печать int матрицы (ч/б)
//спросить искомый элемент в матрице
//метод поиска. принимает матрицу и искомый элемент
//возвращает ПОЗИЦИЮ элемента или "такого нет"


// * Заполнить числами Фиббоначи и выделить цветом найденную цифру
//заполнить массив числами Фибоначчи
//распечатать исходный массив
//в поиске при удаче прервать поиск, чтобы оптимизировать (нужет хотя бы один элемент)
//распечатать массив
//найденное число подсветить зелёным цветом

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
        if ((int.TryParse(inputString, out int data)) && ((data >= 0) || (!signControl)))
        {
            testDigits = true;
            result = data;
        }
        //если введено не число или контроль знака не пройден (при необходимости его проведения), то выводим предупреждение и предлагаем пользователю выбор
        else
        {
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

//заполнение двумерного массива натуральных чисел (через for) от 0 до 100
int[,] FillMatrix(int row, int col)
{
    System.Random numberSyntezator = new System.Random();
    int[,] outMatrix = new int[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            outMatrix[i, j] = numberSyntezator.Next(0, 101);
        }
    }
    return outMatrix;
}

//печать двумерного int массива (через for)
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}  ");
        }
        Console.WriteLine();
    }
}

//поиск элемента в матрице. принимает матрицу и искомый элемент, возвращает массив из трёх чисел. первое - номер строки, второе - номер столбца, третье - 1 (если элемент найден)
//если элемент не найден, то возвращает нулевой массив.
int[] FindElement(int[,] matrix, int element)
{
    int[] array = new int[] { 0, 0, 0 };
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == element)
            {
                array[0] = i;
                array[1] = j;
                array[2] = 1;
                return array;
            }
        }
    }
    return array;
}

//заполнение двумерного массива числами Фибоначчи
int[,] FillMatrixFibonachchi(int row, int col)
{
    int[,] outMatrix = new int[row, col];
    //первые два числа Фибоначчи
    int fib_1 = 0;
    int fib_2 = 1;
    outMatrix[0, 0] = fib_1;
    outMatrix[0, 1] = fib_2;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
            //первые два числа уже заполнены, их не обрабатываем
            if (!((i == 0) && (j == 0) || ((i == 0) && (j == 1))))
            {
                outMatrix[i, j] = fib_1 + fib_2;
                fib_1 = fib_2;
                fib_2 = outMatrix[i, j];
            }
    }
    return outMatrix;
}

//печать двумерного int массива (через for)
void PrintMatrixWithilluminatedElement(int[,] matrix, int[] array)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if ((i == array[0]) && (j == array[1]))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{matrix[i, j]}  ");
                Console.ResetColor();
            }
            else
                Console.Write($"{matrix[i, j]}  ");
        }
        Console.WriteLine();
    }
}

Console.Clear();
int[,] matrix = FillMatrix(10, 10);
PrintMatrix(matrix);
Console.Write("Введите элемент, который надо найти в матрице ");
int element = GetDataTryParse(true);
//массив с координатами элемента и условием его вхождения [2]
int[] elementPosition = FindElement(matrix, element);
if (elementPosition[2] == 1)
    Console.WriteLine($"Такой элемент есть в матрице. Строка {elementPosition[0]}, столбец {elementPosition[1]}.");
else
    Console.WriteLine("Такого элемента в матрице нет.");

//*
Console.WriteLine();

Console.WriteLine("Для отображения решения задачи со * нажмите любую клавишу.");
//ждём нажатия клавиши клавиатуры (её не печатаем, т.к. true)
ConsoleKeyInfo key = Console.ReadKey(true);

matrix = FillMatrixFibonachchi(5, 5);
PrintMatrix(matrix);
Console.Write("Введите число Фибоначчи, которое надо найти в матрице ");
element = GetDataTryParse(true);
elementPosition = FindElement(matrix, element);
if (elementPosition[2] == 1)
{
    Console.WriteLine($"Такое число Фибоначчи есть в матрице. Строка {elementPosition[0]}, столбец {elementPosition[1]}.");
    PrintMatrixWithilluminatedElement(matrix, elementPosition);
}
else
    Console.WriteLine("Такого числа в матрице нет.");







