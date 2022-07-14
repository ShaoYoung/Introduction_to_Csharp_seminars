// HomeWork
// №10 Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.

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

// вариант 1. через деление деление на 10 без остатка и последующее нахождение остатка от деления на 10 
void variant1()
{
    bool correctInput = false;
    while (!correctInput)
    {
        int inputNumber = Math.Abs(GetData());
        if ((inputNumber < 100) || (inputNumber > 999))
        {
            Console.Clear();
            Console.WriteLine("Введите трёхзначное число!!!");
        }
        else
        {
            correctInput = true;
            int secondNumber = (inputNumber / 10) % 10;
            Console.WriteLine("Вторая цифра вашего числа: " + secondNumber);
        }
    }

}

// вариант 2. через вычленение второго символа из строки
void variant2()
{
    bool correctInput = false;
    while (!correctInput)
    {
        string? inputNumber = Console.ReadLine();
        if (!String.IsNullOrEmpty(inputNumber))
        {
            string correctNumber = inputNumber;
            // если число отрицательное, убираем знак '-'
            if (correctNumber[0] == '-')
                correctNumber = correctNumber.Remove(0, 1);
            // убираем нули в начале (если они есть)
            while (correctNumber[0] == '0')
            {
                correctNumber = correctNumber.Remove(0, 1);
                if (correctNumber.Length == 0)
                    break;
            }
            if ((correctNumber.Length != 3) || (!DigitsOnly(correctNumber)))
            {
                Console.Clear();
                Console.WriteLine("Введите трёхзначное число!!!");
            }
            else
            {
                correctInput = true;
                char[] digits = correctNumber.ToCharArray();
                Console.WriteLine("Вторая цифра вашего числа: " + digits[1]);
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Введите трёхзначное число!!!");
        }
    }
}

    Console.Clear();

    Console.WriteLine("Первый вариант.");
    variant1();

    Console.WriteLine("Второй вариант.");
    variant2();



