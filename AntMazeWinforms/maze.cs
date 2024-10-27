using System.Data;
using System.Diagnostics;

namespace AntMazeWinforms {

    public enum Field {
        Empty,
        Wall,
        PlayerStart,
        PlayerEnd
    }


    public class Maze {
        private int[,] map = {
            {1,1,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,0,0,0,0,1},
            {1,0,1,1,0,0,1,1,0,1},
            {1,0,0,0,0,1,1,1,0,1},
            {1,1,1,1,0,3,0,0,0,1},
            {1,0,0,0,1,0,1,1,1,1},
            {1,0,1,0,1,0,1,1,1,1},
            {1,0,1,1,1,2,0,0,0,1},
            {1,0,0,0,0,0,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
        };

        private int max_x;
        private int max_y;

        public Maze() {
            max_y = map.GetLength(0);
            max_x = map.GetLength(1);
            Console.WriteLine($"Column count: {max_x}");
            Console.WriteLine($"Row count: {max_y}");
        }

        public Field GetFieldTypeByCoordinates(int x, int y) {
            if (x < 0 || x > max_x || y < 0 || y > max_y)  {
                throw new ArgumentOutOfRangeException();
            }

            switch (map[y, x]) {
                case 0:
                    return Field.Empty;
                case 1:
                    return Field.Wall;
                case 2:
                    return Field.PlayerStart;
                case 3:
                    return Field.PlayerEnd;
            }

            throw new ArgumentException();
        }

        public void PrintMaze() {
            foreach (var row in map)
            {
                Console.WriteLine(string.Join(" ", row)); 
            }
        }

        public (int, int) GetStartingPosition() {
            for (int y = 0; y < max_y; y++) {
                for (int x = 0; x < max_x; x++) {
                    Field field = this.GetFieldTypeByCoordinates(x, y);
                    if (field == Field.PlayerStart) {
                        return (x, y);
                    }
                }
            }
            throw new DataException();
        }

        public (int, int) GetEndingPosition()
        {
            for (int y = 0; y < max_y; y++)
            {
                for (int x = 0; x < max_x; x++)
                {
                    Field field = this.GetFieldTypeByCoordinates(x, y);
                    if (field == Field.PlayerEnd)
                    {
                        return (x, y);
                    }
                }
            }
            throw new DataException();
        }

        public void SetCell(int x, int y, Field field)
        {

            if (x < 0 || x >= max_x || y < 0 || y >= max_y)
            {
                Debug.WriteLine("Out of bounds, ignoring...");
                return;
            }

            if (field == Field.PlayerStart)
            {
                try
                {
                    (int start_x, int start_y) = GetStartingPosition();
                    map[start_y, start_x] = (int)Field.Empty;
                }
                catch (DataException) { }
            }

            if (field == Field.PlayerEnd)
            {
                try
                {
                    (int start_x, int start_y) = GetEndingPosition();
                    map[start_y, start_x] = (int)Field.Empty;
                }
                catch (DataException) { }
            }
            map[y, x] = (int)field;
        }

        public int[,] GetMap()
        {
            return map;
        }

        public int GetMaxX()
        {
            return max_x;
        }

        public int GetMaxY()
        {
            return max_y;
        }
    }
}