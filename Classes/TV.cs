using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;



namespace PR6.Classes
{
    public class TV
    {
        private int activeChannel;
        private int activeVolume;
        public int ActiveChannel
        {
            get
            {
                return activeChannel;
            }
            set
            {
                if (AllChannels.Count == 0) return;

                if (value == AllChannels.Count)
                    activeChannel = 0;
                else if (value < 0)
                    activeChannel = AllChannels.Count - 1;
                else
                    activeChannel = value;

            }
        }
        public List<Channel> AllChannels = new List<Channel>();
        public TV()
        {
            AllChannels.Add(new Channel()
            {
                Name = "Практическое занятие N3.",
                Src = @"D:\1.mp4"
            });
            AllChannels.Add(new Channel()
            {
                Name = "Практическое занятие N4.",
                Src = @"D:\2.mp4"
            });
            AllChannels.Add(new Channel()
            {
                Name = "Практическое занятие N5.",
                Src = @"D:\3.mp4"
            });

        }
        public void SwapChannel(MediaElement mediaElement, Label nameChannel)
        {
            DoubleAnimation startAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            startAnimation.Completed += delegate
            {
                mediaElement.Source = new Uri(AllChannels[ActiveChannel].Src);
                mediaElement.Play();
                DoubleAnimation endAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.3)
                };
                mediaElement.BeginAnimation(MediaElement.OpacityProperty, endAnimation);
            };
            mediaElement.BeginAnimation(MediaElement.OpacityProperty, startAnimation);
            nameChannel.Content = AllChannels[ActiveChannel].Name;
        }

        public void NextChannel(MediaElement mediaElement, Label nameChannel)
        {
            ActiveChannel++;
            SwapChannel(mediaElement, nameChannel);
        }
        public void BackChannel (MediaElement mediaElement, Label nameChannel)
        {
            ActiveChannel--;
            SwapChannel(mediaElement, nameChannel);
        }

        public void UpSound()
        {
            
            activeVolume++;
        }
        public void DownSound()
        {

        }
    }
}
