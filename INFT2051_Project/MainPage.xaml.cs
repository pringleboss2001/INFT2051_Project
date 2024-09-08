using INFT2051_Project.Pages;
using INFT2051_Project.Services;
using INFT2051_Project.Models;
using INFT2051_Project.ViewModels;

namespace INFT2051_Project
{
    public partial class MainPage : ContentPage
    {
        DataViewModel viewModel;
        DateViewModel dateViewModel;
        public MainPage()
        {
            BindingContext = viewModel = new DataViewModel();
            BindingContext = dateViewModel = new DateViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //Creating the rows in the database table. So that the indexing is predetermined
            TopicData oneStepData   = new TopicData() { Id = 1, TopicName = "One Step Equations", TotalQuestionsAttempted = 0, TotalQuestionsCorrect = 0 };
            TopicData twoStepData   = new TopicData() { Id = 2, TopicName = "Two Step Equations", TotalQuestionsAttempted = 0, TotalQuestionsCorrect = 0 };
            TopicData quadraticData = new TopicData() { Id = 3, TopicName = "Quadratic Equations", TotalQuestionsAttempted = 0, TotalQuestionsCorrect = 0 };
            TopicData fractionData  = new TopicData() { Id = 4, TopicName = "Converting to Fractions", TotalQuestionsAttempted = 0, TotalQuestionsCorrect = 0 };
            TopicData decimalData   = new TopicData() { Id = 5, TopicName = "Converting to Decimals", TotalQuestionsAttempted = 0, TotalQuestionsCorrect = 0 };
            TopicData percentageData = new TopicData() { Id = 6, TopicName = "Converting to Percentages", TotalQuestionsAttempted = 0, TotalQuestionsCorrect = 0 };
            viewModel.OnPropertyChanged("Topics");
            DataViewModel.Current.SaveData(oneStepData);
            DataViewModel.Current.SaveData(twoStepData);
            DataViewModel.Current.SaveData(quadraticData);
            DataViewModel.Current.SaveData(fractionData);
            DataViewModel.Current.SaveData(decimalData);
            DataViewModel.Current.SaveData(percentageData);

            DateViewModel.Current.SaveData(new UserActivity() { Date=DateTime.Today.ToString("dd/MM/yyyy"), answeredQuestion=false});
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
            else if (btn == Fractions)
                await Navigation.PushAsync(new FractionsPage());
            else if (btn == Decimals)
                await Navigation.PushAsync(new DecimalsPage());
            else if (btn == Percentages)
                await Navigation.PushAsync(new PercentagesPage());
            else if (btn == UserData)
                await Navigation.PushAsync(new ViewDataPage());
            else if (btn == HowToUse)
                await Navigation.PushAsync(new HowToUse());

        }
    }

}
