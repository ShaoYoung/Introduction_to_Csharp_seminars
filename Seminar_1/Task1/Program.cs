//Задача №1
//Напишите программу, которая на вход принимает два числа и проверяет, является ли первое число квадратом второго.

Console.Clear();
Console.Write("Введите первое число: ");
string? inputOne = Console.ReadLine();
Console.Write("Введите второе число: ");
string? inputTwo = Console.ReadLine();

if (inputOne != null && inputTwo != null)
{
    int inputNumberOne = int.Parse(inputOne);
    int inputNumberTwo = int.Parse(inputTwo);

    //первый вариант через степень Math.Pow(число, степень)
    if (inputNumberOne == Math.Pow(inputNumberTwo, 2))

    // второй вариант через квадратный корень Math.Sqrt
    // if (Math.Sqrt(inputNumberOne) == inputNumberTwo)

    {
        Console.WriteLine("Первое число является квадратом второго числа");
    }
    else
    {
        Console.WriteLine("Первое число НЕ является квадратом второго числа");
    }
}



