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
    DateViewModel dateViewModel;
    List<TopicData> data = new List<TopicData>();
    List<UserActivity> dates = new List<UserActivity>();
    public ViewDataPage()
	{
		BindingContext = viewModel = new DataViewModel();
        BindingContext = dateViewModel = new DateViewModel();
        InitializeComponent();
        data = DataViewModel.Current.Data;
        dates = DateViewModel.Current.Dates;

        listView.ItemsSource = data;
        listViewActivity.ItemsSource = dates;
        
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");    
    }
}