// Задача 69
//
// На входе A и B
// На выходе A возводится в степень B


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


//возводит a в степень b (через деление на 2). Метод Андрея
int MyPow(int a, int b)
{
    if (b == 2)
    {
        return a * a;
    }
    if (b == 1)
    {
        return a;
    }
    if (b % 2 == 0)
    {
        return MyPow(a, b / 2) * MyPow(a, b / 2);
    }
    else
    {
        return MyPow(a, b / 2) * MyPow(a, (b / 2) + 1);
    }
}


//возводит a в степень b. Метод Кирилла
int PowNumber(int a, int b)
{
    // if (b == 1) return a;
    // return a * PowNumber(a, --b);
    // //более лаконично
    return (b == 1) ? a : a * PowNumber(a, --b);
}


Console.Clear();
Console.Write("Введите число A: ");
int a = GetDataTryParse(true);
Console.Write("Введите число B: ");
int b = GetDataTryParse(true);

DateTime dt = DateTime.Now;
Console.WriteLine($"{a} в степени {b} равно {PowNumber(a, b)}");
TimeSpan interval = DateTime.Now - dt;
Console.WriteLine("Прошло: ");
Console.WriteLine($"Минут-{interval.Minutes}, Секунд-{interval.Seconds}, Милисекунд-{interval.Milliseconds}, Всего милисекунд-{interval.TotalMilliseconds}");

dt = DateTime.Now;
Console.WriteLine($"{a} в степени {b} равно {MyPow(a, b)}");
interval = DateTime.Now - dt;
Console.WriteLine("Прошло: ");
Console.WriteLine($"Минут-{interval.Minutes}, Секунд-{interval.Seconds}, Милисекунд-{interval.Milliseconds}, Всего милисекунд-{interval.TotalMilliseconds}");

dt = DateTime.Now;
Console.WriteLine($"{a} в степени {b} равно {Math.Pow(a, b)}");
interval = DateTime.Now - dt;
Console.WriteLine("Прошло: ");
Console.WriteLine($"Минут-{interval.Minutes}, Секунд-{interval.Seconds}, Милисекунд-{interval.Milliseconds}, Всего милисекунд-{interval.TotalMilliseconds}");
