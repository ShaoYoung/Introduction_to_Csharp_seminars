//методы ввода данныъ с консоли

// проверка на наличие символов в строке s, отличных от цифр. возвращает false, если строка пустая или
// содержит символы - не цифры.
bool DigitsOnly(string s)
{
    if (String.IsNullOrEmpty(s)) return false;
    //проверка на отрицательное число. его тоже проверяем на цифры, но уже без знака
    if (s[0] == '-')
        s = s.Remove(0, 1);
    foreach (char c in s)
    {
        if (c < '0' || c > '9')
            return false;
    }
    return true;
}

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. если что-то не так, консоль очищается и ввод повторяется.
// для проверки использует метод DigitsOnly
int GetDataInt32()
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

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. если что-то не так, консоль очищается и ввод повторяется.
// для проверки использует метод TryParse
int GetDataTryParse()
{
    bool testDigits = false;
    int result = 0;
    while (!testDigits)
    {
        Console.Write("Введите целое число: ");
        string? inputString = Console.ReadLine();
        if ((int.TryParse(inputString, out int data)))
        {
            testDigits = true;
            result = data;
        }
        else
            Console.Clear();
    }
    return result;
}

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. если что-то не так, консоль очищается и ввод повторяется.
// для проверки использует конструкцию try-catch (требует больших производительных ресурсов).
int GetDataTryCatch()
{
    bool testDigits = false;
    // string? inputString = String.Empty;
    int data = 0;
    while (!testDigits)
    {
        try
        {
            Console.Write("Введите целое число: ");
            string? inputString = Console.ReadLine();
            data = int.Parse(inputString);
            //if (data == 1000)
            //искуственно созданное исключение, если использовать, то следить, чтобы не возникли стандартные исключения 
            //     throw new ArgumentOutOfRangeException("Введено число 1000");
            testDigits = true;
        }
        // catch может перехватывать любое исключение (когда ничего не указано) или конкретное исключение (указывается в скобках)
        // лучше перехватывать конкретное исключение
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Возникло исключение: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Возникло исключение: {e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Возникло исключение: {e.Message}");
        }
        catch (OverflowException e)
        {
            Console.WriteLine($"Возникло исключение: {e.Message}");
        }
        // catch (ArgumentOutOfRangeException e)
        // {
        //     Console.WriteLine($"Возникло исключение: {e.Message}");
        // }
    }
    return data;
}

Console.Clear();

int number = GetDataInt32();
Console.WriteLine(number);
number = GetDataTryParse();
Console.WriteLine(number);
number = GetDataTryCatch();
Console.WriteLine(number);
