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

int NaturalInputChecker (string userMessage, string exeptionMessage)
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

int[,] CreateRandomIntegerTable(int rows, int cols, int min, int max)
{
    if (max < min)  // проверка и защита
    {
        int temp = min;
        min = max;
        max = temp;
    }

    Random random = new Random();
    int[,] table = new int[rows, cols];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            table[i, j] = random.Next(min, max+1); // заполнение массива, не забывая, что справа плюс 1 к диапазону

    return table;
}

double[,] CreateRandomDoubleTable(int rows, int cols, double min, double max)
{
    if (max < min)  // проверка и защита
    {
        double temp = min;
        min = max;
        max = temp;
    }

    Random random = new Random();
    double[,] table = new double[rows, cols];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            table[i, j] = min + (max-min)*random.NextDouble(); // заполнение массива, не забывая, что справа плюс 1 к диапазону

    return table;
}

void PrintDoubleTable(double[,] table, int precision)
{
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.Write(Math.Round(table[i, j],precision) + "\t");
        }
        Console.WriteLine();
    }
}

void PrintIntTable(int[,] table)
{
    Console.WriteLine("________________________");
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.Write(table[i, j] + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine("________________________");
}

void ArrayMinMaxSort (int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPos = i;

        for (int j = i+1; j < array.Length; j++)
            if (array[j] < array[minPos]) minPos = j;
        
        int temp = array[i];
        array[i] = array [minPos];
        array[minPos] = temp;
    }
}

void UnfoldTableToArray (int [,] table, int [] array)
{
    int n = 0; 
   // int [] array = new int[table.GetLength(0) * table.GetLength(1)]; // по-хорошему надо для общего случая,
                                                                       // когда мы не знаем , что на вход подаётся, но пока так оставлю.
                                                                       // есть ощущение, что функции фолд и анфолд должны сами создавть
                                                                       // массивы, что бы в основной программе не было этих операций...
    for (int i = 0; i < table.GetLength(0); i++)
        for (int j = 0; j < table.GetLength(1); j++)
        {
            array [n] = table[i,j];
            n++;            
        }
    // return array;
}

void FoldArrayToTable (int [,] table, int [] array)
{
    int n = 0;
    for (int i = 0; i < table.GetLength(0); i++)
        for (int j = 0; j < table.GetLength(1); j++)
        {
            table[i,j] = array[n];
            n++;            
        }
    // return table;
}

void TableMaxMinSort (int[,] table)
{
    int rows = table.GetLength(0), 
        cols = table.GetLength(1); 

    for (int m = 0; m < table.GetLength(0) * table.GetLength(1); m++) // все операции повторяем столько раз, сколько элементов в массиве 
                                                                      // наверное, можно сократить в два раза, если одновременно отсеивать
                                                                      // и минимальный и максимальный элемент в разные углы матрицы
    {
        int minPosI = 0, // позиции элемента, которые будем запоминать
            minPosJ = 0;

        for (int i = 0; i < rows; i++)  // теперь пробегаемся по массиву в поисках позиции элемента с минимальным значением
        {
            for (int j = 0; j < cols; j++) 
            {
                 if (table[i,j] < table[minPosI,minPosJ])
                {
                    minPosI = i;
                    minPosJ = j;
                } 
            }
        }
       
        int temp = table[rows-1,cols-1];  // свапаем последний элемент таблицы с минимальным, не забывая, что отсчёт массива начинается с нуля
        table[rows-1,cols-1] = table [minPosI,minPosJ];
        table[minPosI,minPosJ] = temp;

        cols-=1; // убираем крайний правый элемент в строчке. В случае, если это был последний, тогда убираем нижнюю строчку
        if (cols == 0)
        {
            cols = table.GetLength(1);
            rows -= 1;
        }
    }

       

        
}

// ЗАДАЧИ

