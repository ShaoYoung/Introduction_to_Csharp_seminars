//HomeWork
//№15 Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.

bool NumberInInterval(string s)
{
    // два варианта проверки на пустую строку    
    if (String.IsNullOrEmpty(s)) return false;
    //if (s.Length == 0) return false;
    // foreach - цикл для каждого символа из строки
    foreach (char c in s)
    {
        if (c < '1' || c > '7')
            return false;
    }
    return true;
}


byte GetData()
{
    bool testDigits = false;
    string? inputString = "";
    while (!testDigits)
    {
        Console.Write("Введите цифру, обозначающую день недели:  ");
        inputString = Console.ReadLine();
        if (NumberInInterval(inputString) && (inputString.Length == 1))
            testDigits = true;
        else
            Console.Clear();
    }
    return Convert.ToByte(inputString);
}

//вариант 1. простое сравнение с 6 и 7
void variant1(byte numDay)
{
    if ((numDay == 6) || (numDay == 7))
        Console.WriteLine("Да, день недели с номером " + numDay + " выходной!");
    else
        Console.WriteLine("Нет, день недели с номером " + numDay + " рабочий.");
}

//вариант 2. через проверку входимости в список (list - массив переменной длины)
void variant2(byte numDay)
{
    // массив неизвестной длины -->>> коллекция
    List<byte> evenDayOf = new List<byte>();
    //заполняем список нужными днями недели
    evenDayOf.Add(6);
    evenDayOf.Add(7);
    //проверка входимости numDay в список выходных дней
    if (evenDayOf.Contains(numDay))
        Console.WriteLine("Да, день недели с номером " + numDay + " выходной!");
    else
        Console.WriteLine("Нет, день недели с номером " + numDay + " рабочий.");
}

//вариант 3. через словарь
void variant3(byte numDay)
{
    //словарь (key, value) - номер дня недели (true/false)
    Dictionary<byte, bool> dayOfWeekTF = new Dictionary<byte, bool>();
    //запонение словаря dayOfWeekTF
    for (byte i = 1; i <= 5; i++)
        dayOfWeekTF[i] = false;
    for (byte i = 6; i <= 7; i++)
        dayOfWeekTF[i] = true;

    //словарь (key, value) - номер дня недели (true/false)
    Dictionary<byte, string> dayOfWeek = new Dictionary<byte, string>();
    //запонение словаря dayOfWeek
    dayOfWeek[1] = "понедельник";
    dayOfWeek[2] = "вторник";
    dayOfWeek[3] = "среда";
    dayOfWeek[4] = "четверг";
    dayOfWeek[5] = "пятница";
    dayOfWeek[6] = "суббота";
    dayOfWeek[7] = "воскресенье";

    if (dayOfWeekTF[numDay])
        Console.WriteLine("Да, день недели с номером " + numDay + " выходной! Это " + dayOfWeek[numDay] + ".");
    else
        Console.WriteLine("Нет, день недели с номером " + numDay + " рабочий. Это " + dayOfWeek[numDay] + ".");
}

Console.Clear();
byte numDayOfWeek = GetData();
Console.WriteLine("Первый вариант: ");
variant1(numDayOfWeek);
Console.WriteLine("Второй вариант: ");
variant2(numDayOfWeek);
Console.WriteLine("Третий вариант: ");
variant3(numDayOfWeek);


