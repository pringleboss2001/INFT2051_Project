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
    public ViewDataPage()
	{
		InitializeComponent();
        
    }
}