//Задача №20
//Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними
// в 2D пространстве.
//Например:
//A (3,6); B (2,1) -> 5,09
//A (7,-5); B (1,-1) -> 7,21


// проверка на наличие символов в строке s, отличных от цифр. возвращает false, если строка пустая или
// содержит символы - не цифры
bool DigitsOnly(string s)
{
    if (String.IsNullOrEmpty(s)) return false;
    //проверка на отрицательное число. его тоже проверяем на цифры, но уже без знака
    if (s[0] == '-')
        s = s.Remove(0, 1);
    // foreach - цикл для каждого символа из строки
    foreach (char c in s)
    {
        if (c < '0' || c > '9')
            return false;
    }
    return true;
}


//считывает коордиаты точек A и B, возвращает массив, где [0,0] = Ax, [0,1] = Ay, [1,0] = Bx, [1,1] = By
int[,] readDataOfPoint()
{
    int[,] arrayOut = new int[2, 2];

    bool testInput = false;
    string? inputLine = "";
    while (!testInput)
    {
        Console.WriteLine("Введите координаты точек A и B в формате A (3,6); B (2,1): ");
        inputLine = Console.ReadLine();
        if (!String.IsNullOrEmpty(inputLine))
        {
            try
            {
                //координата Ax (в string). если не число, то ошибка ввода (повторный ввод)
                string coordAXLine = inputLine.Substring(0, inputLine.IndexOf(","));
                coordAXLine = coordAXLine.Substring(coordAXLine.IndexOf("(") + 1);
                Console.WriteLine("Ax = " + coordAXLine);
                if (!DigitsOnly(coordAXLine))
                    break;
                //координата Ay (в string). если не число, то ошибка ввода (повторный ввод)
                string coordAYLine = inputLine.Substring(0, inputLine.IndexOf(")"));
                coordAYLine = coordAYLine.Substring(coordAYLine.IndexOf(",") + 1);
                Console.WriteLine("Ay = " + coordAYLine);
                if (!DigitsOnly(coordAYLine))
                    break;

                string coordBLine = inputLine.Substring(inputLine.IndexOf("B") + 1);
                //координата Bx (в string). если не число, то ошибка ввода (повторный ввод)
                string coordBXLine = coordBLine.Substring(0, coordBLine.IndexOf(","));
                coordBXLine = coordBXLine.Substring(coordBXLine.IndexOf("(") + 1);
                Console.WriteLine("Bx = " + coordBXLine);
                if (!DigitsOnly(coordBXLine))
                    break;

                //координата By (в string). если не число, то ошибка ввода (повторный ввод)
                string coordBYLine = coordBLine.Substring(0, coordBLine.IndexOf(")"));
                coordBYLine = coordBYLine.Substring(coordBYLine.IndexOf(",") + 1);
                Console.WriteLine("By = " + coordBYLine);
                if (!DigitsOnly(coordBYLine))
                    break;

                testInput = true;
                arrayOut[0, 0] = int.Parse(coordAXLine);
                arrayOut[0, 1] = int.Parse(coordAYLine);
                arrayOut[1, 0] = int.Parse(coordBXLine);
                arrayOut[1, 1] = int.Parse(coordBYLine);
            }
            catch
            {
                Console.Clear();
                testInput = false;
            }

        }
    }
    return (arrayOut);
}

// вычисляет длину отрезка. на входе массив координат, на выходе длина в double
double CalculateLengthAB(int[,] coord)
{
    double lengthAB = Math.Sqrt(Math.Pow((coord[0, 0] - coord[1, 0]), 2) + Math.Pow((coord[0, 1] - coord[1, 1]), 2));
    return (lengthAB);
}

Console.Clear();
int[,] coordinates = readDataOfPoint();
double lengthAB = CalculateLengthAB(coordinates);
// форматированный вывод. не более 3-х символов после запятой
Console.WriteLine("Длина отрезка: " + "{0:#.###}", lengthAB);