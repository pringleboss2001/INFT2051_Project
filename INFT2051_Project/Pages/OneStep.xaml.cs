using INFT2051_Project.Models;
using INFT2051_Project.Services;
using INFT2051_Project.ViewModels;
using Mehroz;
using SQLite;
using System.Data;

namespace INFT2051_Project;

public partial class OneStep : ContentPage
{

    int a;
    int b;
    int op;
    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;   //reads in a dataViewModel
    SQLiteConnection connection = DatabaseService.Connection;

    TopicData oneStepData = new TopicData() //creating a new TopicData object to pass to dataViewModel. I need to read in the data base values to this entity
    {
        Id = 0,
        TopicName = "One Step Equations",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0
    };

    
    

    public OneStep()
	{
        InitializeComponent();
        BindingContext = viewModel = new DataViewModel();
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");
        List<TopicData> data = connection.Table<TopicData>().ToList();
        
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
            NextQuestion.Text = "Next Question";
            WorkingGrid.IsVisible = false;
            a = getInteger();
            b = getInteger();
            op = getOperator();

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
                        oneStepData.TotalQuestionsAttempted++;
                        oneStepData.TotalQuestionsCorrect++;
                        questionAttempted = true;
                        questionCorrect=true;
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        AnswerLabel.Text = $"{oneStepData.TotalQuestionsAttempted} , {oneStepData.TotalQuestionsCorrect}";
                        DataViewModel.Current.SaveData(oneStepData);
                    }
                    else
                    {
                        AnswerLabel.Text = $"{oneStepData.TotalQuestionsAttempted} , {oneStepData.TotalQuestionsCorrect}";
                        DataViewModel.Current.SaveData(oneStepData);
                    }
                }
                else
                {
                    if (questionCorrect == false)
                    {
                        oneStepData.TotalQuestionsCorrect++;
                        questionAttempted = true;
                        questionCorrect = true;
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        //Vibration.Default.Vibrate(2);
                        AnswerLabel.Text = $"{oneStepData.TotalQuestionsAttempted} , {oneStepData.TotalQuestionsCorrect}";
                        DataViewModel.Current.SaveData(oneStepData);
                    }
                    else
                    {
                        AnswerLabel.Text = $"{oneStepData.TotalQuestionsAttempted} , {oneStepData.TotalQuestionsCorrect}";
                        DataViewModel.Current.SaveData(oneStepData);
                    }
                }
                
                
            }
            else
            {
                if (questionAttempted==false)   //checking if they have already attempted the question to maintain consistent data

                {
                    //Vibration.Default.Vibrate(10);
                    questionAttempted = true;
                    oneStepData.TotalQuestionsAttempted++;
                    AnswerLabel.Text = $"{oneStepData.TotalQuestionsAttempted} , {oneStepData.TotalQuestionsCorrect}";
                    DataViewModel.Current.SaveData(oneStepData);
                }
                else
                {
                    //Vibration.Default.Vibrate(10);
                    AnswerLabel.Text = $"{oneStepData.TotalQuestionsAttempted} , {oneStepData.TotalQuestionsCorrect}";
                    DataViewModel.Current.SaveData(oneStepData);
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