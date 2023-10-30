using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Juegos;
using Juegos.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
 using System.Collections.Generic; using System.Linq; using System.Text;
using Android.App; using Android.OS; using Android.Widget; using Java.Lang;

[assembly: ExportRenderer(typeof(Juegos.Control.VideoView), typeof(VideoViewRenderer))]

namespace Juegos.Droid.Renderers
{
    public class VideoViewRenderer : ViewRenderer, ISurfaceHolderCallback, MediaController.IMediaPlayerControl, MediaPlayer.IOnPreparedListener
    {

        VideoView videoview;
        MediaPlayer player;
        MediaController mediaController;
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        Handler handler = new Handler();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        public VideoViewRenderer()
        {
        }
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

        public void SurfaceChanged(ISurfaceHolder holder, global::Android.Graphics.Format format, int width, int height)
        {

        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }



        public override bool OnTouchEvent(MotionEvent e)
        {
            mediaController.Show();
            return false;
        }

        //--MediaPlayerControl methods----------------------------------------------------
        public void Start()
        {
            player.Start();
        }


        public void Pause()
        {
            player.Pause();
        }

        public int Duration
        {
            get
            {
                return player.Duration;
            }
        }

        public int CurrentPosition
        {
            get
            {
                return player.CurrentPosition;
            }
        }

        public void SeekTo(int i)
        {
            player.SeekTo(i);
        }

        public bool IsPlaying
        {
            get
            {
                return player.IsPlaying;
            }
        }

        public int BufferPercentage
        {
            get
            {
                return 0;
            }
        }

        public int AudioSessionId
        {
            get
            {
                return 0;
            }
        }

        public bool CanPause()
        {
            return true;
        }

        public bool CanSeekBackward()
        {
            return true;
        }

        public bool CanSeekForward()
        {
            return true;
        }
        //--------------------------------------------------------------------------------

        public void OnPrepared(MediaPlayer mediaPlayer)
        {
            mediaController.SetMediaPlayer(this);
            mediaController.SetAnchorView(videoview);
        }


        public void SurfaceCreated(ISurfaceHolder holder)
        {
            player.SetDisplay(holder);
        }
    }
}