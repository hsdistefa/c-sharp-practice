using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
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


        // Ch. 18
        // OOP Practice
        Color red = new Color(5, 28, 254);
        Console.WriteLine(red.GetGrayscale());
        Ball redBall = new Ball(1, red);
        Console.WriteLine($"Throws: {redBall.GetThrowCount()}");
        Console.WriteLine($"Size: {redBall.size}");
        redBall.Throw();
        Console.WriteLine($"Throws: {redBall.GetThrowCount()}");
        Console.WriteLine($"Size: {redBall.size}");
        redBall.Throw();
        redBall.Throw();
        Console.WriteLine($"Throws: {redBall.GetThrowCount()}");
        Console.WriteLine($"Size: {redBall.size}");
        redBall.Pop();
        Console.WriteLine($"Throws: {redBall.GetThrowCount()}");
        Console.WriteLine($"Size: {redBall.size}");

        // Quiz
        // 1. Classes ARE reference types
        // 2. CLASSES define what a particular type of thing can do and store, while an INSTANCE is a specific object that contains its own set of data.
        // 3. 3 types of members that can be part of a class: Instance variables, methods, constructors
        // 4. If something is static, it IS shared by all instances of a particular type.
        // 5. A CONSTRUCTOR is a special type of method that sets up a new instance
        // 6. PRIVATE: can only be accessed within the class
        // 7. PUBLIC: can be accessed anywhere
        // 8. INTERNAL: can be accessed within the same project only

        // Ch. 20 Tic-Tac-Toe
        Player playerX = new Player();
        Player playerO = new Player();
        Board board = new Board();
        Renderer renderer = new Renderer();
        State CurrentPlayer = State.X;

        renderer.Render(board);
        int turn = 0;
        while (turn < 5) {

            if (CurrentPlayer == State.X) {
                CurrentPlayer = State.O;
            }
            else {
                CurrentPlayer = State.X;
            }

            Position pos = playerX.GetPosition(board);
            board.Place(CurrentPlayer, pos);
            renderer.Render(board);
            turn++;
        }


        
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
public class Color {
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha) {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    public Color(int red, int green, int blue) {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = 255;
    }

    public int[] GetRGBA() {
        int[] rgba = new int[4] {this.red, this.green, this.blue, this.alpha };
        return rgba;
    }

    public void SetRed(int r) {
        this.red = r;
    }

    public float GetGrayscale() {
        return (float)(this.red + this.green + this.blue) / 3;
    }
}

public class Ball {
    public int size;
    public Color color;
    private int throwCount;

    public Ball(int size, Color color) {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }
    public Ball(int size, Color color, int throwCount) {
        this.size = size;
        this.color = color;
        this.throwCount = throwCount;
    }

    public void Pop() {
        this.size = 0;
    }

    public void Throw() {
        this.throwCount++;
    }

    public int GetThrowCount() {
        return this.throwCount;
    }
}

public enum State { Undecided, X, O };

public class Position {
    public int Row {get;}
    public int Column {get;}

    public Position(int Row, int Column) {
        this.Row = Row;
        this.Column = Column;
    }
}
public class Board {
    public int nRows = 3;
    public int nCols = 3;
    public State[,] boardstate = { 
        {State.Undecided, State.Undecided, State.Undecided}, 
        {State.Undecided, State.Undecided, State.Undecided},
        {State.Undecided, State.Undecided, State.Undecided} 
    };

    public void Place(State state, Position position) {
        if (IsValidPlacement(state, position)) {
            this.boardstate[position.Row, position.Column] = state;
        }
    }

    private bool IsValidPlacement(State state, Position position) {
        return true;
    }


}

public class Player {
    public Position GetPosition(Board currentState) {
        int Row = -1;
        while (Row < 1 || Row > 3) {
            Console.WriteLine("Enter a row (1-3):");
            Row = Convert.ToInt32(Console.ReadLine());
        }
        int Column = -1;
        while (Column < 1 || Column > 3) {
            Console.WriteLine("Enter a column (1-3):");
            Column = Convert.ToInt32(Console.ReadLine());
        }

        return new Position(Row-1, Column-1);
    }
}

public class WinChecker {
    public State Check(Board currentState) {
        State state = State.O;
        return state;
    }
}

public class Renderer {
    public void Render(Board board) {
        for (int i=0; i < 3; i++) {
            for (int j=0; j < 3; j++) {
                String pieceStr;
                State cur = board.boardstate[i, j];
                if (cur == State.Undecided) {
                    pieceStr = " ";
                }
                else if (cur == State.X) {
                    pieceStr = "X";
                }
                else {
                    pieceStr = "O";
                }

                Console.Write($" {pieceStr} ");
                if (j < 2) {
                    Console.Write("|");
                }
            }
            if (i < 2) {
                Console.WriteLine("\n---+---+---");
            }
        }
        Console.WriteLine();
    }
}