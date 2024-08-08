//using System.Collections.Concurrent;
//using System.Text;

//namespace LetItSlide
//{
//    internal class Class1
//    {
//        internal static void Main(string[] args)
//        {
//            #region Generate First v1 Puzzles
//            int size = 6;
//            HashSet<ulong> uniqueData = new HashSet<ulong>();
//            for (ulong i = 0; i < (1UL << (size * size)); i++)
//            {
//                Puzzle puzzle = new Puzzle(size);
//                puzzle.SetData(i);

//                List<ulong> transformations = new List<ulong>
//                {
//                    puzzle.GetData()
//                };

//                puzzle.Rotate90Clockwise();
//                transformations.Add(puzzle.GetData());

//                puzzle.Rotate90Clockwise();
//                transformations.Add(puzzle.GetData());

//                puzzle.Rotate90Clockwise();
//                transformations.Add(puzzle.GetData());

//                puzzle.MirrorHorizontally();
//                transformations.Add(puzzle.GetData());

//                puzzle.Rotate90Clockwise();
//                transformations.Add(puzzle.GetData());

//                puzzle.Rotate90Clockwise();
//                transformations.Add(puzzle.GetData());

//                puzzle.Rotate90Clockwise();
//                transformations.Add(puzzle.GetData());

//                ulong minHash = ulong.MaxValue;
//                foreach (var data in transformations)
//                {
//                    minHash = Math.Min(minHash, data);
//                }
//                uniqueData.Add(minHash);
//            }

//            Console.WriteLine($"Number of unique {size}x{size} grids: {uniqueData.Count}");

//            //StringBuilder sb = new StringBuilder();
//            //foreach (var data in uniqueData)
//            //{
//            //    Puzzle puzzle = new Puzzle(size);
//            //    puzzle.SetData(data);
//            //    Console.WriteLine(data);
//            //    puzzle.PrintPuzzle();
//            //    Console.WriteLine();
//            //}
//            //SavePuzzlesToFile(uniqueGrids, @$"C:\Users\rober\Documents\PuzzleData for size {size} by {size}.txt");
//            #endregion
//        }

//        public class Puzzle
//        {
//            /// <summary>
//            /// data is a 64-bit ulong where the bits determine where tiles will go later
//            /// </summary>
//            private ulong data;
            
//            /// <summary>
//            /// Puzzle are always square
//            /// </summary>
//            private int size;

//            public Puzzle(int size)
//            {
//                if (size < 2 || size > 8)
//                {
//                    throw new ArgumentOutOfRangeException("Size must be between 2 and 8.");
//                }
//                this.size = size;
//                data = 0;
//            }
//            public void SetData(ulong newData)
//            {
//                data = newData;
//            }
//            public ulong GetData()
//            {
//                return data;
//            }

//            public void SetCell(int row, int col, bool value)
//            {
//                if (row < 0 || row >= size || col < 0 || col >= size)
//                {
//                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
//                }

//                int bitPosition = row * size + col;
//                if (value)
//                {
//                    data |= (1UL << bitPosition);
//                }
//                else
//                {
//                    data &= ~(1UL << bitPosition);
//                }
//            }

//            public bool GetCell(int row, int col)
//            {
//                if (row < 0 || row >= size || col < 0 || col >= size)
//                {
//                    throw new ArgumentOutOfRangeException("Row and column must be within the grid size.");
//                }

//                int bitPosition = row * size + col;
//                return (data & (1UL << bitPosition)) != 0;
//            }

//            public void PrintPuzzle()
//            {
//                for (int row = 0; row < size; row++)
//                {
//                    for (int col = 0; col < size; col++)
//                    {
//                        Console.Write(GetCell(row, col) ? "1 " : "0 ");
//                    }
//                    Console.WriteLine();
//                }
//            }

//            public void Rotate90Clockwise()
//            {
//                ulong newData = 0;
//                for (int row = 0; row < size; row++)
//                {
//                    for (int col = 0; col < size; col++)
//                    {
//                        if (GetCell(row, col))
//                        {
//                            int newRow = col;
//                            int newCol = size - 1 - row;
//                            int bitPosition = newRow * size + newCol;
//                            newData |= (1UL << bitPosition);
//                        }
//                    }
//                }
//                data = newData;
//            }


//            public void MirrorHorizontally()
//            {
//                ulong newGrid = 0;
//                for (int row = 0; row < size; row++)
//                {
//                    for (int col = 0; col < size; col++)
//                    {
//                        if (GetCell(row, col))
//                        {
//                            int newCol = size - 1 - col;
//                            int bitPosition = row * size + newCol;
//                            newGrid |= (1UL << bitPosition);
//                        }
//                    }
//                }
//                data = newGrid;
//            }

