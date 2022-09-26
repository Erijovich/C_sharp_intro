﻿// ЭТО СЕРВИСНЫЕ ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
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
        Console.WriteLine($"{exerciseNumber} задача: {exerciseText[exerciseNumber - 1]} ");
        switch (exerciseNumber)
        {
            case 1: { ExOne(); break; }
            case 2: { ExTwo(); break; }
            case 3: { ExThree(); break; }
            case 4: { ExFour(); break; }
            case 5: { ExFive(); break; }
            case 6: { ExSix(); break; }
            case 7: { ExSeven(); break; }
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

int[,] InputAndCreateRandomIntegerTable ()
{
    int rows = 0, cols = 0;
    string exeptionMessage = "Только натуральные числа!";

    Console.WriteLine("   Задайте размерность матрицы.");
    rows = NaturalInputChecker("Укажите кол-во строк: " , exeptionMessage);
    cols = NaturalInputChecker("Укажите кол-во столбцов: " , exeptionMessage);

    Console.WriteLine("   Укажите диапазон значений элементов матрицы.");
    Console.Write("Минимальное значение: ");
    int min = InputChecker(exeptionMessage);
    Console.Write("Максимальное значение: ");
    int max = InputChecker(exeptionMessage);

    return CreateRandomIntegerTable(rows, cols, min, max);
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

int Rows (int[,] table) => table.GetLength(0); // не плодите лишних сущностей, хехе...
int Cols (int[,] table) => table.GetLength(1); // .... но так намного читабельнее для меня...


void FillIntUnikRandom()
{

}


// ЗАДАЧИ

void ExOne() // Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
{    
    int[,] table = CreateRandomIntegerTable(7,5,0,99);
    int[] tempArray = new int [table.GetLength(1)]; // будем использовать решение по сортировке одномерного массива, написанное ранее
                                                    // создаём массив длиной в строку заданной таблицы
    Console.WriteLine("Созданная матрица:"); 
    PrintIntTable(table);

    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
            tempArray[j] = table[i,j];

        ArrayMinMaxSort(tempArray);

        for (int j = 0; j < table.GetLength(1); j++)
            table[i,j] = tempArray[tempArray.Length-j-1];
    }

    Console.WriteLine("Отсортированная построчно по убыванию матрица:"); 
    PrintIntTable(table);
}

void ExTwo() // Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
{    
    int[,] table = CreateRandomIntegerTable(9,5,0,10);
    // int[] tempArray = new int [table.GetLength(0)]; // думал сначала создать строку со всеми суммами, но, в общем то, зачем лишние действия..
    int currentSum = 0,
        minSum = 0,
        minSumRowPos = 0;
                                                     

    Console.WriteLine("Созданная матрица:"); 
    PrintIntTable(table);

    for (int j = 0; j < table.GetLength(1); j++)  // сначала объявляем первую строку строкой с минимальной суммой
            minSum += table[0,j]; 

    for (int i = 1; i < table.GetLength(0); i++) // счётчик начнём с 1 , т.к. 0ую строку мы уже и так прошли
    {
        for (int j = 0; j < table.GetLength(1); j++)
            currentSum += table[i,j];

        if (currentSum < minSum) // сравниваем сумую текущей строки с минимальной суммой, в случае успеха объявляем
        {                        // новую минимальную сумму и позицию строки с этой суммой 
            minSum = currentSum;
            minSumRowPos = i;
        }
        currentSum = 0; // не забываем обновить подсчёт суммы
    }
    Console.WriteLine($"В {minSumRowPos} строке сумма элементов минимальна и равна {minSum}"); 
}

void ExThree()  // Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
{
    int[,] tableOne = CreateRandomIntegerTable(2,3,-2,2); 
    int[,] tableTwo = CreateRandomIntegerTable(2,2,-2,2); // маленькие значения легче проверять
    // int[,] tableOne = InputAndCreateRandomIntegerTable(); // слишком долго вбивать значения
    // int[,] tableTwo = InputAndCreateRandomIntegerTable();
    int[,] tableMulti = new int [Rows(tableOne), Cols(tableTwo)];

    Console.WriteLine("Первая матрица:"); 
    PrintIntTable(tableOne);
    Console.WriteLine("Вторая матрица:"); 
    PrintIntTable(tableTwo);

    // не нравятся гетленги тут, тяжело смотрится...
    if (Cols(tableOne) != Rows(tableTwo)) Console.WriteLine ("Произведение двух матриц АВ имеет смысл только в том случае, "
                                                           + "когда число столбцов матрицы А совпадает с числом строк матрицы В ");
    else
    {        
        for (int i = 0; i < Rows(tableMulti); i++)
            for (int j = 0; j < Cols(tableMulti); j++)
            {
                tableMulti[i,j] = 0;
                for (int k = 0; k < Cols(tableOne); k++)
                    tableMulti[i,j] += tableOne[i,k] * tableTwo[k,j];                 
            }
        Console.WriteLine("Произведение матриц:"); 
        PrintIntTable(tableMulti); 
    }
}

void ExFour() // Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
{
    
    int rows = 0, cols = 0, layer = 0;
    bool flag = true;
    string exeptionMessage = "Только натуральные числа!";

    while (flag)
    {
        Console.WriteLine("Задайте размерность кубического массива.");
        rows = NaturalInputChecker("Укажите кол-во строк: " , exeptionMessage);
        cols = NaturalInputChecker("Укажите кол-во столбцов: " , exeptionMessage);
        layer = NaturalInputChecker("Укажите кол-во слоёв: " , exeptionMessage);
        if (rows*cols*layer < 150) flag = false;
        else
        {
            Console.WriteLine("Вы уверены? Количество выводимых на экран элементов для " 
                            + $"такого массива будет равно {rows*cols*layer} штук, "
                            + "займёт много места и времени на выполнение"); 
            Console.Write("1 - продолжть, другое число - повторить ввод: ");
            if (InputChecker("Введите 1, что бы продолжть или другое число, что бы повторить ввод:") == 1) flag = false;
        }
    }

    Console.WriteLine("Укажите диапазон значений элементов кубического массива");
    int min = 0, max = 0;
    flag = true;
    while (flag)
    {    
        Console.Write("Минимальное значение: ");
        min = InputChecker(exeptionMessage);
        Console.Write("Максимальное значение: ");
        max = InputChecker(exeptionMessage);
        if (max-min >= rows*cols*layer) flag = false;
        else Console.WriteLine("В введённом диапазоне не достаточно чисел для заполнения всего массива, попробуй снова:");
    }

    Console.WriteLine("\nЭлементы массива:");

    int [,,] cube = new int[rows,cols,layer];
    var listOfUniqueNumbers = new List<int>(); // попробуем множества
    int item = 0;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            for (int k = 0; k < layer; k++)
            {
                do
                {
                    item = new Random().Next(min, max);
                } while (listOfUniqueNumbers.IndexOf(item) > -1);
                listOfUniqueNumbers.Add(item);
                cube[i, j, k] = item;                
            }
    
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            for (int k = 0; k < layer; k++)
                Console.Write($"{cube[i, j, k]} ({i}, {j}, {k})\t");
        Console.WriteLine();
        }
    }
        
    Console.WriteLine();


}

