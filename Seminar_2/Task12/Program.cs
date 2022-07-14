//Задача №12
//Напишите программу, которая будет принимать на вход два числа и выводить, является ли второе число кратным первому.
// Если второе число некратно первому, то программа выводит остаток от деления.
Console.Clear();

Console.WriteLine("Введите первое число:");
string? inputOne = Console.ReadLine();
Console.WriteLine("Введите второе число:");
string? inputTwo = Console.ReadLine();

if (inputOne != null && inputTwo != null)
{
 
    int a = int.Parse(inputOne);
    int b = int.Parse(inputTwo);

    int c = b % a;
    if (c == 0)
    {
        Console.WriteLine("Кратно.");
    }
    else
    {
        Console.WriteLine("Некратно, остаток " + c);
    }

}

