// Задача 62 Домашнее задание
// Задача со *
// Заполните спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 1   2  3  4
// 12 13 14  5
// 11 16 15  6
// 10  9  8  7

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

//печать двумерного int массива (через for)
void PrintMatrix(int[,] matrix)
{
    //GetLength(0) - кол-во строк, GetLength(1) - кол-во столбцов. Для двумерного массива. Далее GetLength(2) и т.д.
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            string elementMatrix = matrix[i, j].ToString();
            while (elementMatrix.Length < 4)
                elementMatrix = " " + elementMatrix;
            Console.Write(elementMatrix);
        }
        Console.WriteLine();
    }
}

//заполняет матрицу улиткой. размерность матрицы любая (m x n).
// для работы с любой прямоугольной матрицей пришлось добавить проверку после каждой стороны matrixFilled = value < maxValue ? false : true;
int[,] FillSnailMatrix(int m, int n)
{
    int[,] matrix = new int[m, n];
    //количество ячеек (диапазон чисел от 1 до m*n) матрицы
    int maxValue = m * n;
    //начальное значение
    int value = 0;
    int x = 0;
    int y = 0;
    int i;
    int j;
    bool matrixFilled = false;

    while (!matrixFilled)
    {
        //начальная точка очередного кольца
        i = x;
        j = y;

        //заполняем первую строку матрицы
        if (!matrixFilled)
            while (j < n)
                if (value < maxValue)
                    matrix[i, j++] = ++value;
        matrixFilled = value < maxValue ? false : true;
        //текущую позицию матрицы на нужное место
        j--;
        i++;

        //заполняем последний столбец матрицы
        if (!matrixFilled)
            while (i < m)
                if (value < maxValue)
                    matrix[i++, j] = ++value;
        matrixFilled = value < maxValue ? false : true;
        //текущую позицию матрицы на нужное место
        i--;
        j--;

        //заполняем последнюю строку матрицы
        if (!matrixFilled)
            while (j >= x)
                if (value < maxValue)
                    matrix[i, j--] = ++value;
        matrixFilled = value < maxValue ? false : true;
        //текущую позицию матрицы на нужное место
        j++;
        i--;

        //заполняем первый столбец матрицы
        if (!matrixFilled)
            while (i >= y + 1)
                if (value < maxValue)
                    matrix[i--, j] = ++value;
        matrixFilled = value < maxValue ? false : true;

        //убираем внешний контур для следующего прохода
        m = m < 2 ? 0 : m - 1;
        n = n < 2 ? 0 : n - 1;
        x++;
        y++;
    }
    return matrix;
}

Console.Clear();

Console.Write("Введите количество строк матрицы m ");
int m = GetDataTryParse(true);
Console.Write("Введите количество столбцов матрицы n ");
int n = GetDataTryParse(true);
int[,] matrix = FillSnailMatrix(m, n);
PrintMatrix(matrix);
