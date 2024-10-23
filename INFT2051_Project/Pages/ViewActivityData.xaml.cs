using INFT2051_Project.Models;
using INFT2051_Project.ViewModels;

namespace INFT2051_Project.Pages;

public partial class ViewActivityData : ContentPage
{
    DateViewModel dateViewModel;
    List<UserActivity> dates = new List<UserActivity>();
    public ViewActivityData()
	{
        BindingContext = dateViewModel = new DateViewModel();
		InitializeComponent();
        dates = DateViewModel.Current.Dates;
        collViewActivity.ItemsSource = dates;
        
    }

    protected override void OnAppearing()
    {
        dateViewModel.OnPropertyChanged("Dates");
    }

    private async void OnButtonReleased(object sender, EventArgs e)
    {
        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        btn.BackgroundColor = Color.FromArgb("#1e3a8a"); // Return to original color
        btn.Scale = 1.0; // Return to normal size

        if (btn == BackButton)
            await Navigation.PushAsync(new MainPage());
    }
    private void OnButtonPressed(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackgroundColor = Color.FromArgb("#0f172a");
        btn.Scale = 0.95; // Shrink the button slightly
    }
}