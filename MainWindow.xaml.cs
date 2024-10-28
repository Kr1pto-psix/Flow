using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            exitBut.Visibility = Visibility.Hidden;
            desabledBtn1.Visibility = Visibility.Hidden;
            desabledBtn2.Visibility = Visibility.Hidden;
            backbtn.Visibility = Visibility.Hidden;
            grachBtn.Visibility = Visibility.Hidden;
        }


        private void Drag_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (myPopup.IsOpen)
            {
                myPopup.IsOpen = false;
            }
            this.DragMove();
        }

        private void Exit_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (myPopup.IsOpen)
            {
                myPopup.IsOpen = false; // Закрыть Popup, если он открыт
            }
        }


        private void MainWindow_OnDeactivated(object sender, EventArgs e)
        {
            myPopup.IsOpen = false;
        }

        private void MainWindow_OnMouseEnter(object sender, MouseEventArgs e)
        {
            exitBut.Visibility = Visibility.Visible;
            desabledBtn1.Visibility = Visibility.Visible;
            desabledBtn2.Visibility = Visibility.Visible;
            backbtn.Visibility = Visibility.Visible;
            grachBtn.Visibility = Visibility.Visible;
        }


        private void MainWindow_OnMouseLeave(object sender, MouseEventArgs e)
        {
            exitBut.Visibility = Visibility.Hidden;
            desabledBtn1.Visibility = Visibility.Hidden;
            desabledBtn2.Visibility = Visibility.Hidden;
            backbtn.Visibility = Visibility.Hidden;
            grachBtn.Visibility = Visibility.Hidden;
        }
    }
}
