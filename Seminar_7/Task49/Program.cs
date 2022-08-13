//Задача №49
// Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные, и замените эти элементы на их квадраты.
// Например:
// Например, изначально массив выглядел вот так:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Новый массив будет выглядеть вот так:
// 1 4 7 2
// 5 81 2 9
// 8 4 2 4

//массив 16 цветов консоли. глобальный.
ConsoleColor[] consoleColors = new ConsoleColor[]{ConsoleColor.Black,ConsoleColor.Blue,ConsoleColor.Cyan,
                                   ConsoleColor.DarkBlue,ConsoleColor.DarkCyan,ConsoleColor.DarkGray,
                                   ConsoleColor.DarkGreen,ConsoleColor.DarkMagenta,ConsoleColor.DarkRed,
                                   ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.Green,
                                   ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.White,
                                   ConsoleColor.Yellow};

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

//печать цветной int матрицы (через for)
void PrintColorMatrix(int[,] inputMatrix)
{
    for (int i = 0; i < inputMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inputMatrix.GetLength(1); j++)
        {
            Console.ForegroundColor = consoleColors[new System.Random().Next(0, 16)];
            Console.Write($"{inputMatrix[i, j]} ");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}

//изменение матрицы
int[,] UpdateMatrix(int[,] matrix)
{
    int[,] outArray = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if ((i % 2 == 0) && (j % 2 == 0))
                outArray[i, j] = matrix[i, j] * matrix[i, j];
            else
                outArray[i, j] = matrix[i, j];
        }
    }
    return outArray;
}

//изменение матрицы (версия Натальи, инкремент счётчика не 1, а 2, через ref)
void UpdateTwoDimArrayNataliaVersion(ref int[,] inputArray)
{
    int i = 0;
    int j = 0;
    while (i < inputArray.GetLength(0))
    {
        j = 0;
        while (j < inputArray.GetLength(1))
        {
            inputArray[i, j] = inputArray[i, j] * inputArray[i, j];
            j += 2;
        }
        i += 2;
    }
}


Console.Clear();

int[,] twoDimArray = FillMatrix(5, 5);
PrintColorMatrix(twoDimArray);
//--------------------------------------
DateTime d = DateTime.Now;
int[,] bufTwoDimArray = UpdateMatrix(twoDimArray);
Console.WriteLine(DateTime.Now - d);
//--------------------------------------
d = DateTime.Now;
//в массив twoDimArray будут внесены изменения, т.к. метод с ref
UpdateTwoDimArrayNataliaVersion(ref twoDimArray);
Console.WriteLine(DateTime.Now - d);
//--------------------------------------
PrintColorMatrix(bufTwoDimArray);
Console.WriteLine();
PrintColorMatrix(twoDimArray);

