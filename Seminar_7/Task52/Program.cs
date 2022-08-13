// Задача 52. Домашнее задание
// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
// * Дополнительно вывести среднее арифметическое по диагоналям и диагональ выделить разным цветом.

//заполнить массив
//напечатать его
//создать одномерный массив из каждого столбца двумерного массива
//посчитать среднее арифметическое элементов в каждом столбце double отдельным методом. Собрать одномерный массив средних чисел, вывести на печать по формату ДЗ

//*
//каждой диагонали крест накрест (в одну и в другую сторону)
//печать всех диагоналей разным цветом. одна диагональ одним цветом, вторая другим цветом
//среднее арифметическое по каждой диагонали (в одну и в другую сторону)

//массив допустимых цветов консоли. глобальный.
ConsoleColor[] consoleColors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Red };

//заполнение двумерного массива натуральных чисел (через for)
int[,] FillMatrix(int row, int col)
{
    System.Random numberSyntezator = new System.Random();
    int[,] outMatrix = new int[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            outMatrix[i, j] = numberSyntezator.Next(0, 10);
        }
    }
    return outMatrix;
}

//печать двумерного int массива (через for)
void PrintMatrix(int[,] matrix)
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

//создание одномерного массива из столбцов матрицы
int[] MakeArrayFromMatrix(int[,] matrix, int column)
{
    int[] array = new int[matrix.GetLength(0)];
    //заполняем одномерный массив столбцами матрицы
    for (int i = 0; i < matrix.GetLength(0); i++)
        array[i] = matrix[i, column];
    return array;
}

//вычисление среднего арифметического из одномерного массива
double FindAverage(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
        sum += array[i];
    return Math.Round(((float)(sum) / array.Length), 1);
}

//заполнение одномерного массива средних чисел. на входе матрица
double[] FillAverageArray(int[,] matrix)
{
    double[] averageArray = new double[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        int[] columnArray = MakeArrayFromMatrix(matrix, i);
        double average = FindAverage(columnArray);
        averageArray[i] = average;
    }
    return averageArray;
}

//печать double массива
void PrintArray(double[] array)
{
    //из-за точки в конце строки необходима дополнитльная строковая переменная
    string stringArray = string.Join("; ", array) + ".";
    Console.WriteLine(stringArray);
}

//создание одномерного массива из средних арифметических значений диагоналей матрицы и формирование матрицы цвета для печати. на входе матрица и ref матрица цвета
double[] MakeAverageArrayFromMartixDiagonal(int[,] matrix, ref ConsoleColor[,] colorMatrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    //номер цвета шрифта консоли
    int numberColor;
    //количество элементов диагонали с номером diag
    int count = 0;
    //сумма элементов диагонали с номером diag
    int sum = 0;
    //количество диагоналей
    int amountDiagonal = rows + cols - 1;
    double[] averageArray = new double[amountDiagonal];
    for (int diag = 0; diag < amountDiagonal; diag++)
    {
        count = 0;
        sum = 0;
        Console.Write($"Диагональ {diag + 1}: ");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                //критерий отнесения элемента матрицы к диагонали с номером diag
                if (i + j - diag == 0)
                {
                    //увеличиваем сумму элементов диагонали с счётчик их количества
                    sum += matrix[i, j];
                    count++;
                    //задаём цвет для этой диагонали (из глобального массива consoleColors)
                    numberColor = diag - (consoleColors.Length * (diag / consoleColors.Length));
                    colorMatrix[i, j] = consoleColors[numberColor];
                    Console.Write(matrix[i, j] + " ");
                }
        }
        Console.WriteLine();
        averageArray[diag] = Math.Round(((float)(sum) / count), 1); ;
    }
    return averageArray;
}

//поворот int матрицы на 90 градусов против часовой стрелки
int[,] RotateMatrix(int[,] matrix)
{
    int[,] tempMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            tempMatrix[matrix.GetLength(1) - j - 1, i] = matrix[i, j];
    return tempMatrix;
}

//поворот ConsoleColor матрицы на 90 градусов против часовой стрелки
ConsoleColor[,] RotateConsoleColorMatrix(ConsoleColor[,] matrix)
{
    ConsoleColor[,] tempMatrix = new ConsoleColor[matrix.GetLength(1), matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            tempMatrix[matrix.GetLength(1) - j - 1, i] = matrix[i, j];
    return tempMatrix;
}

//печать цветной int матрицы (через for)
void PrintColorMatrix(int[,] inputMatrix, ConsoleColor[,] colorMatrix)
{
    for (int i = 0; i < inputMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inputMatrix.GetLength(1); j++)
        {
            //цвет шрифта консоли меняем согласно матрице цвета colorMatrix
            Console.ForegroundColor = colorMatrix[i, j];
            Console.Write($"{inputMatrix[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.ResetColor();
}

Console.Clear();
int[,] matrix = FillMatrix(4, 7);
PrintMatrix(matrix);
double[] averageArray = FillAverageArray(matrix);
Console.Write("Среднее арифметическое каждого столбца: ");
PrintArray(averageArray);

Console.WriteLine("Для отображения решения задачи со * нажмите любую клавишу.");
//ждём нажатия клавиши клавиатуры (её не печатаем, т.к. true)
ConsoleKeyInfo key = Console.ReadKey(true);

//матрица цвета
ConsoleColor[,] colorMatrix = new ConsoleColor[matrix.GetLength(0), matrix.GetLength(1)];
averageArray = MakeAverageArrayFromMartixDiagonal(matrix, ref colorMatrix);
Console.Write("Среднее арифметическое каждой диагонали (наклон справа сверху влево вниз): ");
PrintArray(averageArray);
PrintColorMatrix(matrix, colorMatrix);
Console.WriteLine();

//поворачиваем матрицу для работы со второй группой диагоналей
int[,] rotatedMatrix = RotateMatrix(matrix);
//матрица цвета повёрнутой матрицы
ConsoleColor[,] colorRotatedMatrix = new ConsoleColor[rotatedMatrix.GetLength(0), rotatedMatrix.GetLength(1)];
averageArray = MakeAverageArrayFromMartixDiagonal(rotatedMatrix, ref colorRotatedMatrix);
Console.Write("Среднее арифметическое каждой диагонали (наклон слева сверху вправо вниз): ");
PrintArray(averageArray);
//поворачиваем матрицу цвета
colorRotatedMatrix = RotateConsoleColorMatrix(colorRotatedMatrix);
PrintColorMatrix(matrix, colorRotatedMatrix);



