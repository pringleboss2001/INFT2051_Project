using INFT2051_Project.Pages;
using INFT2051_Project.Services;
using INFT2051_Project.Models;
using INFT2051_Project.ViewModels;
using SQLite;

namespace INFT2051_Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
            if (btn == OneStepButton)
                await Navigation.PushAsync(new OneStep());
            else if (btn == TwoStepButton)
                await Navigation.PushAsync(new TwoStep());
            else if (btn == QuadraticEquationsButton)
                await Navigation.PushAsync(new QuadraticsPage());
            else if (btn == Perimeter)
                await Navigation.PushAsync(new PerimeterPage());
            else if (btn == Area)
                await Navigation.PushAsync(new AreaPage());
            else if (btn == Fractions)
                await Navigation.PushAsync(new FractionsPage());
            else if (btn == Decimals)
                await Navigation.PushAsync(new DecimalsPage());
            else if (btn == Percentages)
                await Navigation.PushAsync(new PercentagesPage());
            else if (btn == UserData)
                await Navigation.PushAsync(new ViewDataPage());

        }
    }

}
