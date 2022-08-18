// Задача 54. Домашнее задание.
// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 1 2 4 7
// 2 3 5 9
// 2 4 4 8


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

//меняет строку с номером numberRow из матрицы
int[,] ReplaceRowFromMatrix(int[,] matrix, int[] array, int numberRow)
{
    //массив из элементов строки матрицы
    for (int j = 0; j < matrix.GetLength(0); j++)
        matrix[numberRow, j] = array[j];
    return matrix;
}

//сортировка массива методом вставки
//суть в том что, на каждом шаге алгоритма берется один из элементов массива, находится позицию (согласно его значению) для вставки и вставляется
//массив из 1-го элемента считается отсортированным.
int[] InsertionSort(int[] array)
{
    int key;
    int j;
    for (int i = 1; i < array.Length; i++)
    {
        j = i - 1;
        //очередной ключ массива
        key = array[i];
        //сдвигаем массив вправо, пока ключ больше текущего элемента и ещё не начало массива. освобождаем место под ключ
        while ((j >= 0) && (array[j] > key))
        {
            array[j + 1] = array[j];
            j -= 1;
        }
        //записываем ключ на своё (свободное) место в массиве
        array[j + 1] = key;
    }
    return array;
}

//сортировка строк матрицы
int[,] SortMatrixRow(int[,] matrix)
{
    int[] array = new int[matrix.GetLength(0)];
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        //получить строку j
        array = GetRowFromMatrix(matrix, j);
        //отсортировать её
        array = InsertionSort(array);
        //заменить строку
        matrix = ReplaceRowFromMatrix(matrix, array,j);
    }
    return matrix;
}



Console.Clear();
int[,] matrix = FillMatrix(5, 5);
PrintMatrix(matrix);
Console.WriteLine("Упорядоченный массив: ");
matrix = SortMatrixRow(matrix);
PrintMatrix(matrix);
