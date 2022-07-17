//Задача №22
//Напишите программу, которая принимает на вход число (N) и выдаёт таблицу квадратов чисел от 1 до N.

Console.Clear();

Console.Write("Введите число N: ");
string? inputString = Console.ReadLine();

if (!String.IsNullOrEmpty(inputString))
{
    string LineS = "";
    string LineSPow = "";
    int number = Convert.ToInt32(inputString);
    int s = 1;
    while (s <= number)
    {
        LineS = LineS + s + " ";
        LineSPow = LineSPow + Math.Pow(s, 2) + " ";
        s++;
    }
    Console.WriteLine(LineS);
    Console.WriteLine(LineSPow);
}




