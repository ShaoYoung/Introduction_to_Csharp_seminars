//Задача №48
// Задайте двумерный массив размера m на n, каждый элемент в массиве находится по формуле: Aₘₙ = m+n. Выведите полученный массив на экран.
// Пример:
// m = 3, n = 4.
// 0 1 2 3
// 1 2 3 4
// 2 3 4 5

//массив 16 цветов консоли. глобальный.
ConsoleColor[] consoleColors = new ConsoleColor[]{ConsoleColor.Black,ConsoleColor.Blue,ConsoleColor.Cyan,
                                   ConsoleColor.DarkBlue,ConsoleColor.DarkCyan,ConsoleColor.DarkGray,
                                   ConsoleColor.DarkGreen,ConsoleColor.DarkMagenta,ConsoleColor.DarkRed,
                                   ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.Green,
                                   ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.White,
                                   ConsoleColor.Yellow};

//заполнение двумерного массива натуральных чисел (через while)
int[,] FillMatrix(int row, int col)
{
    System.Random numberSyntezator = new System.Random();
    int i = 0;
    int j = 0;
    int[,] outMatrix = new int[row, col];
    while (i < row)
    {
        j = 0;
        while (j < col)
        {
            outMatrix[i, j] = numberSyntezator.Next(0, 101);
            j++;
        }
        i++;
    }
    return outMatrix;
}

//печать двумерного int массива (через while)
void PrintMatrix(int[,] inputMatrix)
{
    int i = 0;
    int j = 0;
    while (i < inputMatrix.GetLength(0))
    {
        j = 0;
        while (j < inputMatrix.GetLength(1))
        {
            Console.Write(inputMatrix[i, j] + " ");
            j++;
        }
        //аналогичная запись
        //Console.Write("\n");
        Console.WriteLine();
        i++;
    }
}

//печать цветной int матрицы (через while)
void PrintColorMatrix(int[,] inputMatrix)
{
    int i = 0;
    int j = 0;
    while (i < inputMatrix.GetLength(0))
    {
        j = 0;
        while (j < inputMatrix.GetLength(1))
        {
            Console.ForegroundColor = consoleColors[new System.Random().Next(0, 16)];
            Console.Write(inputMatrix[i, j] + " ");
            Console.ResetColor();
            j++;
        }
        //Console.Write("\n");
        Console.WriteLine();
        i++;
    }
}

//изменение матрицы
void UpdateMatrix(ref int[,] inputMatrix)

//ref - прямая ссылка на объект снаружи. при помощи метода можно его менять. в этом случае можно через void
//Ключевое слово ref передает аргументы по ссылке.
//Это означает, что любые изменения, внесенные в этот аргумент в методе, будут отражены в этой переменной,
//когда управление вернется к вызывающему методу.
//out - похожее не ref ключевое слово, но есть различия:

// Ref
// Параметр или аргумент должен быть сначала инициализирован, прежде чем он будет передан в ref.
	
// Out
// Инициализация параметра или аргумента перед передачей его в out не является обязательной.

// Ref
// Не требуется присваивать или инициализировать значение параметра (который передается по ref) перед возвратом в вызывающий метод.

// Out	
// Вызываемый метод обязан присвоить или инициализировать значение параметра (который передается в out) перед возвратом в вызывающий метод.

// Ref
// Передача значения параметра по Ref полезна, когда вызываемый метод также должен модифицировать передаваемый параметр.
	
// Out
// Объявление параметра в методе out полезно, когда из функции или метода необходимо вернуть несколько значений.

// Ref
// Инициализация значения параметра перед его использованием в вызывающем методе не обязательна.
	
// Out
// Значение параметра должно быть инициализировано в вызывающем методе перед его использованием.

// Ref
// Когда мы используем REF, данные могут передаваться двунаправленно.
	
// Out
// Когда мы используем OUT, данные передаются только однонаправленно (от вызываемого метода к вызывающему методу).

{
    for (int i = 0; i < inputMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inputMatrix.GetLength(1); j++)
        {
            inputMatrix[i,j]=i+j;
        }
    }
}

Console.Clear();

// Console.Write("Введите количество строк m ");
// int m = int.Parse(Console.ReadLine()?? "");
// Console.Write("Введите количество столбцов n ");
// int n = int.Parse(Console.ReadLine()?? "");

int[,] matrix = FillMatrix(5,8);
PrintMatrix(matrix);
//если в аргументах метода есть ref, то у метода есть возможность внести изменения в аргумент
UpdateMatrix(ref matrix);
PrintColorMatrix(matrix);


