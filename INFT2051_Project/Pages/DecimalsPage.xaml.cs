using INFT2051_Project.ViewModels;
using INFT2051_Project.Models;

namespace INFT2051_Project;

public partial class DecimalsPage : ContentPage
{
    int denominator = 0;
    int numerator = 0;
    float percentageAnswer = 0;
    int FracPerc = 0;

    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;
    DateViewModel dateViewModel;

    TopicData topicData = new TopicData()
    {
        Id = 5,
        TopicName = "Converting to Decimals",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0,
    };

    UserActivity todaysDate = new UserActivity()
    {
        Id = 0,
        Date = DateTime.Today.ToString("dd/MM/yyyy"),
        answeredQuestion = false
    };

    public DecimalsPage()
	{
        BindingContext = viewModel = new DataViewModel();
        BindingContext = dateViewModel = new DateViewModel();
        InitializeComponent();
        Random numberGenerator = new Random();
        denominator = numberGenerator.Next(2, 11);
        numerator = numberGenerator.Next(1, denominator);
        percentageAnswer = numberGenerator.Next(1, 100);
        FracPerc = numberGenerator.Next(1, 3);
        createQuestion(numerator, denominator, percentageAnswer, FracPerc);
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
            //display question function
            questionAttempted = false;
            questionCorrect = false;
            WorkingGrid.IsVisible = false;
            Random numberGenerator = new Random();
            denominator = numberGenerator.Next(2, 11);
            numerator = numberGenerator.Next(1, denominator);
            percentageAnswer = numberGenerator.Next(1, 100);
            FracPerc = numberGenerator.Next(1, 3);
            createQuestion(numerator, denominator, percentageAnswer, FracPerc);
        }
        else if (btn == SubmitAnswer)
        {
            //Display solution + answer
            string answerInput = AnswerInput.Text;
            
            checkAnswer(numerator, denominator, percentageAnswer, FracPerc, answerInput);
        }
        else if (btn == ShowWorking)
        {
            Working3.IsVisible = false;
            WorkingGrid.IsVisible = true;
            showWorking(numerator, denominator, percentageAnswer, FracPerc);
        }
    }

    public void createQuestion(int numerator, int denominator, float percentageAnswer, int FracDec)
    {
        if (FracDec == 1)   //if the question is Fraction --> Percentage
        {
            QuestionLabel.Text = $" {numerator}/{denominator} to a decimal.";
        }
        else   //if the quesiton is Decimal --> Percentage
        {
            QuestionLabel.Text = $" {percentageAnswer.ToString()}% to a decimal.";
        }
    }

    public void showWorking(int numerator, int denominator, float percentageAnswer, int FracPerc)
    {
        if (FracPerc == 1)   //if the question is Fraction --> decimal
        {

            decimal answer = Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)) * 100, 1);
            decimal working = Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)), 3);
            if ((int)answer == answer)
            {
                answer = Math.Round(answer, 0);
            }
            Working1.Text = $"{numerator} \u00F7 {denominator} = {Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)), 3)}";
            Working2.Text = $"{numerator}/{denominator} = {working}";
            Working3.Text = $"{numerator}/{denominator} = {answer}";
        }
        else   //if the quesiton is Percentage --> decimal
        {
            float answer = percentageAnswer / 100;
            Working1.Text = $"{percentageAnswer} \u00F7 100 = {answer.ToString()}";
            Working2.Text = $"{percentageAnswer}% = {answer.ToString()}";
        }

    }

    public void checkAnswer(int numerator, int denominator, float percentageAnswer, int FracPerc, string answerInput)
    {
        decimal fractionAnswer = Math.Round((Convert.ToDecimal(numerator) / Convert.ToDecimal(denominator)), 3);

        if (FracPerc == 1)
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
            float answer = percentageAnswer / 100;
            if (answerInput == answer.ToString())
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