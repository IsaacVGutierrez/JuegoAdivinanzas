using Xamarin.Forms;
using Xam.Forms.VideoPlayer;
using System;


namespace Juegos    
{
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
                      
        }
        private async void OnSalirClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(); // Cierra la página actual
        }
    }
}
