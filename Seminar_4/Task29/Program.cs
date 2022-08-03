// Задача 29: 
// Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// * Ввести с клавиатуры длину массива и диапазон значений элементов

// длина массива, нижняя граница рандомайзера, верхняя граница рандомайзера
// Имена через запятую. Имена в массив через Split (,). Рандомом выдать имя, бегущего в магазин.

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. если что-то пошло не так, консоль очищается и ввод повторяется.
// для проверки использует метод TryParse
int GetDataTryParse()
{
    bool testDigits = false;
    int result = 0;
    while (!testDigits)
    {
        Console.Write("Введите целое число: ");
        string inputString = Console.ReadLine() ?? "";
        //string? inputString = Console.ReadLine();
        if ((int.TryParse(inputString, out int data)))
        {
            testDigits = true;
            result = data;
        }
        else
            Console.Clear();
    }
    return result;
}

//инициализируем рандомайзер (глобальная переменная)
System.Random numberSintezator = new Random();

//формирование массива из восьми элементов
int[] GetEightArray(int bottomLine, int topLine)
{
    int[] array = new int[8];
    for (int i = 0; i < 8; i++)
        array[i] = numberSintezator.Next(bottomLine, topLine + 1);
    return array;
}

//формирование массива из заданного количества элементов
int[] GetAnyArray(int lengthOfArray, int bottomLine, int topLine)
{
    int[] array = new int[lengthOfArray];
    for (int i = 0; i < lengthOfArray; i++)
        array[i] = numberSintezator.Next(bottomLine, topLine + 1);
    return array;
}

//печать числового массива
void PrintIntArray(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length - 1; i++)
        Console.Write(array[i] + ",");
    Console.Write(array[array.Length - 1]);
    Console.Write("]");
}

//формирование строкового массива из имён
string[] GetArrayOfName(string stringOfName)
{
    //разбиваем строку на подстроки. разделитель - ','
    string[] names = stringOfName.Split(',');
    return names;
}

//печать строкового массива
void PrintStringArray(string[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length - 1; i++)
        Console.Write(array[i] + ",");
    Console.Write(array[array.Length - 1]);
    Console.Write("]");
    Console.WriteLine();
}

//рандомное определение имени, бегущего в магазин
void WhoRunsToTheShop(string[] array)
{
    Console.WriteLine(array[numberSintezator.Next(0, array.Length)]);
}

Console.Clear();

Console.Write("Введите длину массива. ");
int lengthOfArray = Math.Abs(GetDataTryParse());

Console.Write("Введите нижнюю границу рандомайзера. ");
int bottomLine = GetDataTryParse();

Console.Write("Введите верхнюю границу рандомайзера. ");
int topLine = GetDataTryParse();

// формируем массив из 8 случайных чисел
int[] numArray = GetEightArray(bottomLine, topLine);
Console.WriteLine($"Первый вариант. Массив из восьми случайных чисел от {bottomLine} до {topLine}:");
PrintIntArray(numArray);

// формируем массив из lengthOfArray случайных чисел
numArray = GetAnyArray(lengthOfArray, bottomLine, topLine);
Console.WriteLine();
Console.WriteLine($"Второй вариант. Массив из {lengthOfArray} случайных чисел от {bottomLine} до {topLine}:");
PrintIntArray(numArray);

Console.WriteLine();
Console.WriteLine("Переходим к поиску бегущего в магазин. Введите все имена через запятую");
string stringOfName = Console.ReadLine() ?? "";
string[] nameArray;
//если введённая строка не пустая, то продолжаем поиск
if (!String.IsNullOrEmpty(stringOfName))
{
    nameArray = GetArrayOfName(stringOfName);
    Console.WriteLine("Массив имён: ");
    PrintStringArray(nameArray);
    Console.Write("В магазин бежит ");
    WhoRunsToTheShop(nameArray);
}
else
    Console.WriteLine("Вы ввели пустую строку! Попробуйте ещё раз.");



