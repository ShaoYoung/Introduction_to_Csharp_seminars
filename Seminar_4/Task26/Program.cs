// Задача №26
// Напишите программу, которая принимает на вход
// число и выдаёт количество цифр в числе.
// Пример:
// 456 -> 3
// 78 -> 2
// 89126 -> 5

Console.Clear();

Console.Write("Введите число: ");

// ??"" защита
string inputLineNumber = Console.ReadLine() ?? "";
long inputNumber = long.Parse(inputLineNumber);

DateTime timePolong = DateTime.Now;


long VariantChar()
{
    // long numberLength = 0;
    // char[] array = inputLineNumber.ToCharArray();
    // numberLength = array.Length;
    // аналогичный вариант inputLineNumber.ToCharArray().Length;
    return inputLineNumber.ToCharArray().Length; ;
}

//оказался самый быстрый метод
long VariantSimple()
{
    long numberLength = 0;
    long digits = 1;
    while (digits < inputNumber)
    {
        digits = digits * 10;
        numberLength++;
    }
    return numberLength;
}

long VariantLog10()
{
    return (long)Math.Log10(inputNumber) + 1;
}




long result = 0;
timePolong = DateTime.Now;
result = VariantChar();
Console.WriteLine(result);
//временной интервал для выполнения метода
Console.WriteLine(DateTime.Now - timePolong);

timePolong = DateTime.Now;
result = VariantSimple();
Console.WriteLine(result);
Console.WriteLine(DateTime.Now - timePolong);

timePolong = DateTime.Now;
result = VariantLog10();
Console.WriteLine(result);
Console.WriteLine(DateTime.Now - timePolong);



// long t;
// t = Environment.TickCount;
// Console.WriteLine("Simple time: {0} ms", Environment.TickCount - t);