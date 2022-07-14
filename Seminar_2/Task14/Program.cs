// Задача №14
// Напишите программу, которая принимает на вход число и проверяет, кратно ли оно одновременно 7 и 23.
Console.Clear();

Console.WriteLine("Введите число:");
string? inputNum = Console.ReadLine();

if (inputNum != null)
{
    int inputNumber = int.Parse(inputNum);
    int b = inputNumber % 7;
    int c = inputNumber % 23;
    if ((b == 0) && (c == 0))
    {
        Console.WriteLine("Это число делится нацело на 7 и на 23");
    }
    else
    {
        Console.WriteLine("Это число НЕ делится нацело на 7 и на 23");
    }
}
