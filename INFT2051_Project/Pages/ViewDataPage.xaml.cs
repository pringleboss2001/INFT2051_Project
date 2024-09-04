namespace INFT2051_Project.Pages;
using INFT2051_Project.Services;
using System.Collections.ObjectModel;
using INFT2051_Project.Models;
using System.Reflection;
using SQLite;
using INFT2051_Project.ViewModels;

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
    }
}