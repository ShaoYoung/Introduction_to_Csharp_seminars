//HomeWork
//№19 Напишите программу, которая принимает на вход пятизначное число и проверяет,
// является ли оно палиндромом.
// 14212 -> нет
// 23432 -> да
// 12821 -> да
//
// * Сделать вариант через СЛОВАРЬ четырехзначных палиндромов

// ЗАДАНИЕ * НЕМНОГО МОДИФИЦИРОВАНО (работает для числа любой разрядности в пределах int32)
// В программе реализованы:
// подсчёт количества и вывод всех палиндромов разрядности вводимого числа (если число разрядов чётное)
// или (разрядности вводимого числа) - 1, если число разрядов нечётное 
// запись палиндромов в словарь, где Keys - номера палиндромов, Values - их значения
// проверка на палиндромность введённого числа через проверку на содержании в словаре вводимого числа

// проверка на наличие символов в строке s, отличных от цифр. возвращает false, если строка пустая или
// содержит символы - не цифры
bool DigitsOnly(string s)
{
    // два варианта проверки на пустую строку    
    if (String.IsNullOrEmpty(s)) return false;
    //if (s.Length == 0) return false;
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
        Console.Write("Введите число от 0 до 2 147 483 647: ");
        inputString = Console.ReadLine();
        testDigits = DigitsOnly(inputString);
    }
    return Convert.ToInt32(inputString);
}

// преобразование числа в массив цифр, на входе любое число int, на выходе одномерный массив цифр этого
// числа длиной, согласно количеству цифр
int[] ConvertNumToArray(int inputNumber)
{
    int colNumbers = inputNumber == 0 ? 1 : (int)Math.Log10(Math.Abs(inputNumber)) + 1;
    int[] numbers = new int[colNumbers];
    numbers[0] = (int)(inputNumber / Math.Pow(10, numbers.Length - 1));
    for (byte i = 1; i < numbers.Length; i++)
    {
        numbers[i] = (int)(inputNumber / Math.Pow(10, numbers.Length - (i + 1)) % 10);
    }
    return numbers;
}

// проверка массива на палиндромность. возвращает true, если массив палиндромен, false - если нет
bool CheckPal(int[] numbers)
{
    for (byte i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] != numbers[numbers.Length - 1 - i])
            return false;
    }
    return true;
}

// вариант 1. решение через поразрядный разбор числа (разрядность любая от 1 до 8). 
// принимает число, проверяет на палиндромность и возвращает true/false
bool variant1(int inputNumber)
{
    int[] numbers = ConvertNumToArray(inputNumber);

    if (CheckPal(numbers))
        return true;
    else
        return false;
}

//метод возвращает словарь палиндромов указанной разрядности
Dictionary<int, int> MakeDictOfPalindromes(int bitDepth)
{
    Dictionary<int, int> palindromes = new Dictionary<int, int>();
    int count = 0;
    //начальное значение диапазона
    int startNum = Convert.ToInt32(Math.Pow(10, bitDepth - 1));
    //для однорязрядных палиндромов начинаем с нуля
    if (bitDepth == 1)
        startNum = 0;
    int endNum = Convert.ToInt32(Math.Pow(10, bitDepth));
    for (int i = startNum; i < endNum; i++)
    {
        int[] numbers = ConvertNumToArray(i);
        if (CheckPal(numbers))
        {
            palindromes.Add(count, i);
            count++;
        }
    }
    return palindromes;
}

// вариант 2. решение через словарь палиндромов. на входе число, на выходе bool-результат
bool variant2(int inputNumber)
{
    //получаем массив цифр введённого числа
    int[] inputNumberArray = ConvertNumToArray(inputNumber);
    //определяем разрядность введённого числа
    int bitDepth = inputNumberArray.Length;
    //если введённое число одноразрядное, то выводим true, т.к. оно по умолчанию палиндром
    if (bitDepth == 1)
        return true;
    //если разрядность числа нечётная, то проверять на палиндромность будем среди палиндромов
    // уменьшенной на 1 разрядности (т.к. средний рязряд не имеет значения)
    if (bitDepth % 2 == 1)
    {
        //помечаем средний элемент массива цифр введённого числа некорректным числом
        inputNumberArray[bitDepth / 2] = 10;
        bitDepth--;
    }
    string numberString = String.Empty;
    //делаем строку из элементов массива
    for (int i = 0; i < inputNumberArray.Length; i++)
    {
        //если элемент массива не помечен
        if (inputNumberArray[i] != 10)
            numberString += inputNumberArray[i];
    }
    //делаем новое число из строки
    inputNumber = int.Parse(numberString);

    //создаём словарь палиндромов необходимой разрядности
    Dictionary<int, int> palindromes = MakeDictOfPalindromes(bitDepth);
    //выводим количество палиндромов (разрядности введённого пользователем числа) минус 1
    Console.WriteLine($"Количество {bitDepth}-разрядных палиндромов: {palindromes.Count()}");
    for (int i = 0; i < palindromes.Count(); i++)
        Console.Write(palindromes[i] + " ");
    Console.WriteLine();

    if (palindromes.ContainsValue(inputNumber))
        return true;
    else
        return false;
}

Console.Clear();
Console.WriteLine("Первый вариант.");
int inputNumber = GetData();
if (variant1(inputNumber))
    Console.WriteLine("Число " + inputNumber + " палиндром!");
else
    Console.WriteLine("Число " + inputNumber + " НЕ палиндром!");

Console.WriteLine("Второй вариант.");
//int inputNumber = GetData();
if (variant2(inputNumber))
    Console.WriteLine("Число " + inputNumber + " палиндром!");
else
    Console.WriteLine("Число " + inputNumber + " НЕ палиндром!");