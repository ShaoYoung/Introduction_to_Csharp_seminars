// Задача 65
// Значения M и N
// Вывод все натуральные числа от M до N

// Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.
// M = 1; N = 5. -> ""1, 2, 3, 4, 5""
// M = 4; N = 8. -> ""4, 6, 7, 8""

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. Принимает bool - необходимость выполнения проверки знака числа.
// для проверки использует метод TryParse
int GetDataTryParse(bool signControl)
{
    bool testDigits = false;
    int result = 0;
    while (!testDigits)
    {
        string? inputString = Console.ReadLine();
        //если введено число и контроль знака пройден, то парсим его и возвращаем
        if ((int.TryParse(inputString, out int data)) && ((data >= 0) || (!signControl)))
        {
            testDigits = true;
            result = data;
        }
        //если введено не число или контроль знака не пройден (при необходимости его проведения), то выводим предупреждение и предлагаем пользователю выбор
        else
        {
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

//формирует строку чисел от m до n
string NumberInIntervalRec(int m, int n)
{
    // 1 вариант
    // string result = string.Empty;
    // if (m == n)
    //     return $"{m}";
    // else
    // {
    //     result = result + m + ", " + NumberInIntervalRec(m + 1, n);
    //     return result;
    // }

    // 2 вариант
    // if (m <= n)
    //     return $"{m}, {NumberInIntervalRec(m + 1, n)}";
    // else
    //     return string.Empty;

    // 3 вариант. Наиболее лаконичный.
    return (m <= n) ? $"{m}, {NumberInIntervalRec(m + 1, n)}" : string.Empty;
}

Console.Clear();

Console.Write("Введите число M ");
int m = GetDataTryParse(true);
Console.Write("Введите число N ");
int n = GetDataTryParse(true);
int temp;
//контроль корректности ввода M и N
if (m > n)
{
    temp = m;
    m = n;
    n = temp;
}
string result = NumberInIntervalRec(m, n);
Console.WriteLine(result.Remove(result.Length - 2, 1));



