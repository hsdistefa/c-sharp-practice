using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
class GlazerCalc
{
    enum Months { January=1, February=2, March=3, April=4, May=5, June=6, July=7, August=8, September=9, October=10, November=11, December=12 };
    static void Main(string[] args)
    {
        // Ch 8
        double pi = Math.PI;
        double r;
        double h;
        Console.WriteLine("Radius: "); 
        //r = Convert.ToDouble(Console.ReadLine());
        r = 2;
        Console.WriteLine("Height: ");
        //h = Convert.ToDouble(Console.ReadLine());
        h = 2;
        Console.WriteLine($"Volume: {Convert.ToString(pi * h * r*r)}");
        Console.WriteLine($"Surface Area: {Convert.ToString(2 * pi * r * (h + r))}");

        // Ch 9
        double a = 1.0 + 1 + 1.0f;
        Console.WriteLine(a); // 3.0
        int x = (int)(7 + 3.0/4.0 * 2);
        Console.WriteLine(x);  // 8
        Console.WriteLine((1 + 1)/2 * 3);  // 3
        
        // Ch 10
        double n1 = -1;
        double n2 = -11.2;
        if (n1 == 0 || n2 == 0)
            Console.WriteLine("Positive"); 
        else if (n1 < 0 && n2 > 0)
            Console.WriteLine("Negative"); 
        else if (n1 > 0 && n2 < 0)
            Console.WriteLine("Negative"); 
        else if (n1 < 0 && n2 < 0)
            Console.WriteLine("Positive"); 
        else if (n1 > 0 && n2 > 0)
            Console.WriteLine("Positive"); 

        // Ch. 12
        // Print-a-Pyramid
        int height = 5;
        for (int i=0; i < height; i++) {
            for (int s=i; s < height - 1; s++) {
                Console.Write(" ");
            }
            for (int j=i*2+1; j > 0; j--) {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        // FizzBuzz
        for (int i=1; i < 101; i++) {
            bool fizz = i % 3 ==0;
            bool buzz = i % 5 ==0;
            if (fizz && buzz) {
                Console.WriteLine("FizzBuzz");
            }
            else if (fizz) {
                Console.WriteLine("Fizz");
            }
            else if (buzz) {
                Console.WriteLine("Buzz");
            }
            else
                Console.WriteLine(i);
        }

        // Ch. 13
        // Copying an array
        int[] arr = new int[10] { 4, 51, -7, 13, -99, 15, -8, 45, 90, 0 };
        int[] copy = new int[arr.Length];
        for (int i=0; i < arr.Length; i++) {
            copy[i] = arr[i];
        }
        for (int i=0; i < arr.Length; i++) {
            Console.WriteLine($"Original: {arr[i]} Copy: {copy[i]}");
        }

        // Min and Avg w/ Foreach
        int min = int.MaxValue;
        double sum = 0.0;
        foreach (int val in arr) {
            if (val < min) {
                min = val;
            }
            sum += val;
        }
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Avg: {sum / arr.Length}");

        // Ch. 14
        // Enumerations
        Months month;
        int intresponse = 1;
        bool isValidResponse = false;
        while (!isValidResponse) {
            Console.WriteLine("Enter a number between 1 and 12");
            //intresponse = Convert.ToInt16(Console.ReadLine());
            intresponse = Convert.ToInt16(2);
            if (intresponse >= 1 && intresponse <= 12) {
                isValidResponse = true;
            }
        }
        month = (Months)intresponse;

        Console.WriteLine(month);

        // Ch. 15
        // Reversing an Array w/ Methods
        int[] numbers = GenerateNumbers(10);
        numbers = Reverse(numbers);
        PrintNumbers(numbers);

        // Fibonacci
        Console.WriteLine(Fibonacci(10));
        
    }
    static int[] GenerateNumbers(int n) {
        int[] arr = new int[n];
        for (int i=0; i < n; i++) {
            arr[i] = i+1;
        }
        return arr;
    }

    static int[] Reverse(int[] arr) {
        /// <summary>
        /// Takes an array of integers and reverses it
        /// </summary>
        /// <param name="arr"> The integer array to reverse</param>
        /// <returns>The reversed array</returns>
        int[] reversed = new int[arr.Length];
        for (int i=0; i < arr.Length; i++) {
            reversed[i] = arr[arr.Length - i - 1];
            Console.WriteLine(reversed[i]);
        }
        arr = reversed;
        PrintNumbers(arr);
        return arr;
    }

    static void PrintNumbers(int[] numbers) {
        for (int i=0; i < numbers.Length; i++) {
            Console.Write($"{numbers[i]} ");
        }
        Console.WriteLine();
    }

    static int Fibonacci(int n) {
        if (n == 1 || n == 2) {
            return 1;
        }

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}