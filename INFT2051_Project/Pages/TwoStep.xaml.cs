using INFT2051_Project.Services;
using INFT2051_Project.ViewModels;
using Mehroz;
using SQLite;
using INFT2051_Project.Models;
namespace INFT2051_Project;

public partial class TwoStep : ContentPage
{
    int a = 0;
    int b = 0;
    int c = 0;
    int AddSub = 0;
    int MulDiv = 0;
    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;

    TopicData topicData = new TopicData()
    {
        Id = 2,
        TopicName = "Two Step Equations",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0,
    };

    public TwoStep()
	{
        BindingContext = viewModel = new DataViewModel();
        InitializeComponent();
        a = getInteger();
        b = getInteger();
        c = getInteger();
        AddSub = getOperatorAddSub();
        MulDiv = getOperatorMulDiv();
        createQuestion(a, b, c, AddSub, MulDiv);
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");
        topicData = DataViewModel.Current.getTopicData(topicData);
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
         
        if (btn == NextQuestion)
        {
            questionAttempted = false;
            questionCorrect = false;
            WorkingGrid.IsVisible = false;
            AnswerLabel.IsVisible = false;
            AnswerInput.Text = "";
            NextQuestion.Text = "Next Question";
            a = getInteger();
            b = getInteger();
            c = getInteger();
            AddSub = getOperatorAddSub();
            MulDiv = getOperatorMulDiv();

            createQuestion(a, b, c, AddSub, MulDiv);
        }   

        else if (btn == SubmitAnswer)
        {
            AnswerLabel.IsVisible = true;
            string input = AnswerInput.Text;
            var answer = getAnswer(a, b, c, MulDiv, AddSub); ;
            if (input == answer)
            {
                if (questionAttempted == false)
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsAttempted++;
                        topicData.TotalQuestionsCorrect++;
                        questionAttempted = true;
                        questionCorrect = true;
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                    }
                    else
                    {
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                    }
                }
                else
                {
                    if (questionCorrect == false)
                    {
                        topicData.TotalQuestionsCorrect++;
                        questionAttempted = true;
                        questionCorrect = true;
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
                    }
                    else
                    {
                        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                        AnswerLabel.Text = $"Correct!";
                        DataViewModel.Current.UpdateData(topicData);
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
                    DataViewModel.Current.UpdateData(topicData);
                }

            }

        }

        else if (btn == ShowWorking)
        {
            WorkingGrid.IsVisible = true;
            showWorking(a, b, c, MulDiv, AddSub);
        }

        else if (btn == Back)
            await Navigation.PushAsync(new MainPage());
    }

    public int getInteger()
    {
        Random numberGenerator = new Random();
        int a = numberGenerator.Next(1, 11);
        return a;
    }

    public int getOperatorAddSub()
    {
        Random numberGenerator = new Random();
        int AddSub = numberGenerator.Next(1, 3);
        return AddSub;
    }

    public int getOperatorMulDiv()
    {
        Random numberGenerator = new Random();
        int MulDiv = numberGenerator.Next(1, 3);
        return MulDiv;
    }

    public void createQuestion(int a, int b, int c, int addsub, int muldiv)
    {
        if (MulDiv == 1)
        {
            if (AddSub == 1)
            {
                //if MulDiv and AddSub == 1, the we have an equation of the form ax + b = c
                QuestionLabel.Text = $"{a}x + {b} = {c}";
            }
            else
            {
                //Equation of the form ax - b = c
                QuestionLabel.Text = $"{a}x - {b} = {c}";
            }
        }

        else if (MulDiv == 2)
        {
            if (AddSub == 1)
            {
                //Equation of the form x/a + b = x
                QuestionLabel.Text = $"x/{a} + {b} = {c}";
            }
            else
            {
                //equation of the form x/a - b = c
                QuestionLabel.Text = $"x/{a} - {b} = {c}";
            }
        }
    }

    public string getAnswer(int a, int b, int c, int MulDiv, int AddSub)
    {
        int TS_Answer = 0;  //initialising the answer
        int TS_Whole_Check_Add = (c - b) % a;   //checking solution is a whole number
        int TS_Whole_Check_Sub = (c + b) % a;   //checking solution is a whole number
        Fraction frac = new Fraction();
        /*
         *If AddSub == 1, the operator is addition
         *If AddSub == 2, the operator is subtraction
         *If MulDiv == 1, the operator is multiplication   
         *If MulDiv == 2, the operator is division
        */

        if (MulDiv == 1 && AddSub == 1)
        {
            //if MulDiv and AddSub == 1, the we have an equation of the form ax + b = c
            TS_Answer = (c - b) / a;
            if (TS_Whole_Check_Add == 0)
                return TS_Answer.ToString();
            else
                frac = new Fraction((c - b), a);
                return frac.ToString();
        }

        else if (MulDiv == 1 && AddSub == 2)
        {
            //Equation of the form ax - b = c
            TS_Answer = ((c + b) / a);
            if (TS_Whole_Check_Sub == 0)
                return TS_Answer.ToString();
            else
                frac = new Fraction((c + b), a);
                return frac.ToString();
        }

        else if (MulDiv == 2 && AddSub == 1)
        {
            //Equation of the form x/a + b = c
            int d = c - b;
            TS_Answer = (d * a);
            return TS_Answer.ToString();
        }
        else
        {
            //equation of the form x/a - b = c
            TS_Answer = ((c + b) * a);
            return TS_Answer.ToString();
        }     
    }

    public void showWorking(int a, int b, int c, int MulDiv, int AddSub)
    {
        Fraction frac = new Fraction();
        if (MulDiv == 1 && AddSub == 1)
        {
            frac = new Fraction((c-b), a);
            //if MulDiv and AddSub == 1, the we have an equation of the form ax + b = c
            Working1.Text = $"{a}x + {b} = {c}";
            Working2.Text = $"{a}x + {b} - {b} = {c} - {b}";
            Working3.Text = $"{a}x = {c - b}";
            Working4.Text = $"{a}x \u00F7 {a} = {c - b} \u00F7 {a}";
            Working5.Text = $"x = {frac}";
        }

        else if (MulDiv == 1 && AddSub == 2)
        {
            //Equation of the form ax - b = c
            frac = new Fraction((c + b), a);
            Working1.Text = $"{a}x - {b} = {c}";
            Working2.Text = $"{a}x - {b} + {b} = {c} + {b}";
            Working3.Text = $"{a}x = {c + b}";
            Working4.Text = $"{a}x \u00F7 {a} = {c + b} \u00F7 {a}";
            Working5.Text = $"x = {frac}";
        }

        else if (MulDiv == 2 && AddSub == 1)
        {
            //Equation of the form x/a + b = c
            Working1.Text = $"x/{a} + {b} = {c}";
            Working2.Text = $"x/{a} + {b} - {b} = {c} - {b}";
            Working3.Text = $"x/{a} = {c - b}";
            Working4.Text = $"x/{a} \u00D7 {a} = {c - b} \u00D7 {a}";
            Working5.Text = $"x = {(c-b)*a}";
        }
        else if (MulDiv == 2 && AddSub == 2)
        {
            //equation of the form x/a - b = c
            Working1.Text = $"x/{a} - {b} = {c}";
            Working2.Text = $"x/{a} - {b} + {b} = {c} + {b}";
            Working3.Text = $"x/{a} = {c + b}";
            Working4.Text = $"x/{a} \u00D7 {a} = {c + b} \u00D7 {a}";
            Working5.Text = $"x = {(c + b) * a}";
        }
    }
}
                
   

            
        