using System;
using System.Windows;

namespace PR6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Classes.TV TV = new Classes.TV();
        public MainWindow()
        {
            InitializeComponent();
            VideoPlayer.Source = new Uri(TV.AllChannels[0].Src);
            VideoPlayer.Play();/*23*/
        }

        private void NextChannel(object sender, RoutedEventArgs e)
        {
            TV.NextChannel(VideoPlayer, NameChannel);
        }

        private void BackChannel(object sender, RoutedEventArgs e)
        {
            TV.BackChannel(VideoPlayer, NameChannel);

        }

        private void downHearth(object sender, RoutedEventArgs e)
        {
            TV.DownSound(VideoPlayer);
        }

        private void upHearth(object sender, RoutedEventArgs e)
        {
            TV.UpSound(VideoPlayer);
        }

        private void pult(object sender, RoutedEventArgs e)
        {
            
            try
            {

                int tvAdressTemp = int.Parse(tvAdress.Text);
                if (tvAdressTemp > TV.AllChannels.Count || tvAdressTemp <=0)
                {
                    MessageBox.Show("Ошибка! Введите существующий канал");
                    tvAdressTemp = TV.AllChannels.Count;
                }
                TV.ActiveChannel = tvAdressTemp-1;
                TV.forTVAdress(VideoPlayer,NameChannel);
            }
            catch
            {
                MessageBox.Show("Ошибка! Введите существующий канал");
                TV.ActiveChannel = TV.AllChannels.Count - 1;
                TV.forTVAdress(VideoPlayer, NameChannel);
                return;
            }
        }
    }
}
