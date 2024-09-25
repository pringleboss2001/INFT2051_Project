using Mehroz;
using INFT2051_Project.Models;
using INFT2051_Project.ViewModels;
namespace INFT2051_Project;

public partial class PercentagesPage : ContentPage
{
    int denominator = 0;
    int numerator = 0;
    float decimalAnswer = 0;
    int FracDec = 0;

    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;
    DateViewModel dateViewModel;

    TopicData topicData = new TopicData()
    {
        Id = 6,
        TopicName = "Converting to Percentages",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0,
    };

    UserActivity todaysDate = new UserActivity()
    {
        Id = 0,
        Date = DateTime.Today.ToString("dd/MM/yyyy"),
        answeredQuestion = false
    };
    public PercentagesPage()
	{
        BindingContext = viewModel = new DataViewModel();
        BindingContext = dateViewModel = new DateViewModel();
        InitializeComponent();
        Random numberGenerator = new Random();
        denominator = numberGenerator.Next(2, 11);
        numerator = numberGenerator.Next(1, denominator);
        decimalAnswer = numberGenerator.Next(1, 100);
        FracDec = numberGenerator.Next(1, 3);
        createQuestion(numerator, denominator, decimalAnswer, FracDec);
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
            Working3.IsVisible = true;
            AnswerLabel.IsVisible = false;
            //display question function
            Random numberGenerator = new Random();
            denominator = numberGenerator.Next(2, 11);
            numerator = numberGenerator.Next(1, denominator); 
            decimalAnswer = numberGenerator.Next(1, 100);
            FracDec = numberGenerator.Next(1, 3);
            createQuestion(numerator, denominator, decimalAnswer, FracDec);
        }
        else if (btn == SubmitAnswer)
        {
            //Display solution + answer
            string answerInput = AnswerInput.Text;
            AnswerLabel.IsVisible = true;
            checkAnswer(numerator, denominator, decimalAnswer, FracDec, answerInput);
        }
        else if (btn == ShowWorking)
        {
            WorkingGrid.IsVisible = true;
            showWorking(numerator, denominator, decimalAnswer, FracDec);
        }
    }

    public void createQuestion(int numerator, int denominator, float decimalAnswer, int FracDec)
    {
        if (FracDec == 1)   //if the question is Fraction --> Percentage
        {
            QuestionLabel.Text = $"Convert {numerator}/{denominator} to a percentage.";
        }
        else   //if the quesiton is Decimal --> Percentage
        {    
            float dec = decimalAnswer / 100;
            QuestionLabel.Text = $"Convert {dec.ToString()} to a percentage.";
        }
    }

    public void showWorking(int numerator, int denominator, float decimalAnswer, int FracDect)
    {
        if (FracDec == 1)   //if the question is Fraction --> Percentage
        {
            
            decimal answer = Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)) * 100, 1);
            decimal working = Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)), 3);
            if ((int)answer == answer)
            {
                answer = Math.Round(answer, 0);
            }
            Working1.Text = $"{numerator} \u00F7 {denominator} = {Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)),3)}";
            Working2.Text = $"{working} \u00D7 100 = {answer}";
            Working3.Text = $"{numerator}/{denominator} = {answer}%";
        }
        else   //if the quesiton is Decimal --> Percentage
        {
            float dec = decimalAnswer / 100;
            Working1.Text = $"{dec} \u00D7 100 = {decimalAnswer.ToString()}";
            Working2.Text = $"{dec} = {decimalAnswer.ToString()}%";
            Working3.IsVisible = false;
        }

    }

    public void checkAnswer(int numerator, int denominator, float decimalAnswer, int FracDec, string answerInput)
    {        
        decimal fractionAnswer = Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)) * 100, 1);

        if ((int)fractionAnswer == fractionAnswer)
        {
            fractionAnswer = Math.Round(fractionAnswer, 0);
        }

        if (FracDec == 1)
        {
            if (answerInput == fractionAnswer.ToString())
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
            if (answerInput == decimalAnswer.ToString())
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