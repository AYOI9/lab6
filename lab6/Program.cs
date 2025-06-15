using System;

class Program
{
    // Объявляем делегат для функции подсчета цифр
    delegate int DigitCountDelegate(int number);

    static void Main()
    {
        // Создаем массив натуральных чисел
        int[] numbers = { 123, 4567, 89, 1011, 5, 27, 987654 };

        Console.WriteLine("Исходные числа:");
        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine("\n");

        // Используем анонимный метод для подсчета цифр
        DigitCountDelegate anonymousMethod = delegate (int n)
        {
            return n.ToString().Length;
        };

        // Используем лямбда-выражение для той же задачи
        DigitCountDelegate lambdaExpression = n => n.ToString().Length;

        // Демонстрация работы всех подходов
        Console.WriteLine("Подсчет цифр с помощью анонимного метода:");
        ProcessNumbers(numbers, anonymousMethod);

        Console.WriteLine("\nПодсчет цифр с помощью лямбда-выражения:");
        ProcessNumbers(numbers, lambdaExpression);

        Console.WriteLine("\nПодсчет цифр для числа 27:");
        Console.WriteLine($"Анонимный метод: {anonymousMethod(27)}");
        Console.WriteLine($"Лямбда-выражение: {lambdaExpression(27)}");

        // Дополнительный пример с Where и лямбдой
        Console.WriteLine("\nЧисла с более чем 2 цифрами:");
        foreach (var num in Array.FindAll(numbers, n => n.ToString().Length > 2))
        {
            Console.WriteLine($"{num} - {num.ToString().Length} цифр");
        }
    }

    // Метод для обработки массива чисел с использованием делегата
    static void ProcessNumbers(int[] numbers, DigitCountDelegate counter)
    {
        foreach (var num in numbers)
        {
            Console.WriteLine($"Число {num} содержит {counter(num)} цифр");
        }
    }
}