void ExFive() // Напишите программу, которая заполнит спирально массив 4 на 4.
{
    int rows = 0, cols = 0;
    string exeptionMessage = "Только натуральные числа!";

    Console.WriteLine("Задайте размерность матрицы.");
    rows = NaturalInputChecker("Укажите кол-во строк: " , exeptionMessage);
    cols = NaturalInputChecker("Укажите кол-во столбцов: " , exeptionMessage);
    int[,] table = new int[rows,cols];


    int power = rows*cols; // мощность таблицы
    int direction = 1, // 1 - направо, 2 - вниз, 3 - налево, 4 - вверх
        currentRow = 0,
        currentCol = 0;

   

    int i = 1;
    while (i <= rows*cols)
    {
        switch (direction)
        {
            case 1: 
            {
                if (currentCol < Cols(table) & table[currentRow,currentCol] == 0) 
                    {
                        table[currentRow,currentCol] = i;
                        i++;
                        if (currentCol < Cols(table)-1) currentCol++;
                        else { currentRow++; direction++;}                        
                    }
            
                else direction++;
                PrintIntTable(table);
                Console.WriteLine($"currentCol = {currentCol}, currentRow = {currentRow}, direction = {direction}");
                break;
            }
            case 2:
            {
                if (currentRow < Rows(table) & table[currentRow,currentCol] == 0) 
                {
                    table[currentRow,currentCol] = i;
                    i++;
                    if (currentRow < Rows(table)-1) currentRow++;
                    else { currentCol--; direction++;}
                }
                else direction++;
                PrintIntTable(table);
                Console.WriteLine($"currentCol = {currentCol}, currentRow = {currentRow}, direction = {direction}");
                break;

            }
            case 3:
            {
                if (currentCol >= 0 & table[currentRow,currentCol] == 0) 
                {
                    table[currentRow,currentCol] = i;
                    i++;
                    if (currentCol > 0) currentCol--;
                    else { currentRow--; direction++;}  
                }
                else direction++;
                PrintIntTable(table);
                Console.WriteLine($"currentCol = {currentCol}, currentRow = {currentRow}, direction = {direction}");
                break;

            }
            case 4:
            {
                if (currentRow >= 0 & table[currentRow,currentCol] == 0) 
                {
                    table[currentRow,currentCol] = i;
                    i++;
                    if (currentRow > 0) currentRow--;
                    else { currentCol++; direction++;}
                }
                else direction++;
                PrintIntTable(table);
                Console.WriteLine($"currentCol = {currentCol}, currentRow = {currentRow}, direction = {direction}");
                break;

            }
            default:
            {
                direction = 1;
                break;
            }
          

        }
       
    }

    
        PrintIntTable(table);
    

 

}

