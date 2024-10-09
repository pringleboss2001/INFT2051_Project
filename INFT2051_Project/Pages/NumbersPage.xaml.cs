namespace INFT2051_Project.Pages;

public partial class NumbersPage : ContentPage
{
	public NumbersPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
        SetInitialStyles();
	}

	private void SetInitialStyles()
	{
        foreach (var view in MainLayout.Children)
        {
            if (view is Button btn)
            {
                btn.BackgroundColor = Color.FromArgb("#1E3A8A");
                btn.TextColor = Colors.White;
                btn.CornerRadius = 8;
                btn.FontSize = 18;
                btn.Padding = new Thickness(15, 10);
            }
        }
    }

    private async void OnButtonPressed(object sender, EventArgs e)
    {
        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        btn.BackgroundColor = Color.FromArgb("#0f172a");
        btn.Scale = 0.95; // Shrink the button slightly
    
        if (btn == Fractions)
            await Navigation.PushAsync(new FractionsPage());
        else if (btn == Decimals)
            await Navigation.PushAsync(new DecimalsPage());
        else if (btn == Percentages)
            await Navigation.PushAsync(new PercentagesPage());
        else if (btn == BackButton)
            await Navigation.PushAsync(new MainPage());
    }
    private void OnButtonReleased(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackgroundColor = Color.FromArgb("#1e3a8a"); // Return to original color
        btn.Scale = 1.0; // Return to normal size
    }
}