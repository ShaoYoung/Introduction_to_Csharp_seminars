//Задача 55
//Двумерный массив
//Заменяет строки на столбцы
//В случае, если это невозможно, программа должна вывести сообщение для пользователя

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
int[,] RotateRowCol(int[,] matrix)
{
    int bufferElement = 0;
    int i = 0;
    int j = 0;
    while (i < matrix.GetLength(0))
    {
        j = i;
        while (j < matrix.GetLength(1))
        {
            bufferElement = matrix[i, j];
            matrix[i, j] = matrix[j, i];
            matrix[j, i] = bufferElement;
            j++;
        }
        i++;
    }
    return matrix;
}

Console.Clear();
int[,] matrix = FillMatrix(5, 5);
PrintMatrix(matrix);
if (matrix.GetLength(0) != matrix.GetLength(1))
    Console.WriteLine("Данный массив перевернуть нельзя!");
else
{
    Console.WriteLine("Изменённый массив: ");
    matrix = RotateRowCol(matrix);
    PrintMatrix(matrix);
}




