using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace AntMazeWinforms
{


    public partial class Form1 : Form
    {

        private enum PaintMode
        {
            None,
            PaintEmpty,
            PaintWall,
            SetStart,
            SetEnd
        }
        private Game game;
        private Image antImage;
        private int boardSize = 10;
        private int squareSize = 40;
        private System.Windows.Forms.Timer timer;

        private PaintMode _activePaintMode;
        private PaintMode activePaintMode
        {
            get { return _activePaintMode; }
            set
            {
                _activePaintMode = value;
                ((Label)this.Controls.Find("ModeLabel", false)[0]).Text = value.ToString();
            }
        }
        private Color[] colors = new Color[]
        {
                Color.White, Color.Black, Color.Purple, Color.Green, Color.Blue,
                Color.Indigo, Color.Violet, Color.Pink, Color.Brown, Color.Gray
        };



        public Form1()
        {
            InitializeComponent();
            game = new Game();
            antImage = Image.FromFile("ant.png");
            activePaintMode = PaintMode.None;
        }

        private void refresh_panel1()
        {
            ((Panel)this.Controls.Find("Panel1", false)[0]).Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            int[,] map = game.GetMap();


            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {

                    int x = j * squareSize;
                    int y = i * squareSize;
                    int size = squareSize;


                    Color color = colors[(int)map[i, j]];


                    g.FillRectangle(new SolidBrush(color), x, y, size, size);
                }
            }

            if (game.GetMoveHistory().Count > 0)
            {
                for (int i = 0; i < (game.GetMoveHistory().Count - 1); i++)
                {
                    (int, int) point1 = game.GetMoveHistory()[i];
                    (int, int) point2 = game.GetMoveHistory()[i + 1];

                    point1.Item1 *= squareSize;
                    point1.Item2 *= squareSize;
                    point2.Item1 *= squareSize;
                    point2.Item2 *= squareSize;

                    point1.Item1 = point1.Item1 + squareSize / 2;
                    point1.Item2 = point1.Item2 + squareSize / 2;
                    point2.Item1 = point2.Item1 + squareSize / 2;
                    point2.Item2 = point2.Item2 + squareSize / 2;

                    g.DrawLine(Pens.Green,
                        point1.Item1,
                        point1.Item2,
                        point2.Item1,
                        point2.Item2);
                }
            }

            int ant_x = game.GetAntX() * squareSize;
            int ant_y = game.GetAntY() * squareSize;

            Bitmap transformedAnt = new Bitmap(antImage);
            switch (game.GetAntDirection())
            {
                case Ant.Direction.Up:
                    break;
                case Ant.Direction.Left:
                    transformedAnt.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case Ant.Direction.Right:
                    transformedAnt.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case Ant.Direction.Down:
                    transformedAnt.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
            }
            g.DrawImage(transformedAnt, ant_x, ant_y, squareSize, squareSize);
            transformedAnt.Dispose();

        }
        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            Debug.WriteLine($"Coordinates: {coordinates}");

            int x = coordinates.X / squareSize;
            int y = coordinates.Y / squareSize;

            switch (activePaintMode)
            {
                case PaintMode.PaintEmpty:
                    game.SetCell(x, y, Field.Empty);
                    break;
                case PaintMode.PaintWall:
                    game.SetCell(x, y, Field.Wall);
                    break;
                case PaintMode.SetStart:
                    game.SetCell(x, y, Field.PlayerStart);
                    game.SetAntPosition(x, y);
                    break;
                case PaintMode.SetEnd:
                    game.SetCell(x, y, Field.PlayerEnd);
                    break;
            }
            ((Panel)this.Controls.Find("Panel1", false)[0]).Refresh();
        }

        private void PaintEmptyButton_Click(object sender, EventArgs e)
        {
            activePaintMode = PaintMode.PaintEmpty;
        }

        private void PaintWallButton_Click(object sender, EventArgs e)
        {
            activePaintMode = PaintMode.PaintWall;
        }

        private void SetStartButton_Click(object sender, EventArgs e)
        {
            activePaintMode = PaintMode.SetStart;
        }

        private void SetEndButton_Click(object sender, EventArgs e)
        {
            activePaintMode = PaintMode.SetEnd;
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            Label statusLabel = ((Label)this.Controls.Find("CurrentStatusLabel", false)[0]);
            statusLabel.Text = "Solving";
            statusLabel.Refresh();
            game.SolveMaze();
            statusLabel.Text = "Solved!";
            statusLabel.Refresh();
            ((Panel)this.Controls.Find("Panel1", false)[0]).Refresh();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            game.Reset();
            ((Panel)this.Controls.Find("Panel1", false)[0]).Refresh();

            ((Label)this.Controls.Find("CurrentStatusLabel", false)[0]).Text = "Idle";
        }
    }
}
