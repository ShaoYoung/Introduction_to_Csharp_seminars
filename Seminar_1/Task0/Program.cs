//Задача №0
//Напишите программу, которая на вход принимает число и выдаёт его квадрат
// (число умноженное на само себя).

Console.Clear();
Console.Write("Введите число: ");
//string? - строка, допускающая значение null
string? inputLine = Console.ReadLine();
//null - отсутствие значения
if (inputLine != null)
{
    //преобразование строки в int
    int inputNumber = int.Parse(inputLine);

    //    int outNumber = inputNumber*inputNumber;

    // вариант через Math.Pow(число, степень)
    int outNumber = (int)Math.Pow(inputNumber, 2);

    Console.WriteLine("Число, возведённое в квадрат: " + outNumber);
}