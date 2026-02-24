namespace PropinaMAUI
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int noPerson = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            calculateTotal();
        }

        private void calculateTotal()
        {
            var totalTip = (bill * tip) / 100;
            var tipByPerson = (totalTip / noPerson);
            lblTip.Text = $"{ tipByPerson:C}";

            var subtotal = (bill / noPerson);
            lblSubtotal.Text = $"{subtotal:C}";

            var totalByPerson = (bill / noPerson);
            Lbltotal.Text = $"{totalByPerson:C}";
        }


        private void sdltip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldtip.Value;
            lblTip.Text = $"Tip: {tip}%";
            calculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldtip.Value = percentage;
            }

            
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if(noPerson > 1)
            {
                noPerson--;
            }
            lblNoperson.Text = noPerson.ToString();
            calculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            noPerson++; 
            lblNoperson.Text = noPerson.ToString();
            calculateTotal();
        }
    }
}
