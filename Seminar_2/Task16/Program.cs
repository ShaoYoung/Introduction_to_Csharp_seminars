// Задача №16
// Напишите программу, которая принимает на вход два числа и проверяет,
// является ли одно число квадратом другого.

Console.Clear();

Console.WriteLine("Введите первое число:");
string? inputFirst = Console.ReadLine();
Console.WriteLine("Введите второе число:");
string? inputSecond = Console.ReadLine();

if ((inputFirst != null) && (inputSecond != null))
{
    int inputNumberFirst = int.Parse(inputFirst);
    int inputNumberSecond = int.Parse(inputSecond);
    //возводим в квадрат и конвертируем в int32
    int a = Convert.ToInt32(Math.Pow(inputNumberFirst,2));
    int b = Convert.ToInt32(Math.Pow(inputNumberSecond,2));
    if ((a == inputNumberSecond) || (b == inputNumberFirst))
    {
        Console.WriteLine("Да!");
    }
    else
    {
        Console.WriteLine("Нет!");
    }
}