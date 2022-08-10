// №43 Домашнее задание
// Напишите программу, которая найдёт точку пересечения двух прямых, 
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; 5,5)
// * Найдите площадь треугольника образованного пересечением 3 прямых

//точки пересечения - глобальные переменные
//метод ввода данных
//метод Calculate
//x=(b2-b1)/(k1-k2) приравняв правые части уравнений
//y из любого уравнения
//метод печати

//глобальные переменные. для задания прямых
int k1;
int b1;
int k2;
int b2;
//обнуляем параментры третьей прямой для корректной работы метода задания прямых InputDataStraightLine, т.к. он может работать как для задания двух прямых, так и для трёх
int k3 = 0;
int b3 = 0;

/// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. Принимает bool - необходимость выполнения проверки знака числа.
// для проверки использует метод TryParse
int GetDataTryParse(bool signControl)
{
    bool testDigits = false;
    int result = 0;
    while (!testDigits)
    {
        string? inputString = Console.ReadLine();
        //если введено число и контроль знака пройден, то парсим его и возвращаем
        if ((int.TryParse(inputString, out int data)) && ((data > 0) || (!signControl)))
        {
            testDigits = true;
            result = data;
        }
        //если введено не число или контроль знака не пройден (при необходимости его проведения), то выводим предупреждение и предлагаем пользователю выбор
        else
        {
            // Console.Clear();
            Console.WriteLine("Не корректный ввод!!!");
            Console.WriteLine("Для завершения программы нажмите клавишу Esc.");
            Console.WriteLine("Для повторного ввода нажмите любую другую клавишу.");
            //ждём нажатия клавиши (клавиша не отображается, т.к. true), если Esc, то завершаем выполнение программы
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                //Завершает этот процесс и возвращает код выхода операционной системе
                Environment.Exit(0);
            else
                Console.Write("Повторите ввод: ");
        }
    }
    return result;
}

//задание прямых (глобальные переменные) принимает bool (необходимость задавать третью прямую и контролировать её) проверка на паралельность
void InputDataStraightLine(bool ThreeStraightLine)
{
    Console.Write("Введите k1 ");
    k1 = GetDataTryParse(false);
    Console.Write("Введите b1 ");
    b1 = GetDataTryParse(false);
    Console.Write("Введите k2 ");
    k2 = GetDataTryParse(false);
    Console.Write("Введите b2 ");
    b2 = GetDataTryParse(false);
    if (!ThreeStraightLine)
    {
        if (k1 == k2)
        {
            Console.WriteLine("Прямые паралельны!!!");
            Environment.Exit(0);
        }
    }
    else
    {
        Console.Write("Введите k3 ");
        k3 = GetDataTryParse(false);
        Console.Write("Введите b3 ");
        b3 = GetDataTryParse(false);
        if ((k1 == k2) || (k1 == k3) || (k2 == k3))
        {
            Console.WriteLine("Есть паралельные прямые!!!");
            Environment.Exit(0);
        }
    }
}

//нахождение точки пересечения двух прямых (глобальные переменные)
double[] FindPointOfIntersectionGlobal()
{
    //массив с координатами точки пересечения двух прямых
    double[] array = new double[2];
    //точка x
    array[0] = Math.Round((float)(b2 - b1) / (k1 - k2), 3);
    //точка y
    array[1] = k1 * array[0] + b1;
    return array;
}

//печать double массива
void PrintArray(double[] array)
{
    Console.WriteLine($"({string.Join("; ", array)})");
}

//нахождение точки пересечения двух прямых (локальные переменные)
double[] FindPointOfIntersectionLocal(int kLoc1, int bLoc1, int kLoc2, int bLoc2)
{
    //массив с координатами точки пересечения двух прямых
    double[] array = new double[2];
    //точка x
    array[0] = Math.Round((float)(bLoc2 - bLoc1) / (kLoc1 - kLoc2), 3);
    //точка y
    array[1] = kLoc1 * array[0] + bLoc1;
    return array;
}

//вычисление длины стороны треугольника
double CalcLengthOfTriangleSide(double[] PointOfIntersection_1_2, double[] PointOfIntersection_1_3)
{
    double sideLength = Math.Sqrt(Math.Pow((PointOfIntersection_1_2[0] - PointOfIntersection_1_3[0]), 2) + Math.Pow((PointOfIntersection_1_2[1] - PointOfIntersection_1_3[1]), 2));
    return Math.Round(sideLength, 3);
}

//вычисление площади треугольника по длинам его сторон по формуле Герона
double CalcSquareOfTriangle(double[] lengthOfTriangleSide)
{
    //полупериметр
    double halfOfPerimeter = (lengthOfTriangleSide[0] + lengthOfTriangleSide[1] + lengthOfTriangleSide[2]) / 2;
    //формула Герона
    double square = Math.Sqrt(halfOfPerimeter*(halfOfPerimeter-lengthOfTriangleSide[0])*(halfOfPerimeter-lengthOfTriangleSide[1])*(halfOfPerimeter-lengthOfTriangleSide[2]));
    return Math.Round(square, 3);
}

Console.Clear();

Console.WriteLine("Введите значения k и b для двух прямых:");
InputDataStraightLine(false);
double[] PointOfIntersection = FindPointOfIntersectionGlobal();
Console.Write("Точка пересечения этих прямых ");
PrintArray(PointOfIntersection);

//*
//метод 1.вводятся три прямые k1, k2, k3; b1, b2, b3
//метод 2. Найти точки пересечения всех трёх прямых. Если хотя бы одна пара не пересекается, то выдать ошибку (нет пересечения)
//метод 3. Найти длины сторон треугольника через его координаты
//метод 4. По трём сторонам найти площадь треугольника
//вывод на печать результата
//вывод промежуточных результатов для проверки

Console.WriteLine("Задача со *. Введите значения k и b для трёх прямых:");
InputDataStraightLine(true);

//три массива - точки пересечения трёх прямых
double[] PointOfIntersection_1_2 = FindPointOfIntersectionLocal(k1, b1, k2, b2);
// Console.Write("Точка пересечения прямых 1 и 2 ");
// PrintArray(PointOfIntersection_1_2);

double[] PointOfIntersection_1_3 = FindPointOfIntersectionLocal(k1, b1, k3, b3);
// Console.Write("Точка пересечения прямых 1 и 3 ");
// PrintArray(PointOfIntersection_1_3);

double[] PointOfIntersection_2_3 = FindPointOfIntersectionLocal(k2, b2, k3, b3);
// Console.Write("Точка пересечения прямых 2 и 3 ");
// PrintArray(PointOfIntersection_2_3);

//массив длин сторон треугольника
double[] lengthOfTriangleSide = new double[3];

lengthOfTriangleSide[0] = CalcLengthOfTriangleSide(PointOfIntersection_1_2, PointOfIntersection_1_3);
// Console.WriteLine($"Длина стороны 1-2: {lengthOfTriangleSide[0]}");

lengthOfTriangleSide[1] = CalcLengthOfTriangleSide(PointOfIntersection_1_2, PointOfIntersection_2_3);
// Console.WriteLine($"Длина стороны 2-3: {lengthOfTriangleSide[1]}");

lengthOfTriangleSide[2] = CalcLengthOfTriangleSide(PointOfIntersection_1_3, PointOfIntersection_2_3);
// Console.WriteLine($"Длина стороны 1-3: {lengthOfTriangleSide[2]}");

Console.WriteLine($"Площадь образованного тремя прямыми треугольника: {CalcSquareOfTriangle(lengthOfTriangleSide)}");


