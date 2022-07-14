//HomeWork
//№13 Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.

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
        Console.Write("Введите численное значение: ");
        inputString = Console.ReadLine();
        testDigits = DigitsOnly(inputString);
    }
    return Convert.ToInt32(inputString);
}

// вариант 1. через длину строки и вычленение третьей цифры 
void variant1()
{
    bool testDigits = false;
    string? inputNumber = "";
    while (!testDigits)
    {
        Console.Write("Введите число: ");
        inputNumber = Console.ReadLine();
        testDigits = DigitsOnly(inputNumber);
    }
    //если число отрицательное, то убираем знак '-'
    if (inputNumber[0] == '-')
        inputNumber = inputNumber.Remove(0, 1);

    // убираем нули в начале (если они есть), чтобы число, введённое пользователем как '001', считалось как 1
    while (inputNumber[0] == '0')
    {
        inputNumber = inputNumber.Remove(0, 1);
        if (inputNumber.Length == 0)
            break;
    }
    if (inputNumber.Length < 3)
    {
        Console.WriteLine("Третьей цифры нет!");
    }
    else
    {
        char[] digits = inputNumber.ToCharArray();
        Console.WriteLine("Третья цифра вашего числа: " + digits[2]);
        //можно сразу взять второй символ строки
        //Console.WriteLine("Третья цифра вашего числа: " + inputNumber[2]);
    }
}

// вариант 2. через int. поиск количества цифр в числе и последующий поиск третьей цифры 
void variant2()
{
    int inputNumber = GetData();
    //количество цифр во введённом числе (через десятичный логарифм модуля введённого числа)
    int colNumber = inputNumber == 0 ? 1 : (int)Math.Log10(Math.Abs(inputNumber)) + 1;
    //    Console.WriteLine("Количество цифр во введённом числе: " + colNumber);
    if (colNumber < 3)
    {
        Console.WriteLine("Третьей цифры нет!");
    }
    else
    {
        int thirdNumber = Math.Abs(inputNumber / (int)Math.Pow(10, (colNumber - 3)) % 10);
        Console.WriteLine("Третья цифра вашего числа: " + thirdNumber);
    }

}

Console.Clear();

Console.WriteLine("Первый вариант.");
variant1();

Console.WriteLine("Второй вариант.");
variant2();