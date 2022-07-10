//Домашнее задание:
// №6 Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).

Console.Clear();
Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();

if (inputLine != null)
{
    try
    {
        int inputNumber = int.Parse(inputLine);

        // вариант через остаток от деления на 2 
        Console.WriteLine("Вариант через остаток от деления на 2:");
        if (inputNumber == 0) Console.WriteLine("Это ноль!!!");
        else if (inputNumber % 2 == 0) Console.WriteLine("Да, число " + inputNumber + " чётное");
        else Console.WriteLine("Нет, число " + inputNumber + " нечётное");

        // вариант с проверкой последней цифры (0, 2, 4, 6, 8)
        Console.WriteLine("Вариант с проверкой последней цифры (0, 2, 4, 6, 8):");
        string lastNum = inputLine.Substring(inputLine.Length - 1, 1);
        byte lastNumber = byte.Parse(lastNum);
        if ((lastNumber == 0) || (lastNumber == 2) || (lastNumber == 4) || (lastNumber == 6) || (lastNumber == 8))
            Console.WriteLine("Да, число " + inputNumber + " чётное");
        else Console.WriteLine("Нет, число " + inputNumber + " нечётное");
    }
    catch
    {
        // вывод сообщения об ошибке
        Console.WriteLine("Не корректный ввод!!!");
    }
}