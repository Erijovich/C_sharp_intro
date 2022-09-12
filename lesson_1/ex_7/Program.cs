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

void FillFunnyArray(int[,] table)
{
    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            table[i, j] = i+j;
        }
    }
}
// первый пример

/* int[,] table = new int[7, 4];
FillArray(table);
PrintArray(table); */ 

/* Задача 48: Задайте двумерный массив размера m на n, каждый элемент в
массиве находится по формуле: Aₘₙ = m+n. Выведите полученный массив на экран.
m = 3, n = 4.
0 1 2 3
1 2 3 4
2 3 4 5 */

// первая задача

/* int[,] table = new int[7, 4];
FillFunnyArray(table);
PrintArray(table); */ 

// вторая задача
/* 
 void ArrayMinMaxSort (int[] array)
 {
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPos = i;

        for (int j = i+1; j < array.Length; j++)
            if (array[j] < array[minPos]) minPos=j;
        
        int temp = array[i];
        array[i] = array [minPos];
        array[minPos] = temp;
    }
 }

int[,] table = new int[7, 4];
FillArray(table);
PrintArray(table);  */

/* Timur Islamgulov: Задача 49: Задайте двумерный массив. 
Найдите элементы, у которых оба индекса нечётные, и 
замените эти элементы на их квадраты.
Например, изначально массив
выглядел вот так:
1 4 7 2
5 9 2 3
8 4 2 4
Timur Islamgulov: Новый массив будет выглядеть
вот так:
1 4 7 2
5 81 2 9
8 4 2 4 

Задача 51: Задайте двумерный массив. Найдите сумму элементов,
находящихся на главной диагонали (с индексами (0,0); (1;1) и т.д.

*/

int [,] ArraySwaper (int[,] table)
{
    for (int i = 1; i < table.GetLength(0); i+=2)
    {
        for (int j = 1; j < table.GetLength(1); j+=2)
        {
            table[i,j]*=table[i,j];                        
        }
        
    }
    return table;
}



int[,] table = new int[10, 10];
FillArray(table);
Console.WriteLine("Изначальный массив:");
PrintArray(table);
Console.WriteLine("Массив с квадраами на нечётных позициях:");
ArraySwaper(table);
PrintArray(table);


int min = table.GetLength(0), sum = 0;
if (min > table.GetLength(1)) min = table.GetLength(1);

for (int i = 0; i < min ; i++) sum+= table[i,i];

Console.WriteLine($"Сумма элементов на главной диагонали: {sum}");