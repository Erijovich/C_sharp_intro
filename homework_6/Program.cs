/* 
Задача 41: Пользователь вводит с клавиатуры M чисел.
Посчитайте, сколько чисел больше 0 ввёл пользователь.

вариация задачи 41 - пользователь не задает сколько
чисел он введет (то есть число M), а подсчет количества
чисел производится после того, как пользователь
не ввел информацию и нажал Enter.

Задача 43: Напишите программу, которая найдёт точку
пересечения двух прямых, заданных уравнениями
y = k1 * x + b1, y = k2 * x + b2; значения
b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

задача 40 - HARD необязательная. На вход программы
подаются три целых положительных числа. Определить,
является ли это сторонами треугольника. Если да, то
вывести всю информацию по нему - площадь, периметр,
значения углов треугольника в градусах, является ли
он прямоугольным, равнобедренным, равносторонним.

задача 2 HARD необязательная. Сгенерировать массив
случайных целых чисел размерностью m*n (размерность
вводим с клавиатуры). Вывести на экран красивенько
таблицей. Перемешать случайным образом элементы массива,
причем чтобы каждый гарантированно переместился на другое
место (возможно для этого удобно будет использование множества)
и выполнить это за m*n / 2 итераций. То есть если массив
три на четыре, то надо выполнить не более 6 итераций.
И далее в конце опять вывести на экран как таблицу.
 */

// ЭТО СЕРВИСНЫЕ ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
// цель - сделат ь так, что бы вообще не трогать их
// но пока не вижу, как грамотно осуществить селектор задач
// их может быть и одна и сто одна..

int InputChecker(string exeptionMessage) //немного изменённая стандартная функция для защиты от ввода не чисел
                    // я понял , что текст ошибки может быть разным и надо его посылать в функцию
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
        Console.Write("Работаем только числами, попробуй снова (ctrl+c для экстренного прерывания): ");
    }
    return InputChecker(); 
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
           // case 5: { ExFive(); break; }
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
    for (int i = 0; i < n; i++) array[i] = rand.Next(min, max+1); // заполнение массива, не забывая, что справа плюс 1 к диапазону
    return array;
}

double[] CreateDoubleArray(int n, double min, double max) // создание массива размера n и заполнение целыми числами из диапазона min..max
{
    if (max < min)  // проверка и защита
    {
        double temp = min;
        min = max;
        max = temp;
    }

    var rand = new Random();
    double[] array = new double[n];
    for (int i = 0; i < n; i++) array[i] = min + (max-min)*rand.NextDouble(); // заполнение массива
                                                                              // rand.NextDouble() возвращает вещественное число из диапазона от 0 до 1
                                                                              // дальше, что бы получить нужный нам диапазон мы должны начать со значения
                                                                              // min и добавить к нему случайное число размером не больше , чем (max-min)
    return array;
}

// посмотреть, можно ли в C# как-то организовать перегрузку метода по типу возвращаемого значения

// ЗАДАЧИ

void ExOne()
{
 
    Console.Write("Введите первое число число: ");

    int [][] megaArray = new int [30][]; //примерно 4 млрд чисел, думаю, хватит. Однако хз, как сделать потенциально бесконечный ввод,
    megaArray [0] = new int [8]; //начнём с 8-ми элементов и будем удваивать при заполнении. 

    string nextInput = string.Empty,
           exeptionMessage = "!Работаем только с целыми числами, введите или число или пустую строку для завершения ввода (ctrl+c для экстренного прерывания)!";

    int nextNumber = 0, 
        counter = 0, 
        currentIndex = 0, 
        currentMaxIndex = megaArray[currentIndex].Length;

    while (true) 
    {        
        nextInput = Console.ReadLine();
        if (nextInput == "") 
        {
            Console.WriteLine("Вы завершили ввод чисел.");
            break;
        }
        else
        {          
            try 
            {
                nextNumber = Convert.ToInt32(nextInput);
                tempArray[currentIndex] = Convert.ToInt32(nextInput);
                currentIndex++;
            }
            catch
            {
                Console.WriteLine(exeptionMessage);
            }
        }     
        Console.Write("Введите следующее число: ");           
    } 






/*     int n = 0;
    while (true) // защита от ввода отрицательной размерности массива
    {
        Console.Write("Задайте размерность массива: ");
        n = InputChecker();
        if (n < 0) Console.WriteLine("Так не получится... размерность массива должна быть натуральным числом... ");
        else break;
    }
    int[] a = CreateArray(n, 100, 1000); // создаём массив и выводим его на экран
    string list = string.Join(", ", a);
    
    Console.WriteLine($"Созданный массив:\n[{list}]"); 

    int count = 0;
    for (int i = 0; i < a.Length; i++)
        if (a[i]%2 == 0) count++;
    
     Console.WriteLine($"В этом массиве {count}"                            // вывод количества чётных чисел
                     + $" чётн{EndingChanger(count, "ое", "ых", "ых")}"     // ееее! используем окончания))
                     + $" чис{EndingChanger(count, "ло", "ла", "ел")}");  */
}

void DynamicArray ()
{

}

