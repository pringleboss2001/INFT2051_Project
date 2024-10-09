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
        listViewActivity.ItemsSource = dates;
        
    }

    protected override void OnAppearing()
    {
        dateViewModel.OnPropertyChanged("Dates");
    }
}