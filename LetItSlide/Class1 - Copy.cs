using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using static LetItSlide.Class1;

// Tarjan's Algorithm for Strongly Connected Components
namespace LetItSlide
{
    internal class Class1
    {
        internal static void Main(string[] args)
        {
            //PrintBurnsidesLemma(2, 8);
            // These puzzle have symmetries removed

            // This function generates all puzzles of size 4 with sub puzzles and symmetries removed.
            int iterations = 10;
            long totalTime = 0;
            int size = 5;
            for(int i  = 0; i < iterations; i++)
            {
                Stopwatch watch = Stopwatch.StartNew();
                GeneratePuzzles(5, false);
                watch.Stop();
                totalTime += watch.ElapsedMilliseconds;
            }
            Console.WriteLine($"It took {(totalTime / iterations) / 1000.0} seconds on average to process this function.");


            //These are v1 puzzle but they have single holes removed
            

            //int size = 5;
            //HashSet<ulong> puzzleData = LoadPuzzlesFromFile(@$"C:\Users\rober\Documents\PuzzleData for size {size} by {size} no holes.tx");

            //foreach (var data in puzzleData)
            //{
            //    Console.WriteLine(data);
            //    puzzle.SetData(data);
            //    puzzle.PrintPuzzle();
            //    Console.WriteLine();
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


        }

        public class Puzzle
        {
            private ulong data;
            private int size;
            private List<int> powersOfTwos = new List<int>();
            

            public Puzzle(int size)
            {
                if (size < 2 || size > 8)
                {
                    throw new ArgumentOutOfRangeException("Size must be between 2 and 8.");
                }
                this.size = size;
                data = 0;
            }


            public void SetData(ulong newData)
            {
                data = newData;
            }


            public ulong GetData()
            {
                return data;
            }


            public void SetCell(int row, int col, bool value)
            {
                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
                }

                int bitPosition = row * size + col;
                if (value)
                {
                    data |= (1UL << bitPosition);
                }
                else
                {
                    data &= ~(1UL << bitPosition);
                }
            }


            public bool GetCell(int row, int col)
            {
                if (row < 0 || row >= size || col < 0 || col >= size)
                {
                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
                }

                int bitPosition = row * size + col;
                return (data & (1UL << bitPosition)) != 0;
            }


