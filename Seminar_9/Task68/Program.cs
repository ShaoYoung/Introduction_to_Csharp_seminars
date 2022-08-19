// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 29
//
//Функция Аккермана:
//при m=0: A(m,n) = n+1;
//при m>0, n=0: A(m,n) = A(m-1,1)
//при m>0, n>0: A(m-1, A(m,n-1))

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

//вычисление функции Аккермана. без фанатизма. переполнение стека уже при m=3,n=11 или m=4 , n=1.
int Accerman(int m, int n)
{
    if (m == 0)
        return n + 1;
    if ((m > 0) && (n == 0))
        return Accerman(m - 1, 1);
    if ((m > 0) && (n > 0))
        return Accerman(m - 1, Accerman(m, n-1));
    return 0;
}


Console.Clear();
Console.Write("Введите число m: ");
int m = GetDataTryParse(true);
Console.Write("Введите число n: ");
int n = GetDataTryParse(true);
Console.WriteLine($"Значение функции Аккермана A({m},{n}) {Accerman(m, n)}");



