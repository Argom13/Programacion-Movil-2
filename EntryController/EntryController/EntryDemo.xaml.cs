using System.Diagnostics;

namespace EntryController;

public partial class EntryDemo : ContentPage
{
	public EntryDemo()
	{
		InitializeComponent();
	}

    private void txtEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Debug.WriteLine(txtEntry.Text);
    }

    private void txtEntry_Completed(object sender, EventArgs e)
    {
        Debug.WriteLine(txtEntry.Text);
    }
}