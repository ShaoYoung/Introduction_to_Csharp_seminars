// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

// * Сделать оценку времени алгоритма через вещественные числа и строки (разложить на символы)
// через тики или DateTime

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


//вариант с остатком от деления на 10
void VariantDiv(int number)
{
    int result = 0;
    //отбрасываем знак (введённое число может быть отрицательным)
    number = Math.Abs(number);
    while (number > 0)
    {
        result += number % 10;
        number = number / 10;
    }
    Console.WriteLine($"Сумма цифр в числе: {result}");
}

//вариант с разделением строки на массив символов
void VariantChar(string number)
{
    int result = 0;
    //избавляемся от знака
    if (number[0] == '-')
        number = number.Remove(0, 1);
    //преобразуем строку в массив символов
    char[] digits = number.ToCharArray();
    for (int i = 0; i < digits.Count(); i++)
    {
        //получаем числовое значение каждого элемента массива символов и суммируем
        result += (int)Char.GetNumericValue(digits[i]);
    }
    Console.WriteLine($"Сумма цифр в числе: {result}");
}

//ввод числа. После проверки строковое значение в переменной inputString, int в переменной inputNumber
bool testDigits = false;
string? inputString = "";
while (!testDigits)
{
    Console.Clear();
    Console.Write("Введите целое число: ");
    inputString = Console.ReadLine() ?? "";
    testDigits = DigitsOnly(inputString);
}
int inputNumber = Convert.ToInt32(inputString);

DateTime timeOper = DateTime.Now;
VariantDiv(inputNumber);
//разница между двумя датами - время выполнения метода с остатком от деления
TimeSpan timeDiv = DateTime.Now - timeOper;
Console.WriteLine($"Метод с остатком от деления занял {timeDiv}");

timeOper = DateTime.Now;
VariantChar(inputString);
//разница между двумя датами - время выполнения метода с массивом символов
TimeSpan timeChar = DateTime.Now - timeOper;
Console.WriteLine($"Метод с массивом символов занял {timeChar}");

Console.WriteLine();
if (timeDiv > timeChar)
    Console.WriteLine("Метод с массивом символов быстрее.");
else
    Console.WriteLine("Метод с остатком от деления быстрее.");


