/* Задача 10: Напишите программу, которая принимает на вход 
трёхзначное число и на выходе показывает вторую цифру этого числа.
456 -> 5
782 -> 8
918 -> 1 */

// int ExOne (int num) {return num;}
// Console.WriteLine(ExOne(Convert.ToInt32(Console.ReadLine()))); //протестил, сработает ли такой вызов

void ExOne(int num)
{
    if (num >= 100)
    {
        if (num < 1000)
        {
            Console.WriteLine($"Second digit of your number is {(num / 10) % 10}");
        }
    }
    else
    {
        Console.WriteLine("Invalid number! Ima to lazy to write whole checking condition, so will return to main menu ");
    }

}

/* Задача 13: Напишите программу, которая выводит третью 
цифру заданного числа или сообщает, что третьей цифры нет.
645 -> 5
78 -> третьей цифры нет
32679 -> 6  */

void ExTwo(int num, int pos)
{

    if (num < 0) num *= -1; // избавляемся от минуса, если будет

    int count = 0; // вспомогательнгый счётчик для общего количества знаков

    for (int i = 1; i <= num; i *= 10) count++;
    if (count < 3) { Console.WriteLine($"Your number have less than {pos} digits. Will return to main menu now"); return; }
    Console.WriteLine($"Total number of digits is {count}");

    for (int i = 0; i < (count - pos); i++) num /= 10;
    Console.WriteLine($"Digit on third position of your number is {num % 10}");
}

/* Задача 15: Напишите программу, которая принимает 
на вход цифру, обозначающую день недели, и проверяет,
является ли этот день выходным.
6 -> да
7 -> да
1 -> нет */

void ExThree (int num)
{
    for (int i = 1 ; i <= 5 ; i++) {
        if (i == num) {
            Console.WriteLine ("nope, itsa workday");
            return;
        }
    }

    for (int i = 6 ; i <= 7 ; i++) {
        if (i == num) {
            Console.WriteLine ("yep, itsa weekend day");
            return;
        }
    }

    Console.WriteLine("Invalid number! No such day. Will go back to menu now.");
}

/* задача необязательная.
"В институте биоинформатики по офису передвигается робот. 
Недавно студенты из группы программистов написали для него программу,
по которой робот, когда заходит в комнату, считает количество
программистов в ней и произносит его вслух: "n программистов".
Для того, чтобы это звучало правильно, для каждого n нужно
использовать верное окончание слова.
Напишите программу, считывающую с пользовательского ввода целое
число n (неотрицательное), выводящее это число в консоль вместе
с правильным образом изменённым словом "программист", для того,
чтобы робот мог нормально общаться с людьми,
например: 1 программист, 2 программиста, 5 программистов.
В комнате может быть очень много программистов.
Проверьте, что ваша программа правильно обработает
все случаи, как минимум до 1000 человек." */

void ExFour (int num)
{
    if (num<0) {
        Console.WriteLine("В комнате только гумманитарии..");
        return;
    }

    //по сути для определения правильного окончания нас интересует только последние две цифры числа. По крайней мере на бумажке у меня так получилось. Значит
    
    int n = num%100;
    
    // Console.WriteLine(num%100); //код для проверки предположения
    // ExFour(Convert.ToInt32(Console.ReadLine()));

    // дальше замечаем, что можно проверку разбить на два этапа, сначала по левому знаку, затем по правому
    // целочисленным делением на 10 получаем левый знак

    string ending = ""; // это будем посылать в функцию для установки окончания

    if (n/10 == 1) 
    {
        ExFourOutput(num, "ов"); // для всех чисел где во втором справа разряде стоит 1 только такой вариант окончания
    }

    else  // в этом ветвлении проверяем крайний правый разряд
    {
       if (n%10 == 1) ExFourOutput(num, "");
       else if (n%10 >=2 && n%10 <=4) ExFourOutput(num, "а");
       else ExFourOutput(num, "ов");
    }
    return;
}

void ExFourOutput(int n,string ending) {Console.WriteLine($"В комнате {n} программист" + ending);}


// ГЛАВНЫЙ КОД НАЧИНАЕТСЯ ЗДЕСЬ

Console.Write("The solution of four exercises is presented here. Select number (1..4): ");
int a = 0;
while (true)
{
    a = Convert.ToInt32(Console.ReadLine()); //работает только с вводом цифр
    Console.WriteLine();

    /* if (a == 0)
    {
        Console.WriteLine("---Good buy!---");
        break;
    } */ 
    // думаю , что выход должен быть по любой клавише, так безопаснее, вдруг ноль не работает или пользователь читать написанное не хочет

    //else if (a == 1)
    if (a == 1)
    {
        Console.WriteLine("---Exercise One---");
        Console.WriteLine("Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.\n");
        Console.Write("Please, insert 3-digit number: ");
        ExOne(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("---End of Exercise---\n");
    }

    else if (a == 2)
    {
        Console.WriteLine("---Exercise Two---");
        Console.WriteLine("Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.\n");
        Console.Write("Please, insert any-digit number: ");
        ExTwo(Convert.ToInt32(Console.ReadLine()), 3);
        Console.WriteLine("---End of Exercise---\n");

    }

    else if (a == 3)
    {
        Console.WriteLine("---Exercise Three---");
        Console.WriteLine("Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.\n");
        Console.Write("Please, insert any number you'd like to check for beeing a weekday number: ");
        ExThree(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("---End of Exercise---\n");

    }

    else if (a == 4)
    {
        Console.WriteLine("---Exercise Four---");
        Console.WriteLine("Напишите программу, считывающую с пользовательского ввода целое число n (неотрицательное), выводящее это число в консоль вместе с правильным образом изменённым словом 'программист'.\n");
        Console.Write("Please, number of coders: ");
        ExFour(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("---End of Exercise---\n");

    }

    else
    {
        // Console.Write("Invalid number! Choose from 1 to 4. Or choose 0 to exit: ");
        Console.Write("Cuz you didn't choose from 1 to 4 this program will end now.\n---Good buy!---");
        break;
    }

    //Console.Write("If you'd like to continue checking on exercises, choose a number from 1 to 4. Or choose 0 to exit: ");
    Console.Write("If you'd like to continue checking on exercises, choose a number from 1 to 4. Or press any other key to exit: ");
}






