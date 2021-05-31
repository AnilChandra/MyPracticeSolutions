using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DP
{
    class DP
    {

        public int DPLongestPlaindrome(char[] str, int[,] matrix)
        {

            for (int i = 0; i < str.Length; i++)
            {
                matrix[i, i] = 1;
            }


            int A = 0;
            int B = 0;

            for (int k = 1; k < str.Length; k++)
            {
                for (A = 0; A < str.Length; A++)
                {
                    B = A + k;

                    if (B >= str.Length)
                        break;

                    if (str[A] == str[B])
                    {
                        matrix[A, B] = matrix[A + 1, B - 1] + 2;
                    }
                    else
                    {
                        matrix[A, B] = Math.Max(matrix[A, B - 1], matrix[A + 1, B]);
                    }

                }
            }
            return matrix[A - 1, B - 1];

        }
        public int LongestPalinodromicSubSequence(char[] str, int[,] matrix)
        {

            if (str.Length == 0) // null character
                return -1;

            if (str.Length == 1 || str.Length == 2) // length is 2 chars so it should be true
                return 0;

            for (int i = 0; i < str.Length; i++)
            {
                matrix[i, i] = 1;
            }
            int column = 0;
            int row = 0;
            for (int i = 1; i < str.Length; i++)
            {
                for (row = 0; row < str.Length; row++)
                {
                    column = row + i;

                    if (column >= str.Length)
                        break;

                    if (str[row] == str[column])
                    {
                        matrix[row, column] = 2 + matrix[row + 1, column - 1];
                    }
                    else
                    {
                        matrix[row, column] = Math.Max(matrix[row, column - 1], matrix[row + 1, column]);
                    }
                }
            }

            return matrix[row - 1, column - 1];
        }
        // 3,4 , -1, 0, 6 , 2 ,3 : -1 , 0 , 2, 3 ( length is 4)
        public int LongIncrSubSeq(int[] A)
        {
            int[] T = new int[A.Length];

            for (int i = 0; i < T.Length; i++)
            {
                T[i] = 1;
            }

            for (int i = 0; i < A.Length - 1; i++)
            {
                int j = i + 1;
                i = 0;
                while (i < j)
                {
                    if (A[i] < A[j] && T[j] < T[i] + 1)
                    {
                        T[j] = T[i] + 1;
                    }
                    i++;
                }
                i--;

            }

            int max = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] > max)
                    max = T[i];

            }
            return max;

        }


        // 4,6,1,3,8,4,6 : 4,6,8
        public void MaxIncSumSubSeq(int[] A)
        {

            int[] T = new int[A.Length];
            int[] Indexes = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                T[i] = A[i];
            }

            for (int i = 0; i < A.Length; i++)
            {
                Indexes[i] = i;
            }

            for (int i = 0; i < A.Length - 1; i++)
            {
                int j = i + 1;
                i = 0;
                while (i < j)
                {
                    if (A[j] > A[i])
                    {
                        if (T[j] < T[i] + A[j])
                        {
                            T[j] = T[i] + A[j];
                            Indexes[j] = i;
                        }
                    }
                    i++;
                }
                i--;
            }

            //check this code to get the series i.e. 4,6, 8 ??
            int max = 0; int MaxIndex = 0; int Fvalue = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] > max)
                {
                    max = T[i];
                    MaxIndex = i;
                    Fvalue = Indexes[i];
                }

            }


        }

        public void LongestCommonSubstr(char[] str1, char[] str2)
        {
            int[,] T = new int[str2.Length + 1, str1.Length + 1];
            int max = 0;

            for (int i = 0; i < str2.Length - 1; i++)
            {
                for (int j = 0; j < str1.Length - 1; j++)
                {
                    if (str2[i] == str1[j])
                    {
                        T[i, j] = T[i - 1, j - 1] + 1;
                        if (max < T[i, j])
                        {
                            max = T[i, j];
                        }

                    }
                }

            }
            Console.WriteLine(max);
            Console.ReadLine();

        }

        public int LongestCommonSubSequence(char[] str1, char[] str2)
        {
            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 0; row < str1.Length; row++)
            {
                for (int column = 0; column < str2.Length; column++)
                {
                    matrix[row, column] = 0;
                }
            }
            int rows = 1;
            int columns = 1;
            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {

                    if (str1[i] == str2[j])
                    {
                        matrix[rows, columns] = 1 + matrix[rows - 1, columns - 1];
                    }
                    else
                    {
                        matrix[rows, columns] = Math.Max(matrix[rows - 1, columns], matrix[rows, columns - 1]);
                    }
                    columns++;
                }
                columns = 1;
                rows++;
            }

            return matrix[str1.Length, str2.Length];

        }

        public void LongestIncreasingSubSequence(int[] arr)
        {
            int[] matrix = new int[arr.Length];


            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = 1;
            }
            int j = 1;
            while (j < arr.Length)
            {
                for (int i = 0; i < j; i++)
                {
                    if (arr[j] > arr[i])
                    {
                        if (matrix[j] <= matrix[i])
                        {
                            matrix[j] = matrix[j] + 1;
                        }
                    }

                }
                j++;
            }

            int max = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (max < matrix[i])
                {
                    max = matrix[i];
                }
            }
            Console.WriteLine("Max Longest sub-seq is : " + max);
            Console.ReadLine();

        }

        public void LongestCommonSubString(char[] str1, char[] str2)
        {
            if (str1.Length == 0 || str2.Length == 0)
                return;

            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    matrix[i, j] = 0;
                }

            }

            int row = 1;
            int column = 1;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        matrix[row, column] = 1 + matrix[row - 1, column - 1];
                    }
                    else
                    {
                        // This is not needed as the problem is longest common sub-string not sub-sequence
                        matrix[row, column] = Math.Max(matrix[row, column - 1], matrix[row - 1, column]);
                    }
                    column++;
                }
                column = 1;
                row++;
            }

            int max = 0;
            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (max < matrix[i, j])
                        max = matrix[i, j];
                }

            }
            Console.WriteLine("Max common substring is : " + max);
            Console.ReadLine();
        }

        public void MinimumEditDistanceBwTwoStrings(char[] str1, char[] str2)
        {
            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];
            int count = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                matrix[0, i] = count++;
            }
            count = 0;
            for (int i = 1; i <= str2.Length; i++)
            {
                matrix[i, 0] = count++;
            }
            int rows = 1;
            int columns = 1;
            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        matrix[rows, columns] = matrix[rows - 1, columns - 1];
                    }
                    else
                    {
                        matrix[rows, columns] = 1 + Math.Min(matrix[rows - 1, columns - 1], Math.Min(matrix[rows - 1, columns], matrix[rows, columns - 1]));
                    }
                    columns++;
                }
                rows++;
                columns = 1;
            }

            Console.Write("Minimum Edit Distance : " + matrix[str1.Length, str2.Length]);
            Console.ReadLine();
        }

        public void LongestIncreasingSubSequence1(int[] arr)
        {
            int[] matrix = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                matrix[i] = 1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        matrix[i] = 1 + Math.Max(matrix[i], matrix[j]);
                    }
                }
            }
            int max = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] > max)
                {
                    max = matrix[i];
                }
            }
            Console.Write("Max increasing sub-sequence is : " + max);
            Console.ReadLine();
        }

        public void BuyingAndSellingStockSingleTrans(int[] stockPrices)
        {
            int profit = 0;
            int minimumPrice = int.MaxValue;

            for (int i = 0; i < stockPrices.Length; i++)
            {
                profit = Math.Max(profit, stockPrices[i] - minimumPrice);
                minimumPrice = Math.Min(minimumPrice, stockPrices[i]);
            }
            Console.Write("Max profit is : " + profit);
            Console.ReadLine();
        }

        public void PermutationsOfString(char[] input, char[] result, int[] count, int level)
        {
            if (level == input.Length)
            {

                foreach (char ch in result)
                    Console.Write(ch);
                Console.WriteLine();
                return;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (count[i] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result[level] = input[i];
                        count[i]--;
                        PermutationsOfString(input, result, count, level + 1);
                        count[i]++;
                    }
                }
            }

        }

        //static int[] pathRows = {0,0,1,1,-1,1,-1,-1 };
        //static int[] pathColumns = {1,-1,-1, 1,1,0,0,-1};
        static int[] pathRows = { 0, 0, 0, 1, 1, 1, -1, 2, 2 };
        static int[] pathColumns = { 0, -1, 1, 0, -1, 1, 0, 0, 1 };

        static bool IsValid(int rowNew, int colNew, bool[,] visited)
        {
            if ((rowNew >= 0) && (colNew >= 0) && (colNew < 3) && (rowNew < 3) && (!visited[rowNew, colNew]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Boggle(char[,] board, bool[,] visited, int row, int column, string word, List<string> englishDictionary)
        {
            //Console.WriteLine(word);
            if (englishDictionary.Contains(word))
            {
                Console.Write(word);
                Console.WriteLine();
            }
            if (board.Length == word.Length)
            {
                return;
            }
            for (int i = 0; i < pathColumns.Length; i++)
            {
                int rowNew = row + pathRows[i];
                int columnNew = column + pathColumns[i];
                if (IsValid(rowNew, columnNew, visited))
                {
                    visited[rowNew, columnNew] = true;
                    Boggle(board, visited, rowNew, columnNew, word + board[rowNew, columnNew], englishDictionary);
                    visited[rowNew, columnNew] = false;
                }

            }
        }

        static int[] rows = { -1, -1, -1, 0, 0, 1, 1, 1 };
        static int[] cols = { -1, 0, 1, -1, 1, -1, 0, 1 };

        static bool IsValidate(int row, int col)
        {
            if (row >= 0 && col >= 0 && row < 3 && col < 3)
                return true;
            else
                return false;
        }

        public int TicTacToe(int player, int row, int col, int[,] board)
        {


            if (row < 0 || col < 0 || row > 3 || col > 3)
                return -1;

            if (player != 1 || player != 2)
                return -1;

            board[row, col] = player == 1 ? 1 : 2;

            //check for row
            bool win = true;
            for (int i = 0; i <= 2; i++)
            {
                //if (IsValidate(row, i))


                if (board[row, i] != player)
                {
                    win = false;
                    break;
                }
            }
            if (win)
            {
                return player == 1 ? 1 : 2;
            }
            win = true;

            //check for col
            for (int i = 0; i <= 2; i++)
            {
                if (board[i, row] != player)
                {
                    win = false;
                    break;
                }
            }
            if (win)
            {
                return player == 1 ? 1 : 2;
            }

            //check for diagonal
            if (row == col)
            {
                win = true;
                for (int i = 0; i <= 2; i++)
                {
                    if (board[i, i] != player)
                    {
                        win = false;
                        break;
                    }
                }
            }
            if (win)
            {
                return player == 1 ? 1 : 2;
            }

            //check for reverse diagonal
            if (row == 2 - 1 - col)
            {
                win = true;
                for (int i = 0; i <= 2; i++)
                {
                    if (board[i, col - 1] != player)
                    {
                        win = false;
                        break;
                    }
                }
                if (win)
                {
                    return player == 1 ? 1 : 2;
                }
            }
            return -1;


        }

        static int[] ratRows = { -1, 0, 0, 1 };
        static int[] ratColumns = { 0, -1, 1, 0 };

        static bool IsValidMaze(int[,] visited, int[,] maze, int newRatRow, int newRatColumn)
        {
            if ((newRatRow < 4) && (newRatRow >= 0) && (newRatColumn < 4) && (newRatColumn >= 0) && (visited[newRatRow, newRatColumn] == 0) && maze[newRatRow, newRatColumn] == 1)
            {
                return true;
            }
            return false;
        }

        public void RatInMaze(int[,] maze, int[,] visited, int row, int column, int finalRow, int finalColumn, int move)
        {
            if (row == finalRow && column == finalColumn)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(visited[i, j] + ",");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("******************");
            }
            else
            {
                for (int i = 0; i < ratRows.Length; i++)
                {
                    int newRatRow = row + ratRows[i];
                    int newRatColumn = column + ratColumns[i];
                    if (IsValidMaze(visited, maze, newRatRow, newRatColumn))
                    {
                        move++;
                        visited[newRatRow, newRatColumn] = move;
                        RatInMaze(maze, visited, newRatRow, newRatColumn, finalColumn, finalColumn, move);
                        move--;
                        visited[newRatRow, newRatColumn] = 0;
                    }

                }

            }

        }

        static int[] knightRows = { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] knightColumns = { 1, 2, 2, 1, -1, -2, -2, -1 };
        static bool IsVisitedByKnight(int row, int column, int[,] visited)
        {

            if ((row < 8) && (row >= 0) && (column < 8) && (column >= 0) && (visited[row, column] == 0))
            {
                return true;
            }

            return false;
        }

        public bool FindKnightTour(int[,] visited, int row, int col, int move)
        {
            if (move == 64)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write($"{visited[i, j]}, ");
                    }
                    Console.WriteLine();
                }
                return true;
            }
            else
            {
                for (int index = 0; index < knightRows.Length; index++)
                {
                    int rowNew = row + knightRows[index];
                    int colNew = col + knightColumns[index];
                    if (IsVisitedByKnight(rowNew, colNew, visited))
                    {
                        move++;
                        visited[rowNew, colNew] = move;
                        if (FindKnightTour(visited, rowNew, colNew, move))
                        {
                            return true;
                        }
                        move--;
                        visited[rowNew, colNew] = 0;
                    }
                }
            }
            return false;
        }

        public void NextGreatestElement(int[] arr)
        {

            Stack<int> collection = new Stack<int>();
            collection.Push(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < collection.Peek())
                {
                    collection.Push(arr[i]);
                }
                else if (arr[i] > collection.Peek())
                {
                    // Need to check , this is not working
                    foreach (int value in collection)
                    {
                        if (arr[i] > collection.Peek())
                        {

                            int pop = collection.Pop();
                            Console.Write(pop + " -" + arr[i]);
                        }
                        Console.WriteLine();
                    }
                    collection.Push(arr[i]);
                }
            }
        }

        public bool NQueen(bool[,] board, int size, int row)
        {
            if (row == size - 1)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(board[i, j] + " ");
                    }
                }
                return true;
            }
            else
            {
                for (int col = 0; col < size; col++)
                {
                    int rowNew = row + 1;
                    if (isSafe(board, rowNew, col, size))
                    {
                        board[rowNew, col] = true;
                        if (NQueen(board, size, rowNew))
                        {
                            return true;
                        }
                        board[rowNew, col] = false;
                    }
                }
                return false;

            }

        }

        static bool isSafe(bool[,] board, int row, int col, int size)
        {
            bool valid = true;

            for (int i = 0; i < size; i++)
            {
                if (board[i, col])
                {
                    valid = false;
                }
            }

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j])
                {
                    valid = false;
                }
            }
            for (int i = row, j = col; i >= 0 && j < size; i--, j++)
            {
                if (board[i, j])
                {
                    valid = false;
                }
            }


            return valid;
        }



        static bool isItSafe(int row, int column, bool[,] matrix)
        {
            if ((row >= 0) && (row < matrix.GetLength(0)) && (column >= 0) && (column < matrix.GetLength(1)) && (matrix[row, column] == false))
            {
                return true;
            }
            else return false;
        }

        public void MyBoggle(char[,] board, bool[,] matrix, string word, int row, int column, List<string> dictionary)
        {
            Console.WriteLine(word);
            if (dictionary.Contains(word))
            {
                //Console.WriteLine(word);
            }
            if (word.Length == board.Length)
            {
                return;
            }
            else
            {
                for (int i = 0; i < pathRows.Length; i++)
                {
                    int newRow = row + pathRows[i];
                    int newColumn = column + pathColumns[i];
                    if (isItSafe(newRow, newColumn, matrix))
                    {
                        matrix[newRow, newColumn] = true;
                        MyBoggle(board, matrix, word + board[newRow, newColumn], newRow, newColumn, dictionary);
                        matrix[newRow, newColumn] = false;
                    }

                }

            }

        }

        public void GenerateParenthesis(int leftParethesis, int rightParenthesis, string parentString, List<string> result)
        {

            if (leftParethesis == 0 && rightParenthesis == 0)
            {
                result.Add(parentString);
                Console.WriteLine(parentString);
                Console.WriteLine();
                return;
            }

            if (leftParethesis > 0)
            {
                GenerateParenthesis(leftParethesis - 1, rightParenthesis, parentString + "(", result);
            }

            if (leftParethesis < rightParenthesis)
            {
                GenerateParenthesis(leftParethesis, rightParenthesis - 1, parentString + ")", result);
            }
        }


        public void Brackets(int open, int close, string output, int pairs)
        {
            if (open == pairs && close == pairs)
            {
                Console.WriteLine(output);

            }
            else
            {
                if (open < pairs)
                {
                    Brackets(open + 1, close, output + "(", pairs);
                }
                if (close < open)
                {
                    Brackets(open, close + 1, output + ")", pairs);

                }

            }
        }

        public bool isSudokuSafe(int row, int col, int[,] board, int value)
        {
            for (int column = 0; column < board.GetLength(0); column++)
            {
                if (board[row, column] == value)
                    return false;
            }
            for (int rows = 0; rows < board.GetLength(0); rows++)
            {
                if (board[rows, col] == value)
                    return false;
            }
            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int rowStart = row - row % sqrt;
            int colStart = col - col % sqrt;

            for (int i = rowStart; i < rowStart + sqrt; i++)
            {
                for (int j = colStart; j < colStart + sqrt; j++)
                {
                    if (board[i, j] == value)
                        return false;
                }
            }

            return true;
        }

        public bool SolveSudoku(int[,] board, int n)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        // we still have some remaining 
                        // missing values in Sudoku 
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }

            // no empty space left 
            if (isEmpty)
            {
                return true;
            }

            // else for each-row backtrack 
            for (int num = 1; num <= board.GetLength(0); num++)
            {
                if (isSudokuSafe(row, col, board, num))
                {
                    board[row, col] = num;
                    if (SolveSudoku(board, n))
                    {
                        // print(board, n); 
                        return true;
                    }
                    else
                    {
                        board[row, col] = 0; // replace it 
                    }
                }
            }
            return false;
        }

        public void ZeroOneKnapSack(int[] weights, int[] profits, int totalWeight)
        {
            int[,] matrix = new int[weights.Length + 1, totalWeight + 1];
            int rows = 0;

            for (int i = 1; i <= weights.Length; i++)
            {
                for (int j = 1; j <= totalWeight; j++)
                {
                    if (j < weights[rows])
                    {
                        matrix[i, j] = matrix[i - 1, j];

                    }
                    else
                    {
                        matrix[i, j] = Math.Max(
                        matrix[i - 1, j], (matrix[i - 1, j - weights[rows]] + profits[rows]));
                    }
                }
                rows++;
            }

            int row = weights.Length;
            int cols = totalWeight;
            int bottomValue = matrix[row, cols];
            List<int> myList = new List<int>();
            int remainingProfit = 0;
            while (bottomValue == matrix[row, cols])
            {
                row--;
            }
            myList.Add(weights[row++]);
            remainingProfit = matrix[row, cols] - profits[--row];
            row = row + 1;
            while (remainingProfit != matrix[row, cols])
            {
                cols--;
            }
            row = row - 1;
            while (remainingProfit == matrix[row, cols])
            {
                row--;
            }
            myList.Add(weights[row]);
            remainingProfit = matrix[++row, cols] - profits[--row];

            if (remainingProfit == 0)
                return;

        }

        public int maxHistogram(int[] input)
        {
            Stack<int> collection = new Stack<int>();
            int maxArea = 0; int area = 0; int i;
            List<int> areas = new List<int>();
            for (i = 0; i < input.Length;)
            {
                if (collection.Count == 0 || input[collection.Peek()] <= input[i])
                {
                    collection.Push(i++);

                }
                else
                {
                    int top = collection.Pop();
                    if (collection.Count == 0)
                    {
                        area = input[top] * i;
                        areas.Add(area);
                    }
                    else
                    {
                        area = input[top] * (i - collection.Peek() - 1);
                        areas.Add(area);
                    }
                    if (area > maxArea)
                        maxArea = area;
                }
            }
            while (collection.Count != 0)
            {
                int top = collection.Pop();
                if (collection.Count == 0)
                {
                    area = input[top] * i;
                    areas.Add(area);
                }
                else
                {
                    area = input[top] * (i - collection.Peek() - 1);
                    areas.Add(area);
                }
                if (area > maxArea)
                    maxArea = area;
            }

            return maxArea;
        }
        //DP : Top-Down approach
        public int EggDropping(int eggs, int floors)
        {
            int[,] matrix = new int[eggs + 1, floors + 1];
            int c = 0;

            // considering there is only 1 egg and n floors
            //Minimum number of attempts will be the number of floors
            for (int i = 0; i <= floors; i++)
            {
                matrix[1, i] = i;
            }

            //as the first row in top-down is already filled with the above loop
            //start next loop starting with 2 eggs considering rows: eggs & columns: floors
            for (int e = 2; e <= eggs; e++)
            {
                for (int f = 1; f <= floors; f++)
                {
                    // if number of floors are less than number of eggs
                    if (f < e)
                    {
                        matrix[e, f] = matrix[e - 1, f];
                        continue;
                    }
                    matrix[e, f] = int.MaxValue;
                    for (int k = 1; k <= f; k++)
                    {
                        c = 1 + Math.Max(matrix[e - 1, k - 1], matrix[e, f - k]);
                        if (c < matrix[e, f])
                        {
                            matrix[e, f] = c;
                        }
                    }

                }
            }

            return matrix[eggs, floors];
        }

        static int[] eggdrop = new int[20];
        public int EggDroppingRecursion(int eggs, int floors, int[,] cache)
        {

            if (floors == 0 || floors == 1)
            {
                return floors;
            }

            if (eggs == 1)
            {
                return floors;
            }
            if (cache[eggs, floors] != int.MaxValue)
            {
                return cache[eggs, floors];
            }

            //int min = 1000;
            for (int i = 1; i <= floors; i++)
            {
                int trials = 1 + Math.Max(EggDroppingRecursion(eggs - 1, i - 1, cache), EggDroppingRecursion(eggs, floors - i, cache));
                cache[eggs, floors] = Math.Min(cache[eggs, floors], trials);
                //if (trials < min)
                //{
                //    min = trials;
                //}
            }

            //return min;
            return cache[eggs, floors];
        }

        public int CoinChange(int[] coins, int curCoin, int Value, int[] dp)
        {

            if (Value == 0) return 1;

            if (Value < 0) return 0;

            if (dp[Value] != 0)
                return dp[Value];


            for (int coin = curCoin; coin < coins.Length; coin++)
            {
                dp[Value] = dp[Value] + CoinChange(coins, coin, Value - coins[coin], dp);

            }

            return dp[Value];
        }

        public int CoinChangex(int[] coins, int curCoin, int Value, int[] dp)
        {

            if (Value == 0) return 1;

            if (Value < 0) return 0;

            int nCombos = 0;


            for (int coin = curCoin; coin < coins.Length; coin++)
            {
                nCombos += CoinChangex(coins, coin, Value - coins[coin], dp);

            }
            return nCombos;
        }

        public int FewestCoinsChange(int[] coins, int value, int[] dp)
        {
            dp[0] = 0;
            for (int i = 1; i <= value; i++)
            {
                dp[i] = int.MaxValue;
            }

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 1; j < dp.Length; j++)
                {
                    if (j - coins[i] >= 0)
                    {
                        if (dp[j - coins[i]] + 1 < dp[j])
                        {
                            dp[j] = 1 + (dp[j - coins[i]]);
                        }
                    }
                }
            }

            return dp[value];
        }

        public List<string> RestoreIpAddress(string s)
        {
            List<string> result = new List<string>();
            int lengthOfString = s.Length;
            for (int i = 1; i < lengthOfString && i < 4; ++i)
            {
                string first = s.Substring(0, i);
                if (!isValidIP(first))
                    continue;
                for (int j = 1; j < lengthOfString && j < 4; ++j)
                {
                    string second = s.Substring(i, i + j);
                    if (!isValidIP(second))
                        continue;
                    for (int k = 1; i + j + k < lengthOfString && k < 4; ++k)
                    {
                        string third = s.Substring(i + j, i + j + k);
                        string fourth = s.Substring(i + j + k);
                        if (!isValidIP(third) || !isValidIP(fourth))
                            continue;
                        result.Add(first + "." + second + "." + third + "." + fourth);
                    }
                }
            }
            return result;
        }

        static bool isValidIP(string s)
        {
            if (s.Length > 3)
                return false;
            if (s.StartsWith("0") && s.Length > 2)
                return false;
            int value = int.Parse(s);
            if (value < 0 && value > 255)
                return false;
            return true;
        }


        static char[] symbol = new char[7];
        public void PrintEquation(int Index, int[] arr)
        {

            for (int i = 1; i <= Index; i++)
            {
                Console.Write(arr[i - 1] + " " + symbol[i] + " ");
            }
        }
        public void MakeValidEquation(int[] arr, int secondIndexIncrementing, int lastElementOfArray, int result)
        {
            int temp = result;
            if (secondIndexIncrementing == lastElementOfArray)
            {
                if (result == 5)
                {
                    PrintEquation(secondIndexIncrementing, arr);
                }
                else return;
            }
            else
            {
                result = result + arr[secondIndexIncrementing];
                symbol[secondIndexIncrementing] = '+';
                MakeValidEquation(arr, secondIndexIncrementing + 1, lastElementOfArray, result);
                temp = temp - arr[secondIndexIncrementing];
                symbol[secondIndexIncrementing] = '-';
                MakeValidEquation(arr, secondIndexIncrementing + 1, lastElementOfArray, temp);
            }


        }
        public class obj
        {
            public int remainingWeight;
            public int remainingItems;
            public obj(int remainingWeight, int remainingItems)
            {
                this.remainingItems = remainingItems;
                this.remainingWeight = remainingWeight;
            }
        }

        public int TopDownRecursive(int [] values, int [] weights, int W)
        {
            Dictionary<obj, int> map = new Dictionary<obj, int>();
            return TopDownRecursiveUtil(values,weights,W,values.Length,0,map);
        }
        public int TopDownRecursiveUtil(int [] values, int[] weights, int remainingWeight, int totalItems, int currentItem, Dictionary<obj,int> map)
        {
            if (currentItem >= totalItems || remainingWeight <= 0)
            {
                return 0;
            }

            obj key = new obj(totalItems - currentItem - 1, remainingWeight);

            if (map.ContainsKey(key))
            {
                int val = map[key];
                return val;
            }
            int maxValue;

            if (remainingWeight < weights[currentItem])
            {
                maxValue = TopDownRecursiveUtil(values, weights, remainingWeight, totalItems, currentItem + 1, map);
            }
            else
            {
                maxValue = Math.Max(values[currentItem] + TopDownRecursiveUtil(values, weights, remainingWeight - weights[currentItem], totalItems, currentItem + 1, map),
                            TopDownRecursiveUtil(values,weights,remainingWeight,totalItems,currentItem+1,map));
            }

            map.Add(key,maxValue);
            return maxValue;
            
        }

        public int RecrsiveRodCutting(int [] price, int len)
        {
            if (len <= 0)
            {
                return 0;
            }
            int maxValue = 0;
            for (int i =0; i < len; i++)
            {
                int val = price[i] + RecrsiveRodCutting(price, len-i-1);
                if (maxValue < val)
                    maxValue = val;
            }
            return maxValue;
        }

        
        public int NwaysToScoreRrusnInBballs(int balls, int runs)
        {
            if (balls == 0 && runs == 0)
                return 1;
            if (balls == 0 && runs > 0)
                return 0;
            if (balls > 0 && runs == 0)
                return 1;
            if (runs < 0)
                return 0;

            int noOfPossinilities = 0;

            //noOfPossinilities += NwaysToScoreRrusnInBballs(balls - 1, runs) +
            //                        NwaysToScoreRrusnInBballs(balls - 1, runs - 1) +
            //                        NwaysToScoreRrusnInBballs(balls - 1, runs - 2) +
            //                        NwaysToScoreRrusnInBballs(balls - 1, runs - 3);


            noOfPossinilities = noOfPossinilities + NwaysToScoreRrusnInBballs(balls - 1, runs) +
                                    NwaysToScoreRrusnInBballs(balls - 1, runs - 1) + NwaysToScoreRrusnInBballs(balls - 1, runs - 2) +
                                    NwaysToScoreRrusnInBballs(balls - 1, runs - 3) + NwaysToScoreRrusnInBballs(balls - 1, runs - 4);

           return noOfPossinilities;
        
        }
        public int NwaysToScoreRrusnInBballsWithMemoization(int balls, int runs, int[,] mem)
        {
            if (balls == 0 && runs == 0)
                return 1;
            if (balls == 0 && runs > 0)
                return 0;
            if (balls > 0 && runs == 0)
                return 1;
            if (runs < 0)
                return 0;

            if (mem[balls, runs] != -1)
            {
                return mem[balls, runs];
            }

            mem[balls, runs] = NwaysToScoreRrusnInBballsWithMemoization(balls - 1, runs,mem) +
                               NwaysToScoreRrusnInBballsWithMemoization(balls - 1, runs - 1,mem) + NwaysToScoreRrusnInBballsWithMemoization(balls - 1, runs - 2,mem) +
                               NwaysToScoreRrusnInBballsWithMemoization(balls - 1, runs - 3,mem) + NwaysToScoreRrusnInBballsWithMemoization(balls - 1, runs - 4,mem);


            return mem[balls, runs];
     
        }

        public int MaxProfit(int index, int buySell, int [] prices, int [,] mem)
        {

            if (index >= prices.Length)
                return 0;

            if (mem[buySell,index] != -1)
            {
                return mem[buySell,index];
            }

            int profit = 0;
            if (buySell == 0)
            {
                int buy = MaxProfit(index+1, 1, prices,mem) - prices[index];
                int noBuy = MaxProfit(index+1,0, prices,mem);
                profit = Math.Max(buy,noBuy);
            }
            else
            {
                int sell = MaxProfit(index+2, 0, prices,mem) + prices[index];
                int noSell = MaxProfit(index+1,1,prices,mem);
                profit = Math.Max(sell,noSell);
            }
            return mem[buySell, index] = profit;
            //return profit;
        
        }

        public int minCostRec(int[,] cost, int s, int d)
        {
            // If source is same as destination 
            // or destination is next to source 
            if (s == d || s + 1 == d)
                return cost[s, d];

            // Initialize min cost as direct 
            // ticket from source 's' to  
            // destination 'd'. 
            int min = cost[s, d];

            // Try every intermediate vertex to 
            // find minimum 
            for (int i = s + 1; i < d; i++)
            {
                int c = minCostRec(cost, s, i) +
                           minCostRec(cost, i, d);

                if (c < min)
                    min = c;
            }

            return min;

        }

        public void MaxSumSubArrayOfGivenSize(int [] array, int size)
        {
            int sumOfFirstWindowOfSize=0;
           
            for (int i =0; i < size; i++)
            {
                sumOfFirstWindowOfSize += array[i];
            }
            int maxSum = sumOfFirstWindowOfSize;
            
            for (int i =1; i <= array.Length -3; i++)
            {

                sumOfFirstWindowOfSize = sumOfFirstWindowOfSize - array[i - 1] + array[i+size-1];
                if (sumOfFirstWindowOfSize > maxSum)
                    maxSum = sumOfFirstWindowOfSize;
            }
            Console.WriteLine("Sum of max Windows Sum :  " + maxSum);
            Console.ReadLine();
             
        }

        public int MincostTickets(int[] days, int[] costs, int i, int [] dp)
        {
            if (i >= days.Length) return 0;
            if (dp[i] > 0) return dp[i];
            int mindayCost = costs[0] + MincostTickets(days, costs, i+1,dp);

            int k = i;
            for (; k < days.Length; k++)
            {
                if (days[k] >= days[i] + 7)
                { break; }
            }
            int minWeekCost = costs[1] + MincostTickets(days, costs, k,dp);

            for (; k < days.Length; k++)
            {
                if (days[k] >= days[i] + 30)
                { break; }
            }
            int minMonthlyCost = costs[2] + MincostTickets(days, costs, k,dp);
            dp[i] = Math.Min(mindayCost, Math.Min(minWeekCost, minMonthlyCost));
            return dp[i];
            //return Math.Min(mindayCost, Math.Min(minWeekCost, minMonthlyCost));
        }

        
        public List<String> WordBreak(String S, int start, List<string> dictionary)
        {
            List<string> validSubstr = new List<string>();
            
            if (start == S.Length)
               validSubstr.Add("");
            for(int end = start+1; end <= S.Length; end++)
            {
                string prefix = S.Substring(start,end -start);
                if (dictionary.Contains(prefix))
                {
                    List<string> suffixes = WordBreak(S,end,dictionary);
                    foreach (string suffix in suffixes)
                    {
                        Console.WriteLine(prefix);
                        Console.WriteLine(" ");
                        Console.WriteLine(suffix);
                        validSubstr.Add(prefix + " " + suffix);
                       // validSubstr.Add(prefix + (suffix.Equals("") ? "" : " ") + suffix );
                        //if (suffix.Equals(""))
                        //{
                        //    validSubstr.Add(prefix + "" + suffix);
                        //}
                        //else
                        //{
                        //    validSubstr.Add(prefix + " " + suffix);
                        //}
                    }
                }
            }

            return validSubstr;
        }

        public int NumberOfSquares(int n)
        {
            if (n < 0) return int.MaxValue;
            if (n == 0) return 0;

            int min = n;

            for (int i =1; i * i <= n; i++)
            {
                
                min = Math.Min(NumberOfSquares(n-i*i),min);
                if (n == 12)
                {
                    Console.WriteLine(i + "  " + min);
                }
            }
            
            return min+1;
        }
        static void Main(string[] args)
        {
            DP dp = new DP();
             //string s = "pqrdrpd";
            //string s = "bcdb";
           // string s = "forgeeksskeegfor";

            //char[] MyArray = s.ToCharArray();
            //int [,] matrix = new int[s.Length,s.Length];
            ////int length = dp.DPLongestPlaindrome(MyArray, matrix);
            //int length = dp.LongestPalinodromicSubSequence(MyArray, matrix);
            //Console.WriteLine("Length of Longest Palindrome is :  " + length);
            //Console.Read();

            //string s1 = "abcd";
            //string s2 = "pqcde";

            //char[] str1 = s1.ToCharArray();
            //char[] str2 = s2.ToCharArray();

            //int length = dp.LongestCommonSubSequence(str1, str2);
            //Console.WriteLine("Length of Longest subseq is :  " + length);
            //Console.Read();

            // Longest Icreasing Sub-Sequence
            int[] A = { 3, 4, -1, 0, 6, 2, 3 };
            //int[] A = { 2,5,1,8,3};
            // dp.LongIncrSubSeq(A);
            //dp.LongestIncreasingSubSequence(A);
            //int[] A = { 4,6,1,3,8,4,6};
            // dp.MaxIncSumSubSeq(A);

            //Longest common substring in two strings
            //String strA = "bqdrcvefgh";
            //String strB = "abcvdefgh";

            //char[] str1 = strA.ToCharArray();
            //char[] str2 = strB.ToCharArray();

            //dp.LongestCommonSubstr(str1, str2);
            //string str1 = "bqdrcvefgh";
            //string str2 = "abcvdefgh";
            string str1 = "abcdef";
            string str2 = "azced";
            char[] a = str1.ToCharArray();
            char[] b = str2.ToCharArray();
            //dp.LongestCommonSubString(a, b);
            //dp.MinimumEditDistanceBwTwoStrings(a,b);
            //dp.LongestIncreasingSubSequence1(A);

            //int [] stockPrices = { 100, 180, 260, 310, 40, 535, 695 };
            //dp.BuyingAndSellingStockSingleTrans(stockPrices);


            //Recursion and Backtracking
            char[] input = { 'A', 'B', 'C' };
            char[] result = new char[input.Length];
            int[] count = { 1, 1, 1 };

            int level = 0;
            dp.PermutationsOfString(input, result, count, level);
            //Console.ReadLine();

            //char[,] board = { { 'G', 'I', 'Z' }, { 'U', 'E', 'K' }, { 'Q', 'S', 'E' } };
            ////char[,] board = { {'F','O','B'},
            ////                  {'O','A','E'},
            ////                  {'K','S','C' }};
            //bool[,] visited = { { false, false, false }, { false, false, false }, { false, false, false } };
            //string word = string.Empty;
            //List<string> englishDictionary = new List<string> { "GEEKS", "QUIZ", "FOR", "GO" };
            ////List<string> englishDictionary = new List<string> { "FACE", "BOOK", "ACE", "BOOKS", "ACES" };


            //for (int rows = 0; rows < 3; rows++)
            //{
            //    for (int columns = 0; columns < 3; columns++)
            //    {
            //        visited[rows, columns] = true;
            //        Boggle(board, visited, 0, 0, word + board[rows, columns], englishDictionary);


            //        visited[rows, columns] = false;
            //    }
            //}
            //Console.ReadLine();


            //int[] arr = {5,3,2,10,6,8,1,4,12,7,4};
            //dp.NextGreatestElement(arr);
            //Console.ReadLine();

            //int[,] maze = { {1,1,0,1 },
            //                {0,1,1,1 },
            //                {0,1,0,1 },
            //                {0,1,1,1 }};

            //int[,] visited = { {0,0,0,0},
            //                   {0,0,0,0},
            //                   {0,0,0,0},
            //                   {0,0,0,0}};

            //visited[0,0] = 1;

            //dp.RatInMaze(maze,visited,0,0,3,3,1);


            //int[,] visited = { {0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 },
            //{0,0,0,0,0,0,0,0 }};

            //visited[0, 0] = 1;
            //dp.FindKnightTour(visited,0,0,1);
            //Console.ReadLine();

            //bool[,] board = { { false,false,false,false},
            //                   { false,false,false,false},
            //                   { false,false,false,false},
            //                   { false,false,false,false}};

            //dp.NQueen(board, 4, -1);

            //char[,] table = { {'F','O','B'},
            //                  {'O','A','E'},
            //                  {'K','S','C' }};


            //bool[,] matrix = {{ false,false,false},
            //                   {false,false,false},
            //                   {false,false,false}};

            //char[,] table = { {'A','N'},
            //                  {'L','I'},
            //                  {'C','H'}};


            //bool[,] matrix = {{ false,false},
            //                   {false,false},
            //                   {false,false}};
            //string word = string.Empty;

            ////List<string> dict = new List<string> { "FACE", "BOOK", "ACE", "BOOKS", "ACES" };
            //List<string> dict = new List<string> { "AN", "ANIL", "LINA", "NAIL" };
            //for (int rows = 0; rows < table.GetLength(0); rows++)
            //{
            //    for (int columns = 0; columns < table.GetLength(1); columns++)
            //    {
            //        matrix[rows, columns] = true;
            //        dp.MyBoggle(table, matrix, word + table[rows, columns], 0, 0, dict);
            //        matrix[rows, columns] = false;
            //        //for (int i = 0; i < matrix.GetLength(0); i++)
            //        //{
            //        //    for (int j = 0; j < matrix.GetLength(1); j++)
            //        //    {
            //        //        matrix[i, j] = false;
            //        //    }
            //        //}


            //    }
            //}



            //Given a set of paranthesis, get all possible combinations with set of parnthesis
            //Finding all combinations of well-formed brackets

            // Method 1
            //List<string> result = new List<string>();
            //dp.GenerateParenthesis(3, 3, "", result);
            //Console.ReadLine();

            //Method 2
            //string output = string.Empty;
            //dp.Brackets(0, 0, output, 3);
            //Console.ReadLine();


            //Sudoku solver
            //int[,] board = new int[,]
            //{
            //    {3, 0, 6, 5, 0, 8, 4, 0, 0},
            //    {5, 2, 0, 0, 0, 0, 0, 0, 0},
            //    {0, 8, 7, 0, 0, 0, 0, 3, 1},
            //    {0, 0, 3, 0, 1, 0, 0, 8, 0},
            //    {9, 0, 0, 8, 6, 3, 0, 0, 5},
            //    {0, 5, 0, 0, 9, 0, 6, 0, 0},
            //    {1, 3, 0, 0, 0, 0, 2, 5, 0},
            //    {0, 0, 0, 0, 0, 0, 0, 7, 4},
            //    {0, 0, 5, 2, 0, 6, 3, 0, 0}
            // };

            // int[,] board = new int[,]
            //{
            //     {1,0,3,0},
            //     {0,0,2,1},
            //     {0,1,0,2},
            //     {2,4,0,0}
            // };
            //int N = board.GetLength(0);

            //if(dp.SolveSudoku(board,N))
            //{
            //    for (int i=0; i < board.GetLength(0); i++)
            //    {
            //        for (int j=0; j < board.GetLength(1); j++)
            //        {
            //            Console.Write(board[i,j]);
            //            Console.Write(" ");
            //        }
            //        Console.WriteLine();
            //    }
            //}

            //else
            //{
            //    Console.Write("No solution");
            //}
            //Console.ReadLine();


            // 0 - 1 kanpsack problem
            //int[] weights = { 3,4,6,5};
            //int[] profits = { 2,3,1,4 };
            //int totalWeights = 8;

            ////int[] weights = { 2, 3, 4, 5 };
            ////int[] profits = { 1, 2, 5, 6 };
            ////int totalWeights = 8;
            //dp.ZeroOneKnapSack(weights, profits, totalWeights);

            //Largest Area under Histogram
            //int[] arr = {6,2,5,4,5,1,6};
            //int max = dp.maxHistogram(arr);
            //Console.WriteLine(max);
            //Console.ReadLine();

            //Egg dropping problem

            //int n = dp.EggDropping(2,4);
            //int[,] cache = new int[2+1,4+1];
            //for (int i = 2; i <= 2; i++)
            //{
            //    for (int j = 2; j <= 4; j++)
            //    {
            //        cache[i, j] = int.MaxValue;
            //    }
            //}
            //int s = dp.EggDroppingRecursion(2,4,cache);

            //Coin Change Problem
            //You are given coins of different denominations and a total amount of money
            //Write a function to compute the number of combinations that make up that amount.
            //int[] coins = { 1, 2 };
            //int amount = 4;
            //int CurrCoin = 0;
            //int[] myDp = new int[amount + 1]; // dp version not returning right value need to check

            //int Combinations = dp.CoinChangex(coins, CurrCoin, amount, myDp);
            //Console.WriteLine("Total combinations :   " + Combinations);
            //Console.ReadLine();

            //You are given coins of different denominations and a total amount of money amount. 
            //Write a function to compute the fewest number of coins that you need to make up that amount

            //int[] coins = { 1, 2,5};
            //int amount = 11;
            //int[] dpx = new int[amount + 1];
            //int minCombinations = dp.FewestCoinsChange(coins, amount, dpx);
            //Console.WriteLine("Total combinations :   " + minCombinations);
            //Console.ReadLine();

            //string ip = "25525511135";
            //dp.RestoreIpAddress(ip);

            //int[] equationVariables = { 1, 2, 3, 4, 5, 5 };
            //int secondIndex = 1; int LengthOfArray = equationVariables.Length-1; int result = equationVariables[0];
            //dp.MakeValidEquation(equationVariables, secondIndex, LengthOfArray, result);

            //0-1 Knapsack usin recursion and DP
            //int[] val = { 2, 4, 6, 9 };
            //int[] weight = {2, 2, 4, 5};
            //int r = dp.TopDownRecursive(val, weight, 8);
            //Console.WriteLine(r);
            //Console.ReadLine();

            //Given a rod of length and prices at which different length of this rod can sell
            // how do you cut this rod to maximize profit
            //int[] p = {2,3};
            //dp.RecrsiveRodCutting(p, 3);



            //Number of ways to Score R runs in B balls
            //int balls = 5; int runs = 11;
            //int[,] mem = new int[balls+1, runs+1];
            //for (int i = 0; i < mem.GetLength(0); i++)
            //{
            //    for (int j = 0; j < mem.GetLength(1); j++)
            //    {
            //        mem[i, j] = -1;
            //    }
            //}

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //int noOfWays = dp.NwaysToScoreRrusnInBballs(balls, runs);
            ////using Memoization
            ////int noOfWays = dp.NwaysToScoreRrusnInBballsWithMemoization(balls, runs, mem);
            //Console.WriteLine(noOfWays);
            //stopwatch.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //Console.ReadLine();

            //Find the minimum cost of travel between two stations when you can choose to break at any station
            //(without backward movement).
            //int INF = int.MaxValue; int N = 4;
            //int[,] cost = { {0, 15, 80, 90},
            //            {INF, 0, 40, 50},
            //            {INF, INF, 0, 70},
            //            {INF, INF, INF, 0} };
            //dp.minCostRec(cost, 0, N - 1);

            //Best Time to Buy and Sell Stock with Cooldown
            //You may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again)
            //After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
            //int[] prices = { 1,2,3,0,2};
            //int buySell = 1; int price = prices.Length;
            //int[,] mem = new int[buySell + 1, price + 1];
            //for (int i = 0; i < mem.GetLength(0); i++)
            //{
            //    for (int j = 0; j < mem.GetLength(1); j++)
            //    {
            //        mem[i, j] = -1;
            //    }
            //}
            //int profit = dp.MaxProfit(0,0,prices,mem);
            //Console.WriteLine(profit);
            //stopwatch.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //Console.ReadLine();


            //int[] arr = {3,5,-1,8,4,2,-6,10,7 };
            //dp.MaxSumSubArrayOfGivenSize(arr,3);

            //Minimum Cost For Tickets 
            //https://leetcode.com/problems/minimum-cost-for-tickets/
            //int[] days = { 1, 4, 6, 7, 8, 20 };
            //int[] costs = { 2, 7, 15 };
            //int[] dpr = new int[days.Length];
            //int minCost = dp.MincostTickets(days,costs,0,dpr);
            //Console.WriteLine("Minimum cost to travel is :  " + minCost);
            //stopwatch.Stop();
            //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //Console.ReadLine();

            //https://leetcode.com/problems/word-break-ii/
            //List<string> dict = new List<string>();
            //dict.Add("apple"); dict.Add("pen"); dict.Add("applepen"); dict.Add("pine"); dict.Add("pineapple");
            //List<string>ValidWord =   dp.WordBreak("pineapplepenapple", 0, dict);
            //foreach (string s in ValidWord)
            //{
            //    Console.WriteLine(s);
            //}

            //int n = dp.NumberOfSquares(12);
            //Console.WriteLine("Min Squares are :  " + n);
        }
    }
}
