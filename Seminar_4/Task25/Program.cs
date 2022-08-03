// Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

//* Написать калькулятор с операциями +, -, /, * и возведение в степень

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

//возведение в степень с использованием Math.Pow
int VariantA(int number, int degree)
{
    return ((int)Math.Pow(number, degree));
}

//возведение в степень с использованием цикла while
int VariantB(int number, int degree)
{
    int result = 1;
    int count = 1;
    while (count <= degree)
    {
        result = result *= number;
        count++;
    }
    return result;
}

//печать двух результатов возведения в степень
void PrintResult(int varA, int varB)
{
    Console.WriteLine($"Первый вариант (возведение в степень через Math.Pow): {varA}");
    Console.WriteLine($"Второй вариант (возведение в степень через цикл while): {varB}");
}

// калькулятор
void Calculator(int firstNumber, int secondNumber)
{
    bool correctInput = false;
    string operation = string.Empty;
    //ввод действия с числами (с проверкой корректности)
    while (!correctInput)
    {
        Console.Write("Введите дополнительную операцию с этими числами (+, -, /, *, ^): ");
        operation = Console.ReadLine() ?? "";
        if (operation.Length == 1)
            if ((operation == "+") || (operation == "-") || (operation == "/") || (operation == "*") || (operation == "^"))
                correctInput = true;
        Console.Clear();
    }
    //селектор операции и вывод результата
    switch (operation)
    {
        case "+":
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {firstNumber + secondNumber}");
            break;
        case "-":
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {firstNumber - secondNumber}");
            break;
        case "/":
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {((double)firstNumber / secondNumber)}");
            break;
        case "*":
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {firstNumber * secondNumber}");
            break;
        case "^":
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {(int)Math.Pow(firstNumber, secondNumber)}");
            break;
    }
}

Console.Clear();

Console.Write("Введите первое число. ");
int number = GetDataTryParse();
Console.Write("Введите второе число (степень). ");
int degree = GetDataTryParse();

PrintResult(VariantA(number, degree), VariantB(number, degree));

Calculator(number, degree);