            public string PrintPuzzle()
            {
                StringBuilder sb = new StringBuilder();
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        sb.Append(GetCell(row, col) ? "1 " : "0 ");
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
                        if (GetCell(row, col))
                        {
                            int newRow = col;
                            int newCol = size - 1 - row;
                            int bitPosition = newRow * size + newCol;
                            newData |= (1UL << bitPosition);
                        }
                    }
                }
                data = newData;
            }


            public void MirrorHorizontally()
            {
                ulong newGrid = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (GetCell(row, col))
                        {
                            int newCol = size - 1 - col;
                            int bitPosition = row * size + newCol;
                            newGrid |= (1UL << bitPosition);
                        }
                    }
                }
                data = newGrid;
            }

            // This is nice, but it needs to be made more generic so it seaches all sub puzzles, not just ones with holes.
            //public bool HasHoles()
            //{
            //    for (int row = 0; row < size; row++)
            //    {
            //        for (int col = 0; col < size; col++)
            //        {
            //            if (GetCell(row, col) == false)
            //            {
            //                // Check top left corner
            //                if(row == 0 &&  col == 0)
            //                {
            //                    if(GetCell(row, col + 1) == true && GetCell(row + 1, col) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole in the top left corner.");
            //                        return true;
            //                    }
            //                }

            //                // Check top edge
            //                if(row == 0 && col > 0 && col < size - 1)
            //                {
            //                    if(GetCell(row, col - 1) == true && GetCell(row + 1, col) == true && GetCell(row, col + 1) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole along the top edge.");
            //                        return true;
            //                    }
            //                }

            //                // Check top right corner
            //                if(row == 0 && col == size - 1)
            //                {
            //                    if (GetCell(row, col - 1) == true && GetCell(row + 1, col) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole in the top right corner.");
            //                        return true;
            //                    }
            //                }

            //                // Check left edge
            //                if (row > 0 && row < size - 1 && col == 0)
            //                {
            //                    if (GetCell(row - 1, col) == true && GetCell(row, col + 1) == true && GetCell(row + 1, col) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole along the left edge.");
            //                        return true;
            //                    }
            //                }

            //                // Check middle
            //                if (row > 0 && row < size -1 && col > 0 && col < size - 1)
            //                {
            //                    if (GetCell(row - 1, col) == true && GetCell(row, col + 1) == true && GetCell(row + 1, col) == true && GetCell(row, col - 1) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole in the middle.");
            //                        return true;
            //                    }
            //                }

            //                // Check right edge
            //                if (row > 0 && row < size - 1 && col == size - 1)
            //                {
            //                    if (GetCell(row - 1, col) == true && GetCell(row, col - 1) == true && GetCell(row + 1, col) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole along the right edge.");
            //                        return true;
            //                    }
            //                }


            //                // Check bottom left corner
            //                if (row == size - 1 && col == 0)
            //                {
            //                    if (GetCell(row - 1, col) == true && GetCell(row, col + 1) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole in the bottom left corner.");
            //                        return true;
            //                    }
            //                }

            //                //Check bottom edge
            //                if (row == size - 1 && col > 0 && col < size - 1)
            //                {
            //                    if (GetCell(row, col - 1) == true && GetCell(row - 1, col) == true && GetCell(row, col + 1) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole along the bottom edge.");
            //                        return true;
            //                    }
            //                }

            //                // Check bottom right corner
            //                if (row == size - 1 && col == size - 1)
            //                {
            //                    if (GetCell(row, col - 1) == true && GetCell(row - 1, col) == true)
            //                    {
            //                        //Console.WriteLine("This puzzle has a hole in the bottom right corner.");
            //                        return true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    return false;
            //}


            //public bool HasSubPuzzles(StringBuilder sb)

            public bool HasSubPuzzles()
            {
                // Loop over every size below the current puzzle size
                for(int n = size - 1; n > 0; n--)
                {
                    for(int row = 0; row < size - n + 1; row++)
                    {
                        for(int col = 0; col < size - n + 1; col++)
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
                            if(row > 0 && hasSubPuzzles == true)
                            {
                                // Loop over each cell in the row
                                for(int i = 0; i < n; i++)
                                {
                                    // If a cell is empty, return false
                                    if(GetCell(row - 1, col + i) == false)
                                    {
                                        hasSubPuzzles = false;
                                        break;
                                    }
                                }
                            }

                            // Check the left edge
                            if(col > 0 && hasSubPuzzles == true)
                            {
                                for(int i = 0; i < n; i++)
                                {
                                    if( GetCell(row + i, col - 1) == false)
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
                                for(int i = 0; i < n; i++)
                                {
                                    if (GetCell(row + n, col + i) == false)
                                    {
                                        hasSubPuzzles = false;
                                        break;
                                    }
                                }
                            }

                            // Check right edge
                            if(col + n < size && hasSubPuzzles == true)
                            {
                                for(int i = 0; i < n; i++)
                                {
                                    if (GetCell(row + i, col + n) == false)
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

            //public void FillSubMatrix(int row, int col, int n)
            //{
            //    int row ** row;
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
                using(BinaryWriter w = new BinaryWriter(fs))
                {
                    foreach(var element in puzzles)
                    {
                        w.Write(element);
                    }
                }
            }
        }

        //static HashSet<ulong> LoadPuzzlesFromFileBin(string filePath)
        //{
        //    HashSet<ulong> puzzles = new HashSet<ulong>();
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        using (BinaryReader r = new BinaryReader(fs))
        //        {
        //            while(r.ReadInt64() != 0)
        //            {

        //            }
        //        }
        //    }
        //}

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

        #region Puzzle Generation

        public static void GeneratePuzzles(int size, bool save)
        {
            HashSet<ulong> uniqueData = new HashSet<ulong>();

            object lockObject = new object();

            ulong maxIterations = 1UL << (size * size);
            int chunkSize = 1000000;

            Parallel.For(0, (int)((maxIterations + (ulong)chunkSize - 1) / (ulong)chunkSize), chunkIndex =>
            {
                ulong start = (ulong)chunkIndex * (ulong)chunkSize;
                ulong end = Math.Min(start + (ulong)chunkSize, maxIterations);

                // DO NOT MOVE! For some reason, this has to be inside the parallel for loop
                Puzzle puzzle = new Puzzle(size);
                for (ulong i = start; i < end; i++)
                {
                    puzzle.SetData(i);

                    //// Check for holes before doing all the rotation checks
                    if (puzzle.HasSubPuzzles())
                    {
                        continue;
                    }

                    List<ulong> transformations = new List<ulong>
                    {
                        puzzle.GetData()
                    };

                    puzzle.Rotate90Clockwise();
                    transformations.Add(puzzle.GetData());

                    puzzle.Rotate90Clockwise();
                    transformations.Add(puzzle.GetData());

                    puzzle.Rotate90Clockwise();
                    transformations.Add(puzzle.GetData());

                    puzzle.MirrorHorizontally();
                    transformations.Add(puzzle.GetData());

                    puzzle.Rotate90Clockwise();
                    transformations.Add(puzzle.GetData());

                    puzzle.Rotate90Clockwise();
                    transformations.Add(puzzle.GetData());

                    puzzle.Rotate90Clockwise();
                    transformations.Add(puzzle.GetData());

                    ulong minHash = ulong.MaxValue;
                    foreach (var data in transformations)
                    {
                        minHash = Math.Min(minHash, data);
                    }

                    lock (lockObject)
                    {

                        //This is for testing only. Please delete afterwards
                        //uniqueData.Add(i);
                        uniqueData.Add(minHash);
                    }

                }
            });
            // Console.WriteLine($"Number of unique {size}x{size} grids with no holes is: {uniqueData.Count}");
            //Save the unique data to a file or process it further
            List<ulong> sortedList = new List<ulong>(uniqueData);
            sortedList.Sort();
            
            // Sometimes we don't want to save, such as during testing
            if(save == true)
            {
                SavePuzzlesToFileBin(sortedList, @$"C:\Users\rober\Documents\PuzzleData for size {size} by {size} no holes.bin");
            }
        }
        #endregion

        #region Burnside's Lemma
        // Burnside's Lemma is used to calculate the number of puzzle minus the all the duplicates
        // https://en.wikipedia.org/wiki/Burnside%27s_lemma
        // These formulas come from Marko Riedel's answer on the following post:
        // https://math.stackexchange.com/questions/570003/how-many-unique-patterns-exist-for-a-n-times-n-grid
        // More info can also be found here:
        // https://www.youtube.com/watch?v=D0d9bYZ_qDY
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
    }
}
