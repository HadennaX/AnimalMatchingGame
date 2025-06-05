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
                "🐻‍❄️", "🐻‍❄️",
                "🦄","🦄",
                "🐰", "🐰",
                "🦝", "🦝",
                "🐉","🐉",
                "🦋", "🦋",
                "🐙", "🐙"
                ];
            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalEmoji.Count);
                String nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
