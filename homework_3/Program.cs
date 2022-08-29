// ЭТО СЕРВИСНЫЕ ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
// цель - сделат ь так, что бы вообще не трогать их
// но пока не вижу, как грамотно осуществить селектор задач
// их может быть и одна и сто одна..

int InputChecker() // функция для защиты от ввода не-чисел
                   // нам нужны однотипные проверки во всех задачах
{
    try
    {
        return Convert.ToInt32(Console.ReadLine());
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
                                                                   // и это всё только для изменения окончания в одном месте ...
{
    int n = num % 100;
    string ending = string.Empty; // это будем посылать в функцию для установки окончания

    if (n / 10 == 1) ending = many;                   // предпоследний разряд - 1
    else  // в этом ветвлении проверяем последний разряд
    {
        if (n % 10 == 1) ending = one;                 // последний разряд - 1
        else if (n % 10 >= 2 && n % 10 <= 4) ending = two; // последний разряд - 2..4
        else ending = many;                          // последний разряд - 5..9 или 0
    }
    return ending;
}

bool ExInit(int a, int n) // выбор и инициализация конкретной задачи, 
                          // после выполнения - возвращаем значение флага,
                          // который показывает будем дальше работать
                          // или же прерываем работу
                          // a - номер задачи
                          // n - количество задач
{
    if (a > 0 && a <= n)
    {
        Console.WriteLine($"\n---Exercise {a}---");
        if (a == 1) ExOne();
        else if (a == 2) ExTwo();
        else if (a == 3) ExThree();
        else if (a == 4) ExFour();  // в случае изменения количества задач только здесь или добавляем или убираем функции
        Console.WriteLine("---End of Exercise---");
    }
    else if (a == 0) return false; //для завершения работы хотелось бы, конечно, использоват не 0 , а какой-нибудь Esc
    else if (a > 0) Console.WriteLine($"Здесь только {n} задач{EndingChanger(n, "а", "и", "")}..."); // неважно , что это ветвеление перекрывает диапазон значения количества задач, проверка будет только в случае, если самая первая проверка не пройдёт
    else Console.WriteLine("Отрицательное значение номера задачи? ну ладно, попробуй снова..");

    return true;
}

// ЗАДАЧИ

void ExOne()  // Exercise One
{
    Console.WriteLine("Напишите программу, которая принимает "   //  ---> думаю , надо сделать массив с текстами задач, кажется неправильным,
                    + "на вход пятизначное число и проверяет, "  //  что в каждой функции надо писать. Всё должно быть в одном месте.
                    + "является ли оно палиндромом.");
    Console.WriteLine();

    int n = 0;
    int digits = 5; //количество знаков числа палиндромность которого мы будем проверять

    while (true) // выпустим только после ввода 5-ти значного числа
    {
        Console.Write($"Введите {digits}-ти значное число: ");
        n = InputChecker();

        if (n < 1) n *= -1;

        if (n < IntPower(10, digits - 1) || n >= IntPower(10, digits)) Console.WriteLine("Не-а! Строго 5-ти значное число. "
                                                                                   + "Если не получается - то ctrl+c для прерывания программы.");
        else break;
    }

    Console.WriteLine(PalindromChecker(n));
}

bool PalindromChecker(int n) // в принципе можен работать для любого количества цифр в числе
{

    int count = 0; // вспомогательнгый счётчик для поиска общего количества знаков
    for (int i = 1; i <= n; i *= 10) count++;

    int j = count; // если число чётное, то проверок ровно половину от количества знаков, если нечётное - то надо исключить центральную цифру, а потом так же половина
    if (count % 2 == 0) j /= 2;
    else j = (j - 1) / 2;

    for (int i = 1; i <= j; i++)
    {
        //последовательно отсекаем части числа , что бы получить по цифре для сравнения
   
        int leftDigit = n / IntPower(10, count-i); // Console.WriteLine("left dig before " + leftDigit + " "); // отладка
        leftDigit %= IntPower(10, 1);              // Console.WriteLine("left dig after " + leftDigit + " ");

        int rightDigit = n % IntPower(10, i);      // Console.WriteLine("right dig before " +rightDigit + " ");
        rightDigit /= IntPower(10, i-1);           // Console.WriteLine("right dig after " +rightDigit + " "); 

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

void ExTwo() // Exercise Two
{
    Console.WriteLine("Напишите программу, которая принимает на "
                    + "вход координаты двух точек и находит "
                    + "расстояние между ними в 3D пространстве."
                    + "\nRED - попробуем найти расстояние между "
                    + "двумя точками в N-мерном пространстве."
                    + "\nА ещё вводить числа будем не ручками, "
                    + "а псевдорандомом.");
    Console.WriteLine();

    int n = 0, min = 0, max = 0;

    while (true)
    {
        Console.Write("Введите размерность пространства: ");
        n = InputChecker();

        if (n < 1) Console.WriteLine("Так не получится... Пространства "
                                + "с нулевым или отрицательным количеством измерений "
                                + "мы пока не придумали. Вроде бы...");
        else break;
    }

    Console.Write("Введите диапазон значений координат\nМинимальное значение: ");
    min = InputChecker();
    Console.Write("Максимальное значение: ");
    max = InputChecker();

    if (max < min)  // проверка и защита
    {
        Console.WriteLine("Нас не проведёшь, меняю значения минимума и максимума!");
        int temp = min;
        min = max;
        max = temp;
    }

    int[] a = CreateArray(n, min, max);      // точка а в n-мерном пространстве
    string list = string.Join(", ", a);
    Console.WriteLine($"Координаты первой точки:\n({list})");

    int[] b = CreateArray(n, min, max);      // точка b в n-мерном пространстве
    list = string.Join(", ", b);
    Console.WriteLine($"Координаты второй точки:\n({list})");

    Console.WriteLine($"Длина вектора = {VectorLength(a, b)}");

}

int[] CreateArray(int n, int min, int max) // создание массива размера n и заполнение целыми числами из диапазона min..max
{
    int[] arr = new int[n];
    for (int i = 0; i < n; i++) arr[i] = new Random().Next(min, max);
    return arr;
}

double VectorLength(int[] a, int[] b) // длина отрезка между двумя заданными точками в N-мерном пространстве
{
    int sum = 0;
    int length = a.Length;
    for (int i = 0; i < length; i++) sum += (a[i] - b[i]) * (a[i] - b[i]);
    return Math.Sqrt(sum);
}

void ExThree() // Exercise Three
{
    Console.WriteLine("Напишите программу, которая принимает "
                    + "на вход число (N) и выдаёт таблицу "  // всё-таки строку, а не таблицу, или однострочную (одностолбцовую) таблицу
                    + "кубов чисел от 1 до N.\n"
                    + "RED - Усложним и будем возводить в любую степень");
    Console.WriteLine();

    int n = 0;

    while (true)
    {
        Console.Write("Введите число, список степеней которого хотите получить: ");
        n = InputChecker();

        if (n < 1) Console.WriteLine("Так не получится... Число должно быть больше нуля");
        else if (n > 300)
        {
            Console.Write("Вывод слишком большого количества чисел может "
                            + "подгрузить систему. Повтори ввод числа, если "
                            + "ты уверен в своём решении: ");
            if (InputChecker() == n) break;
            else Console.WriteLine("Ха-ха, слабак!");
        }
        else break;
    }

    Console.Write("Введите число, обозначающее в какую степень хотите возвести: ");
    int p = InputChecker();

    string list = string.Join(" ", PowerList(n, p));
    Console.WriteLine(list);
}

double[] PowerList(int n, int pow) // возвращает массив степеней от 1 до n^pow
                                   // зачем мелочиться? в любую степень! 
{
    double[] arr = new double[n];
    for (int i = 1; i < n + 1; i++) arr[i - 1] = Math.Pow(Convert.ToDouble(i), Convert.ToDouble(pow));
    //думаю, можно было бы через цикл написать свою функцию, работающую только с int числами       
    return arr;
}

void ExFour() // Exercise Four
{
    Console.WriteLine("Напишите программу, которая считывает с консоли "
                    + "числа (по одному в строке) до тех пор, пока сумма "
                    + "введённых чисел не будет равна 0 и сразу после "
                    + "этого выводит сумму квадратов всех считанных чисел.\n"
                    + "Гарантируется, что в какой-то момент сумма введённых "
                    + "чисел окажется равной 0, после этого считывание "
                    + "продолжать не нужно.");
    Console.WriteLine();

    int sum = 0, squareSum = 0, currentNum = 0;

    Console.Write("Введите первое число для подсчёта суммы квадратов: ");
    while (true)
    {
        currentNum = InputChecker();
        sum += currentNum;
        squareSum += IntPower(currentNum, 2);

        if (sum == 0) break;

        Console.Write($"сумма чисел = {sum}, введите следующее число: ");
    }
    Console.WriteLine($"сумма введёных чисел достигла нуля\nСумма квадратов всех введёных чисел равна {squareSum}");
}

// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.WriteLine("Домашка третья");
bool flag = true;
int num = 4; // общее количество задач (планирую использовать эту обёртку и дальше, поэтому нужна универсальность)
             // однако всё равно придётся ручками менять значение num и ветвление в функции ExInit()

while (flag) // бесконечный цикл, пока флаг = true. 
{
    Console.Write($"\nВведите или номер задачи (1..{num}) или 0 "
                    + "для выхода (для экстренного прерывания "
                    + "использовать сочетание клавиш ctrl+C): ");

    flag = ExInit(InputChecker(), num);

    if (!flag)
    {
        Console.WriteLine("---Good buy!---");
        break;
    }
}


