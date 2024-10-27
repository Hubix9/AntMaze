using System.Diagnostics;

namespace AntMazeWinforms {
    public class Ant
    {

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }


        public int Pos_x { get; set; }
        public int Pos_y { get; set; }
        public Direction Dir { get; set; }
        public List<(int, int)> Memory { get; set; }


        public Ant(int start_x, int start_y)
        {
            Pos_x = start_x;
            Pos_y = start_y;
            Memory = new List<(int, int)>();
        }

        public void SetPosition(int x, int y)
        {
            Pos_x = x;
            Pos_y = y;
            Memory.Clear();
            Dir = Direction.Up;
        }

        public void Move(Maze maze)
        {
            this.LogPosition();
            switch (Dir)
            {
                case Direction.Up:
                    if (this.GetForward(maze) != Field.Wall)
                    {
                        Pos_y--;
                    }
                    break;
                case Direction.Down:
                    if (this.GetForward(maze) != Field.Wall)
                    {
                        Pos_y++;
                    }
                    break;
                case Direction.Left:
                    if (this.GetForward(maze) != Field.Wall)
                    {
                        Pos_x--;
                    }
                    break;
                case Direction.Right:
                    if (this.GetForward(maze) != Field.Wall)
                    {
                        Pos_x++;
                    }
                    break;
            }

            Debug.WriteLine($"Ant position: {Pos_x}, {Pos_y}");
        }

        public Field GetForward(Maze maze)
        {
            switch (Dir)
            {
                case Direction.Up:
                    return maze.GetFieldTypeByCoordinates(Pos_x, Pos_y - 1);
                case Direction.Down:
                    return maze.GetFieldTypeByCoordinates(Pos_x, Pos_y + 1);
                case Direction.Left:
                    return maze.GetFieldTypeByCoordinates(Pos_x - 1, Pos_y);
                case Direction.Right:
                    return maze.GetFieldTypeByCoordinates(Pos_x + 1, Pos_y);
            }
            return Field.Wall;
        }

        public Field GetLeft(Maze maze)
        {
            switch (Dir)
            {
                case Direction.Up:
                    return maze.GetFieldTypeByCoordinates(Pos_x - 1, Pos_y);
                case Direction.Down:
                    return maze.GetFieldTypeByCoordinates(Pos_x + 1, Pos_y);
                case Direction.Left:
                    return maze.GetFieldTypeByCoordinates(Pos_x, Pos_y + 1);
                case Direction.Right:
                    return maze.GetFieldTypeByCoordinates(Pos_x, Pos_y - 1);
            }
            return Field.Wall;
        }

        public Field GetRight(Maze maze)
        {
            switch (Dir)
            {
                case Direction.Up:
                    return maze.GetFieldTypeByCoordinates(Pos_x + 1, Pos_y);
                case Direction.Down:
                    return maze.GetFieldTypeByCoordinates(Pos_x - 1, Pos_y);
                case Direction.Left:
                    return maze.GetFieldTypeByCoordinates(Pos_x, Pos_y - 1);
                case Direction.Right:
                    return maze.GetFieldTypeByCoordinates(Pos_x, Pos_y + 1);
            }
            return Field.Wall;
        }

        public void TurnLeft()
        {
            switch (Dir)
            {
                case Direction.Up:
                    Dir = Direction.Left;
                    break;
                case Direction.Down:
                    Dir = Direction.Right;
                    break;
                case Direction.Left:
                    Dir = Direction.Down;
                    break;
                case Direction.Right:
                    Dir = Direction.Up;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Dir)
            {
                case Direction.Up:
                    Dir = Direction.Right;
                    break;
                case Direction.Down:
                    Dir = Direction.Left;
                    break;
                case Direction.Left:
                    Dir = Direction.Up;
                    break;
                case Direction.Right:
                    Dir = Direction.Down;
                    break;
            }
        }

        public void LogPosition()
        {
            Memory.Add((Pos_x, Pos_y));
        }

        public void printHistory()
        {
            for (int i = 0; i < Memory.Count; i++)
            {
                Debug.WriteLine($"Step {i}: {Memory[i]}");
            }
        }
    }
}