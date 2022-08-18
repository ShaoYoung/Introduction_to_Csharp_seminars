//Задача 57
//Составить частотный словарь элементов двумерного массива
//Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных
//array = [1,2,3,4,2,1,3,2,4,2,3,7]
//alphabet = [1,2,3,4,7]
//frequency = [2,4,3,2,1]

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

//печать int массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(" ", array)}]");
}

//заполнение частотного словаря. на вхоже матрица и размер алфавита (допустимый диапазон элементов матрицы от 0 до alphabetLength-1)
int[] FrequencyCollect(int[,] matrix, int alphabetLength)
{
    int[] resultArray = new int[alphabetLength];
    int i = 0;
    int j = 0;
    while (i < matrix.GetLength(0))
    {
        j = 0;
        while (j < matrix.GetLength(1))
        {
            //собираем частоту появления элементов
            resultArray[matrix[i, j]]++;
            j++;
        }
        i++;
    }
    return resultArray;
}


Console.Clear();
int[,] matrix = FillMatrix(5, 5);
PrintMatrix(matrix);
Console.WriteLine("Частотный массив: ");
PrintArray(FrequencyCollect(matrix, 10));

