/* Задача 53: Задайте двумерный массив. Напишите программу,
 которая поменяет местами первую и последнюю строку массива.

Задача 55: Задайте двумерный массив. Напишите программу, 
которая заменяет строки на столбцы. В случае, если это
 невозможно, программа должна вывести сообщение для пользователя.
 */

void FillArray(int[,] table)
{
    Random random = new Random();
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            table[i, j] = random.Next(10);
        }
    }
}

void PrintArray(int[,] table)
{
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.Write(table[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

void ChangeFirstAndLastRows() // =)
{
    int rows = 4,
        cols = 4;
    int[,] table = new int[rows, cols];
    FillArray(table);
    PrintArray(table);

    int temp = 0;

    for (int i = 0; i < cols; i++)
    {
        temp = table[0, i];
        table[0, i] = table[rows - 1, i];
        table[rows - 1, i] = temp;
    }

    Console.WriteLine();

    PrintArray(table);
}

void SwapRowsAndColumns ()
{
    Console.Write("Введите кол-во строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите кол-во столбцов: ");
    int cols = Convert.ToInt32(Console.ReadLine());
    int[,] table = new int[rows, cols];

    FillArray(table);
    PrintArray(table);

    if (rows != cols) Console.WriteLine("Так не получится");
    else
    {
        int temp = 0;
        for (int i = 0; i < rows; i++)
            for (int j = i; j < cols; j++)
            {
                temp = table[i, j];
                table[i, j] = table[j, i];
                table[j, i] = temp;
            }
        Console.WriteLine("Первый разворот: ");
        PrintArray(table);

        int[,] newTable = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                newTable[i, j] = table[j, i];
            }
        Console.WriteLine("Второй разворот: ");
        PrintArray(newTable);
    }
}

// нам нужно сначала размерность создать , затем уже 


/*
составть частотоыный словарь элментов двумерного массива (сколько раз встречается элемент входных данных)
*/

void FrequencyDictionary ()
{
    Console.Write("Введите кол-во строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите кол-во столбцов: ");
    int cols = Convert.ToInt32(Console.ReadLine());
    int[,] table = new int[rows, cols];

    FillArray(table);
    PrintArray(table);

    int[] counters = new int [10];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            counters[table[i, j]]++;           

        for (int i = 0; i < counters.Length; i++)
            if (counters[i] != 0)
                Console.WriteLine($"количество {i} - {counters[i]}");
}  



/*
задайте двумернывй массив из целых чисел. програ удаляет строку и столбец на персечении которых наименший элемент массива
*/

void DeleteWeakLink ()
{
    Console.Write("Введите кол-во строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите кол-во столбцов: ");
    int cols = Convert.ToInt32(Console.ReadLine());
    int[,] table = new int[rows, cols];

    FillArray(table);
    PrintArray(table);

    int posI = 0,
        posJ = 0,
        min = table[0,0];

        
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            if (table[i,j] < min) //стопится на первом найденом минимуме, если они будут повторяться
            {
                min = table[i,j];
                posI = i;
                posJ =j;
            }

     int[,] newTable = new int[rows-1, cols-1];

     for (int i = 0; i < newTable.GetLength(0) ; i++)
        for (int j = 0; j < newTable.GetLength(1) ; j++)
        {
            if (i != posI || j != posJ) 
            {
                newTable[i,j] = table [i,j];
            }
        } 
    PrintArray(table);
}

FrequencyDictionary (); 
//DeleteWeakLink();



int[,] NewMatrix()
{
    Console.WriteLine("Введите количество строк");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов");
    int n = Convert.ToInt32(Console.ReadLine());

    int[,] matrix = new int[m, n];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(1, 10);
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    return (matrix);
}
/* 
int [] FrequencyDictionary(int[,] matrix)
{
    int[] array = new int[10];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[matrix[i, j]] += 1;
        }
    }
    return array;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > 0) 
        {
            Console.WriteLine($"Число {i} встречается {array[i]} раз");
        }
    }
    Console.WriteLine();
}

PrintArray(FrequencyDictionary(NewMatrix()));
 */