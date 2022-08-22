// Задача 2: Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.

// a = 5; b = 7 -> max = 7
// a = 2 b = 10 -> max = 10
// a = -9 b = -3 -> max = -3

int a=0,b=0,c=0,max=0,min=0;

Console.WriteLine("\n___EXERCISE I___\n");

Console.Write("input first number: ");
a = Convert.ToInt32(Console.ReadLine());
Console.Write("input second number: ");
b = Convert.ToInt32(Console.ReadLine());

max = a;
min = b;
if (a<b) {max = b; min = a;}
Console.WriteLine("\nmax = " + max + ", min = " + min + "\n");


// // Задача 4: Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.

// // 2, 3, 7 -> 7
// // 44 5 78 -> 78
// // 22 3 9 -> 22

Console.WriteLine("\n___EXERCISE II___\n");

Console.Write("input first number: ");
a = Convert.ToInt32(Console.ReadLine());
Console.Write("input second number: ");
b = Convert.ToInt32(Console.ReadLine());
Console.Write("input third number: ");
c = Convert.ToInt32(Console.ReadLine());

max = a;
if (b>max) {max = b;}
if (c>max) {max = c;}
Console.WriteLine("\nmax = " + max + "\n");

// // Задача 6: Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).

// // 4 -> да
// // -3 -> нет
// // 7 -> нет

Console.WriteLine("\n___EXERCISE III___\n");

Console.Write("input number to check: ");
a = Convert.ToInt32(Console.ReadLine());
if (a % 2 == 0) {
    Console.WriteLine("yep, dis even");
}
else {
    Console.WriteLine("nope, dis odd");
}

// // Задача 8: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.

// // 5 -> 2, 4
// 8 -> 2, 4, 6, 8

Console.WriteLine("\n___EXERCISE IV___\n");

Console.Write("input positive number: ");
a = Convert.ToInt32(Console.ReadLine());

for (int i = 2; i <= a; i +=2) Console.Write(i + " ");