namespace INFT2051_Project.Pages;
using INFT2051_Project.Services;
using System.Collections.ObjectModel;
using INFT2051_Project.Models;
using System.Reflection;
using SQLite;
using INFT2051_Project.ViewModels;
using Plugin.Maui.Calendar.Models;

public partial class ViewDataPage : ContentPage
{
    DataViewModel viewModel;
    List<TopicData> data = new List<TopicData>();

    public ViewDataPage()
    {
        BindingContext = viewModel = new DataViewModel();
        InitializeComponent();
        data = DataViewModel.Current.Data;
        listView.ItemsSource = data;
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");
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

    private async void OnButtonReleased(object sender, EventArgs e)
    {
        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        btn.BackgroundColor = Color.FromArgb("#1e3a8a"); // Return to original color
        btn.Scale = 1.0; // Return to normal size

        if (btn == BackButton)
            await Navigation.PushAsync(new MainPage());
    }

    private async void OnButtonPressed(object sender, EventArgs e)
    {
        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        btn.BackgroundColor = Color.FromArgb("#0f172a");
        btn.Scale = 0.95; // Return to normal size

        
    }
}