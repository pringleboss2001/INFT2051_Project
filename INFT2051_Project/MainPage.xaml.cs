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
            else if (btn.Text == "Year 9 Questions")
                btn.Text = "year 9";
            else if (btn.Text == "Year 10 Questions")
                btn.Text = "year 10";
        }
    }

}
