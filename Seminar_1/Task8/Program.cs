// Домашнее задание:
// №8 Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
Console.Clear();

Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();
if (inputLine != null)
{
    int inputNumber = int.Parse(inputLine);

    string lineOutput = "";
    int honest = 2;
    while (honest <= inputNumber)
    {
        lineOutput = lineOutput + honest + ", ";
        honest += 2;
    }
    // убираем лишнюю запятую и пробел в конце итоговой строки
    string lineOutputClear = lineOutput.Remove(lineOutput.Length - 2, 2);

    Console.WriteLine(lineOutputClear);
}
