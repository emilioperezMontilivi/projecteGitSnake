using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjecteSnake
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int SNAKE_HEAD_SIZE_WIDTH = 35;
        public const int SNAKE_HEAD_SIZE_HEIGHT = 35;
        JocSnake joc;
        DispatcherTimer timer;
        SolidColorBrush brushSnake = new SolidColorBrush(Colors.Green);
        SolidColorBrush brushPoma = new SolidColorBrush(Colors.Red);
        public MainWindow()
        {
            InitializeComponent();
            InitializeComponent();
            this.KeyDown += GameWindow_KeyDown;
            joc = new JocSnake();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(500);
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                joc.Direccio = DireccioSnake.Nord;
            }
            else if (e.Key == Key.Down)
            {
                joc.Direccio = DireccioSnake.Sud;
            }
            else if (e.Key == Key.Left)
            {
                joc.Direccio = DireccioSnake.Oest;
            }
            else
            {
                joc.Direccio = DireccioSnake.Est;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Pintar
            canvas.Children.Clear();
            Ellipse elSnake = new Ellipse()
            {
                Fill = brushSnake,
                Width = SNAKE_HEAD_SIZE_WIDTH,
                Height = SNAKE_HEAD_SIZE_HEIGHT,
            };
            Canvas.SetTop(elSnake, joc.Cap.Y * SNAKE_HEAD_SIZE_HEIGHT);
            Canvas.SetLeft(elSnake, joc.Cap.X * SNAKE_HEAD_SIZE_HEIGHT);
            canvas.Children.Add(elSnake);

            foreach (var poma in joc.Pomes)
            {
                Ellipse elpoma = new Ellipse()
                {
                    Fill = brushPoma,
                    Width = SNAKE_HEAD_SIZE_WIDTH,
                    Height = SNAKE_HEAD_SIZE_HEIGHT,
                };
                Canvas.SetTop(elpoma, poma.Y * SNAKE_HEAD_SIZE_HEIGHT);
                Canvas.SetLeft(elpoma, poma.X * SNAKE_HEAD_SIZE_HEIGHT);
                canvas.Children.Add(elpoma);
            }

            joc.moure();
        }

        private void btnIniciaJoc_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
