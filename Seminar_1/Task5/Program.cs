//Задача №5
// Напишите программу, которая на вход принимает одно число (N),
//а на выходе показывает все целые числа в промежутке от -N до N.

Console.Clear();

Console.Write("Введите число: ");
string? inputLine = Console.ReadLine();

string lineOutput = "";

// if (inputLine != null)
// {
//     int inputNumber = int.Parse(inputLine);
//     int endNumber = inputNumber;
//     inputNumber = (-1) * inputNumber;

//     while (inputNumber <= endNumber)
//     {
//         lineOutput = lineOutput + inputNumber + ", ";
//         inputNumber++;
//     }

// //убираем лишнюю запятую в конце итоговой строки
//     string lineOutputClear = lineOutput.Remove(lineOutput.Length-2,2);

//     Console.WriteLine(lineOutputClear);

// }


//второй вариант с расхождением в две стороны. ускоряет алгоритм в 2 раза.
if (inputLine != null)
{
    int inputNumber = int.Parse(inputLine);
    int countNumber = 1;
    lineOutput = "0";
    
    while (countNumber <= inputNumber)
    {
        lineOutput = ((-1) * countNumber) + ", " + lineOutput + ", " + countNumber;
        countNumber++;
    }

    Console.WriteLine(lineOutput);

}