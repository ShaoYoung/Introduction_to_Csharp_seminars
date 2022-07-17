//HomeWork
//№21 Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
//A (3,6,8); B (2,1,-7), -> 15.84
//A (7,-5,0); B (1,-1,9) -> 11.53
//* Сделать метод загрузки кнопки


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


//считывает коордиаты точек A и B, возвращает массив, где 
//[0,0] = Ax, [0,1] = Ay, [0,2] = Az, [1,0] = Bx, [1,1] = By, [1,2] = Bz
int[,] readDataOfPoint()
{
    int[,] arrayOut = new int[2, 3];

    bool testInput = false;
    string? inputLine = "";
    while (!testInput)
    {
        Console.WriteLine("Введите координаты точек A и B в формате A (7,-5,0); B (1,-1,9): ");
        inputLine = Console.ReadLine();
        if (!String.IsNullOrEmpty(inputLine))
        {
            try
            {
                testInput = true;
                //координата Ax (в string). если не число, то ошибка ввода (повторный ввод)
                string coordAXLine = inputLine.Substring(0, inputLine.IndexOf(","));
                coordAXLine = coordAXLine.Substring(coordAXLine.IndexOf("(") + 1);
                Console.WriteLine("Ax = " + coordAXLine);
                if (!DigitsOnly(coordAXLine))
                    testInput = false;

                string coordAYZLine = inputLine.Substring(0, inputLine.IndexOf(")"));
                coordAYZLine = coordAYZLine.Substring(coordAYZLine.IndexOf(",") + 1);
                //координата Ay (в string). если не число, то ошибка ввода (повторный ввод)
                string coordAYLine = coordAYZLine.Substring(0, coordAYZLine.IndexOf(","));
                Console.WriteLine("Ay = " + coordAYLine);
                if (!DigitsOnly(coordAYLine))
                    testInput = false;

                //координата Az (в string). если не число, то ошибка ввода (повторный ввод)
                string coordAZLine = coordAYZLine.Substring(coordAYZLine.IndexOf(",") + 1);
                Console.WriteLine("Az = " + coordAZLine);
                if (!DigitsOnly(coordAZLine))
                    testInput = false;

                string coordBLine = inputLine.Substring(inputLine.IndexOf("B") + 1);
                //координата Bx (в string). если не число, то ошибка ввода (повторный ввод)
                string coordBXLine = coordBLine.Substring(0, coordBLine.IndexOf(","));
                coordBXLine = coordBXLine.Substring(coordBXLine.IndexOf("(") + 1);
                Console.WriteLine("Bx = " + coordBXLine);
                if (!DigitsOnly(coordBXLine))
                    testInput = false;

                //координата By (в string). если не число, то ошибка ввода (повторный ввод)
                string coordBYZLine = coordBLine.Substring(0, coordBLine.IndexOf(")"));
                coordBYZLine = coordBYZLine.Substring(coordBYZLine.IndexOf(",") + 1);
                //координата By (в string). если не число, то ошибка ввода (повторный ввод)
                string coordBYLine = coordBYZLine.Substring(0, coordBYZLine.IndexOf(","));
                Console.WriteLine("By = " + coordBYLine);
                if (!DigitsOnly(coordBYLine))
                    testInput = false;

                //координата Bz (в string). если не число, то ошибка ввода (повторный ввод)
                string coordBZLine = coordBYZLine.Substring(coordBYZLine.IndexOf(",") + 1);
                Console.WriteLine("Bz = " + coordBZLine);
                if (!DigitsOnly(coordBZLine))
                    testInput = false;

                arrayOut[0, 0] = int.Parse(coordAXLine);
                arrayOut[0, 1] = int.Parse(coordAYLine);
                arrayOut[0, 2] = int.Parse(coordAZLine);
                arrayOut[1, 0] = int.Parse(coordBXLine);
                arrayOut[1, 1] = int.Parse(coordBYLine);
                arrayOut[0, 2] = int.Parse(coordBZLine);
            }
            catch
            {
                Console.Clear();
                testInput = false;
            }
        }
        else
            Console.Clear();
    }
    return (arrayOut);
}

// вычисляет длину отрезка. на входе массив координат, на выходе длина в double
double CalculateLengthAB(int[,] coord)
{
    double lengthAB = Math.Sqrt(Math.Pow((coord[0, 0] - coord[1, 0]), 2) + Math.Pow((coord[0, 1] - coord[1, 1]), 2) + Math.Pow((coord[0, 2] - coord[1, 2]), 2));
    return (lengthAB);
}

Console.Clear();
int[,] coordinates = readDataOfPoint();
double lengthAB = CalculateLengthAB(coordinates);
// форматированный вывод. не более 3-х символов после запятой
Console.WriteLine("Длина отрезка: " + "{0:#.###}", lengthAB);