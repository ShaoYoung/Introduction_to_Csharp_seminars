// Задача №28
// Напишите программу, которая принимает на вход
// число N и выдаёт произведение чисел от 1 до N.
// Например:
// 4 -> 24
// 5 -> 120



Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();
int inputNum = int.Parse(inputLine);

DateTime timePolong = DateTime.Now;
Console.WriteLine(sumNums(inputNum));
Console.WriteLine("Simple time: {0} ms", DateTime.Now - timePolong);

timePolong = DateTime.Now;
Console.WriteLine(mulRec(inputNum));
Console.WriteLine("Recurse time: {0} ms", DateTime.Now - timePolong);


//простое перемножение
int sumNums(int num)
{
    int sum = 1;
    for (int i = 1; i <= inputNum; i++)
    {
        //равносильно sum = sum * i
        sum *= i;
    }
    return sum;
}

//решение через рекурсию
int mulRec(int num) 
{
    if (num == 1) {
        return 1;
    } else {
        return num * mulRec(num - 1);
    }
}







