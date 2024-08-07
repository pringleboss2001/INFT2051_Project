namespace INFT2051_Project;

public partial class AreaPage : ContentPage
{
	public AreaPage()
	{
		InitializeComponent();
	}

    public async void OnButtonClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        if (btn == Back)
            await Navigation.PushAsync(new MainPage());
    }
}