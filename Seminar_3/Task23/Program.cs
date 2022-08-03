//№23 Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.1
//3 -> 1, 8, 27
//5 -> 1, 8, 27, 64, 125
//* Вывести таблицу с границами и значениями друг над другом


// проверка на наличие символов в строке s, отличных от цифр. возвращает false, если строка пустая или
// содержит символы - не цифры
bool DigitsOnly(string s)
{
    // два варианта проверки на пустую строку    
    if (String.IsNullOrEmpty(s)) return false;
    //if (s.Length == 0) return false;
    //проверка на отрицательное число. его тоже проверяем на цифры, но уже без знака
    if (s[0] == '-')
        s = s.Remove(0, 1);
    // foreach - цикл для каждого символа из строки
    foreach (char c in s)
    {
        if (c < '0' || c > '9')
            return false;
    }
    return true;
}

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число
int GetData()
{
    bool testDigits = false;
    string? inputString = "";
    while (!testDigits)
    {
        Console.Clear();
        Console.Write("Введите целое число: ");
        inputString = Console.ReadLine();
        testDigits = DigitsOnly(inputString);
    }
    return Convert.ToInt32(inputString);
}

//метод создаёт словарь чисел от 1 до number и их кубов
Dictionary<int, int> MakeDictOfCubes(int number)
{
    Dictionary<int, int> dictOfCubes = new Dictionary<int, int>();
    for (int i = 1; i <= number; i++)
        dictOfCubes.Add(i, Convert.ToInt32(Math.Pow(i, 3)));
    return dictOfCubes;
}

//метод печатает int-словарь (простая печать)
void SimplePrint(Dictionary<int, int> dictOfCubes)
{
    //печатаем ключи
    foreach (int num in dictOfCubes.Keys)
    {
        Console.Write($"{num} ");
    }

    Console.WriteLine();

    //печатаем значения (кубы)
    foreach (int num in dictOfCubes.Values)
    {
        Console.Write($"{num} ");
    }
    Console.WriteLine();
}

//метод преобразует int-словарь в форматированный string-словарь
Dictionary<string, string> ConvertDict(Dictionary<int, int> dictOfCubes)
{
    Dictionary<string, string> dictOfString = new Dictionary<string, string>();

    foreach (int num in dictOfCubes.Keys)
    {
        string cubeString = Convert.ToString(dictOfCubes[num]);
        string numberString = Convert.ToString(num);
        string spaceString = String.Empty;
        //считаем разницу в количестве символов числа и числа в кубе. добавляем необходимые пробелы
        //перед числами
        for (int i = 0; i < (cubeString.Length - numberString.Length); i++)
        {
            spaceString += " ";
        }
        numberString = spaceString + numberString;
        dictOfString.Add(numberString + "|", cubeString + "|");
    }

    return dictOfString;
}

//метод печатает string-словарь (табличная печать, вариант №1 (без учёта размеров консоли))
void PrintStringDict(Dictionary<string, string> dictOfString)
{
    Console.WriteLine("Вариант_1:");
    //печатаем горизонтальную строку
    foreach (string num in dictOfString.Keys)
    {
        for (int i = 1; i <= num.Length; i++)
        {
            Console.Write("-");
        }
    }
    Console.Write("-");
    Console.WriteLine();

    //печатаем ключи (числа)
    Console.Write("|");
    foreach (string num in dictOfString.Keys)
    {
        Console.Write($"{num}");
    }

    //печатаем горизонтальную строку
    Console.WriteLine();
    foreach (string num in dictOfString.Keys)
    {
        for (int i = 1; i <= num.Length; i++)
        {
            Console.Write("-");
        }
    }
    Console.Write("-");
    Console.WriteLine();

    //печатаем значения (кубы)
    Console.Write("|");
    foreach (string num in dictOfString.Values)
    {
        Console.Write($"{num}");
    }

    //печатаем горизонтальную строку
    Console.WriteLine();
    foreach (string num in dictOfString.Keys)
    {
        for (int i = 1; i <= num.Length; i++)
        {
            Console.Write("-");
        }
    }
    Console.Write("-");

    Console.WriteLine();

}

//метод печатает string-словарь (табличная печать, вариант №2 (с учётом размеров консоли))
void PrintStringDictConsole(Dictionary<string, string> dictOfString)
{
    try
    {
        Console.WriteLine("Вариант_2:");
        Console.Write("-");
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
        Console.Write("|");
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
        Console.Write("-");
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
        Console.Write("|");
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
        Console.Write("-");
        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 4);
        foreach (string num in dictOfString.Keys)
        {
            //если очередное значение не влезет по ширине в оставшееся в терминале место,
            // то начинаем печатать строку ниже с нулевой позиции
            if (Console.BufferWidth - Console.CursorLeft < num.Length)
            {
                Console.SetCursorPosition(0, Console.CursorTop + 5);
                Console.WriteLine("Продолжение таблицы");
            }
            //печатаем горизонтальную строку
            for (int i = 1; i <= num.Length; i++)
            {
                Console.Write("-");
            }
            //печатаем ключи (числа)
            Console.SetCursorPosition(Console.CursorLeft - num.Length, Console.CursorTop + 1);
            Console.Write($"{num}");
            //печатаем горизонтальную строку
            Console.SetCursorPosition(Console.CursorLeft - num.Length, Console.CursorTop + 1);
            for (int i = 1; i <= num.Length; i++)
            {
                Console.Write("-");
            }
            //печатаем значения (кубы)
            Console.SetCursorPosition(Console.CursorLeft - num.Length, Console.CursorTop + 1);
            Console.Write($"{dictOfString[num]}");
            //печатаем горизонтальную строку
            Console.SetCursorPosition(Console.CursorLeft - num.Length, Console.CursorTop + 1);
            for (int i = 1; i <= num.Length; i++)
            {
                Console.Write("-");
            }
            //возвращаем курсор вверх для печати очередного элемента словаря
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 4);
        }
        //возвращаем курсор на место
        Console.SetCursorPosition(0, Console.CursorTop + 5);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.WriteLine("Не достаточно высоты терминала для вывода таблицы!!!");
    }

}

int inputNumber = GetData();
Dictionary<int, int> dictOfCubes = MakeDictOfCubes(inputNumber);
Console.WriteLine("Простая печать.");
SimplePrint(dictOfCubes);

Console.WriteLine("Табличная печать.");
Dictionary<string, string> dictOfString = ConvertDict(dictOfCubes);
PrintStringDict(dictOfString);

PrintStringDictConsole(dictOfString);

