using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Tic_Tac
{
    public partial class Control : Window
    {
        public Modal MyGameBoard = new Modal();

        public Control()
        {
            InitializeComponent();
            this.DataContext = MyGameBoard;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;

            if (MyGameBoard.currentPlayer == Modal.CurrentPlayer.X)
            {
                clickedButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#811717"));
            }
            else if (MyGameBoard.currentPlayer == Modal.CurrentPlayer.O)
            {
                clickedButton.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#126712"));
            }
            clickedButton.Background = Brushes.WhiteSmoke;
            clickedButton.Content = MyGameBoard.currentPlayer;
            clickedButton.IsHitTestVisible = false;

            MyGameBoard.UpdateBoard(clickedButton.Name);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(MyGrid) - 1; i++) 
            {
                var child = VisualTreeHelper.GetChild(MyGrid, i) as Button;
                child.Content = null;
                child.IsHitTestVisible = true;
                child.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            }
            MyGameBoard = new Modal();
            this.DataContext = MyGameBoard;
        }
    }

    
}
