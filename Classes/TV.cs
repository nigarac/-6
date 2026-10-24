using System;
using System.Collections.Generic;
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
                if (activeChannel < AllChannels.Count - 1)
                    activeChannel = value;
                else
                    activeChannel = 0;
                if (activeChannel < 0)
                    activeChannel = AllChannels.Count - 1;
                
            }
        }
        public List<Channel> AllChannels = new List<Channel>();
        public TV()
        {
            AllChannels.Add(new Channel()
            {
                Name = "Практическое занятие N3.",
                Src = ""
            });
            AllChannels.Add(new Channel()
            {
                Name = "Практическое занятие N4.",
                Src = ""
            });
            AllChannels.Add(new Channel()
            {
                Name = "Практическое занятие N5.",
                Src = ""
            });

        }
        public void SwapChannel(MediaElement mediaElement, Label nameChannel)
        {
            DoubleAnimation startAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            startAnimation.Completed += delegate
            {
                mediaElement.Source = new Uri(AllChannels[ActiveChannel].Src);
                mediaElement.Play();
                DoubleAnimation endAnimation = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.6)
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

        }
        public void DownSound()
        {

        }
    }
}
