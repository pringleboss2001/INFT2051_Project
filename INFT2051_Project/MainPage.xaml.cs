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
            SetInitialStyles();

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
                       
            if (btn == EquationsButton)
                await Navigation.PushAsync(new EquationsPage());
            else if (btn == NumbersButton)
                await Navigation.PushAsync(new NumbersPage());
            else if (btn == UserData)
                await Navigation.PushAsync(new ViewDataPage());
            else if (btn == ActivityData)
                await Navigation.PushAsync(new ViewActivityData());
            else if (btn == HowToUse)
                await Navigation.PushAsync(new HowToUse());

        }
        private void OnButtonPressed(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundColor = Color.FromArgb("#0f172a");
            btn.Scale = 0.95; // Shrink the button slightly
        }
    }

}
