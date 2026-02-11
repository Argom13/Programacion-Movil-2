namespace CambioColor
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();
            var color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256)
                );

            SetColor(color);

            SldRed.Value = color.Red;
            SldGreen.Value = color.Green;
            SldBlue.Value = color.Green;

            isRandom = false;
        }

        private void SetColor(Color color)
        {
            BtnRandom.Background = color;
            Container.BackgroundColor = color;
            lblHexa.Text = color.ToHex();
        }
    }
}
