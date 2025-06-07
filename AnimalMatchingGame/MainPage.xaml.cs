namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {

            AnimalButtons.IsVisible = true;
            // Setando o AnimalButton como true aqui e na MainPage.xaml como false, quando o método for iniciado, ou seja,
            // o botão for clickado, os botões de animais estarão visíveis.

            PlayAgainButton.IsVisible = false;

            List<string> animalEmoji = [
                "🐻","🐻",
                "🐻‍❄️","🐻‍❄️",
                "🦄","🦄",
                "🐰","🐰",
                "🦝","🦝",
                "🐉","🐉",
                "🦋","🦋",
                "🐙","🐙"
                ];
            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalEmoji.Count);
                String nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);
        }

        int tenthsOfSecondsElapsed = 0;

        private bool TimerTick()
        {
            if (!this.IsLoaded) return false;

            tenthsOfSecondsElapsed++;
            TimeElapsed.Text = "Time Elapsed: " +
                (tenthsOfSecondsElapsed / 10F).ToString("0.0");

            if (PlayAgainButton.IsVisible)
            {
                tenthsOfSecondsElapsed = 0;
                return false;
            }

            return true;
        }

        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button buttonClicked)
            {
                if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
                {
                    
                    buttonClicked.BackgroundColor = Colors.HotPink;
                    lastClicked = buttonClicked;
                    findingMatch = true;
                }
                else
                {
                    if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && (!String.IsNullOrWhiteSpace(buttonClicked.Text)))
                    {
                        matchesFound++;
                        lastClicked.Text = string.Empty;
                        buttonClicked.Text = string.Empty;

                    }

                    lastClicked.BackgroundColor = Colors.LightSalmon;
                    buttonClicked.BackgroundColor = Colors.LightSalmon;
                    findingMatch = false;

                }

            }
            if (matchesFound == 8)
            {
                matchesFound = 0;
                AnimalButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
            }
        }
    }

}
