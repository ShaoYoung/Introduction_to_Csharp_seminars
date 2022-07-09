//Задача №7
//Напишите программу, которая принимает на вход трёхзначное число
// и на выходе показывает последнюю цифру этого числа.

Console.Clear();

Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();

if (inputLine != null)
//первый вариант, остаток от деления на 10. частный случай.
{
    int inputNumber = int.Parse(inputLine);

    int lastNumber = inputNumber % 10;

    Console.WriteLine("Через остаток от деления на 10: " + lastNumber);


    //---------------------------------------

    //второй вариант. вводится строка и берётся последний символ

    string lastNum = inputLine.Substring(inputLine.Length - 1, 1);
    //int lastNum = int.Parse(inputLkneOne[inputLkneOne.Length-1].ToString());
    Console.WriteLine("Через последний символ строки: " + lastNum);

    //третий вариант через преобразование строки в массив символов
    
    int length = inputLine.Length;
    char[] M = inputLine.ToCharArray();
    Console.WriteLine("Через массив символов: " + M[length - 1]);

}