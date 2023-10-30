using System;
using Xamarin.Forms;
using Xam.Forms.VideoPlayer;
using System.Diagnostics;

namespace Juegos
{
    public partial class GanadorPage : ContentPage
    {
        public GanadorPage()
        {
            InitializeComponent();
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