void ExTwo()
{
    int n = 0, min=0, max =0;
    while (true) // защита от ввода отрицательной размерности массива
    {
        Console.Write("Задайте размерность массива: ");
        n = InputChecker();
        if (n < 0) Console.WriteLine("Так не получится... размерность массива должна быть натуральным числом... ");
        else break;
    }

    Console.Write("Введите диапазон значений элементов массива\nМинимальное значение: ");
    min = InputChecker();
    Console.Write("Максимальное значение: ");
    max = InputChecker();

    int[] a = CreateArray(n, min, max); // создаём массив и выводим его на экран
    string list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");

    int sum = 0;
    for (int i = 1; i < a.Length; i+=2) sum+=a[i];
    
     Console.WriteLine($"Сумма элементов этого массива, стоящих на нечётных позициях равна {sum}"); // вывод суммы
}

void ExThree()
{
    int n = 0;
    double min=0, max =0;
    while (true) // защита от ввода отрицательной размерности массива
    {
        Console.Write("Задайте размерность массива: ");
        n = InputChecker();
        if (n < 0) Console.WriteLine("Так не получится... размерность массива должна быть натуральным числом... ");
        else break;
    }

    Console.Write("Введите диапазон вещестенных значений элементов массива\nМинимальное значение: ");
    min = InputDoubleChecker();
    Console.Write("Максимальное значение: ");
    max = InputDoubleChecker();

    double[] a = CreateDoubleArray(n, min, max); // создаём массив и выводим его на экран
    string list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");

    double dif = 0, minNum = a[0], maxNum = a[0];
    for (int i = 1; i < a.Length; i++)
    {
        if (a[i] < minNum) minNum = a[i];
        else if (a[i] > maxNum) maxNum = a[i];
    }

    dif = maxNum - minNum;
    Console.WriteLine($"Максимальный элемент массива: {maxNum}");
    Console.WriteLine($"Минимальный элемент массива: {minNum}");
    Console.WriteLine($"Разница между максимальным и минимальным элементами массива равна {dif}"); // вывод разницы

}

void ExFour()
{
    Console.Write($"Введите число для проверки на палиндромность: ");
    int n = InputChecker();   // думаю, что, по-хорошему надо вводить через строку, и если на первых позицях будут стоять нули - тогда мы их не будем терять
    if (n < 1) n *= -1;  // убираем минус , если будет
    if (PalindromChecker(n)) Console.WriteLine("Сие число есмь палиндромъ!");
    else Console.WriteLine("Число сие палиндромомъ никакъ не является!");
}

bool PalindromChecker(int n) 
{
    int count = 0; // вспомогательнгый счётчик для поиска общего количества знаков
    for (int i = 1; i <= n; i *= 10) count++;

     int leftDigit = 0, rightDigit =0;
    for (int i = 1; i <= count/2 + count%2; i++) // если число чётное, то проверок ровно половину от количества знаков, если нечётное - то надо исключить центральную цифру, а потом так же половина
    {
        //последовательно отсекаем части числа , что бы получить по цифре для сравнения
   
        leftDigit = n / IntPower(10, count-i); // Console.WriteLine("left dig before " + leftDigit + " "); // отладка
        leftDigit %= IntPower(10, 1);          // Console.WriteLine("left dig after " + leftDigit + " ");

        rightDigit = n % IntPower(10, i);      // Console.WriteLine("right dig before " +rightDigit + " ");
        rightDigit /= IntPower(10, i-1);       // Console.WriteLine("right dig after " +rightDigit + " "); 

        if (leftDigit != rightDigit) return false;         
    }
    return true;
}

int IntPower(int number, int power) // integer функция возведения в степень 
{
    if (power == 0) return 1;
    int result = number;
    for (int i = 1; i < power; i++) result *= number;
    // Console.Write("power is " + result + ", "); // отладка
    return result;
}

double VectorLength(int[] a, int[] b) // длина отрезка между двумя заданными точками в N-мерном пространстве
{
    int sum = 0;
    int length = a.Length;
    for (int i = 0; i < length; i++) sum += (a[i] - b[i]) * (a[i] - b[i]);
    return Math.Sqrt(sum);
}



// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ


Console.WriteLine("\n    --- Домашка шестая ---");
bool flag = true;
int num = 4; // придётся руками менять значение num и ветвление в функции ExInit()

string[] exerciseList = {
                            "1 задача: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь. При этом пользователь не задает сколько чисел он введет (то есть число M), а подсчет количества чисел производится после того, как пользователь не ввел информацию и нажал Enter.",
                            "2 задача: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.",
                            "3 задача HARD: На вход программы подаются три целых положительных числа. Определить , является ли это сторонами треугольника. Если да, то вывести всю информацию по нему - площадь, периметр, значения углов треугольника в градусах, является ли он прямоугольным, равнобедренным, равносторонним.",
                            "4 задача HARD: Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры). Вывести на экран красивенько таблицей. Перемешать случайным образом элементы массива, причем чтобы каждый гарантированно переместился на другое место (возможно для этого удобно будет использование множества) и выполнить это за m*n / 2 итераций. То есть если массив три на четыре, то надо выполнить не более 6 итераций. И далее в конце опять вывести на экран как таблицу."
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