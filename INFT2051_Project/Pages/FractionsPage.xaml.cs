using Mehroz;
using INFT2051_Project.Models;
using INFT2051_Project.ViewModels;
namespace INFT2051_Project;

public partial class FractionsPage : ContentPage
{
    int percentageAnswer = 0;
    int decimalAnswer = 0;
    int PercDec = 0;

    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;
    DateViewModel dateViewModel;

    TopicData topicData = new TopicData()
    {
        Id = 4,
        TopicName = "Converting to Fractions",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0,
    };

    UserActivity todaysDate = new UserActivity()
    {
        Id = 0,
        Date = DateTime.Today.ToString("dd/MM/yyyy"),
        answeredQuestion = false
    };
    public FractionsPage()
	{
        BindingContext = viewModel = new DataViewModel();
        BindingContext = dateViewModel = new DateViewModel();
        InitializeComponent();
        Random numberGenerator = new Random();
        decimalAnswer = numberGenerator.Next(1, 100);
        percentageAnswer = numberGenerator.Next(1, 100);
        PercDec = numberGenerator.Next(1, 3);
        createQuestion(percentageAnswer, decimalAnswer, PercDec);
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");
        dateViewModel.OnPropertyChanged("Dates");
        topicData = DataViewModel.Current.getTopicData(topicData);
        todaysDate = DateViewModel.Current.getDateData(todaysDate);
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {

        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        if (btn == Back)
            await Navigation.PushAsync(new MainPage());
        else if (btn == NextQuestion)
        {
            AnswerInput.Text = "";
            questionCorrect = false;
            questionAttempted = false;
            WorkingGrid.IsVisible = false;
            Random numberGenerator = new Random();
            decimalAnswer = numberGenerator.Next(1, 100);
            percentageAnswer = numberGenerator.Next(1, 100);
            PercDec = numberGenerator.Next(1, 3);
            createQuestion(percentageAnswer, decimalAnswer, PercDec);
        }
        else if (btn == SubmitAnswer)
        {
            //Display solution + answer
            string answerInput = AnswerInput.Text;
            checkAnswer(percentageAnswer, decimalAnswer, PercDec, answerInput);
        }
        else if (btn == ShowWorking)
        {
            WorkingGrid.IsVisible = true;
            showWorking(percentageAnswer, decimalAnswer, PercDec);
        }
    }

    public void createQuestion(int percentageAnswer, int decimalAnswer, int PercDec)
    {
        if (PercDec == 1)
        {
            QuestionLabel.Text = $" {percentageAnswer}% to a fraction.";
        }
        else
        {
            decimal dec = Convert.ToDecimal(decimalAnswer) / 100;
            QuestionLabel.Text = $" {dec} to a fraction.";
        }
    }

    public void showWorking(int percentageAnswer, int decimalAnswer, int PercDec)
    {
        decimal dec = Convert.ToDecimal(decimalAnswer) / 100;
        if (PercDec == 1)
        {
            Fraction frac = new Fraction(percentageAnswer, 100);
            Working1.Text = $"{percentageAnswer}% = {percentageAnswer}/100";
            Working2.Text = $"If possible, simplify. {percentageAnswer}/100 = {frac}";
            Working3.Text = $"{percentageAnswer}% = {frac}";
        }
        else
        {
            Fraction frac = new Fraction(decimalAnswer, 100);
            Working1.Text = $"{dec} = {decimalAnswer}/100";
            Working2.Text = $"If possible, simplify. {decimalAnswer}/100 = {frac}";
            Working3.Text = $"{dec} = {frac}";
        }
    }

    public void checkAnswer(int percentageAnswer, int decimalAnswer, int PercDec, string answerInput)
    {
        if (PercDec == 1)
        {
            Fraction fractionFromPerc = new Fraction(percentageAnswer, 100);
            if (answerInput == fractionFromPerc.ToString())
            {
                if (questionAttempted == false)
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsAttempted++;
                        topicData.TotalQuestionsCorrect++;
                        todaysDate.answeredQuestion = true;
                        questionAttempted = true;
                        questionCorrect = true;
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                        DateViewModel.Current.SaveData(todaysDate);
                    }
                    else
                    {
                        AnswerLabel.Text = $"Correct!";
                    }
                }
                else
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsCorrect++;
                        todaysDate.answeredQuestion = true;
                        questionAttempted = true;
                        questionCorrect = true;
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                        DateViewModel.Current.SaveData(todaysDate);
                    }
                    else
                    {
                        AnswerLabel.Text = $"Correct!";
                    }
                }
            }
            else
            {
                if (questionAttempted == false)   //checking if they have already attempted the question to maintain consistent data

                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
                    questionAttempted = true;
                    topicData.TotalQuestionsAttempted++;
                    AnswerLabel.Text = $"Incorrect, try again!";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
                    AnswerLabel.Text = $"Incorrect, try again!";
                }
            }
        }
        else
        {
            Fraction fractionFromDec = new Fraction(decimalAnswer,100);
            if (answerInput == fractionFromDec.ToString())
            {
                if (questionAttempted == false)
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsAttempted++;
                        topicData.TotalQuestionsCorrect++;
                        todaysDate.answeredQuestion = true;
                        questionAttempted = true;
                        questionCorrect = true;
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                        DateViewModel.Current.SaveData(todaysDate);
                    }
                    else
                    {
                        AnswerLabel.Text = $"Correct!";
                    }
                }
                else
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsCorrect++;
                        todaysDate.answeredQuestion = true;
                        questionAttempted = true;
                        questionCorrect = true;
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                        DateViewModel.Current.SaveData(todaysDate);
                    }
                    else
                    {
                        AnswerLabel.Text = $"Correct!";
                    }
                }
            }
            else
            {
                if (questionAttempted == false)   //checking if they have already attempted the question to maintain consistent data

                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
                    questionAttempted = true;
                    topicData.TotalQuestionsAttempted++;
                    AnswerLabel.Text = $"Incorrect, try again!";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
                    AnswerLabel.Text = $"Incorrect, try again!";
                }
            }
        }
    }
}