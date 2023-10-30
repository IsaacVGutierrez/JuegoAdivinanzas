using System;
using Xamarin.Forms;
using Xam.Forms.VideoPlayer;
using System.Diagnostics;
using MediaManager.Forms;

namespace Juegos
{
    public partial class MainPage : ContentPage
    {
        private int numeroAdivinar= 0;
        private int intentos = 0;
        private const int intentosMaximos = 10;
        private const int rangoCercano = 5;

        public MainPage()
        {
            InitializeComponent();
            numeroAdivinar = new Random().Next(1, 101);


        }

        private void OnGuessClicked(object sender, EventArgs e)
        {
            if (int.TryParse(guessEntry.Text, out int guess))
            {
                if (guess < 1 || guess > 100)
                {
                    DisplayAlert("Error", "El número debe estar entre 1 y 100.", "OK");
                    guessEntry.Text = string.Empty;
                }
                else
                {

                    intentos++;
                    int diferencia = Math.Abs(numeroAdivinar - guess);

                    if (guess == numeroAdivinar)
                    {
                        HandleGameEnd($"¡Felicitaciones! Adivinaste el número {numeroAdivinar} en {intentos} intentos.");
                    }
                    else if (intentos < intentosMaximos)
                    {
                        string mensaje = diferencia <= rangoCercano ? "Estás cerca" : guess < numeroAdivinar ? "Demasiado bajo" : "Demasiado alto";
                        resultLabel.Text = $"Intento #{intentos}: {mensaje}. Intenta de nuevo.";
                    }
                    else
                    {
                        HandleGameEnd($"Perdiste. El número correcto era {numeroAdivinar}.");


                    }
                }
            }
            else
            {
                DisplayAlert("Error", "Ingresa un número válido.", "OK");
                guessEntry.Text = string.Empty;
            }
        }

        private void OnRestartClicked(object sender, EventArgs e)
        {
          
            intentos = 0;
            numeroAdivinar = new Random().Next(1, 101);
            resultLabel.Text = string.Empty;
            guessEntry.Text = string.Empty;
            guessEntry.IsEnabled = true;
        }



        private async void HandleGameEnd(string message)
        {
            if (message.Contains("Perdiste"))
            {
                await Navigation.PushModalAsync(new ImagenPage("cara.jpg")); // Reemplaza el nombre de tu imagen
                resultLabel.Text = message;
                guessEntry.IsEnabled = false;
            }

            else if (message.Contains("¡Felicitaciones!"))
            {
                await Navigation.PushModalAsync(new GanadorPage());
                resultLabel.Text = message;
                guessEntry.IsEnabled = false;
            }
        }

        private async void OnVerVideoClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VideoPage()); // Abre la página del video
        }

    }
}
