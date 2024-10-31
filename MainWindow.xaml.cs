using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

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
        

        private CircleState circleState1 = CircleState.circle;
        private CircleState circleState2 = CircleState.circle;
        private CircleState circleState3 = CircleState.circle;
        private CircleState circleState4 = CircleState.circle;
        private int circleCounter = 8;
        private DispatcherTimer timer;
        private int time = 1;
        private TimeSpan timeLeft;
        private bool backBtnEnabled = false;
        private const string HostsPath = @"C:\Windows\System32\drivers\etc\hosts";


      
        public MainWindow()
        {

            InitializeComponent();
            exitBut.Visibility = Visibility.Hidden;
            desabledBtn1.Visibility = Visibility.Hidden;
            desabledBtn2.Visibility = Visibility.Hidden;
            backbtn.Visibility = Visibility.Hidden;
            grachBtn.Visibility = Visibility.Hidden;
            this.themeType = ThemeType.Dark;
            timeLeft = TimeSpan.FromMinutes(time);
            this.minTimeBlok.Text = timeLeft.ToString(@"mm"); // Форматируем вывод (минуты:секунды)
            this.secTimeBlock.Text = timeLeft.ToString(@"ss");
            InitializeTimer();

        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Интервал срабатывания таймера
            timer.Tick += Timer_Tick; // Подписка на событие Tick
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1)); // Уменьшаем оставшееся время на 1 секунду
                this.minTimeBlok.Text = timeLeft.ToString(@"mm"); // Форматируем вывод (минуты:секунды)
                this.secTimeBlock.Text = timeLeft.ToString(@"ss");
            }
            else
            {
                timer.Stop();
                OnTimerFinished();


            }
        }

        private void OnTimerFinished()
        {
            
            MessageBox.Show("Время вышло!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            this.circleCounter -= 1;
            this.StartButtonImage.Source = (BitmapImage)FindResource("play");
        }

        private void BlockSite(string site)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(HostsPath))
                {
                    sw.WriteLine($"127.0.0.1 {site}");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UnblockSite(string site)
        {
            try
            {
                var lines = File.ReadAllLines(HostsPath).ToList();
                bool removed = lines.RemoveAll(line => line.Contains(site)) > 0;

                if (removed)
                {
                    File.WriteAllLines(HostsPath, lines);
                    
                }
                else
                {
                    MessageBox.Show($"{site} не найден в файле hosts.", "Информация", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            grachBtn.Visibility = Visibility.Visible;
            if (this.backBtnEnabled)
                this.backbtn.Visibility = Visibility.Visible;
        }


        private void MainWindow_OnMouseLeave(object sender, MouseEventArgs e)
        {
            exitBut.Visibility = Visibility.Hidden;
            desabledBtn1.Visibility = Visibility.Hidden;
            desabledBtn2.Visibility = Visibility.Hidden;
            grachBtn.Visibility = Visibility.Hidden;
            if(this.backBtnEnabled)
                this.backbtn.Visibility = Visibility.Hidden;
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

                this.minTimeBlok.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.secTimeBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

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
                if (circleState3 == CircleState.fill)
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

                this.secTimeBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.minTimeBlok.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                

                this.popupBackground.Background = new SolidColorBrush(Color.FromArgb(204, 40, 42, 42));
            }
        }

        private void UpdateCircle()
        {
            if (themeType == ThemeType.Dark)
            {
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
                if (circleState3 == CircleState.fill)
                    this.cirlce3.Source = (BitmapImage)FindResource("lightCercleFill");
                if (circleState3 == CircleState.half)
                    this.cirlce3.Source = (BitmapImage)FindResource("lightCercleHalf");

                if (circleState4 == CircleState.circle)
                    this.cirlce4.Source = (BitmapImage)FindResource("lightCercleEmpty");
                if (circleState4 == CircleState.fill)
                    this.cirlce4.Source = (BitmapImage)FindResource("lightCercleFill");
                if (circleState4 == CircleState.half)
                    this.cirlce4.Source = (BitmapImage)FindResource("lightCercleHalf");

            }
            else
            {

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

            }
        }
        private void Start(object sender, RoutedEventArgs e)
        {
            
            if (!this.timer.IsEnabled)
            {
                this.backbtn.Visibility = Visibility.Visible;
                this.backBtnEnabled = true;
                switch (this.circleCounter)
                {
                    case 8: this.circleState1 = CircleState.half;
                        break;
                    case 7: this.circleState1 = CircleState.fill;
                        break;
                    case 6: this.circleState2 = CircleState.half;
                        break;
                    case 5: this.circleState2 = CircleState.fill;
                        break;
                    case 4: this.circleState3 = CircleState.half;
                        break;
                    case 3: this.circleState3 = CircleState.fill;
                        break;
                    case 2: this.circleState4 = CircleState.half;
                        break;
                    case 1: this.circleState4 = CircleState.fill;
                        break;
                }
                if (this.circleCounter == 0)
                {
                    this.circleCounter = 8;
                    this.circleState1 = CircleState.half;
                    this.circleState2 = CircleState.circle;
                    this.circleState3 = CircleState.circle;
                    this.circleState4 = CircleState.circle;
                }
                UpdateCircle();
                timer.Start();
                this.StartButtonImage.Source = (BitmapImage)FindResource("pause");
            }
            else
            {
                
                timer.Stop();
                this.StartButtonImage.Source = (BitmapImage)FindResource("play");
            }
            

        }

        private void Backbtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.backBtnEnabled = false;
            this.backbtn.Visibility = Visibility.Hidden;
            if (this.timer.IsEnabled)
            {
                timer.Stop();
                this.StartButtonImage.Source = (BitmapImage)FindResource("play");
            }
            

            this.timeLeft = TimeSpan.FromMinutes(time);
            this.minTimeBlok.Text = timeLeft.ToString(@"mm"); // Форматируем вывод (минуты:секунды)
            this.secTimeBlock.Text = timeLeft.ToString(@"ss");
        }

        private void BreakDurBat_OnMouseEnter(object sender, MouseEventArgs e)
        {
            clearPopups(sender, e);
            this.breakPopup.IsOpen = true;
        }

        private void clearPopups(object sender, MouseEventArgs e)
        {
            this.breakPopup.IsOpen = false;
            this.flowPopup.IsOpen = false;
            this.settingsPopup.IsOpen = false;
        }

        private void FlowDurBat_OnMouseEnter(object sender, MouseEventArgs e)
        {
            clearPopups(sender, e);
            this.flowPopup.IsOpen = true;
        }

        private void SettingsBtnInPopup_OnMouseEnter(object sender, MouseEventArgs e)
        {
            clearPopups(sender, e);
            this.settingsPopup.IsOpen = true;
        }

        private void OpenAboutForm_Click(object sender, RoutedEventArgs e)
        {
            about abo = new about();
            abo.ShowDialog();
        }
    }
}
