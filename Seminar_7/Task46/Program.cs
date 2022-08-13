//Задача №46
// Задайте двумерный массив размером m×n, заполненный случайными целыми числами.
// Например:
// m = 3, n = 4.
// -1 4 8 19
// 5 -2 33 -2
// -77 3 8 1

//массив 16 цветов консоли. глобальный.
ConsoleColor[] consoleColors = new ConsoleColor[]{ConsoleColor.Black,ConsoleColor.Blue,ConsoleColor.Cyan,
                                   ConsoleColor.DarkBlue,ConsoleColor.DarkCyan,ConsoleColor.DarkGray,
                                   ConsoleColor.DarkGreen,ConsoleColor.DarkMagenta,ConsoleColor.DarkRed,
                                   ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.Green,
                                   ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.White,
                                   ConsoleColor.Yellow};

//заполнение двумерного массива натуральных чисел (через while)
// int[,] FillMatrix(int row, int col)
// {
//     System.Random numberSyntezator = new System.Random();
//     int i = 0;
//     int j = 0;
//     int[,] outMatrix = new int[row, col];
//     while (i < row)
//     {
//         j = 0;
//         while (j < col)
//         {
//             outMatrix[i, j] = numberSyntezator.Next(0, 101);
//             j++;
//         }
//         i++;
//     }
//     return outMatrix;
// }

//заполнение двумерного массива натуральных чисел (через for)
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

//печать двумерного int массива (через while)
// void PrintMatrix(int[,] inputMatrix)
// {
//     int i = 0;
//     int j = 0;
//     while (i < inputMatrix.GetLength(0))
//     {
//         j = 0;
//         while (j < inputMatrix.GetLength(1))
//         {
//             Console.Write(inputMatrix[i, j] + " ");
//             j++;
//         }
//         //аналогичная запись
//         //Console.Write("\n");
//         Console.WriteLine();
//         i++;
//     }
// }

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

//печать цветной int матрицы (через while)
// void PrintColorMatrix(int[,] inputMatrix)
// {
//     int i = 0;
//     int j = 0;
//     while (i < inputMatrix.GetLength(0))
//     {
//         j = 0;
//         while (j < inputMatrix.GetLength(1))
//         {
//             Console.ForegroundColor = consoleColors[new System.Random().Next(0, 16)];
//             Console.Write(inputMatrix[i, j] + " ");
//             Console.ResetColor();
//             j++;
//         }
//         //Console.Write("\n");
//         Console.WriteLine();
//         i++;
//     }
// }

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


Console.Clear();
int[,] matrix = FillMatrix(5, 8);
PrintMatrix(matrix);
PrintColorMatrix(matrix);




