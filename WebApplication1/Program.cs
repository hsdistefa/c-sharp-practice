using System;
class GlazerCalc
{
    static void Main(string[] args)
    {
        // Ch 8
        double pi = Math.PI;
        double r;
        double h;
        Console.WriteLine("Radius: "); 
        r = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Height: ");
        h = Convert.ToDouble(Console.ReadLine());
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
    }
}