//            // These aren't needed but I'll keep them around in case I need to implement them in Godot
//            #region
//            //public void Rotate180()
//            //{
//            //    ulong newGrid = 0;
//            //    for (int row = 0; row < size; row++)
//            //    {
//            //        for (int col = 0; col < size; col++)
//            //        {
//            //            if (GetCell(row, col))
//            //            {
//            //                int newRow = size - 1 - row;
//            //                int newCol = size - 1 - col;
//            //                int bitPosition = newRow * size + newCol;
//            //                newGrid |= (1UL << bitPosition);
//            //            }
//            //        }
//            //    }
//            //    data = newGrid;
//            //}

//            //public void Rotate270Clockwise()
//            //{
//            //    ulong newGrid = 0;
//            //    for (int row = 0; row < size; row++)
//            //    {
//            //        for (int col = 0; col < size; col++)
//            //        {
//            //            if (GetCell(row, col))
//            //            {
//            //                int newRow = size - 1 - col;
//            //                int newCol = row;
//            //                int bitPosition = newRow * size + newCol;
//            //                newGrid |= (1UL << bitPosition);
//            //            }
//            //        }
//            //    }
//            //    data = newGrid;
//            //}

//            //public void MirrorVertically()
//            //{
//            //    ulong newGrid = 0;
//            //    for (int row = 0; row < size; row++)
//            //    {
//            //        for (int col = 0; col < size; col++)
//            //        {
//            //            if (GetCell(row, col))
//            //            {
//            //                int newRow = size - 1 - row;
//            //                int bitPosition = newRow * size + col;
//            //                newGrid |= (1UL << bitPosition);
//            //            }
//            //        }
//            //    }
//            //    data = newGrid;
//            //}

//            //    public void MirrorDiagonal()
//            //    {
//            //        ulong newGrid = 0;
//            //        for (int row = 0; row < size; row++)
//            //        {
//            //            for (int col = 0; col < size; col++)
//            //            {
//            //                if (GetCell(row, col))
//            //                {
//            //                    int newRow = col;
//            //                    int newCol = row;
//            //                    int bitPosition = newRow * size + newCol;
//            //                    newGrid |= (1UL << bitPosition);
//            //                }
//            //            }
//            //        }
//            //        data = newGrid;
//            //    }

//            //    public void MirrorAntiDiagonal()
//            //    {
//            //        ulong newGrid = 0;
//            //        for (int row = 0; row < size; row++)
//            //        {
//            //            for (int col = 0; col < size; col++)
//            //            {
//            //                if (GetCell(row, col))
//            //                {
//            //                    int newRow = size - 1 - col;
//            //                    int newCol = size - 1 - row;
//            //                    int bitPosition = newRow * size + newCol;
//            //                    newGrid |= (1UL << bitPosition);
//            //                }
//            //            }
//            //        }
//            //        data = newGrid;
//            //    }
//            #endregion
//        }

//        static void SavePuzzlesToFile(HashSet<ulong> puzzles, string filePath)
//        {
//            using (StreamWriter writer = new StreamWriter(filePath))
//            {
//                foreach (var puzzle in puzzles)
//                {
//                    writer.WriteLine(puzzle);
//                }
//            }
//        }

//        static HashSet<ulong> LoadPuzzlesFromFile(string filePath)
//        {
//            HashSet<ulong> puzzles = new HashSet<ulong>();

//            using (StreamReader reader = new StreamReader(filePath))
//            {
//                string line;
//                while ((line = reader.ReadLine()) != null)
//                {
//                    if (ulong.TryParse(line, out ulong puzzle))
//                    {
//                        puzzles.Add(puzzle);
//                    }
//                }
//            }

//            return puzzles;
//        }

//        #region Burnside's Lemma
//        // Burnside's Lemma is used to calculate the number of puzzle minus the all the duplicates
//        // https://en.wikipedia.org/wiki/Burnside%27s_lemma
//        // These formulas come from Marko Riedel's answer on the following post:
//        // https://math.stackexchange.com/questions/570003/how-many-unique-patterns-exist-for-a-n-times-n-grid
//        // More info can also be found here:
//        // https://www.youtube.com/watch?v=D0d9bYZ_qDY
//        public static void PrintBurnsidesLemma(double colors, double size)
//        {
//            double sizeSqr = size * size;
//            double sizeSqrPlusSizeOverTwo = (sizeSqr + size) / 2;
//            // First term
//            double output = Math.Pow(colors, sizeSqr);

//            // The case that size was even
//            if (size % 2 == 0)
//            {
//                // Second term
//                output += 3 * Math.Pow(colors, sizeSqr / 2);
//                // Third term
//                output += 2 * Math.Pow(colors, sizeSqrPlusSizeOverTwo);
//                // Fourth term
//                output += 2 * Math.Pow(colors, sizeSqr / 4);
//            }
//            else
//            {
//                // Second term
//                output += 4 * Math.Pow(colors, sizeSqrPlusSizeOverTwo);
//                // Third term
//                output += 2 * Math.Pow(colors, (sizeSqr + 3) / 4);
//                // Fourth term
//                output += Math.Pow(colors, (sizeSqr + 1) / 2);
//            }
//            Console.WriteLine((output / 8).ToString("N19"));
//        }
//        #endregion
//    }
//}
