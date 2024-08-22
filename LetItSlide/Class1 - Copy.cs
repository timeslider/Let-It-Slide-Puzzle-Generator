using System.Text;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using static LetItSlide.Class1;
using System.Numerics;
using System.Text.RegularExpressions;

// TODO
// Finish writing LoadPuzleFromFileBin
// Tarjan's Algorithm for Strongly Connected Components
namespace LetItSlide
{
    internal class Class1
    {
        internal static void Main(string[] args)
        {
            ////Timing Puzzle generation
            //Stopwatch watch = Stopwatch.StartNew();
            //GeneratePuzzles(6, true, true, false);
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed.ToString());

            //// Trying to figure out why fill doesn't work
            //Puzzle temp = new Puzzle(5);
            //temp.SetWallData(33411071);
            //Console.WriteLine(temp.PrintPuzzle());
            //temp.FillSubPuzzles(temp);
            //Console.WriteLine();
            //Console.WriteLine(temp.PrintPuzzle());


            //int size = 5;
            //HashSet<ulong> puzzles = new HashSet<ulong> { };
            //Stopwatch watch = Stopwatch.StartNew();
            //puzzles = PolyominoGenerator(size);
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed.ToString());



            //List<ulong> sortedList = new List<ulong>(puzzles);
            //sortedList.Sort();
            //SavePuzzlesToFileBin(sortedList, @$"C:\Users\rober\Documents\Polyominoes {size}.bin");
            //SavePuzzlesToFile(puzzles, @$"C:\Users\rober\Documents\Polyominoes {size}.txt");

            //Console.WriteLine($"Found {puzzles.Count}");


            // Testing DISPLACEMENT

            // Initialize variables
            int n = 10; // Example size
            int[] S = new int[n];
            int[,] M = new int[n,n];
            int[] GroupP = new int[n];
            int p1 = 1; // Example value
            int pi = 1; // Example value

            // Example array p
            int[] p = new int[n];

            // Call the function
            DISPLACEMENT(1, p);

            // Output the results
            Console.WriteLine("S: " + string.Join(", ", S));
            Console.WriteLine("M: " + string.Join(", ", M));



            //Puzzle tempPuzzle = new Puzzle(size);
            //foreach (var puzzle in puzzles)
            //{
            //    tempPuzzle.SetWallData(puzzle);
            //    Console.WriteLine(tempPuzzle.PrintPuzzle(true));
            //    tempPuzzle.SetWallData(0);
            //}

            //int n = 9; // Example value
            //var (counts, shapes) = RedelmeierAlgorithm.Redelmeier(n);
            //Puzzle puzzle = new Puzzle(8);
            //foreach (var shape in shapes)
            //{
            //    puzzle.SetWallData(shape);
            //    Console.WriteLine(puzzle.PrintPuzzle());
            //    puzzle.SetWallData(0);
            //    Console.WriteLine();
            //}
            //Console.WriteLine("Counts: " + string.Join(", ", counts));

            //Puzzle temp = new Puzzle(5);
            //temp.SetTileCell(0, 0, true);
            //temp.SetTileCell(0, 4, true);

            //temp.SetWallCell(4, 2, true);
            //temp.SetWallCell(0, 2, true);
            //Console.WriteLine(temp.PrintPuzzle());


            ////Loading from Bin file
            //List<ulong> puzzles = LoadPuzzlesFromFileBin(@"C:\Users\rober\Documents\PuzzleData for size 6 by 6 no holes.bin");
            //Puzzle temp = new Puzzle(6);
            //int start = 0;
            //StringBuilder sb = new StringBuilder();
            //for (int i = start; i < start + puzzles.Count; i++)
            //{
            //    sb.Append($"This is puzzle index: {i} but it's puzzle {puzzles[i]}\n");
            //    //Console.WriteLine($"This is puzzle index: {i} but it's puzzle {puzzles[i]}");
            //    temp.SetWallData(puzzles[i]);
            //    //Console.WriteLine(temp.PrintPuzzle());
            //    sb.Append(temp.PrintPuzzle());
            //}



            //using (StreamWriter writer = new StreamWriter(@"C:\Users\rober\Documents\All puzzles so far.txt"))
            //{
            //    writer.Write(sb);
            //}

            ////Seeing all 3x3 puzzles
            //int size = 3;
            //Puzzle puzzle = new Puzzle(size);
            //for (ulong i = 0; i < Math.Pow(2, Math.Pow(size, 2)); i++)
            //{

            //    puzzle.SetWallData(i);
            //    Console.WriteLine(puzzle.PrintPuzzle());
            //    Console.WriteLine();
            //    puzzle.SetWallData(0);
            //}


