/* Задача 32: Напишите программу замена элементов массива:
положительные элементы замените на соответствующие отрицательные, и наоборот.
[-4, -8, 8, 2] -> [4, 8, -8, -2] 
Задача 33: Задайте массив. Напишите программу, которая определяет, 
присутствует ли заданное число в массиве.
4; массив [6, 7, 19, 345, 3] -> нет
-3; массив [6, 7, 19, 345, 3] -> да
 */

/* Задайте одномерный массив из 15 случайных чисел. 
Найдите количество элементов массива, 
значения которых лежат в отрезке [10,99]. 
Пример для массива из 5, а не 123 элементов. 
В своём решении сделайте для 123
[5, 18, 123, 6, 2] -> 1
[1, 2, 3, 6, 2] -> 0
[10, 11, 12, 13, 14] -> 5

Задача 37: Найдите произведение пар чисел 
в одномерном массиве. Парой считаем первый 
и последний элемент, второй и предпоследний 
и т.д. Результат запишите в новом массиве.
[1 2 3 4 5] -> 5 8 3
[6 7 3 6] -> 36 21
 */

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

void ExOne ()
{
    int sumP = 0;
    int sumN = 0;

    int[] a = CreateArray(8, -10, 10);
    string list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");

    foreach (int item in a)
    {
        if (item > 0 ) sumP+= item;
        else sumN += item;

        
    }

    Console.WriteLine ($"сумма позитива: {sumP}, сумма неегатива: {sumN}");
}

void ExTwo ()
{
    int[] a = CreateArray(8, 10, 0);
    string list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");

    for (int i = 0; i < a.Length; i++) a[i]*=-1;
    
    list = string.Join(", ", a);
    Console.WriteLine($"изменённый массив:\n[{list}]");

}
/* 
void ExThree()
{
    int[] a = CreateArray(4, 0, 1000);
    string list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");

  /*   int count = 0;

    for (int i = 0; i< a.Length; i++) 
        if (a[i] >= 10 && a[i] < 100) count++;

    Console.WriteLine($"количество элементов в диапазоне 10..99: {count}");
 */
/* 
    int e = a.Length;
    int j = a.Length;
    if (j % 2 == 0) 
    {
        j /= 2;
        int[] b = CreateArray(j, 0, 0);
        list = string.Join(", ", b);
        Console.WriteLine($"Созданный массив:\n[{list}]\nj = {j}, e = {e}");
        for (int i = 0; i < j; i++) 
        {
            
            b[i] = a[i]*a[e-i];
            Console.WriteLine($"a[i] {a[i]}   a[e-i] {a[e-i]}    b[i] {b[i]}");
            
        }
    }

    else 
    {
        j = (j + 1) / 2;
        int[] b = CreateArray(j, 0, 0);
        list = string.Join(", ", b);
        Console.WriteLine($"Созданный массив:\n[{list}]\nj = {j}, e = {e}");
        for (int i = 0; i < j-1; i++) 
        {
            
            b[i] = a[i]*a[e-i];
            Console.WriteLine($"a[i] {a[i]}   a[e-i] {a[e-i]}    b[i] {b[i]}");
            
        }
    }
    
   
    
    list = string.Join(", ", a);
    Console.WriteLine($"Созданный массив:\n[{list}]");

 } */

//  ExOne();
 ExTwo();
//ExThree();