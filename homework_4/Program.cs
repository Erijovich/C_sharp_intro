// ЭТО СЕРВИСНЫЕ ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
// цель - сделат ь так, что бы вообще не трогать их
// но пока не вижу, как грамотно осуществить селектор задач
// их может быть и одна и сто одна..

int InputChecker() // функция для защиты от ввода не-целых-чисел
                   // нам нужны однотипные проверки во всех задачах
{
    try
    {
        return Convert.ToInt32(Console.ReadLine());  // почему то не работает без переноса строки -  return Convert.ToInt32(Console.Read());  
    }
    catch
    {
        Console.Write("Работаем только с целыми числами, попробуй снова (ctrl+c для экстренного прерывания): ");
    }
    return InputChecker();  //фак еее! чёт долго доходило, как сделать проверку так, что бы при неверном вводе можно было опять попробовать
}

string EndingChanger(int num, string one, string two, string many) // Функция для замены окончания, на входе числительное и окончания
                                                                   // для один -ист, два -иста, много -истов, окончания для разных
                                                                   // слов могут быть разные, поэтому посылаем их в функцию
                                                                   // и весь этот код только для изменения окончания в одном месте,
                                                                   // который почти никогда не будет меняться, всегда по 4 задачи...
{
    int n = num % 100;
    string ending = string.Empty; // это будем посылать в функцию для установки окончания

    if (n / 10 == 1) ending = many;                        // предпоследний разряд - 1
    else  // в этом ветвлении проверяем последний разряд
    {
        if (n % 10 == 1) ending = one;                     // последний разряд - 1
        else if (n % 10 >= 2 && n % 10 <= 4) ending = two; // последний разряд - 2..4
        else ending = many;                                // последний разряд - 5..9 или 0
    }
    return ending;
}

bool ExInit(int exerciseNumber, int totalCount, string[] exerciseText) // выбор и инициализация конкретной задачи, 
                                                                       // после выполнения - возвращаем значение флага,
                                                                       // который показывает будем дальше работать
                                                                       // или же прерываем работу
                                                                       // exerciseNumber - номер задачи
                                                                       // totalCount - количество задач
{
    if (exerciseNumber > 0 && exerciseNumber <= totalCount)
    {
        Console.WriteLine($"\n---Exercise {exerciseNumber}---");
        Console.WriteLine(exerciseText[exerciseNumber - 1]);
        switch (exerciseNumber)
        {
            case 1: { ExOne(); break; }
            case 2: { ExTwo(); break; }
            case 3: { ExThree(); break; }
            case 4: { ExFour(); break; }
        }
        Console.WriteLine("---End of Exercise---");
        return true;
    }
    else
    {
        switch (exerciseNumber)
        {
            case 0: return false;
            default: { Console.WriteLine($"Здесь только {totalCount} задач{EndingChanger(totalCount, "а", "и", "")}..."); return true; }
        }
    }
}

int[] CreateArray(int n, int min, int max) // создание массива размера n и заполнение целыми числами из диапазона min..max
{
    if (max < min)  // проверка и защита
    {
        int temp = min;
        min = max;
        max = temp;
    }

    var rand = new Random();
    int[] array = new int[n];
    for (int i = 0; i < n; i++) array[i] = rand.Next(min, max); // заполнение массива
    return array;
}

double ToPower(double number, double power) // double функция возведения в степень 
{
    if (power == 0) return 1;
    double result = number;
    for (int i = 1; i < power; i++) result *= number;
    return result;
}

int IntPower(int number, int power) // integer функция возведения в степень 
{
    if (power == 0) return 1;
    int result = number;
    for (int i = 1; i < power; i++) result *= number;
    // Console.Write("power is " + result + ", "); // отладка
    return result;
}

// ЗАДАЧИ

void ExOne()  // Exercise One
{
    Console.Write("Необходимо возвести число (введите число): ");
    int n = InputChecker(), 
        p = 0;

    while (true) // защито от ввода не натуральной степени
    {
        Console.Write("в эту степень (введите число): ");
        p = InputChecker();
        if (p < 0) Console.WriteLine("Так не получится... степень должна быть натуральным числом... ");
        else break;
    }
    Console.WriteLine($"{n} в степени {p} равно {ToPower(n, p)}");
}

void ExTwo() // Exercise Two
{
    Console.Write("Введите число, сумму цифр которого хотете посчитать: ");
    int n = InputChecker(),
        length = 0,
        disect = n,
        sum = 0;

    if (n < 0) n *= -1;

    for (int i = 1; i <= n; i *= 10) length++; //количество знаков в введённом числе
    for (int i = 0; i < length; i++) sum += (n / (IntPower(10, i))) % 10; // этой конструкцией мы последовательно
                                                                          // обрабатываем каждый разряд введённого
                                                                          // числа, начиная с самого правого и 
                                                                          // добавляем эту цифру в sum
    Console.WriteLine("Сумма цифр введённого числа: " + sum);
}

void ExThree() // Exercise Three
{
    int[] a = CreateArray(8, -10, 10);
    string list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");
}

void ExFour() // Exercise Four
{
    int n = 0, min = 0, max = 0;

    while (true) // защито от ввода неправильной размерности
    {
        Console.Write("Введите размерность массива: ");
        n = InputChecker();
        if (n < 1) Console.WriteLine("Так не получится... Размерность должна быть больше нуля. (Можно и ноль, но не нужно) ");
        else break;
    }

    Console.Write("Введите диапазон значений элементов массива\nМинимальное значение: ");
    min = InputChecker();
    Console.Write("Максимальное значение: ");
    max = InputChecker();

    int[] array = CreateArray(n, min, max); // создаём массив и выводим его на экран
    string list = string.Join(", ", array);
    Console.WriteLine($"Созданный массив:\n[{list}]");

    ArrayMaxMinSort(array);

    list = string.Join(", ", array);
    Console.WriteLine($"Упорядоченный массив:\n[{list}]");
}

void ArrayMaxMinSort(int[] array) // сортировка массива методом макс-мин
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int posMax = i;

        for (int j = i + 1; j < array.Length; j++)
            if (array[j] > array[posMax]) posMax = j;

        int temp = array[i];
        array[i] = array[posMax];
        array[posMax] = temp;
    }
}

// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.WriteLine("\n    --- Домашка четвёртая ---");
bool flag = true;
int num = 4; // придётся руками менять значение num и ветвление в функции ExInit()

string[] exerciseList = {
                            "1 задача: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.",
                            "2 задача: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.",
                            "3 задача: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.",
                            "4 задача: Написать программу сортировки массива от большего к меньшему. Массив задается размерностью N с клавиатуры, далее заполняется случайными целыми числами."
                        };

foreach (string text in exerciseList) Console.WriteLine(text);

while (flag) // бесконечный цикл, пока флаг = true. 
{
    Console.Write($"\nВведите или номер задачи (1..{num}) или 0 "
                    + "для выхода (для экстренного прерывания - ctrl+C): ");

    flag = ExInit(InputChecker(), num, exerciseList);

    if (!flag)
    {
        Console.WriteLine("---Good buy!---\n");
        break;
    }
}

