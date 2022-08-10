// №41 Домашнее задание
// Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// -1, -7, 567, 89, 223-> 3
// * Пользователь вводит число нажатий, затем программа следит за нажатиями и выдает сколько чисел больше 0 было введено.

//контроль ввода числа
//если не число, то повтор и возможность выхода через Esc.

// M  - глобальная переменная
// собирается массив пока i<M. 1.Отдельный метод. Возвращает массив.

//2. Метод определения количества чисел больше нуля

//3. void PrintResult

//*
//польз вводит число, сколько будет нажатий (число нажатий клавиш клавиатуры)
//вычислить сколько чисел больше нуля он ввёл. пользователь может ввести любой символ на клавиатуре. учитывать знак "-"
//вывести результат

//обернуть в методы

//ConsoleKeyInfo Key;
//key = Console.ReadKey;
//if (key.Key == ConsoleKey.D0)
//if (key.Key == ConsoleKey.NumPad0)


Console.Clear();
Console.Write("Введите целое положительное число M: ");
//m - глобальная переменная (с контролем знака)
int m = GetDataTryParse(true);

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

//печать int массива
void PrintArray(int[] array)
{
    Console.WriteLine($"[{string.Join(" ", array)}]");
}

//ввод массива. ничего не принимает, т.к. использует глобальную переменную m
int[] GetArray()
{
    int[] array = new int[m];
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Введите {i + 1} число ");
        array[i] = GetDataTryParse(false);
    }
    return array;
}

//подсчёт количества положительных чисел в int массиве
int CalcPositiveNumber(int[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
        if (array[i] > 0)
            count++;
    return count;
}

//домашнее задание
int[] inputArray = GetArray();
Console.WriteLine("Вы ввели массив:");
PrintArray(inputArray);
Console.WriteLine($"В этом массиве {CalcPositiveNumber(inputArray)} положительное(ых) число(а, ел).");

//задача со *

//строка нажатых символов. глобальная.
string stringOfPressedKeys = string.Empty;

//подсчёт количества положительных чисел во введенных пользователем символах
//критерий окончания числа - любой символ - не цифра
//001 -> 1, -001 -> 0.
int CalcPositiveNumberInKeyPress(int numberOfPress)
{
    //массив клавиш с цифрами, с которых может начинаться число (1-9)
    ConsoleKey[] numbersKeyArray = new ConsoleKey[18]
    {
        ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8, ConsoleKey.D9,
        ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6, ConsoleKey.NumPad7, ConsoleKey.NumPad8, ConsoleKey.NumPad9
    };
    int count = 0;
    int currentNumPress = 0;
    ConsoleKeyInfo key;
    bool acceptCount = true;
    bool waitForNotNumber = false;
    while (currentNumPress < numberOfPress)
    {
        //считываем символ с клавиатуры
        key = Console.ReadKey();
        //готовим строку нажатых клавиш для отображения
        MakeStringOfPressedKey(key);
        //инкремент количества нажатий
        currentNumPress++;
        //если был нажат минус, будем ждать не цифру
        if (key.Key == ConsoleKey.OemMinus)
        {
            waitForNotNumber = true;
        }
        //если нажата не цифра из массива, не минус, не 0, то не цифру больше не ждём
        if ((Array.BinarySearch(numbersKeyArray, key.Key) < 0) && (key.Key != ConsoleKey.OemMinus) && (key.Key != ConsoleKey.D0) && (key.Key != ConsoleKey.NumPad0))
        {
            waitForNotNumber = false;
        }
        if (!waitForNotNumber)
        {
            //если нажатая клавиша входит в массив и разрешён счёт, то инкрементируем счётчик положительных чисел
            if ((Array.BinarySearch(numbersKeyArray, key.Key) > (-1)) && (acceptCount))
                count++;
            //если нажатая цифра, то следующую клавишу за число считать не будем (число продолжается)
            if (Array.BinarySearch(numbersKeyArray, key.Key) > (-1))
                acceptCount = false;
            else
                acceptCount = true;
        }
    }
    return count;
}

//формирование строки нажатых клавиш. stringOfPressedKeys - глобальная переменная
void MakeStringOfPressedKey(ConsoleKeyInfo key)
{
    stringOfPressedKeys = stringOfPressedKeys + key.KeyChar.ToString() + " ";
}

Console.Write("Задача со *. Введите число нажатий клавиатуры: ");
int numberOfPress = GetDataTryParse(true);
Console.WriteLine($"Нажмите любые кнопки на клавиатуре {numberOfPress} раз:");
int count = CalcPositiveNumberInKeyPress(numberOfPress);
Console.WriteLine();
Console.WriteLine($"Вы нажали следующие клавиши: {stringOfPressedKeys}");
Console.WriteLine($"В ваших нажатиях обнаружилось {count} положительное(ых) число(а, ел).");



