// Задача 64: Домашнее задание.
// Задайте N
// Выведите натуральные числа от N до 1

// ввод значения. запрашивает ввод, конвертирует в int32 и возвращает это число. Принимает bool - необходимость выполнения проверки знака числа.
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

//формирует строку чисел от n до 1 (3 варианта)
string NumberInIntervalRec(int n)
{
    // 1 вариант
    // string result = string.Empty;
    // if (n == 1)
    //     return $" {n}";
    // else
    // {
    //     result = result + n + ", " + NumberInIntervalRec(n - 1);
    //     return result;
    // }

    // 2 вариант
    // if (n >= 1)
    //     return $"{n}, {NumberInIntervalRec(n - 1)}";
    // else
    //     return string.Empty;

    // 3 вариант. Наиболее лаконичный.
    return (n >= 1) ? $"{n}, {NumberInIntervalRec(n - 1)}" : string.Empty;
}

Console.Clear();

Console.Write("Введите натуральное число N ");
int n = GetDataTryParse(true);

string result = NumberInIntervalRec(n);
//убираем лишнюю запятую в конце строки
Console.WriteLine(result.Remove(result.Length - 2, 1));
