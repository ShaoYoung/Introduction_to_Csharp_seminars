// Задача 58 Домашнее задание
// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, заданы 2 массива:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// и
// 1 5 8 5
// 4 9 4 2
// 7 2 2 6
// 2 3 4 7
// Их произведение будет равно следующему массиву:
// 1 20 56 10
// 20 81 8 6
// 56 8 4 24
// 10 6 24 49
//умножать не строки на строки и столбцы на стодбцы
//умножить строки одной матрицы на столбцы другой матрицы и наоборот
//проверка условий. длина столбцов А = длине строк B и наоборот

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. Принимает bool - необходимость выполнения проверки знака числа.
// для проверки использует метод TryParse
int GetDataTryParse(bool signControl)
{
    bool testDigits = false;
    int result = 0;
    while (!testDigits)
    {
        string? inputString = Console.ReadLine();
        //если введено число и контроль знака пройден, то парсим его и возвращаем
        if ((int.TryParse(inputString, out int data)) && ((data >= 0) || (!signControl)))
        {
            testDigits = true;
            result = data;
        }
        //если введено не число или контроль знака не пройден (при необходимости его проведения), то выводим предупреждение и предлагаем пользователю выбор
        else
        {
            Console.WriteLine("Не корректный ввод!!!");
            Console.WriteLine("Для завершения программы нажмите клавишу Esc.");
            Console.WriteLine("Для повторного ввода нажмите любую другую клавишу.");
            //ждём нажатия клавиши (клавиша не отображается, т.к. true), если Esc, то завершаем выполнение программы
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                //Завершает этот процесс и возвращает код выхода операционной системе
                Environment.Exit(0);
            else
                Console.Write("Повторите ввод: ");
        }
    }
    return result;
}

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

//умножение двух матриц. столбец матрицы A на строку матрицы B и наоборот. возвращает матрицу
int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
{
    for (int i = 0; i < matrixA.GetLength(0); i++)
        for (int j = 0; j < matrixA.GetLength(1); j++)
            matrixA[i, j] *= matrixB[j, i];
    return matrixA;
}

Console.Clear();
Console.Write("Введите количество строк первой матрицы m ");
int m = GetDataTryParse(true);
Console.Write("Введите количество столбцов первой матрицы n ");
int n = GetDataTryParse(true);
int[,] matrixA = FillMatrix(m, n);
PrintMatrix(matrixA);

Console.Write("Введите количество строк второй матрицы m ");
m = GetDataTryParse(true);
Console.Write("Введите количество столбцов второй матрицы n ");
n = GetDataTryParse(true);
int[,] matrixB = FillMatrix(m, n);
PrintMatrix(matrixB);

if ((matrixA.GetLength(0) == matrixB.GetLength(1)) && (matrixA.GetLength(1) == matrixB.GetLength(0)))
{
    Console.WriteLine("Произведение двух матриц (строки A * столбцы B и наоборот):");
    PrintMatrix(MultiplyMatrix(matrixA, matrixB));
}
else
    Console.WriteLine("Перемножение двух матриц (строки A * столбцы B и наоборот) невозможно!");







