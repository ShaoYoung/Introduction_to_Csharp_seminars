//Задача №18
//Напишите программу, которая по заданному номеру четверти, 
//показывает диапазон возможных координат точек в этой четверти (x и y).

//проверка на ввод цифр из диапазона от 1 до 4
bool NumberInInterval(string s)
{
    // два варианта проверки на пустую строку    
    if (String.IsNullOrEmpty(s)) return false;
    //if (s.Length == 0) return false;
    // foreach - цикл для каждого символа из строки
    foreach (char c in s)
    {
        if (c < '1' || c > '4')
            return false;
    }
    return true;
}

//ввод данных с консоли, проверяет возвращает номер четверти от 1 до 4
byte GetData()
{
    bool testDigits = false;
    string? inputString = "";
    while (!testDigits)
    {
        Console.Write("Введите цифру, обозначающую четверть: ");
        inputString = Console.ReadLine();
        if (NumberInInterval(inputString) && (inputString.Length == 1))
            testDigits = true;
        else
            Console.Clear();
    }
    return Convert.ToByte(inputString);
}

//печать допустимых значений x и y. принимает номер четверти.
void WriteAnswer(byte numQuoter)
{
    if (numQuoter == 1) Console.WriteLine("Допустимо: x>0; y>0");
    if (numQuoter == 2) Console.WriteLine("Допустимо: x<0; y>0");
    if (numQuoter == 3) Console.WriteLine("Допустимо: x<0; y<0");
    if (numQuoter == 4) Console.WriteLine("Допустимо: x>0; y<0");
}

Console.Clear();
byte numQuoter = GetData();

WriteAnswer(numQuoter);

