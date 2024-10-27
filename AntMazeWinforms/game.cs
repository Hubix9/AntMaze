using System.Diagnostics;

namespace AntMazeWinforms {

    public class Game
    {
        private Maze maze;
        private Ant ant;

        public Game()
        {
            maze = new Maze();
            var starting_position = maze.GetStartingPosition();
            ant = new Ant(starting_position.Item1, starting_position.Item2);
            Debug.WriteLine($"Starting position is: {starting_position}");
        }

        public int[,] GetMap()
        {
            return maze.GetMap();
        }

        public void SetCell(int x, int y, Field value)
        {
            Debug.WriteLine($"Settings cell: {x}, {y}, {value}");
            maze.SetCell(x, y, value);
        }

        public int GetAntX()
        {
            return ant.Pos_x;
        }

        public int GetAntY()
        {
            return ant.Pos_y;
        }

        public Ant.Direction GetAntDirection()
        {
            return ant.Dir;
        }

        public void SetAntPosition(int x, int y)
        {
            ant.SetPosition(x, y);
        }

        public void SolveMaze()
        {
            Random rand = new Random();

            Debug.WriteLine($"Start Pos: {maze.GetStartingPosition()}");
            Debug.WriteLine($"End Pos: {maze.GetEndingPosition()}");
            while (true)
            {
                if (maze.GetFieldTypeByCoordinates(ant.Pos_x, ant.Pos_y) == Field.PlayerEnd)
                {
                    Debug.WriteLine("Maze solved!");
                    ant.LogPosition();
                    ant.printHistory();
                    break;
                }

                int action = rand.Next(0, 4);
                try
                {
                    switch (action)
                    {
                        case 0:
                            ant.TurnLeft();
                            break;
                        case 1:
                            ant.TurnRight();
                            break;
                        case 2:
                            ant.Move(maze);
                            break;
                        case 3:
                            while (ant.GetForward(maze) != Field.Wall)
                            {
                                ant.Move(maze);
                            }
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException) {}
            }
            
        }

        public List<(int, int)> GetMoveHistory() {
            return ant.Memory;
        }

        public void Reset()
        {
            ant.SetPosition(maze.GetStartingPosition().Item1, maze.GetStartingPosition().Item2);
        }
    }
}