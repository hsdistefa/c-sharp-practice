using System;
using System.Data;
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
        WinChecker winChecker = new WinChecker();

        renderer.Render(board);
        while (!winChecker.Check(board)) {
            State currentPlayer = board.GetCurrentPlayer();
            Position pos;
            if (currentPlayer == State.X) {
                pos = playerX.GetPosition(board);
            }
            else {
                pos = playerO.GetPosition(board);
            }
            board.Place(currentPlayer, pos);
            renderer.Render(board);
            board.SwitchPlayer();
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

    public State CurrentPlayer = State.X;
    public State[,] boardstate = { 
        {State.Undecided, State.Undecided, State.Undecided}, 
        {State.Undecided, State.Undecided, State.Undecided},
        {State.Undecided, State.Undecided, State.Undecided} 
    };

    public void Place(State state, Position position) {
        this.boardstate[position.Row, position.Column] = state;
    }

    public State GetCurrentPlayer() {
        return this.CurrentPlayer;
    }
    public void SwitchPlayer() {
        if (this.CurrentPlayer == State.X) {
            this.CurrentPlayer = State.O;
        }
        else {
            this.CurrentPlayer = State.X;
        }
    }



}

public class Player {
    public Position GetPosition(Board currentBoard) {
        int row;
        int column;
        do {
            Console.WriteLine($"{currentBoard.GetCurrentPlayer()}'s turn:");
            Console.WriteLine("Enter a row (1-3):");
            row = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a column (1-3):");
            column = Convert.ToInt32(Console.ReadLine());
        } while (!IsValidPlacement(currentBoard, row, column));

        return new Position(row-1, column-1);
    }

    private bool IsValidPlacement(Board board, int row, int column) {
        if (row < 1 || row > board.nRows) {
            Console.WriteLine($"Invalid Row: {row}");
            return false;
        }
        else if (column < 1 || column > board.nCols) {
            Console.WriteLine($"Invalid Column: {column}");
            return false;
        }
        else if (board.boardstate[row-1, column-1] != State.Undecided) {
            Console.WriteLine($"Invalid Move: Cannot draw on an occupied square!");
            return false;
        }
        return true;
    }
}

public class WinChecker {
    public bool Check(Board board) {
        State player = board.GetCurrentPlayer();
        for (int i=0; i < board.nRows; i++) {
            if (RowWin(i, board)) {
                return true;
            }
            // Assumes square board
            else if (ColWin(i, board)) {
                return true;
            }
        }
        if (DiagWinULtoLR(board) || DiagWinURtoLL(board)) {
            return true;
        }

        if (IsDraw(board)) {
            return true;
        }

        return false;
    }
    public bool IsDraw(Board board) {
        for (int i=0; i < board.nRows; i++) {
            for (int j=0; j < board.nCols; j++) {
                if (board.boardstate[i, j] == State.Undecided) {
                    return false;
                }
            }
        }
        Console.WriteLine("Draw!");
        return true;
    }

    private bool RowWin(int row, Board board) {
        State currState = board.boardstate[row, 0];
        if (currState == State.Undecided) {
            return false;
        }
        for (int j=1; j < board.nCols; j++) {
            if (board.boardstate[row, j] != currState) {
                return false;
            }
        }
        Console.WriteLine($"{currState} Wins!");
        return true;
    }

    private bool ColWin(int col, Board board) {
        State currState = board.boardstate[0, col];
        if (currState == State.Undecided) {
            return false;
        }
        for (int i=1; i < board.nCols; i++) {
            if (board.boardstate[i, col] != currState) {
                return false;
            }
        }
        Console.WriteLine($"{currState} Wins!");
        return true;
    }
    private bool DiagWinULtoLR(Board board) {
        State currState = board.boardstate[0, 0];
        if (currState == State.Undecided) {
            return false;
        }
        for (int i=0; i < board.nRows; i++) {
            if (board.boardstate[i, i] != currState) {
                return false;
            }    
        }
        Console.WriteLine($"{currState} Wins!");
        return true;
    }
    private bool DiagWinURtoLL(Board board) {
        State currState = board.boardstate[0, board.nCols - 1];
        if (currState == State.Undecided) {
            return false;
        }
        for (int i=board.nRows-1; i >= 0; i--) {
            Console.WriteLine(i);
            if (board.boardstate[board.nRows-i-1, i] != currState) {
                return false;
            }    
        }
        Console.WriteLine($"{currState} Wins!");
        return true;
    }
}

public class Renderer {
    public void Render(Board board) {
        for (int i=0; i < 3; i++) {
            for (int j=0; j < 3; j++) {
                string pieceStr;
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