namespace INFT2051_Project.Pages;
using INFT2051_Project.ViewModels;
using INFT2051_Project.Services;

public partial class ViewData : ContentPage
{
	TopicViewModel viewModel;
	public ViewData()
	{
		//BindingContent = viewModel = new TopicViewModel();
		
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
		viewModel.OnPropertyChanged("Topics");
    }
}