// Задача 56 Домашнее задание
// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: например, 1 строка
// * выдать саму строку

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

//получает строку с номером numberRow из матрицы
int[] GetRowFromMatrix(int[,] matrix, int numberRow)
{
    //массив из элементов строки матрицы
    int[] array = new int[matrix.GetLength(0)];
    for (int j = 0; j < matrix.GetLength(0); j++)
        array[j] = matrix[numberRow, j];
    return array;
}

//печать int массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(" ", array)}]");
}

//суммирует элементы массива
int SumElementArray(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
        sum += array[i];
    return sum;
}

//ищет наименьший элемент массива. возвращает его индекс
int FindMinInArray(int[] array)
{
    int min = array[0];
    int minIndex = 0;
    for (int i = 1; i < array.Length; i++)
        if (array[i] < min)
        {
            min = array[i];
            minIndex = i;
        }
    return minIndex;
}

//ищет строку матрицы с наименьшей суммой элементов. возвращает массив (минимальную строку). номер строки через ref
int[] FindMinSumRowElement(int[,] matrix, ref int indexMinRow)
{
    int[] array = new int[matrix.GetLength(0)];
    int[] outputArray = new int[matrix.GetLength(0)];
    //формируем массив из сумм элементов строк матрицы
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        //получить строку j
        array = GetRowFromMatrix(matrix, j);
        outputArray[j] = SumElementArray(array);
    }
    //массив сумм элементов каждой строки матрицы (для проверки)
    // PrintArray(outputArray);
    //номер строки с наименьшей суммой элементов
    indexMinRow = FindMinInArray(outputArray);
    //сама строка в виде массива
    outputArray = GetRowFromMatrix(matrix, indexMinRow);
    return outputArray;
}


Console.Clear();
int[,] matrix = FillMatrix(5, 5);
//индекс строки с наименьшей суммой элементов
int indexMinRow = int.MaxValue;
PrintMatrix(matrix);
Console.WriteLine("Строка матрицы с наименьшей суммой элементов: ");
PrintArray(FindMinSumRowElement(matrix, ref indexMinRow));
Console.WriteLine($"Её номер: {indexMinRow}");