void ExOne()
{    
    int rows = 0, cols = 0, precision = 0;
    string exeptionMessage = "Только натуральные числа!";

    Console.WriteLine("Задайте размерность массива.");
    rows = NaturalInputChecker("Укажите кол-во строк: " , exeptionMessage);
    cols = NaturalInputChecker("Укажите кол-во столбцов: " , exeptionMessage);
    
    Console.WriteLine("Укажите диапазон вещестенных значений элементов массива");
    Console.Write("Минимальное значение: ");
    double min = InputDoubleChecker();
    Console.Write("Максимальное значение: ");
    double max = InputDoubleChecker();

    precision = NaturalInputChecker("Укажите необходимую точность вывода: " , exeptionMessage);

    double[,] matrix = CreateRandomDoubleTable(rows, cols, min, max); // создаём массив и выводим его на экран
    PrintDoubleTable(matrix,precision);
}

void ExTwo()
{
    string exeptionMessage = "Только натуральные числа!";
    int[,] matrix = CreateRandomIntegerTable(10,8,0,99);   
    PrintIntTable(matrix);
   
    int rowNumber = NaturalInputChecker("Укажите номер строки: " , exeptionMessage);
    int colNumer = NaturalInputChecker("Укажите номер столбца: " , exeptionMessage);

    if (rowNumber > matrix.GetLength(0) || colNumer > matrix.GetLength(1)) Console.WriteLine("Out of boundaries");
    else Console.WriteLine("Значение элемента таблице на указанной позиции равно " + matrix[rowNumber,colNumer]);
}

void ExThree()
{
    int[,] matrix = CreateRandomIntegerTable(3,8,0,99);
    PrintIntTable(matrix);
    int sum = 0;

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            sum+=matrix[i,j];            
        Console.Write(Math.Round((double)sum/matrix.GetLength(0), 2) + "\t");
    }
    Console.WriteLine();
}

void ExFour() // сортировка
{
    int rows = 0, cols = 0;
    string exeptionMessage = "Только натуральные числа!";

    Console.WriteLine("Задайте размерность массива.");
    rows = NaturalInputChecker("Укажите кол-во строк: " , exeptionMessage);
    cols = NaturalInputChecker("Укажите кол-во столбцов: " , exeptionMessage);

    Console.WriteLine("Укажите диапазон значений элементов массива");
    Console.Write("Минимальное значение: ");
    int min = InputChecker(exeptionMessage);
    Console.Write("Максимальное значение: ");
    int max = InputChecker(exeptionMessage);

    int[,] matrix = CreateRandomIntegerTable(rows, cols, min, max);
    int[,] matrix2 = matrix;   // копию матрицы для проверки пары предположений, так то не нужно
    Console.Write("Созданная таблица:");
    PrintIntTable(matrix);

    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch(); // проверим заодно , какой способ быстрее

    stopwatch.Start();
    int [] array = new int[matrix.GetLength(0) * matrix.GetLength(1)];
    UnfoldTableToArray(matrix, array);
    ArrayMinMaxSort(array);
    FoldArrayToTable(matrix, array);
    stopwatch.Stop();

    Console.WriteLine($"\nТаблица, отсортированая через разворот в одномерный массив. Время выполнения {stopwatch.ElapsedTicks} тиков");
    PrintIntTable(matrix);

    stopwatch.Restart();
    TableMaxMinSort(matrix2);
    stopwatch.Stop();

    Console.WriteLine($"\nТаблица, отсортированая незнаю-как-это-может-называться способом. Время выполнения {stopwatch.ElapsedTicks} тиков");
    PrintIntTable(matrix2);

}

// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.Clear();
Console.WriteLine("\n    --- Домашка шестая ---");
bool flag = true;
string exeptionMessage = "Нужно ввести номер задачи цифрами или '0' для выхода (ctrl+c для экстренного прерывания): ";

string[] exerciseList = {
                            "1 задача: Задайте двумерный массив размером mxn, заполненный случайными вещественными числами.",
                            "2 задача: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.",
                            "3 задача: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.",
                            "4 задача HARD: Задайте двумерный массив из целых чисел. Количество строк и столбцов задается с клавиатуры. Отсортировать элементы по возрастанию слева направо и сверху вниз."
                        };

foreach (string text in exerciseList) Console.WriteLine(text);

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