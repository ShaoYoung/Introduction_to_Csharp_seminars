// Задача №42
// Напишите программу, которая будет преобразовывать десятичное число в двоичное.
// Например:
// 45 -> 101101
// 3 -> 11
// 2 -> 10

//Для перевода целого десятичного числа в двоичную систему счисления нужно последовательно выполнять деление данного числа
//и получаемых целых частных на 2 до тех пор, пока не получим частное, которое будет равно нулю.

//Выполнить деление исходного числа на 2. Если результат деления больше или равен 2, продолжать делить его на 2 до тех пор,
//пока результат деления не станет равен 1.
//Выписать результат последнего деления и все остатки от деления в обратном порядке в одну строку.

//делить на 2, остаток от деления (%) записать в список, потом его перевернуть

//Через список List<bool> binary = new List<bool>();
//binary.Add(0); - добавление элемента

//печать byte списка
// void PrintList(List<bool> list)
// {
//     Console.WriteLine($"[{string.Join(" ", list)}]");
// }

Console.Clear();
//сокращённая форма записи
//Console.WriteLine(Convert.ToString(int.Parse(Console.ReadLine()), 2));

//разложенная строка
int number = int.Parse(Console.ReadLine());
//преобразование в строку. второй аргумент - основание преобразования.
string outLine = Convert.ToString(number,2);
Console.WriteLine(outLine);

// string binary = Convert.ToString(value, 2);


//метод Кирилла
Console.Write("Введите десятичное число: ");
int decemalNumber = ReadDecemalNumber();
PrintAnswer(BinaryConverter(decemalNumber));


int ReadDecemalNumber(){
    return int.Parse(Console.ReadLine() ?? "");
}

string BinaryConverter(int num) {
    string bin = "";
    while(num > 0) {
        if (num % 2 == 1) {
            bin = "1" + bin;
        } else {
            bin = "0" + bin;            
        }
        num /= 2;
    }
    return bin;
}

void PrintAnswer(string answer){
    Console.WriteLine("Введенное число в двоичном виде: " + answer);
}



