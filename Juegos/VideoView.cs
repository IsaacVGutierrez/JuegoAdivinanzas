using System;
using Xamarin.Forms;

namespace Juegos.Control
{
    public class VideoView : View
    {
        public Action StopAction;

        public static readonly BindableProperty FileSourceProperty =
            BindableProperty.Create(nameof(FileSource), typeof(string), typeof(VideoView), string.Empty);

        public string FileSource
        {
            get { return (string)GetValue(FileSourceProperty); }
            set { SetValue(FileSourceProperty, value); }
        }

        public void Stop()
        {
            StopAction?.Invoke();
        }
    }
}
