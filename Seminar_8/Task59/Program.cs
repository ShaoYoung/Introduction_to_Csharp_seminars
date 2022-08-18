//Задача 59
//Двумерный массив
//Удалить строку и столбец, на пересечени которых расположен наименьший элемент массива
//


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

//поиск индекса минимального элемента в матрице
int[] FindMinElement(int[,] matrix)
{
    int[] array = new int[] { 0, 0 };
    int minElement = int.MaxValue;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < minElement)
            {
                minElement = matrix[i, j];
                array[0] = i;
                array[1] = j;
            }
        }
    }
    return array;
}

//формирует новую матрицу без строки и столбца, на пересечени которых находится минимальный элемент
int[,] UpdateMatrix(int[,] matrix, int row, int col)
{
    int[,] outArray = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    int i = 0;
    int j = 0;
    int k = 0;
    int m = 0;
    while (i < matrix.GetLength(0))
    {
        j = 0;
        m = 0;
        while (j < matrix.GetLength(1))
        {
            if ((i != row) && (j != col))
                outArray[k, m] = matrix[i, j];
            if (j != col)
                m++;
            j++;
        }
        if (i != row)
            k++;
        i++;
    }
    return outArray;
}

Console.Clear();
int[,] matrix = FillMatrix(5, 5);
PrintMatrix(matrix);
Console.WriteLine();

int[] indexes = FindMinElement(matrix);
Console.WriteLine($"Наименьший элемент матрицы имеет индекс {indexes[0]} {indexes[1]}");
int[,] buffer = UpdateMatrix(matrix, indexes[0], indexes[1]);
PrintMatrix(buffer);