            // Is 8x8 even possible?
            //Stopwatch watch = Stopwatch.StartNew();
            //ulong count = 0;
            //for(ulong i = 0; i < ulong.MaxValue; i++)
            //{
            //    count++;
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed.ToString());

            // 




            ////// LUT Table creation
            //int size = 5;
            //Puzzle puzzle = new Puzzle(size);

            ////puzzle.CreateMaskForLUT();

            //// Testing mask and fill
            //foreach (var item in puzzle.LUT5x5)
            //{
            //    Console.WriteLine("Mask");
            //    puzzle.SetWallData(item[0]);
            //    Console.WriteLine(puzzle.PrintPuzzle());
            //    Console.WriteLine();
            //    Console.WriteLine("Fill");
            //    puzzle.SetWallData(item[1]);
            //    Console.WriteLine(puzzle.PrintPuzzle());
            //    Console.WriteLine("-----------------------");
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            // Auto gen lookup table

            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        puzzle.SetWallCell(i, j, true);
            //        Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //        //Console.WriteLine(puzzle.PrintPuzzle());
            //        puzzle.SetWallData(0);
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < size - 1; i++)
            //{
            //    for (int j = 0; j < size - 1; j++)
            //    {
            //        puzzle.SetWallCell(i, j, true);
            //        puzzle.SetWallCell(i, j + 1, true);
            //        puzzle.SetWallCell(i + 1, j, true);
            //        puzzle.SetWallCell(i + 1, j + 1, true);
            //        Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //        //Console.WriteLine(puzzle.PrintPuzzle());
            //        puzzle.SetWallData(0);
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < size - 2; i++)
            //{
            //    for (int j = 0; j < size - 2; j++)
            //    {
            //        puzzle.SetWallCell(i, j, true);
            //        puzzle.SetWallCell(i, j + 1, true);
            //        puzzle.SetWallCell(i, j + 2, true);
            //        puzzle.SetWallCell(i + 1, j, true);
            //        puzzle.SetWallCell(i + 1, j + 1, true);
            //        puzzle.SetWallCell(i + 1, j + 2, true);
            //        puzzle.SetWallCell(i + 2, j, true);
            //        puzzle.SetWallCell(i + 2, j + 1, true);
            //        puzzle.SetWallCell(i + 2, j + 2, true);
            //        Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //        //Console.WriteLine(puzzle.PrintPuzzle());
            //        puzzle.SetWallData(0);
            //    }
            //    Console.WriteLine();
            //}


            //for (int i = 0; i < size - 3; i++)
            //{
            //    for (int j = 0; j < size - 3; j++)
            //    {
            //        puzzle.SetWallCell(i, j, true);
            //        puzzle.SetWallCell(i, j + 1, true);
            //        puzzle.SetWallCell(i, j + 2, true);
            //        puzzle.SetWallCell(i, j + 3, true);
            //        puzzle.SetWallCell(i + 1, j, true);
            //        puzzle.SetWallCell(i + 1, j + 1, true);
            //        puzzle.SetWallCell(i + 1, j + 2, true);
            //        puzzle.SetWallCell(i + 1, j + 3, true);
            //        puzzle.SetWallCell(i + 2, j, true);
            //        puzzle.SetWallCell(i + 2, j + 1, true);
            //        puzzle.SetWallCell(i + 2, j + 2, true);
            //        puzzle.SetWallCell(i + 2, j + 3, true);
            //        puzzle.SetWallCell(i + 3, j, true);
            //        puzzle.SetWallCell(i + 3, j + 1, true);
            //        puzzle.SetWallCell(i + 3, j + 2, true);
            //        puzzle.SetWallCell(i + 3, j + 3, true);
            //        Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //        //Console.WriteLine(puzzle.PrintPuzzle());
            //        puzzle.SetWallData(0);
            //    }
            //    Console.WriteLine();
            //}

            //for (int i = 0; i < size - 4; i++)
            //{
            //    for (int j = 0; j < size - 4; j++)
            //    {
            //        puzzle.SetWallCell(i, j, true);
            //        puzzle.SetWallCell(i, j + 1, true);
            //        puzzle.SetWallCell(i, j + 2, true);
            //        puzzle.SetWallCell(i, j + 3, true);
            //        puzzle.SetWallCell(i, j + 4, true);
            //        puzzle.SetWallCell(i + 1, j, true);
            //        puzzle.SetWallCell(i + 1, j + 1, true);
            //        puzzle.SetWallCell(i + 1, j + 2, true);
            //        puzzle.SetWallCell(i + 1, j + 3, true);
            //        puzzle.SetWallCell(i + 1, j + 4, true);
            //        puzzle.SetWallCell(i + 2, j, true);
            //        puzzle.SetWallCell(i + 2, j + 1, true);
            //        puzzle.SetWallCell(i + 2, j + 2, true);
            //        puzzle.SetWallCell(i + 2, j + 3, true);
            //        puzzle.SetWallCell(i + 2, j + 4, true);
            //        puzzle.SetWallCell(i + 3, j, true);
            //        puzzle.SetWallCell(i + 3, j + 1, true);
            //        puzzle.SetWallCell(i + 3, j + 2, true);
            //        puzzle.SetWallCell(i + 3, j + 3, true);
            //        puzzle.SetWallCell(i + 3, j + 4, true);
            //        puzzle.SetWallCell(i + 4, j, true);
            //        puzzle.SetWallCell(i + 4, j + 1, true);
            //        puzzle.SetWallCell(i + 4, j + 2, true);
            //        puzzle.SetWallCell(i + 4, j + 3, true);
            //        puzzle.SetWallCell(i + 4, j + 4, true);
            //        Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //        //Console.WriteLine(puzzle.PrintPuzzle());
            //        puzzle.SetWallData(0);
            //    }
            //    Console.WriteLine();
            //}



            //// 1x1 for a 5x5
            //// Upper corner
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(1, 0, true);

            //// one over
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(0, 2, true);

            //// one over
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(0, 3, true);

            //// one over
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(0, 4, true);

            //// one over
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(1, 4, true);

            //// back to start, down one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(2, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// Over one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(1, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// Over one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(1, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// Over one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(1, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// Over one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 4, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(1, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// back to start, down one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// back to start, down one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(4, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(4, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// back to start, down one
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 1, true);
            ////puzzle.SetWallCell(4, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(4, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(4, 1, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(4, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(4, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(4, 3, true);
            //puzzle.SetWallCell(3, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));


            // 2x2 for a 5x5
            // Upper corner
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(2, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(2, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(0, 4, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(2, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(2, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 2nd row
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(3, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(3, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(3, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(0, 4, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(3, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 3rd row
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(4, 0, true);
            //puzzle.SetWallCell(4, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 1, true);
            //puzzle.SetWallCell(4, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(4, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(4, 3, true);
            //puzzle.SetWallCell(4, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 4th row
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(4, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(4, 3, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 2, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(4, 4, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(4, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 1st row 3x3
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(3, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 4, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(2, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(3, 2, true);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(2, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 2nd row 3x3
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(4, 1, true);
            //puzzle.SetWallCell(4, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 3, true);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(4, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(0, 4, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 4, true);
            //puzzle.SetWallCell(4, 3, true);
            //puzzle.SetWallCell(4, 2, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 3rd row 3x3
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(2, 3, true);
            //puzzle.SetWallCell(3, 3, true);
            //puzzle.SetWallCell(4, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 1, true);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(4, 4, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 0, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 2, true);
            //puzzle.SetWallCell(1, 3, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 1, true);
            //puzzle.SetWallCell(3, 1, true);
            //puzzle.SetWallCell(4, 1, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 1st row 4x4
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 4, true);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(4, 0, true);
            //puzzle.SetWallCell(4, 1, true);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(4, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 1, true);
            //puzzle.SetWallCell(4, 2, true);
            //puzzle.SetWallCell(4, 3, true);
            //puzzle.SetWallCell(4, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            // 2nd row 4x4
            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 4, true);
            //puzzle.SetWallCell(2, 4, true);
            //puzzle.SetWallCell(3, 4, true);
            //puzzle.SetWallCell(4, 4, true);
            //puzzle.SetWallCell(0, 0, true);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(0, 3, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //puzzle.SetWallData(0);
            //puzzle.SetWallCell(1, 0, true);
            //puzzle.SetWallCell(2, 0, true);
            //puzzle.SetWallCell(3, 0, true);
            //puzzle.SetWallCell(4, 0, true);
            //puzzle.SetWallCell(0, 1, true);
            //puzzle.SetWallCell(0, 2, true);
            //puzzle.SetWallCell(0, 3, true);
            //puzzle.SetWallCell(0, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //Puzzle puzzle = new Puzzle(5);

            //// 1x2 mask
            //puzzle.SetWallData(0b000000000000000000000000000000000000000101010101010101010101010);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));

            //// 1x2 fill
            //puzzle.SetWallData(0b000000000000000000000000000000000000000000000000000000000100001);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));


            //// Timing Puzzle HasSubPuzzle
            //Stopwatch watch = Stopwatch.StartNew();
            //GeneratePuzzles(5, false, false, false);

            //PrintBurnsidesLemma(2, 6);

            //// Testing Fill
            //Puzzle tempPuzzle = new Puzzle(5);
            //tempPuzzle.SetWallCell(0, 2, true);
            //tempPuzzle.SetWallCell(1, 2, true);
            //tempPuzzle.SetWallCell(2, 0, true);
            //tempPuzzle.SetWallCell(2, 1, true);
            //tempPuzzle.SetWallCell(2, 3, true);
            //tempPuzzle.SetWallCell(2, 4, true);
            //tempPuzzle.SetWallCell(3, 2, true);
            //tempPuzzle.SetWallCell(4, 2, true);
            //Console.WriteLine("Original");
            //Console.WriteLine(tempPuzzle.PrintPuzzle());
            //Console.WriteLine();
            //tempPuzzle.FillSubPuzzles();
            //Console.WriteLine("Filled in");
            //Console.WriteLine(tempPuzzle.PrintPuzzle());




            //Stopwatch watch = Stopwatch.StartNew();
            //Puzzle tempPuzzle = new Puzzle(5);
            //ulong start = 10_000_000;
            //ulong count = 50;
            //// Testing LUT
            //for (ulong i = start; i < start + count; i++)
            //{
            //    tempPuzzle.SetWallData(i);
            //    foreach(var maskAndFill in tempPuzzle.LUT5x5)
            //    {
            //        if((tempPuzzle.GetWallData() & maskAndFill[0]) == maskAndFill[0])
            //        {
            //            Console.WriteLine("Original Puzze");
            //            Console.WriteLine(tempPuzzle.PrintPuzzle());
            //            tempPuzzle.SetWallData(tempPuzzle.GetWallData() | maskAndFill[1]);
            //            Console.WriteLine();
            //            Console.WriteLine("Filled in");
            //            Console.WriteLine(tempPuzzle.PrintPuzzle());
            //        }
            //    }
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed.ToString());





            //Puzzle puzzle = new Puzzle(5);
            //ulong puzzleInt = 55003UL;
            //puzzle.SetWallData(puzzleInt);
            //Console.WriteLine("Original");
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine();
            //puzzle.Rotate90Clockwise();
            //Console.WriteLine("Original Rotation");
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine();
            //puzzle.SetWallData(puzzleInt);
            //puzzle.Rotate90Fast();
            //Console.WriteLine("Fast rotate");
            //Console.WriteLine(puzzle.PrintPuzzle());


            // Testing fast rotation
            //Puzzle puzzle = new Puzzle(5);
            //int col = 2;
            //puzzle.SetWallCell(0, col, true);
            //puzzle.SetWallCell(1, col, true);
            //puzzle.SetWallCell(2, col, false);
            //puzzle.SetWallCell(3, col, false);
            //puzzle.SetWallCell(4, col, true);
            //Console.WriteLine("Original");
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //Console.WriteLine(puzzle.PrintPuzzle());
            //puzzle.Rotate90Fast();
            //Console.WriteLine();
            //Console.WriteLine("Fast Rotated");
            //Console.WriteLine(Convert.ToString((long)puzzle.GetWallData(), 2).PadLeft(63, '0'));
            //Console.WriteLine(puzzle.PrintPuzzle());





            //PrintBurnsidesLemma(2, 8);
            // These puzzle have symmetries removed

            //int iterations = 10;
            //long totalTime = 0;
            //int size = 5;
            //for (int i = 0; i < iterations; i++)
            //{
            //    Stopwatch watch = Stopwatch.StartNew();
            //    // This function generates all puzzles of size 4 with sub puzzles and symmetries removed.
            //    GeneratePuzzles(5, false, true, true);
            //    watch.Stop();
            //    totalTime += watch.ElapsedMilliseconds;
            //}
            //Console.WriteLine($"It took {(totalTime / iterations) / 1000.0} seconds on average to process this function.");

            // Testing the move function






            //// Testing move, not finished...
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine();

            //puzzle.SetTileCell(4, 4, true);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine();

            //puzzle.Move(4, 4, Puzzle.Direction.Left);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine();

            //puzzle.Move(4, 0, Puzzle.Direction.Up);
            //Console.WriteLine(puzzle.PrintPuzzle());

            //puzzle.Move(2, 0, Puzzle.Direction.Right);
            //Console.WriteLine(puzzle.PrintPuzzle());


            //These are v1 puzzle but they have single holes removed


            //int size = 5;
            //Puzzle puzzle = new Puzzle(size);
            //var puzzleData = LoadPuzzlesFromFile(@$"c:\users\rober\documents\puzzledata for size {size} by {size} no holes.txt");

            //int i = 0;
            //foreach (var data in puzzleData)
            //{
            //    if (i > 100)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(data);
            //    puzzle.SetWallData(data);
            //    puzzle.PrintPuzzle();
            //    Console.WriteLine();
            //    i++;
            //}

            // Testing HasSubPuzzle
            //int size = 5;
            //Puzzle puzzle = new Puzzle(size);
            //StringBuilder sb = new StringBuilder();
            //for (int i = 1000000; i < 2000000; i++)
            //{
            //    puzzle.SetData((ulong)i);
            //    if (puzzle.HasSubPuzzles(sb) == true)
            //    {
            //        sb.Append((ulong)i + "\n");
            //        sb.Append(puzzle.PrintPuzzle());
            //    }
            //}

            //using (StreamWriter streamWriter = new StreamWriter(@$"C:\Users\rober\Documents\Let It Slide holes test.txt"))
            //{
            //    streamWriter.Write(sb);
            //}

            //puzzle.SetCell(0, 4, true);
            //puzzle.SetCell(1, 4, true);
            //puzzle.SetCell(2, 4, true);
            //puzzle.SetCell(3, 4, true);
            //puzzle.SetCell(3, 0, true);
            //puzzle.SetCell(4, 1, true);
            //puzzle.SetCell(4, 2, true);
            //puzzle.SetCell(4, 3, true);


            //puzzle.SetData(0);
            //Console.WriteLine(puzzle.PrintPuzzle());
            //Console.WriteLine(puzzle.HasSubPuzzles());


            //int size = 4;
            //Puzzle puzzle = new Puzzle(size);
            int l(int[] p) => p.Length;

            void DISPLACEMENT(int i, int[] p)
            {
                if (i == 1)
                {
                    S[1] = 0;
                    M[1, 1] = 0;
                    return;
                }

                int j = GroupP[i];
                M[i, j] = 0;
                if (j == i)
                {
                    M[i, i] = 0;
                    return;
                }

                if (j < i)
                {
                    DISPLACEMENT(j, p);
                }
                else
                {
                    M[i, j] = 1;
                    DISPLACEMENT(2, p);
                    for (int pIndex = 1; pIndex < i; pIndex++)
                    {
                        for (int a = 0; a < pIndex; a++)
                        {
                            j = GroupP[pIndex - i];
                            S[j] = a;
                            M[j, i] = a;
                            if (j < i)
                            {
                                DISPLACEMENT(j, p);
                            }
                        }
                    }
                }

                S[i] = p.Length - p.Length + GroupP.Length - 1;
                for (int k = 0; k < GroupP.Length - 2; k++)
                {
                    M[j, i] += M[j - 1, i] + M[j - 2, i];
                }
            }

        }

        public class Puzzle
        {
            private ulong wallData;
            private ulong tileData;
            private int size;
            public List<List<ulong>> LUT5x5 = new List<List<ulong>>();
            public List<List<ulong>> LUT6x6 = new List<List<ulong>>();

            public Puzzle(int size)
            {
                if (size < 1 || size > 8)
                {
                    throw new ArgumentOutOfRangeException("Size must be between 2 and 8.");
                }
                this.size = size;
                wallData = 0;
                tileData = 0;
            }


            public void SetWallData(ulong newData)
            {
                wallData = newData;
            }

            public void SetTileData(ulong newData)
            {
                tileData = newData;
            }


            public ulong GetWallData()
            {
                return wallData;
            }

            public ulong GetTileData()
            {
                return tileData;
            }


            public void SetWallCell(int row, int col, bool value)
            {
                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
                }

                int bitPosition = row * size + col;
                if (value)
                {
                    wallData |= (1UL << bitPosition);
                }
                else
                {
                    wallData &= ~(1UL << bitPosition);
                }
            }

            public void SetTileCell(int row, int col, bool value)
            {
                //// See if the following code works. Taken from: https://www.youtube.com/watch?v=MzfQ8H16n0M
                //long SetCellState(long bitboard, int row, int col)
                //{
                //    long newBit = 1L << (row * size + col);
                //    return (bitboard |= newBit);
                //}
                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
                }

                int bitPosition = row * size + col;
                if (value)
                {
                    tileData |= (1UL << bitPosition);
                }
                else
                {
                    tileData &= ~(1UL << bitPosition);
                }
            }

            public bool GetWallCell(int row, int col)
            {
                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
                }

                int bitPosition = row * size + col;
                return (wallData & (1UL << bitPosition)) != 0;
            }

            public bool GetTileCell(int row, int col)
            {
                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
                }

                int bitPosition = row * size + col;
                return (tileData & (1UL << bitPosition)) != 0;
            }


            public string PrintPuzzle(bool invert = false)
            {
                StringBuilder sb = new StringBuilder();
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        // Horrible readability...
                        if (invert == true)
                        {
                            if (GetWallCell(row, col) == true)
                            {
                                sb.Append("- ");
                            }
                            else if (GetTileCell(row, col) == true)
                            {
                                sb.Append("T ");
                            }
                            else
                            {
                                sb.Append("W ");
                            }
                        }
                        else
                        {
                            if (GetWallCell(row, col) == true)
                            {
                                sb.Append("W ");
                            }
                            else if (GetTileCell(row, col) == true)
                            {
                                sb.Append("T ");
                            }
                            else
                            {
                                sb.Append("- ");
                            }
                        }
                    }
                    sb.Append('\n');
                }
                return sb.ToString();
            }


            public void Rotate90Clockwise()
            {
                ulong newData = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (GetWallCell(row, col))
                        {
                            int newRow = col;
                            int newCol = size - 1 - row;
                            int bitPosition = newRow * size + newCol;
                            newData |= (1UL << bitPosition);
                        }
                    }
                }
                wallData = newData;
            }

            // This rotates and flips
            public void Rotate90andFlip()
            {
                wallData = bit_permute_step(wallData, 0x00006300, 16);
                wallData = bit_permute_step(wallData, 0x020a080a, 4);
                wallData = bit_permute_step(wallData, 0x0063008c, 8);
                wallData = bit_permute_step(wallData, 0x00006310, 16);
            }

            public void Rotate90Fast()
            {
                ulong r0 = Bmi2.X64.ParallelBitExtract(wallData, 0b0000100001000010000100001);
                ulong r1 = Bmi2.X64.ParallelBitExtract(wallData, 0b0001000010000100001000010);
                ulong r2 = Bmi2.X64.ParallelBitExtract(wallData, 0b0010000100001000010000100);
                ulong r3 = Bmi2.X64.ParallelBitExtract(wallData, 0b0100001000010000100001000);
                ulong r4 = Bmi2.X64.ParallelBitExtract(wallData, 0b1000010000100001000010000);
                wallData = (r0 << 20) | (r1 << 15) | (r2 << 10) | (r3 << 5) | (r4);
            }


            public void Flip()
            {
                if (size == 2)
                {
                    wallData = ((wallData << 2) & 0b0000000000000000000000000000000000000000000000000000000000001100) |
                               ((wallData >> 2) & 0b0000000000000000000000000000000000000000000000000000000000000011);
                }
                if (size == 3)
                {
                    wallData = ((wallData << 6) & 0b0000000000000000000000000000000000000000000000000000000111000000) |
                               ((wallData) & 0b0000000000000000000000000000000000000000000000000000000000111000) |
                               ((wallData >> 6) & 0b0000000000000000000000000000000000000000000000000000000000000111);
                }
                if (size == 4)
                {
                    wallData = ((wallData << 12) & 0b0000000000000000000000000000000000000000000000001111000000000000) |
                               ((wallData << 4) & 0b0000000000000000000000000000000000000000000000000000111100000000) |
                               ((wallData >> 4) & 0b0000000000000000000000000000000000000000000000000000000011110000) |
                               ((wallData >> 12) & 0b0000000000000000000000000000000000000000000000000000000000001111);
                }
                if (size == 5)
                {
                    wallData = ((wallData << 20) & 0b0000000000000000000000000000000000000001111100000000000000000000) |
                               ((wallData << 10) & 0b0000000000000000000000000000000000000000000011111000000000000000) |
                               ((wallData) & 0b0000000000000000000000000000000000000000000000000111110000000000) |
                               ((wallData >> 10) & 0b0000000000000000000000000000000000000000000000000000001111100000) |
                               ((wallData >> 20) & 0b0000000000000000000000000000000000000000000000000000000000011111);
                }
                if (size == 6)
                {
                    wallData = ((wallData << 30) & 0b0000000000000000000000000000111111000000000000000000000000000000) |
                               ((wallData << 18) & 0b0000000000000000000000000000000000111111000000000000000000000000) |
                               ((wallData << 6) & 0b0000000000000000000000000000000000000000111111000000000000000000) |
                               ((wallData >> 6) & 0b0000000000000000000000000000000000000000000000111111000000000000) |
                               ((wallData >> 18) & 0b0000000000000000000000000000000000000000000000000000111111000000) |
                               ((wallData >> 30) & 0b0000000000000000000000000000000000000000000000000000000000111111);
                }

                //if (size == 7)

                if (size == 8)
                {
                    wallData = (wallData << 56) |
                    ((wallData << 40) & 0b0000000011111111000000000000000000000000000000000000000000000000) |
                    ((wallData << 24) & 0b0000000000000000111111110000000000000000000000000000000000000000) |
                    ((wallData << 8) & 0b0000000000000000000000001111111100000000000000000000000000000000) |
                    ((wallData >> 8) & 0b0000000000000000000000000000000011111111000000000000000000000000) |
                    ((wallData >> 24) & 0b0000000000000000000000000000000000000000111111110000000000000000) |
                    ((wallData >> 40) & 0b0000000000000000000000000000000000000000000000001111111100000000) |
                    ((wallData >> 56));

                }
            }


            public void MirrorHorizontally()
            {
                ulong newGrid = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (GetWallCell(row, col))
                        {
                            int newCol = size - 1 - col;
                            int bitPosition = row * size + newCol;
                            newGrid |= (1UL << bitPosition);
                        }
                    }
                }
                wallData = newGrid;
            }

            //public bool HasSubPuzzles(StringBuilder sb)

            // This is the old HasSubPuzzles method.
            // It works and it's fast, but I need to see if I can do better
            public bool HasSubPuzzlesOld()
            {
                // This can probably be speed up via bit manipulation
                // Loop over every size below the current puzzle size
                for (int n = size - 1; n > 0; n--)
                {
                    for (int row = 0; row < size - n + 1; row++)
                    {
                        for (int col = 0; col < size - n + 1; col++)
                        {
                            bool hasSubPuzzles = true;
                            // From here, we need to check for a loop.
                            // Assume that the n x n grid is around position (row, col)
                            // And that (row, col) is in the top left most cell of the n x n grid we are checking
                            // Therefore we need to check for walls along row - 1, row + n, col - 1, and col + n
                            // If any of these exceed the bounds of the puzzle, then move on to the next one
                            // If all the walls exist, fill the n x n grid with wall and return true
                            // Filling all the n x n grid with walls will ensure we capture the single one with filled walls
                            // Without having to check the inner walls

                            // Check the top edge
                            // We only need to check above row, if row is greater than 0.
                            if (row > 0 && hasSubPuzzles == true)
                            {
                                // Loop over each cell in the row
                                for (int i = 0; i < n; i++)
                                {
                                    // If a cell is empty, return false
                                    if (GetWallCell(row - 1, col + i) == false)
                                    {
                                        hasSubPuzzles = false;
                                        break;
                                    }
                                }
                            }

                            // Check the left edge
                            if (col > 0 && hasSubPuzzles == true)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    if (GetWallCell(row + i, col - 1) == false)
                                    {
                                        hasSubPuzzles = false;
                                        break;
                                    }
                                }
                            }

                            // Check bottom edge
                            // Similar to how only need to check above row, if row is greater than 0,
                            // We only need to check the bottom row if the current row + n is less than the puzzle size
                            if (row + n < size && hasSubPuzzles == true)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    if (GetWallCell(row + n, col + i) == false)
                                    {
                                        hasSubPuzzles = false;
                                        break;
                                    }
                                }
                            }

                            // Check right edge
                            if (col + n < size && hasSubPuzzles == true)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    if (GetWallCell(row + i, col + n) == false)
                                    {
                                        hasSubPuzzles = false;
                                        break;
                                    }
                                }
                            }

                            // If we make it here and hasSubPuzzle is still true, then we found a sub puzzle
                            if (hasSubPuzzles == true)
                            {
                                //Console.WriteLine($"\nPuzzle {data} has a sub puzzle around row: {row}, col: {col} when n is {n}\n");
                                //sb.Append(($"\nPuzzle {data} has a sub puzzle around row: {row}, col: {col} when n is {n}\n"));
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public void CreateMaskForLUT()
            {
                // This can probably be speed up via bit manipulation
                // Loop over every size below the current puzzle size
                List<ulong> masks = new List<ulong>();

                for (int n = 1; n < size; n++)
                {
                    Puzzle temp = new Puzzle(size);
                    for (int row = 0; row < size - n + 1; row++)
                    {
                        for (int col = 0; col < size - n + 1; col++)
                        {
                            // Check the top edge
                            if (row > 0)
                            {
                                // Loop over each cell in the row
                                for (int i = 0; i < n; i++)
                                {
                                    temp.SetWallCell(row - 1, col + i, true);
                                }
                            }

                            // Check the left edge
                            if (col > 0)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    temp.SetWallCell(row + i, col - 1, true);
                                }
                            }

                            // Check bottom edge
                            if (row + n < size)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    temp.SetWallCell(row + n, col + i, true);
                                }
                            }

                            // Check right edge
                            if (col + n < size)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    temp.SetWallCell(row + i, col + n, true);
                                }
                            }
                            //Console.WriteLine(temp.PrintPuzzle());
                            Console.WriteLine(Convert.ToString((long)temp.GetWallData(), 2).PadLeft(63, '0'));
                            temp.SetWallData(0);
                        }
                        Console.WriteLine();
                    }
                }
            }

            // I'm including puzzle here for testing purposes
            public void FillSubPuzzles(Puzzle puzzle)
            {
                // This is used to fill all the holes as a last step
                ulong outputFill = 0;
                foreach (List<ulong> maskAndFill in LUT5x5)
                {
                    // Checks if wallData contains all of the mask
                    if ((wallData & maskAndFill[0]) == maskAndFill[0])
                    {
                        //// Testing
                        //if(puzzle.GetWallData() == 33411071)
                        //{
                        //    temp.SetWallData(0);
                        //    Console.WriteLine($"This is puzzle{puzzle.GetWallData()}");
                        //    Console.WriteLine(puzzle.PrintPuzzle());
                        //    Console.WriteLine();
                        //    Console.WriteLine("Checking this mask:");
                        //    temp.SetWallData(maskAndFill[0]);
                        //    Console.WriteLine(temp.PrintPuzzle());
                        //    temp.SetWallData(0);
                        //    Console.WriteLine();
                        //    Console.WriteLine("And filling it with:");
                        //    temp.SetWallData(maskAndFill[1]);
                        //    Console.WriteLine(temp.PrintPuzzle());
                        //    temp.SetWallData(0);
                        //}
                        outputFill |= maskAndFill[1];
                    }
                }
                wallData |= outputFill;
                //Console.WriteLine("This is everything it found that can be filled.");
                //temp.SetWallData(outputFill);
                //Console.WriteLine(temp.PrintPuzzle());
                //temp.SetWallData(0);
                //Console.WriteLine("This is puzzle after filling.");
                //Console.WriteLine(puzzle.PrintPuzzle());
            }

            public enum Direction
            {
                Up,
                Down,
                Left,
                Right
            }

            public Puzzle Move(int row, int col, Direction direction)
            {
                // It might be quicker if we create a data structure that is prepopulated with info about how you can move
                // For example, row 2, col 3 might be able to move 1 unit up, 2 units down, 3 to the left, and 2 to right (just making up numbers)
                // These numbers can be stored in a data structure, so instead of looping to find where the wall is
                // You could access this data. 
                Puzzle newPuzzle = new Puzzle(size);
                newPuzzle.SetTileData(tileData);
                if (GetTileCell(row, col) == false)
                {
                    throw new ArgumentOutOfRangeException("There is no moveable tile at that location.");
                }

                if (direction == Direction.Up)
                {
                    int i = 1;
                    while (row - i > 0 && GetWallCell(row - i, col) == false && GetTileCell(row - i, col) == false)
                    {
                        i++;
                    }
                    // Unset the original
                    newPuzzle.SetTileCell(row, col, false);
                    // Set the new one
                    newPuzzle.SetTileCell(row - i + 1, col, true);
                }

                if (direction == Direction.Left)
                {
                    int i = 1;
                    while (col - i > 0 && GetWallCell(row, col - i) == false && GetTileCell(row, col - i) == false)
                    {

                        i++;
                    }
                    newPuzzle.SetTileCell(row, col, false);
                    newPuzzle.SetTileCell(row, col - i, true);

                }

                if (direction == Direction.Down)
                {
                    int i = 1;
                    while (col - i > 0 && GetWallCell(row, col - i) == false && GetTileCell(row, col - i) == false)
                    {

                        i++;
                    }
                    newPuzzle.SetTileCell(row, col, false);
                    newPuzzle.SetTileCell(row, col - i, true);

                }

                return newPuzzle;
            }


            //public void FillSubMatrix(int row, int col, int n)
            //{
            //    int row ** row;
            //}

            //public int GetWidth()
            //{

            //}
        }



        static void SavePuzzlesToFile(HashSet<ulong> puzzles, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var puzzle in puzzles)
                {
                    writer.WriteLine(puzzle);
                }
            }
        }

        static void SavePuzzlesToFileBin(List<ulong> puzzles, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    foreach (var element in puzzles)
                    {
                        w.Write(element);
                    }
                }
            }
        }

        static List<ulong> LoadPuzzlesFromFileBin(string filePath)
        {
            List<ulong> puzzles = new List<ulong>();

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (BinaryReader r = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
                        puzzles.Add(r.ReadUInt64());
                    }
                }
            }

            return puzzles;
        }

        static HashSet<ulong> LoadPuzzlesFromFile(string filePath)
        {
            HashSet<ulong> puzzles = new HashSet<ulong>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (ulong.TryParse(line, out ulong puzzle))
                    {
                        puzzles.Add(puzzle);
                    }
                }
            }
            return puzzles;
        }

        // I'm not even sure what this is going to do
        static List<List<ulong>> MaskAndFillGen(int size)
        {
            List<List<ulong>> masksAndFills = new List<List<ulong>>();
            // Normalize mask (shift it so the first row with an empty cell is flush with the top row
            // and the first column with an empty cell is flush with the left column



            return masksAndFills;
        }

        // Lookup table
        static int[] BitsSetTable256 = new int[256];

        // Function to initialise the lookup table
        public static void initialize()
        {
            // To initially generate the table algorithmically
            BitsSetTable256[0] = 0;
            for (int i = 0; i < 256; i++)
            {
                BitsSetTable256[i] = (i & 1) + BitsSetTable256[i / 2];
            }
        }

        // Function to return the count of set bits in n
        public static int countSetBits(ulong n)
        {
            return (BitsSetTable256[n & 0xff]
                    + BitsSetTable256[(n >> 8) & 0xff]
                    + BitsSetTable256[(n >> 16) & 0xff]
                    + BitsSetTable256[(n >> 24) & 0xff]
                    + BitsSetTable256[(n >> 32) & 0xff]
                    + BitsSetTable256[(n >> 40) & 0xff]
                    + BitsSetTable256[(n >> 48) & 0xff]
                    + BitsSetTable256[(n >> 56) & 0xff]);

        }

        // This works
        // But we need to exclude the ones that fewer bits than size
        public static HashSet<ulong> PolyominoGenerator(int size)
        {
            HashSet<ulong> output = new HashSet<ulong>();
            Stack<ulong> candidates = new Stack<ulong>();

            candidates.Push(1UL);
            Puzzle puzzle = new Puzzle(size);

            initialize();

            while (candidates.Count > 0)
            {
                ulong candidate = candidates.Pop();
                output.Add(candidate);

                puzzle.SetWallData(candidate);
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (puzzle.GetWallCell(row, col))
                        {
                            ulong newCandidate;

                            if (row > 0)
                            {
                                newCandidate = candidate | (1UL << ((row - 1) * size + col));
                                if (!output.Contains(newCandidate))
                                {
                                    candidates.Push(newCandidate);
                                }
                            }
                            if (row < size - 1)
                            {
                                newCandidate = candidate | (1UL << ((row + 1) * size + col));
                                if (!output.Contains(newCandidate))
                                {
                                    candidates.Push(newCandidate);
                                }
                            }
                            if (col > 0)
                            {
                                newCandidate = candidate | (1UL << (row * size + (col - 1)));
                                if (!output.Contains(newCandidate))
                                {
                                    candidates.Push(newCandidate);
                                }
                            }
                            if (col < size - 1)
                            {
                                newCandidate = candidate | (1UL << (row * size + (col + 1)));
                                if (!output.Contains(newCandidate))
                                {
                                    candidates.Push(newCandidate);
                                }
                            }
                        }
                    }
                }
            }
            return output;
        }



        #region Puzzle Generation


        // TODO Extract the fuctionally that checks for duplicate rotations and mirrors
        public static void GeneratePuzzles(int size, bool save, bool includeSubPuzzles, bool includeSymmetries)
        {
            HashSet<ulong> uniqueData = new HashSet<ulong>();

            Puzzle puzzle = new Puzzle(size);
            for (ulong i = 0; i < Math.Pow(2, size * size); i++)
            {
                // DO NOT MOVE! For some reason, this has to be inside the parallel for loop
                puzzle.SetWallData(i);

                // Check for holes before doing all the rotation checks
                if (includeSubPuzzles == false)
                {
                    puzzle.FillSubPuzzles(puzzle);
                }

                //// This is for testing
                //lock (lockObject)
                //{
                //    uniqueData.Add(i);
                //}

                if (includeSymmetries == false)
                {
                    List<ulong> transformations = new List<ulong>
                    {
                        puzzle.GetWallData()
                    };

                    puzzle.Rotate90Fast();
                    transformations.Add(puzzle.GetWallData());

                    puzzle.Rotate90Fast();
                    transformations.Add(puzzle.GetWallData());

                    puzzle.Rotate90Fast();
                    transformations.Add(puzzle.GetWallData());

                    puzzle.Flip();
                    transformations.Add(puzzle.GetWallData());

                    puzzle.Rotate90Fast();
                    transformations.Add(puzzle.GetWallData());

                    puzzle.Rotate90Fast();
                    transformations.Add(puzzle.GetWallData());

                    puzzle.Rotate90Fast();
                    transformations.Add(puzzle.GetWallData());

                    ulong minHash = ulong.MaxValue;
                    foreach (var data in transformations)
                    {
                        minHash = Math.Min(minHash, data);
                    }

                    uniqueData.Add(minHash);

                }
            }
            // At this point, uniqueData has all the data we want; however, it's unsorted because of the Parallel.For loop
            List<ulong> sortedList = new List<ulong>(uniqueData);
            sortedList.Sort();

            // Sometimes we don't want to save, such as during testing
            if (save == true)
            {
                //Save the unique data to a file or process it further
                SavePuzzlesToFileBin(sortedList, @$"C:\Users\rober\Documents\PuzzleData for size {size} by {size} no holes.bin");
            }
            Console.WriteLine($"Number of unique {size}x{size} grids with no holes is: {uniqueData.Count}");
        }
        #endregion

        #region Burnside's Lemma
        // Burnside's Lemma is used to calculate the number of puzzle minus the all the duplicates
        // https://en.wikipedia.org/wiki/Burnside%27s_lemma
        // These formulas come from Marko Riedel's answer on the following post:
        // https://math.stackexchange.com/questions/570003/how-many-unique-patterns-exist-for-a-n-times-n-grid
        // More info can also be found here:
        // https://www.youtube.com/watch?v=D0d9bYZ_qDY

        /// <summary>
        /// Calculates the number of puzzle minus the all the duplicates
        /// </summary>
        /// <param name="colors">We're using only black and white so this is typically going to be 2</param>
        /// <param name="size">The length of one side of a puzzle</param>
        public static void PrintBurnsidesLemma(double colors, double size)
        {
            double sizeSqr = size * size;
            double sizeSqrPlusSizeOverTwo = (sizeSqr + size) / 2;
            // First term
            double output = Math.Pow(colors, sizeSqr);

            // The case that size was even
            if (size % 2 == 0)
            {
                // Second term
                output += 3 * Math.Pow(colors, sizeSqr / 2);
                // Third term
                output += 2 * Math.Pow(colors, sizeSqrPlusSizeOverTwo);
                // Fourth term
                output += 2 * Math.Pow(colors, sizeSqr / 4);
            }
            else
            {
                // Second term
                output += 4 * Math.Pow(colors, sizeSqrPlusSizeOverTwo);
                // Third term
                output += 2 * Math.Pow(colors, (sizeSqr + 3) / 4);
                // Fourth term
                output += Math.Pow(colors, (sizeSqr + 1) / 2);
            }
            Console.WriteLine((output / 8).ToString("N19"));
        }
        #endregion

        public static ulong bit_permute_step(ulong x, ulong m, int shift)
        {
            ulong temp;
            temp = ((x >> shift) ^ x) & m;
            x = (x ^ temp) ^ (temp << shift);
            return x;
        }
    }

    class RedelmeierAlgorithm
    {
        static List<(int, int)> Neighbors(List<(int, int)> polyomino)
        {
            var found = new List<(int, int)>();
            foreach (var (x, y) in polyomino)
            {
                foreach (var (deltaX, deltaY) in new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) })
                {
                    if (y + deltaY < 0 || (y + deltaY == 0 && x + deltaX < 0))
                        continue;

                    var newSquare = (x + deltaX, y + deltaY);
                    if (!found.Contains(newSquare))
                        found.Add(newSquare);
                }
            }
            return found;
        }

        static ulong PolyominoToBitboard(List<(int, int)> polyomino)
        {
            ulong bitboard = 0;
            foreach (var (x, y) in polyomino)
            {
                bitboard |= 1UL << (x + y * 8); // Assuming an 8x8 grid
            }
            return bitboard;
        }

        static void RedelmeierRecursion(int n, int[] counts, List<(int, int)> polyomino, List<(int, int)> untriedSet, List<ulong> shapes)
        {
            while (untriedSet.Count > 0)
            {
                var newSquare = untriedSet[untriedSet.Count - 1];
                untriedSet.RemoveAt(untriedSet.Count - 1);

                var newUntriedSet = new List<(int, int)>(untriedSet);
                var newSquareNeighbors = Neighbors(new List<(int, int)> { newSquare });
                var polyominoNeighbors = Neighbors(polyomino);

                foreach (var s in newSquareNeighbors)
                {
                    if (!polyominoNeighbors.Contains(s) && !polyomino.Contains(s))
                        newUntriedSet.Add(s);
                }

                var newPolyomino = new List<(int, int)>(polyomino) { newSquare };
                counts[newPolyomino.Count]++;
                shapes.Add(PolyominoToBitboard(newPolyomino));

                if (newPolyomino.Count < n)
                    RedelmeierRecursion(n, counts, newPolyomino, newUntriedSet, shapes);
            }
        }

        public static (int[], List<ulong>) Redelmeier(int n)
        {
            var counts = new int[n + 1];
            counts[0] = 1;

            var polyomino = new List<(int, int)>();
            var untriedSet = new List<(int, int)> { (0, 0) };
            var shapes = new List<ulong>();

            RedelmeierRecursion(n, counts, polyomino, untriedSet, shapes);
            return (counts, shapes);
        }

    }
        





}
