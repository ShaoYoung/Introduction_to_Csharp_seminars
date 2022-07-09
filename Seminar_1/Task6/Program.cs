//Домашнее задание:
// №6 Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).

Console.Clear();
Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();

if (inputLine != null)
{
    int inputNumber = int.Parse(inputLine);
    if (inputNumber == 0) Console.Write("Это ноль!!!");
    else if (inputNumber % 2 == 0) Console.Write("Да, число " + inputNumber + " чётное");
    else Console.Write("Нет, число " + inputNumber + " нечётное");

}