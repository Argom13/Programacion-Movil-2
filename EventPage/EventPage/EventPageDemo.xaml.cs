namespace EventPage;

public partial class EventPageDemo : ContentPage
{
	public EventPageDemo()
	{
		InitializeComponent();
	}

    private void btnTest_Clicked(object sender, EventArgs e)
    {
		DisplayAlert("Test", "Boton funcionando", "OK");
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        DisplayAlert("Test", $"Change: {e.Value}", "OK");
    }

    private void SearchControl_SearchButtonPressed(object sender, EventArgs e)
    {
        DisplayAlert("Test", $"Searching: {SearchControl.Text}", "OK");
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("Test", "Element: Tapped", "OK");
    }

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblSlider.Text = slider.Value.ToString();
    }

    private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if(stepper != null)
        {
            lblSlider.Text = stepper.Value.ToString();
        }
    }
}