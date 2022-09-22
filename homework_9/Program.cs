// ЭТО СЕРВИСНЫЕ ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
// цель - сделат ь так, что бы вообще не трогать их
// но пока не вижу, как грамотно осуществить селектор задач
// их может быть и одна и сто одна..

int InputChecker(string exeptionMessage) //немного изменённая стандартная функция для защиты от ввода не чисел
                                         // я понял , что текст ошибки может быть разным и удобно его посылать в функцию
                                         // поэтому она принимаеит string аргумент
{
    try
    {
        return Convert.ToInt32(Console.ReadLine());  // почему то не работает без переноса строки -  return Convert.ToInt32(Console.Read());  
    }
    catch
    {
        Console.WriteLine(exeptionMessage);
    }
    return InputChecker(exeptionMessage);  
}

double InputDoubleChecker() // функция для защиты от ввода не-чисел
                            // нам нужны однотипные проверки во всех задачах
{
    try
    {
        return Convert.ToDouble(Console.ReadLine()); 
    }
    catch
    {
        Console.Write("Можно ввести любое вещественное число: ");
    }
    return InputDoubleChecker(); 
}

int InputNaturalChecker (string userMessage, string exeptionMessage)
{
    int naturalNumber;
    while (true)
    {
        Console.Write(userMessage);
        naturalNumber = InputChecker(exeptionMessage);
        if (naturalNumber < 0) Console.WriteLine(exeptionMessage);
        else break;
    }
    return naturalNumber;

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
        Console.WriteLine($"{exerciseNumber} задача: {exerciseText[exerciseNumber - 1]} ");
        switch (exerciseNumber)
        {
            case 1: { ExOne(); break; }
            case 2: { ExTwo(); break; }
            case 3: { ExThree(); break; }

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

// ЗАДАЧИ

void ExOne() // Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.
{
    Console.WriteLine("Задайте первое число (M): ");
    double M = InputDoubleChecker();
    Console.WriteLine("Задайте второе число (N): ");
    double N = InputDoubleChecker(); 

    if (M < 0) M = 0; // Не существует единого для большинства математиков мнения ... считать ли ноль натуральным числом или нет (википедия)
    if (N < 0) N = 0; // Так что ноль натурал =)

    int n, m;

    if (M < N) // у большего числа отбрасываем дробную часть, меньшее - округляем вверх
    {
        n =  Convert.ToInt32(Math.Truncate(N));
        m =  Convert.ToInt32(Math.Ceiling(M));
    } else {
        m =  Convert.ToInt32(Math.Truncate(M));
        n =  Convert.ToInt32(Math.Ceiling(N));
    }

    Console.Write($"({M}) ");
    if (M - Math.Truncate(M) != 0  // мега сложное условие, надо облегчать. В целом тут всё для проверки  диапазона типа 1 и 1.1, надо учесть все варианты
      & N - Math.Truncate(N) != 0     
      & Math.Abs(Math.Truncate(M) - Math.Truncate(N)) < 1) Console.WriteLine("В заданом диапазоне нет натуральных чисел");
    else if (m < n) 
        for (int i = m; i <= n; i++) Console.Write(i + " ");
    else 
        for (int i = m; i >= n; i--) Console.Write(i + " ");
    Console.WriteLine($"({N})");
}


void ExTwo() // Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
{
    string exeptionMessage = "Только натуральные числа!";
    int m = InputNaturalChecker("Задайте первое число (M): " , exeptionMessage);
    int n = InputNaturalChecker("Задайте второе число (N): " , exeptionMessage);
    if (n < m) Swap(ref n, ref m);
    Console.WriteLine("Сумма всех натуралов = " + ReturnSumNatural(m, n));
}

void ExThree() // Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
{
    string exeptionMessage = "Только натуральные числа!";
    int m = InputNaturalChecker("Задайте первое число (M): " , exeptionMessage);
    int n = InputNaturalChecker("Задайте второе число (N): " , exeptionMessage);
    Console.WriteLine($"A({m}, {n}) = " + Ackerman((ulong)m,(ulong)n));
}

void Swap(ref int a, ref int b) // прикольный способ без использования дополнительной переменной
{
   a = a + b;
   b = a - b;
   a = a - b;
}

string ReturnMNNatural(int M, int N)
    {
        if (N==M) return $"{M}";
        return ReturnMNNatural(M, N-1) + $", {N}"; 
    }
    
int ReturnSumNatural(int n, int m)
{
    if (n==m) return m;
    return n + ReturnSumNatural(n + 1, m);
}

ulong Ackerman (ulong m, ulong n)
{
    if (m == 0)
    {
        return n + 1;
    }
    if (m > 0 & n == 0)
    {
         return (Ackerman(m - 1, 1));
     }
    if (m > 0 & n > 0)
     {
         return (Ackerman(m - 1, Ackerman(m, n - 1)));
     }
     return 0;
}

// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.Clear();
Console.WriteLine("\n    --- Домашка девятая ---");
bool flag = true;
string exeptionMessage = "Нужно ввести номер задачи цифрами или '0' для выхода (ctrl+c для экстренного прерывания): ";

string[] exerciseList = {
                            "Задайте значения M и N. Напишите программу, которая выведет все натуральные числа в промежутке от M до N.",
                            "Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.",
                            "Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n."
                        };

// foreach (string text in exerciseList) Console.WriteLine(text);
for (int i = 0; i < exerciseList.Length; i++) Console.WriteLine((i+1) + " задача: " + exerciseList[i]);

while (flag) // бесконечный цикл, пока флаг = true. 
{
    Console.Write($"\nВведите или номер задачи (1..{exerciseList.Length}) или 0 "
                    + "для выхода (для экстренного прерывания - ctrl+C): ");

    flag = ExInit(InputChecker(exeptionMessage), exerciseList.Length, exerciseList);

    if (!flag)
    {
        Console.WriteLine("---Good buy!---\n");
        break;
    }
}