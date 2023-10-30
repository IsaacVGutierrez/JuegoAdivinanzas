using System;
using Xamarin.Forms;
using Xam.Forms.VideoPlayer;
using System.Diagnostics;

namespace Juegos
{
    public partial class ImagenPage : ContentPage
    {
        public ImagenPage(string imagePath)
        {
            InitializeComponent();
            ImageSource source = ImageSource.FromFile(imagePath);
            imageView.Source = source;
        }

        private async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }




    }
}
