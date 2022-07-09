//Задача №3
//Напишите программу, которая будет выдавать название дня недели по заданному номеру.

Console.Clear();
Console.Write("Введите номер дня недели: ");
string? inputLine = Console.ReadLine();

// строковый массив
string[] dayOfWeek = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

// или можно так задать массив
//string[] dayOfWeek = new string[7];
// dayOfWeek[0] = "Понедельник";
// dayOfWeek[1] = "Вторник";
// dayOfWeek[2] = "Среда";
// dayOfWeek[3] = "Четверг";
// dayOfWeek[4] = "Пятница";
// dayOfWeek[5] = "Суббота";
// dayOfWeek[6] = "Воскресенье";

//null - отсутствие значения
if (inputLine != null)
{
    int inputNumber = int.Parse(inputLine);
    Console.WriteLine("Это " + dayOfWeek[inputNumber - 1]);


// второй вариант через switch
// switch(inputNumber)
// {
//     case 1:
//     Console.WriteLine("Понедельник");
//     break;

//     case 2:
//     Console.WriteLine("Вторник");
//     break;

//     case 3:
//     Console.WriteLine("Среда");
//     break;

//     case 4:
//     Console.WriteLine("Четверг");
//     break;

//     case 5:
//     Console.WriteLine("Пятница");
//     break;

//     case 6:
//     Console.WriteLine("Суббота");
//     break;

//     case 7:
//     Console.WriteLine("Воскресенье");
//     break;
// }

//3-й вариант через System
string outDayOfWeek = System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName((DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(inputNumber));

 Console.WriteLine("Это " + outDayOfWeek);

}