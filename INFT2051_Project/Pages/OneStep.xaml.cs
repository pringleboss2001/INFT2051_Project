using INFT2051_Project.Models;
using INFT2051_Project.Services;
using INFT2051_Project.ViewModels;
using Mehroz;
using SQLite;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace INFT2051_Project;

public partial class OneStep : ContentPage
{
    int a;
    int b;
    int op;
    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;
    DateViewModel dateViewModel;
    
    TopicData topicData = new TopicData()
    {
        Id = 1,
        TopicName = "One Step Equations",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0,
    };

    UserActivity todaysDate = new UserActivity()
    {
        Id = 0,
        Date = DateTime.Today.ToString(),
        answeredQuestion = false
    };

    public OneStep()
	{
        BindingContext = viewModel = new DataViewModel();
        BindingContext = dateViewModel = new DateViewModel();
        InitializeComponent();
        createQuestion(a=getInteger(), b=getInteger(), op=getOperator());
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");
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
            questionAttempted = false;
            questionCorrect = false;
            WorkingGrid.IsVisible = false;
            a = getInteger();
            b = getInteger();
            op = getOperator();

            createQuestion(a, b, op);
        }

        else if (btn == SubmitAnswer)
        {
            string input = AnswerInput.Text;
            var answer = getAnswer(a, b, op);
            if (input == answer)
            {
                if (questionAttempted==false)
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsAttempted++;
                        topicData.TotalQuestionsCorrect++;
                        todaysDate.answeredQuestion = true;
                        questionAttempted = true;
                        questionCorrect=true;
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        AnswerLabel.Text = $"{topicData.TotalQuestionsAttempted} , {topicData.TotalQuestionsCorrect}";
                        DataViewModel.Current.UpdateData(topicData);
                        DateViewModel.Current.SaveData(todaysDate);
                    }
                    else
                    {
                        AnswerLabel.Text = $"{topicData.TotalQuestionsAttempted} , {topicData.TotalQuestionsCorrect}";
                        //AnswerLabel.Text = $"correct";
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
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        AnswerLabel.Text = $"{topicData.TotalQuestionsAttempted} , {topicData.TotalQuestionsCorrect}";
                        //AnswerLabel.Text = $"correct";
                        DataViewModel.Current.UpdateData(topicData);
                        DateViewModel.Current.SaveData(todaysDate);
                    }
                    else
                    {
                        AnswerLabel.Text = $"{topicData.TotalQuestionsAttempted} , {topicData.TotalQuestionsCorrect}";
                        //AnswerLabel.Text = $"correct";
                    }
                }
                
                
            }
            else
            {
                if (questionAttempted==false)   //checking if they have already attempted the question to maintain consistent data

                {
                    //Vibration.Default.Vibrate(10);
                    questionAttempted = true;
                    topicData.TotalQuestionsAttempted++;
                    AnswerLabel.Text = $"{topicData.TotalQuestionsAttempted} , {topicData.TotalQuestionsCorrect}";
                    //AnswerLabel.Text = $"wrong";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                {
                    //Vibration.Default.Vibrate(10);
                    AnswerLabel.Text = $"{topicData.TotalQuestionsAttempted} , {topicData.TotalQuestionsCorrect}";
                    //AnswerLabel.Text = $"wrong";
                }
                
            }
                
        }

        else if (btn == ShowWorking)
        {
            WorkingGrid.IsVisible = true;
            showWorking(a, b, op);
        }
    }

    public int getOperator()
    {
        int operatorSelect=0;   //initialise operatorSelect
        Random numberGenerator = new Random();
        operatorSelect = numberGenerator.Next(1, 5);    //generators a number from 1 to 4. 1=Addition, 2=Subtraction, 3=Multiplication, 4=Division
        return operatorSelect;
    }

    public int getInteger()
    {
        int a;
        Random numberGenerator = new Random();
        a = numberGenerator.Next(1, 30);
        return a;
    }

    public void createQuestion(int a, int b, int op)
    {
        if (op == 1)
        {
            QuestionLabel.Text = $"x + {a} = {b}";
        }

        else if (op == 2)
        {
            QuestionLabel.Text = $"x - {a} = {b}";
        }

        else if (op == 3)
        {
            QuestionLabel.Text = $"{a}x = {b}";
        }

        else
        {
            QuestionLabel.Text = $"x/{a} = {b}";
        }
    }

    public string getAnswer(int a, int b, int operatorSelect)
    {
        Fraction frac = new Fraction(b, a); //making a fraction with numerator b, denominator a
        float answer = 0;
        if (operatorSelect == 1)    //if the equation is of the from x + a = b
        {
            answer = (b - a);
            return answer.ToString();
        }

        else if (operatorSelect == 2)    //if the equation is of the from x - a = b
        {
            answer = (b + a);
            return answer.ToString();
        }

        else if (operatorSelect == 3)    //if the equation is of the from ax = b
        {
           //Need to check if the division b/a is a whole number.
           answer = (b / a);
           return frac.ToString();
        }

        else        //If the equation is of the form x/a = b
        {
            answer = (b * a);
            return answer.ToString();
        }
    }

    public void showWorking(int a, int b, int op)
    {
        Fraction frac = new Fraction(b, a); //making a fraction with numerator b, denominator a
        float answer = 0;
        if (op == 1)    //if the equation is of the from x + a = b
        {
            answer = (b - a);
            Working1.Text = $"x + {a} = {b}";
            Working2.Text = $"x + {a} - {a} = {b} - {a}";
            Working3.Text = $"x = {answer}";
        }

        else if (op == 2)    //if the equation is of the from x - a = b
        {
            answer = (b + a);
            Working1.Text = $"x - {a} = {b}";
            Working2.Text = $"x - {a} + {a} = {b} + {a}";
            Working3.Text = $"x = {answer}";
        }

        else if (op == 3)    //if the equation is of the from ax = b
        {
            //Need to check if the division b/a is a whole number.
            answer = (b / a);
            Working1.Text = $"{a}x = {b}";
            Working2.Text = $"{a}x \u00F7 {a} = {b} \u00F7 {a}";
            Working3.Text = $"x = {frac}";

        }

        else        //If the equation is of the form x/a = b
        {
            answer = (b * a);
            Working1.Text = $"x/{a} = {b}";
            Working2.Text = $"x/{a} \u00D7 {a} = {b} \u00d7 {a}";
            Working3.Text = $"x = {answer}";
        }
    }
}