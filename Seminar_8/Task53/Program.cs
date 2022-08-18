// Задача 53
// Задайте двумерный массив. Напишите программу которая поменяет местами первую и последнюю строки массива.


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

//меняет местами первую и последнюю строки матрицы
int[,] RotateRowFirstLast(int[,] matrix)
{
    int bufferElement = 0;
    int i = 0;
    int j = 0;
    while (j < matrix.GetLength(1))
    {
        //используем буфер
        bufferElement = matrix[0, j];
        matrix[0, j] = matrix[matrix.GetLength(0) - 1, j];
        matrix[matrix.GetLength(0) - 1, j] = bufferElement;
        j++;
    }
    return matrix;
}

Console.Clear();
int[,] matrix = FillMatrix(5, 5);
PrintMatrix(matrix);
Console.WriteLine("Изменённый массив: ");
matrix = RotateRowFirstLast(matrix);
PrintMatrix(matrix);