void ExSix() // Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры).
             // Вывести на экран красивенько таблицей. Перемешать случайным образом элементы массива,
             // причем чтобы каждый гарантированно переместился на другое место (возможно для этого
             // удобно будет использование множества) и выполнить это за m*n / 2 итераций. То есть
             // если массив три на четыре, то надо выполнить не более 6 итераций. И далее в конце
             // опять вывести на экран как таблицу.",
{

}
void ExSeven() // Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
               // При этом пользователь не задает сколько чисел он введет (то есть число M), а подсчет количества
               // чисел производится после того, как пользователь не ввел информацию и нажал Enter."
{

}

// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.Clear();
Console.WriteLine("\n    --- Домашка восьмая ---");
bool flag = true;
string exeptionMessage = "Нужно ввести номер задачи цифрами или '0' для выхода (ctrl+c для экстренного прерывания): ";

string[] exerciseList = {
                            "Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.",
                            "Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.",
                            "Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.",
                            "Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.",
                            "Напишите программу, которая заполнит спирально массив 4 на 4.",
                            "(прошлое дз HARD) Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры). Вывести на экран красивенько таблицей. Перемешать случайным образом элементы массива, причем чтобы каждый гарантированно переместился на другое место (возможно для этого удобно будет использование множества) и выполнить это за m*n / 2 итераций. То есть если массив три на четыре, то надо выполнить не более 6 итераций. И далее в конце опять вывести на экран как таблицу.",
                            "(прошлое дз, попробовать Split()) Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь. При этом пользователь не задает сколько чисел он введет (то есть число M), а подсчет количества чисел производится после того, как пользователь не ввел информацию и нажал Enter."
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