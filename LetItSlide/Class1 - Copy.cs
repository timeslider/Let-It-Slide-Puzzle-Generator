using System.Drawing;

namespace LetItSlide
{
    internal class Class1
    {
        internal static void Main(string[] args)
        {
            // These puzzle have symmetries removed
            #region Generates v1 puzzles
            //int size = 3;
            //HashSet<ulong> uniqueData = new HashSet<ulong>();
            //object lockObject = new object();

            //ulong maxIterations = 1UL << (size * size);
            //int chunkSize = 1000000;

            //Parallel.For(0, (int)((maxIterations + (ulong)chunkSize - 1) / (ulong)chunkSize), chunkIndex =>
            //{
            //    ulong start = (ulong)chunkIndex * (ulong)chunkSize;
            //    ulong end = Math.Min(start + (ulong)chunkSize, maxIterations);

            //    for (ulong i = start; i < end; i++)
            //    {
            //        Puzzle puzzle = new Puzzle(size);
            //        puzzle.SetData(i);

            //        // Check for holes before doing all the rotation checks


            //        List<ulong> transformations = new List<ulong>
            //        {
            //            puzzle.GetData()
            //        };

            //        puzzle.Rotate90Clockwise();
            //        transformations.Add(puzzle.GetData());

            //        puzzle.Rotate90Clockwise();
            //        transformations.Add(puzzle.GetData());

            //        puzzle.Rotate90Clockwise();
            //        transformations.Add(puzzle.GetData());

            //        puzzle.MirrorHorizontally();
            //        transformations.Add(puzzle.GetData());

            //        puzzle.Rotate90Clockwise();
            //        transformations.Add(puzzle.GetData());

            //        puzzle.Rotate90Clockwise();
            //        transformations.Add(puzzle.GetData());

            //        puzzle.Rotate90Clockwise();
            //        transformations.Add(puzzle.GetData());

            //        ulong minHash = ulong.MaxValue;
            //        foreach (var data in transformations)
            //        {
            //            minHash = Math.Min(minHash, data);
            //        }

            //        lock (lockObject)
            //        {
            //            uniqueData.Add(minHash);
            //        }
            //    }
            //});
            //Console.WriteLine($"Number of unique {size}x{size} grids: {uniqueData.Count}");
            //// Save the unique data to a file or process it further
            //SavePuzzlesToFile(uniqueData, @$"C:\Users\rober\Documents\PuzzleData for size {size} by {size}.txt");
            #endregion

            // These are v1 puzzle but they have single holes removed
            #region Generates v2 puzzles
            int size = 5;
            HashSet<ulong> uniqueData = new HashSet<ulong>();
            object lockObject = new object();

            ulong maxIterations = 1UL << (size * size);
            int chunkSize = 1000000;

            Parallel.For(0, (int)((maxIterations + (ulong)chunkSize - 1) / (ulong)chunkSize), chunkIndex =>
            {
                ulong start = (ulong)chunkIndex * (ulong)chunkSize;
                ulong end = Math.Min(start + (ulong)chunkSize, maxIterations);

                for (ulong i = start; i < end; i++)
                {
                    Puzzle puzzle = new Puzzle(size);
                    puzzle.SetData(i);

                    // Check for holes before doing all the rotation checks
                    if (puzzle.HasHoles())
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
                        uniqueData.Add(minHash);
                    }
                }
            });
            Console.WriteLine($"Number of unique {size}x{size} grids with no holes is: {uniqueData.Count}");
            // Save the unique data to a file or process it further
            SavePuzzlesToFile(uniqueData, @$"C:\Users\rober\Documents\PuzzleData for size {size} by {size} no holes.txt");
            #endregion

            //int size = 4;
            //HashSet<ulong> puzzleData = LoadPuzzlesFromFile(@$"C:\Users\rober\Documents\PuzzleData for size {size} by {size}.txt");
            //Puzzle puzzle = new Puzzle(size);
            
            //foreach(var data in puzzleData)
            //{
            //    Console.WriteLine(data);
            //    puzzle.SetData(data);
            //    puzzle.HasHoles();
            //    puzzle.PrintPuzzle();
            //    Console.WriteLine();
            //}

        }

        public class Puzzle
        {
            private ulong data;
            private int size;

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
            public void PrintPuzzle()
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write(GetCell(row, col) ? "1 " : "0 ");
                    }
                    Console.WriteLine();
                }
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

            public bool HasHoles()
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (GetCell(row, col) == false)
                        {
                            // Check top left corner
                            if(row == 0 &&  col == 0)
                            {
                                if(GetCell(row, col + 1) == true && GetCell(row + 1, col) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole in the top left corner.");
                                    return true;
                                }
                            }

                            // Check top edge
                            if(row == 0 && col > 0 && col < size - 1)
                            {
                                if(GetCell(row, col - 1) == true && GetCell(row + 1, col) == true && GetCell(row, col + 1) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole along the top edge.");
                                    return true;
                                }
                            }

                            // Check top right corner
                            if(row == 0 && col == size - 1)
                            {
                                if (GetCell(row, col - 1) == true && GetCell(row + 1, col) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole in the top right corner.");
                                    return true;
                                }
                            }

                            // Check left edge
                            if (row > 0 && row < size - 1 && col == 0)
                            {
                                if (GetCell(row - 1, col) == true && GetCell(row, col + 1) == true && GetCell(row + 1, col) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole along the left edge.");
                                    return true;
                                }
                            }

                            // Check middle
                            if (row > 0 && row < size -1 && col > 0 && col < size - 1)
                            {
                                if (GetCell(row - 1, col) == true && GetCell(row, col + 1) == true && GetCell(row + 1, col) == true && GetCell(row, col - 1) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole in the middle.");
                                    return true;
                                }
                            }

                            // Check right edge
                            if (row > 0 && row < size - 1 && col == size - 1)
                            {
                                if (GetCell(row - 1, col) == true && GetCell(row, col - 1) == true && GetCell(row + 1, col) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole along the right edge.");
                                    return true;
                                }
                            }


                            // Check bottom left corner
                            if (row == size - 1 && col == 0)
                            {
                                if (GetCell(row - 1, col) == true && GetCell(row, col + 1) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole in the bottom left corner.");
                                    return true;
                                }
                            }

                            //Check bottom edge
                            if (row == size - 1 && col > 0 && col < size - 1)
                            {
                                if (GetCell(row, col - 1) == true && GetCell(row - 1, col) == true && GetCell(row, col + 1) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole along the bottom edge.");
                                    return true;
                                }
                            }

                            // Check bottom right corner
                            if (row == size - 1 && col == size - 1)
                            {
                                if (GetCell(row, col - 1) == true && GetCell(row - 1, col) == true)
                                {
                                    //Console.WriteLine("This puzzle has a hole in the bottom right corner.");
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
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
    }
}
