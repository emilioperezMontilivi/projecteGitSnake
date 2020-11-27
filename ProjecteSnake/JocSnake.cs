using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjecteSnake
{
    class JocSnake
    {
        public const int WIDTH = 5;
        public const int HEIGHT = 5;
        public const int NPOMES = 3;

        private Point cap;
        DireccioSnake direccio;
        private List<Point> pomes;

        public JocSnake()
        {
            cap = new Point(0, 0);
            pomes = new List<Point>();
            //distribuir les pomes
            Random r = new Random();
            for (int i = 0; i < NPOMES; i++)
            {
                var x = r.Next(0, WIDTH - 1);
                var y = r.Next(0, HEIGHT - 1);
                while (x == 0 && y == 0)
                {
                    x = r.Next(0, WIDTH - 1);
                    y = r.Next(0, HEIGHT - 1);
                }

                pomes.Add(new Point(x, y));
            }

        }

        public DireccioSnake Direccio { get => direccio; set => direccio = value; }
        public Point Cap { get => cap; set => cap = value; }
        public List<Point> Pomes { get => pomes; set => pomes = value; }

        public void moure()
        {
            if (direccio == DireccioSnake.Nord)
            {
                cap.Y--;
                if (cap.Y < 0)
                {
                    cap.Y = HEIGHT - 1;
                }

            }
            else if (direccio == DireccioSnake.Sud)
            {
                cap.Y++;
                if (cap.Y == HEIGHT)
                {
                    cap.Y = 0;
                }
            }
            else if (direccio == DireccioSnake.Est)
            {
                cap.X++;
                if (cap.X == WIDTH)
                {
                    cap.X = 0;
                }
            }
            else
            {
                cap.X--;
                if (cap.X < 0)
                {
                    cap.X = WIDTH;
                }
            }
        }

    }
    public enum DireccioSnake
    {
        Nord,
        Sud,
        Est,
        Oest
    }
}
