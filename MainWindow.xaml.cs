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
    public enum ThemeType
    {
        Dark =0,
        Light =1
    }

    public enum CircleState
    {
        circle = 0,
        half = 1,
        fill =2
    }
    public partial class MainWindow : Window
    {
        private ThemeType themeType;
        private bool start = false;

        private CircleState circleState1 = CircleState.circle;
        private CircleState circleState2 = CircleState.circle;
        private CircleState circleState3 = CircleState.circle;
        private CircleState circleState4 = CircleState.circle;


        public MainWindow()
        {

            InitializeComponent();
            exitBut.Visibility = Visibility.Hidden;
            desabledBtn1.Visibility = Visibility.Hidden;
            desabledBtn2.Visibility = Visibility.Hidden;
            backbtn.Visibility = Visibility.Hidden;
            grachBtn.Visibility = Visibility.Hidden;
            this.themeType = ThemeType.Dark;
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

        private void quitSettingsButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            if (themeType == ThemeType.Dark)
            {
                themeType = ThemeType.Light;

                if (circleState1 == CircleState.circle)
                    this.cirlce1.Source = (BitmapImage)FindResource("darkCercle");
                if (circleState1 == CircleState.fill)
                    this.cirlce1.Source = (BitmapImage)FindResource("darkCercleFill");
                if (circleState1 == CircleState.half)
                    this.cirlce1.Source = (BitmapImage)FindResource("darkCerleHalf");


                if (circleState2 == CircleState.circle)
                    this.cirlce2.Source = (BitmapImage)FindResource("darkCercle");
                if (circleState2 == CircleState.fill)
                    this.cirlce2.Source = (BitmapImage)FindResource("darkCercleFill");
                if (circleState2 == CircleState.half)
                    this.cirlce2.Source = (BitmapImage)FindResource("darkCerleHalf");


                if (circleState3 == CircleState.circle)
                    this.cirlce3.Source = (BitmapImage)FindResource("darkCercle");
                if (circleState3 == CircleState.fill)
                    this.cirlce3.Source = (BitmapImage)FindResource("darkCercleFill");
                if (circleState3 == CircleState.half)
                    this.cirlce3.Source = (BitmapImage)FindResource("darkCerleHalf");

                if (circleState4 == CircleState.circle)
                    this.cirlce4.Source = (BitmapImage)FindResource("darkCercle");
                if (circleState4 == CircleState.fill)
                    this.cirlce4.Source = (BitmapImage)FindResource("darkCercleFill");
                if (circleState4 == CircleState.half)
                    this.cirlce4.Source = (BitmapImage)FindResource("darkCerleHalf");

                this.MainWindowBorder.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.DragMover.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                this.exitBut.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.desabledBtn1.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.desabledBtn2.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                this.FlowLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                this.backBtnImage.Source = (BitmapImage)FindResource("backLight");
                this.grachBtnImage.Source = (BitmapImage)FindResource("darkGrach");
                this.settingsBtnImage.Source = (BitmapImage)FindResource("blackSettings");

                this.separator1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.separator2.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                this.minTimeBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.hourTimeBlok.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                this.popupBackground.Background = new SolidColorBrush(Color.FromArgb(204, 255, 255, 255));

            }
            else
            {
                themeType = ThemeType.Dark;

                if (circleState1 == CircleState.circle)
                    this.cirlce1.Source = (BitmapImage)FindResource("lightCercleEmpty");
                if (circleState1 == CircleState.fill)
                    this.cirlce1.Source = (BitmapImage)FindResource("lightCercleFill");
                if (circleState1 == CircleState.half)
                    this.cirlce1.Source = (BitmapImage)FindResource("lightCercleHalf");


                if (circleState2 == CircleState.circle)
                    this.cirlce2.Source = (BitmapImage)FindResource("lightCercleEmpty");
                if (circleState2 == CircleState.fill)
                    this.cirlce2.Source = (BitmapImage)FindResource("lightCercleFill");
                if (circleState2 == CircleState.half)
                    this.cirlce2.Source = (BitmapImage)FindResource("lightCercleHalf");


                if (circleState3 == CircleState.circle)
                    this.cirlce3.Source = (BitmapImage)FindResource("lightCercleEmpty");
                if (circleState1 == CircleState.fill)
                    this.cirlce3.Source = (BitmapImage)FindResource("lightCercleFill");
                if (circleState3 == CircleState.half)
                    this.cirlce3.Source = (BitmapImage)FindResource("lightCercleHalf");

                if (circleState4 == CircleState.circle)
                    this.cirlce4.Source = (BitmapImage)FindResource("lightCercleEmpty");
                if (circleState4 == CircleState.fill)
                    this.cirlce4.Source = (BitmapImage)FindResource("lightCercleFill");
                if (circleState4 == CircleState.half)
                    this.cirlce4.Source = (BitmapImage)FindResource("lightCercleHalf");

                this.MainWindowBorder.Background = new SolidColorBrush(Color.FromRgb(40,42,42));
                this.DragMover.Background = new SolidColorBrush(Color.FromRgb(40, 42, 42));


                this.exitBut.Stroke = new SolidColorBrush(Color.FromRgb(45, 48, 47));
                this.desabledBtn1.Stroke = new SolidColorBrush(Color.FromRgb(45, 48, 47));
                this.desabledBtn2.Stroke = new SolidColorBrush(Color.FromRgb(45, 48, 47));
                

                this.FlowLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                this.backBtnImage.Source = (BitmapImage)FindResource("backDark");
                this.grachBtnImage.Source = (BitmapImage)FindResource("lightGrach");
                this.settingsBtnImage.Source = (BitmapImage)FindResource("lightSettings");

                this.separator1.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.separator2.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                this.minTimeBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.hourTimeBlok.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                

                this.popupBackground.Background = new SolidColorBrush(Color.FromArgb(204, 40, 42, 42));
            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            this.start = !this.start;
            if (this.start)
            {
                this.StartButtonImage.Source = (BitmapImage)FindResource("pause");
            }
            else
            {
                this.StartButtonImage.Source = (BitmapImage)FindResource("play");
            }
            

        }
    }
}
