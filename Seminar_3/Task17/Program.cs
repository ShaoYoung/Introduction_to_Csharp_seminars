//Задача №17
//Напишите программу, которая принимает на вход координаты точки (X и Y),
// причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости, в которой находится эта точка.
// Например:
// x=34; y=-30 -> 4
// x=2; y=4-> 1
// x=-34; y=-30 -> 3

//Метод считывает точки и возвращает массив
int[,] readPoint()
{
    Console.Clear();
    string? inputLine = Console.ReadLine();
    //берём подстроку из ввенённой строки от 0 символа до  символа ";"
    string coordXLine = inputLine.Substring(0, inputLine.IndexOf(";"));
    //из этой подстроки берём подстроку от символа "=" до конца строки (+1 - подстрока до конца строки)
    coordXLine = coordXLine.Substring(coordXLine.IndexOf("=") + 1);

    //берём подстроку из ввенённой строки от символа ";" до конца строки
    string coordYLine = inputLine.Substring(inputLine.IndexOf(";") + 1);
    //из этой подстроки берём подстроку от символа "=" до конца строки (+1 - подстрока до конца строки)
    coordYLine = coordYLine.Substring(coordYLine.IndexOf("=") + 1);

    Console.WriteLine(coordXLine + " " + coordYLine);

    int coordX = int.Parse(coordXLine);
    int coordY = int.Parse(coordYLine);
    //двумерный массив arrayOut
    int[,] arrayOut = new int[1, 2];
    arrayOut[0, 0] = coordX;
    arrayOut[0, 1] = coordY;

    return arrayOut;
}

//Печатает номер четверти, на входе двумерный массив
void printQuoter(int[,] arrayPoint)
{
    if ((arrayPoint[0, 0] > 0) && (arrayPoint[0, 1] > 0))
        Console.WriteLine("1-я четверть.");
    if ((arrayPoint[0, 0] < 0) && (arrayPoint[0, 1] > 0))
        Console.WriteLine("2-я четверть.");
    if ((arrayPoint[0, 0] > 0) && (arrayPoint[0, 1] < 0))
        Console.WriteLine("4-я четверть.");
    if ((arrayPoint[0, 0] < 0) && (arrayPoint[0, 1] < 0))
        Console.WriteLine("3-я четверть.");
}

int[,] arrayPoint = readPoint();

printQuoter(arrayPoint);



