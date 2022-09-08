void PrintArray (int[] arr)
{
    string list = string.Join(", ", arr);
    Console.WriteLine($"Массив:\n[{list}]"); 
}

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
    return InputChecker();  
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

// Console.Write("Введите размерность массива: ");
// int n = InputChecker();

// int [] numbers = new int[n];
// for(int i = 0; i < n; i++)
// {
//     numbers[i] = new Random().Next(0,100);
//     if (i!=n-1)  Console.Write($"{numbers[i]}, ");
//     else Console.WriteLine($"{numbers[i]}");
// }
// Console.WriteLine();

// int buf;

// for (int i = 0; i < n/2; i++)
// {
//     buf = numbers[i];
//     numbers[i] = numbers[n-1-i];
//     numbers[n-1-i] = buf;
    
// }

// PrintArray(numbers);


/* Напишите программу, которая принимает на вход три числа и проверяет, может ли существовать треугольник с сторонами такой длины.
Теорема о неравенстве треугольника: каждая сторона треугольника меньше суммы двух других сторон.

Задача 42: Напишите программу, которая будет преобразовывать десятичное число в двоичное.
45 -> 101101
3  -> 11
2  -> 10 */

/* Console.WriteLine("Напишите программу, которая принимает на вход три числа и проверяет, может ли существовать треугольник с сторонами такой длины."
                +" Теорема о неравенстве треугольника: каждая сторона треугольника меньше суммы двух других сторон.");
bool TriChecker (int a, int b, int c)
{
    if (a+b>c && b+c>a && c+a>b) return true;
    else return false;
}

Console.Write("Введите сторону: ");
int a = InputChecker();
Console.Write("Введите сторону: ");
int b = InputChecker();
Console.Write("Введите сторону: ");
int c = InputChecker();

if (TriChecker(a,b,c)) Console.WriteLine("да, треугло");
else Console.WriteLine("нет, не треугло");


Console.Write("Введите десятичное число: ");
int d = InputChecker(), dv = 0;

*/
/*  //чужое
int[] RandomArray(int size, int minValue, int maxValue) {
    int[] result = new int[size];
    for (int i = 0; i < size; ++i) {
        result[i] = new Random().Next(minValue, maxValue);
    }
    return result;
} 
 */

/* //чужое
 void PrintArray(int[] array) {
    for(int i = 0; i < array.Length - 1; ++i) {
        Console.Write($"{array[i]}, ");
    }
    Console.WriteLine(array[array.Length - 1]);
} */

void Reverse(int[] array) {
    for (int i = 0; i < array.Length / 2; ++i) {
        int temp = array[i];
        array[i] = array[array.Length - 1 -i];
        array[array.Length - 1 -i] = temp;
    }
}
/*  //чужое
void Task1() {
    int[] arr = RandomArray(6, 1, 100);
    PrintArray(arr);
    Reverse(arr);
    PrintArray(arr);
}

bool IsTrianglePossible(int a, int b, int c) {
    return (a < b + c && b < a + c && c < a + b);
} */
/* 
void Task40() {
    Console.Write("Введите первую сторону треугольника: ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите вторую сторону треугольника: ");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите третью сторону треугольника: ");
    int c = Convert.ToInt32(Console.ReadLine());
    Console.Write($"{a}, {b}, {c} - треугольник ");
    if (!IsTrianglePossible(a, b, c)) {
        Console.Write("не ");
    }
    Console.WriteLine("возможен.");
}

int ConvertToBinary(int number) {
    int result = 0;
    int order = 1;                      // Переменная для перехода на следующую цифру числа в двоичной записи
    while (number > 0) {                
        result += (number % 2) * order; // Записываем в результирующую переменную следующую цифру 
                                        // (Каждая цифра двоичной записи - остаток от деления на 2,
                                        // умножение на order позволяет записать следующую цифру отдельно,
                                        // вместо того, чтобы прибавлять к первому числу)
        order *= 10;
        number /= 2;
    }
    return result;
}



void Task42() {
    Console.Write("Введите число: ");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"{x} -> {ConvertToBinary(x)}");
}

//Task40();
Task42();
 */


/* Console.WriteLine("Введите число");
int a = Convert.ToInt32(Console.ReadLine());
int c = 0;
string b = String.Empty;
while (a >= 1)
{
    c = a%2;
    b = b+Convert.ToString(c);
    a = a/2;
}
char [] b2 = b.ToCharArray();
Array.Reverse(b2);
Console.WriteLine(b2);
 */

/* 
 Задача 44: Не используя рекурсию, выведите первые N чисел Фибоначчи. 
 Первые два числа Фибоначчи: 0 и 1.
Если N = 5 -> 0 1 1 2 3
Если N = 3 -> 0 1 1
Если N = 7 -> 0 1 1 2 3 5 8
 Задача 45: Напишите программу, которая будет создавать копию 
 заданного массива с помощью поэлементного копирования. */




Console.Write("Введите количество чисел, необходимых для вывода: ");
int n = InputChecker();
int a = 0, b =1, c =0;

if (n==0) Console.Write(a);
else if (n == 1) Console.Write(a + " " + b);
else 
{
    Console.Write(a + " " + b + " ");
    for (int i = 2; i < n; i++)
    {
        c = a+b;
        Console.Write(c + " ");
        a =b;
        b =c;
    }
}
Console.WriteLine();

/* 
Console.Write("Введите количество чисел, необходимых для вывода: ");
int m = Convert.ToInt32(Console.ReadLine());
int x = 0, y =1, z =0;

if (n==0) Console.Write(a);
else if (n == 1) Console.Write(a + " " + b);
else 
{
    Console.Write(a + " " + b + " ");
    for (int i = 2; i < n; i++)
    {
        c = a+b;
        Console.Write(c + " ");
        a =b;
        b =c;
    }
} */



    while (true) // защита от ввода отрицательной размерности массива
    {
        Console.Write("Задайте размерность массива: ");
        n = InputChecker();
        if (n < 0) Console.WriteLine("Так не получится... размерность массива должна быть натуральным числом... ");
        else break;
    }
    Console.Write("Введите диапазон значений элементов массива\nМинимальное значение: ");
    int min = InputChecker();
    Console.Write("Максимальное значение: ");
    int max = InputChecker();
    int[] x = CreateArray(n, min, max); // создаём массив и выводим его на экран
    string list = string.Join(", ", x);    
    Console.WriteLine($"Созданный массив:\n[{list}]"); 

    int[] y = CreateArray(n, 0, 0); 

    for (int i = 0; i < x.Length; i++) y[i] = x[i];

    list = string.Join(", ", y);    
    Console.WriteLine($"Созданный массив:\n[{list}]"); 

