//Задача №51
// Задайте двумерный массив. Найдите сумму элементов, находящихся на главной диагонали (с индексами (0,0); (1;1) и т.д.
// Например:
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Сумма элементов главной диагонали: 1+9+2 = 12

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

//поиск суммы элементов по диагонали
int CalculateDiagonalMartix(int[,] matrix)
{
    int outSumDiagonal = 0;
    //через один цикл, т.к. i и j одинаковые
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        outSumDiagonal += matrix[i,i];
    }
    // for (int i = 0; i < matrix.GetLength(0); i++)
    //     for (int j = 0; j < matrix.GetLength(1); j++)
    //         if (i == j)
    //             outSumDiagonal += matrix[i,j];
    return outSumDiagonal;
}

Console.Clear();
int[,] matrix = FillMatrix(3,3);
PrintMatrix(matrix);
Console.WriteLine($"Сумма элементов по диагонали: {CalculateDiagonalMartix(matrix)}");


