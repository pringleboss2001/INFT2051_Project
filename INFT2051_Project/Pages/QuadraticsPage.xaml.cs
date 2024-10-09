using INFT2051_Project.Models;
using INFT2051_Project.Pages;
using INFT2051_Project.Services;
using INFT2051_Project.ViewModels;
using Mehroz;
using SQLite;
using System.Data;
namespace INFT2051_Project;

public partial class QuadraticsPage : ContentPage
{
    int a = 0;
    int b = 0;
    bool questionAttempted;
    bool questionCorrect;

    DataViewModel viewModel;

    TopicData topicData = new TopicData()
    {
        Id = 3,
        TopicName = "Quadratic Equations",
        TotalQuestionsAttempted = 0,
        TotalQuestionsCorrect = 0,
    };


    public QuadraticsPage()
    {
        BindingContext = viewModel = new DataViewModel();
        InitializeComponent();
        a = getInteger();
        b = getInteger();
        createQuestion(a, b);
    }

    protected override void OnAppearing()
    {
        viewModel.OnPropertyChanged("Topics");
        topicData = DataViewModel.Current.getTopicData(topicData);
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {

        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        if (btn == Back)
            await Navigation.PushAsync(new EquationsPage());
        else if (btn == NextQuestion)
        {
            AnswerInput1.Text = "";
            AnswerInput2.Text = "";
            questionAttempted = false;
            questionCorrect = false;
            WorkingArea.IsVisible = false;
            AnswerLabel.IsVisible = false;
            a = getInteger();
            b = getInteger();
            createQuestion(a, b);
        }

        else if (btn == SubmitAnswer)
        {
            string input_1 = AnswerInput1.Text;
            string input_2 = AnswerInput2.Text;
            AnswerLabel.IsVisible = true;
            checkAnswer(a, b, input_1, input_2);
        }

        else if (btn == ShowWorking)
        {
            WorkingArea.IsVisible = true;
            showWorking(a, b);
        }
    }

    public int getInteger()
    {
        Random numberGenerator = new Random();
        int a = numberGenerator.Next(-9, 10);
        return a;
    }

    public int getOperatorAddSub()
    {
        Random numberGenerator = new Random();
        int AddSub = numberGenerator.Next(1, 3);
        return AddSub;
    }

    public void checkAnswer(int a, int b, string input_a, string input_b)
    {
        string string_a = a.ToString();
        string string_b = b.ToString();

        if (string_a == input_a && string_b == input_b)
        {
            if (questionAttempted == false)
            {
                if (questionCorrect == false)
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    questionAttempted = true;
                    questionCorrect = true;
                    topicData.TotalQuestionsCorrect++;
                    topicData.TotalQuestionsAttempted++;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                { 
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    questionAttempted = true;
                    questionCorrect = true;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
                
            }
            else
            {
                if (questionCorrect == false)
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    topicData.TotalQuestionsCorrect++;
                    questionAttempted = true;
                    questionCorrect = true;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    questionAttempted = true;
                    questionCorrect = true;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
            }
        }

        else if (string_a == input_b && string_b == input_a)
        {
            if (questionAttempted == false)
            {
                if (questionCorrect == false)
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    questionAttempted = true;
                    questionCorrect = true;
                    topicData.TotalQuestionsCorrect++;
                    topicData.TotalQuestionsAttempted++;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    questionAttempted = true;
                    questionCorrect = true;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }

            }
            else
            {
                if (questionCorrect == false)
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    topicData.TotalQuestionsCorrect++;
                    questionAttempted = true;
                    questionCorrect = true;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
                else
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                    questionAttempted = true;
                    questionCorrect = true;
                    AnswerLabel.Text = "Both are correct";
                    DataViewModel.Current.UpdateData(topicData);
                }
            }
        }

        else if (string_a == input_a && string_b != input_b)
        {
            if (questionAttempted == false)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                questionAttempted = true;
                topicData.TotalQuestionsAttempted++;
                DataViewModel.Current.UpdateData(topicData);
                AnswerLabel.Text = $"{a} is correct";
            }
            else
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                AnswerLabel.Text = $"{a} is correct";
            }
        }

        else if (string_a != input_a && string_b == input_b)
        {
            if (questionAttempted == false)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                questionAttempted = true;
                topicData.TotalQuestionsAttempted++;
                DataViewModel.Current.UpdateData(topicData);
                AnswerLabel.Text = $"{b} is correct";
            }
            else
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                AnswerLabel.Text = $"{b} is correct";
            }
        }

        else if (string_a != input_b && string_b == input_a)
        {
            if (questionAttempted == false)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                questionAttempted = true;
                topicData.TotalQuestionsAttempted++;
                DataViewModel.Current.UpdateData(topicData);
                AnswerLabel.Text = $"{b} is correct";
            }
            else
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                AnswerLabel.Text = $"{b} is correct";
            }
        }

        else if (string_a == input_b && string_b != input_a)
        {
            if (questionAttempted == false)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                questionAttempted = true;
                topicData.TotalQuestionsAttempted++;
                DataViewModel.Current.UpdateData(topicData);
                AnswerLabel.Text = $"{a} is correct";
            }
            else
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                AnswerLabel.Text = $"{a} is correct";
            }
        }

        else
        {
            if (questionAttempted == false)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));

                questionAttempted = true;
                topicData.TotalQuestionsAttempted++;
                AnswerLabel.Text = $"Neither {input_a} or {input_b} are correct";
                DataViewModel.Current.UpdateData(topicData);
            }
            else
            {                
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
                AnswerLabel.Text = $"Neither {input_a} or {input_b} are correct";
            }
                
        }
    }

    public void showWorking(int a, int b)
    {
        int question_a = -1 * a;
        int question_b = -1 * b;


        if (a == b && a != 0) // checking if it is a repeated root, i.e (x + a)^2 if a is -/ve. and (x - a)^2 if a is positive.
        {
            if (a < 0)  //(x+a)^2
            {
                Working1.IsVisible = true;
                Working2.IsVisible = true;
                Working3.IsVisible = true;
                Working4.IsVisible = true;
                Working5.IsVisible = true;
                Working1.Text = $"x\u00b2 + {-2 * a}x + {a * a}  = 0";
                Working2.Text = $"a + b = {2 * question_a} and a × b = {a * a}";
                Working3.Text = $"{question_a} + {question_a} = {2 * question_a} and {question_a} × {question_a} = {a * a}";
                Working4.Text = $"(x + {question_a})\u00b2 = 0";
                Working5.Text = $"x = {a}. (Repeated Roots)";
            }
            else    //(x-a)^2
            {
                Working1.IsVisible = true;
                Working2.IsVisible = true;
                Working3.IsVisible = true;
                Working4.IsVisible = true;
                Working5.IsVisible = true;
                Working1.Text = $"x\u00b2 - {2 * a}x + {a * a} = 0";
                Working2.Text = $"a + b = {2 * question_a} and a × b = {a * a}";
                Working3.Text = $"{question_a} + {question_a} = {2 * question_a} and {question_a} × {question_a} = {a * a}";
                Working4.Text = $"(x - {a})\u00b2 = 0";
                Working5.Text = $"x = {a}. (Repeated Roots)";
            }
        }

        else if (b == -1 * a)    //checking for difference of two squares. (x+a)(x-a)
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = true;
            Working5.IsVisible = true;
            Working1.Text = $"x\u00b2 - {a * a} = 0";
            Working2.Text = $"a + b = 0 and a × b = {a * b}";
            Working3.Text = $"{question_a} + {question_b} = 0 and {question_a} × {question_b} = {a * b}";
            if (a < 0)
            {
                Working4.Text = $"(x + {question_a})(x - {-1 * question_b}) = 0";
            }
            else 
            {
                Working4.Text = $"(x - {a})(x + {question_b}) = 0";
            }
            Working5.Text = $"x = {a} or x = {b}";
        }

        else if (a < 0 && b < 0) //if a and b are negative. i.e (x+a)(x+b)=0. 
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = true;
            Working5.IsVisible = true;
            Working1.Text = $"x\u00b2 + {-1 * (a + b)}x + {a * b}  = 0";
            Working2.Text = $"a + b = {-1 * (a + b)} and a × b = {a * b}";
            Working3.Text = $"{question_a} + {question_b} = {-1 * (a + b)} and {question_a} × {question_b} = {a * b}";
            Working4.Text = $"(x + {question_a})(x + {question_b}) = 0";
            Working5.Text = $"x = {a} or x = {b}";
        }

        else if (a < 0 && b == 0)    //if a is negative and b is 0. x(x + a)
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = false;
            Working5.IsVisible = false;
            Working1.Text = $"x\u00b2 + {-1 * a}x = 0";
            Working2.Text = $"x(x + {question_a}) = 0";
            Working3.Text = $"x = {a} or x = 0";
        }

        else if (a < 0 && b > 0) //if a is negative and b is positive. (x+a)(x-b). x^2 + (a - b)x - ab
        {
            //Need to check if question_a is more/less positive/negative than question_b
            if (question_a > Math.Abs(question_b))  // should be positive x coefficient
            {
                Working1.IsVisible = true;
                Working2.IsVisible = true;
                Working3.IsVisible = true;
                Working4.IsVisible = true;
                Working5.IsVisible = true;
                Working1.Text = $"x\u00b2 + {question_a + question_b}x - {-1 * a * b} = 0";
                Working2.Text = $"a + b = {question_a + question_b} and a × b = {a * b}";
                Working3.Text = $"{question_a} + {question_b} = {question_a + question_b} and {question_a} × {question_b} = {a * b}";
                Working4.Text = $"(x + {question_a})(x - {b}) = 0";
                Working5.Text = $"x = {a} or x = {b}";
            }

            else if (question_a < Math.Abs(question_b))  // should be positive x coefficient
            {
                Working1.IsVisible = true;
                Working2.IsVisible = true;
                Working3.IsVisible = true;
                Working4.IsVisible = true;
                Working5.IsVisible = true;
                Working1.Text = $"x\u00b2 - {-1 * (question_a + question_b)}x - {-1 * a * b}  = 0";
                Working2.Text = $"a + b = {question_a + question_b} and a × b = {a * b}";
                Working3.Text = $"{question_a} + {question_b} = {question_a + question_b} and {question_a} × {question_b} = {a * b}";
                Working4.Text = $"(x + {question_a})(x - {-1 * question_b}) = 0";
                Working5.Text = $"x = {a} or x = {b}";
            }
        }

        else if (a == 0 && b < 0)    //x(x+b)
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = false;
            Working5.IsVisible = false;
            Working1.Text = $"x\u00b2 + {-1 * b}x = 0";
            Working2.Text = $"x(x + {question_b}) = 0";
            Working3.Text = $"x = {b} or x = 0";
            
        }

        else if (a == 0 && b == 0)   //x^2
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = false;
            Working4.IsVisible = false;
            Working5.IsVisible = false;
            Working1.Text = $"x\u00b2 = 0";
            Working2.Text = $"x = 0 (repeated root)";
        }

        else if (a == 0 && b > 0)    //x(x-b)
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = false;
            Working5.IsVisible = false;
            Working1.Text = $"x\u00b2 - {b}x = 0";
            Working2.Text = $"x(x - {b}) = 0";
            Working3.Text = $"x = 0 or x = {b}";
        }

        else if (a > 0 && b < 0) //(x-a)(x+b). x^2 + (b-a)x - ab
        {
            if (question_b > Math.Abs(question_a))
            {
                Working1.IsVisible = true;
                Working2.IsVisible = true;
                Working3.IsVisible = true;
                Working4.IsVisible = true;
                Working5.IsVisible = true;
                Working1.Text = $"x\u00b2 + {(question_b + question_a)}x - {-1 * a * b} = 0";
                Working2.Text = $"a + b = {(question_b + question_a)} and a × b = {question_b * question_a}";
                Working3.Text = $"{question_a} + {question_b} = {(question_b + question_a)} and {question_a} × {question_b} = {question_b * question_a}";
                Working4.Text = $"(x - {a})(x + {question_b}) = 0";
                Working5.Text = $"x = {a} or x = {b}";
            }
            else if (question_b < Math.Abs(question_a))
            {
                Working1.IsVisible = true;
                Working2.IsVisible = true;
                Working3.IsVisible = true;
                Working4.IsVisible = true;
                Working5.IsVisible = true;
                Working1.Text = $"x\u00b2 - {-1*(question_b + question_a)}x - {-1 * a * b} = 0";
                Working2.Text = $"a + b = {(question_b + question_a)} and a × b = {question_a * question_b}";
                Working3.Text = $"{question_a} + {question_b} = {(question_b + question_a)} and {question_a} × {question_b} = {question_a * question_b}";
                Working4.Text = $"(x - {a})(x + {question_b}) = 0";
                Working5.Text = $"x = {a} or x = {b}";
            }

        }

        else if (a > 0 && b == 0)    //x(x-a)
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = false;
            Working5.IsVisible = false;
            Working1.Text = $"x\u00b2 - {a}x = 0";
            Working2.Text = $"x(x - {a}) = 0";
            Working3.Text = $"x = 0 or x = {a}";
        }

        else if (a > 0 && b > 0) //(x-a)(x-b). x^2 - (a + b)x + ab
        {
            Working1.IsVisible = true;
            Working2.IsVisible = true;
            Working3.IsVisible = true;
            Working4.IsVisible = true;
            Working5.IsVisible = true;
            Working1.Text = $"x\u00b2 - {a + b}x + {a * b} = 0";
            Working2.Text = $"a + b = {question_a + question_b} and a × b = {question_a * question_b}";
            Working3.Text = $"{question_a} + {question_b} = {question_a + question_b} and {question_a} × {question_b} = {question_a * question_b}";
            Working4.Text = $"(x - {a})(x - {b}) = 0";
            Working5.Text = $"x = {a} or x = {b}";
        }


    }

    public void createQuestion(int a, int b)
    {
        int question_a = -1 * a;
        int question_b = -1 * b;
        //Gotta checkl for all combinations of roots a and b. REMEMBER, A AND B ARE SELECTED SUCH THAT WHEN X=A OR X=B, THE EQUATION = 0
        //then check for the nature of the middle term (a + b)x

        if (a == 0 && b == 0)   //x^2
        {
            QuestionLabel.Text = $"x\u00b2 = 0";
        }

        else if (a == b) // checking if it is a repeated root, i.e (x + a)^2 if a is -/ve. and (x - a)^2 if a is positive.
        {
            if (a < 0)  //(x+a)^2
            {
                QuestionLabel.Text = $"x\u00b2 + {-2 * a}x + {a * a}  = 0";
            }
            else    //(x-a)^2
            {
                QuestionLabel.Text = $"x\u00b2 - {2 * a}x + {a * a} = 0";
            }
        }

        else if (b == -1 * a)    //checking for difference of two squares. (x+a)(x-a)
        {
            QuestionLabel.Text = $"x\u00b2 - {a * a} = 0";
        }

        else if (a < 0 && b < 0) //if a and b are negative. i.e (x+a)(x+b)=0. 
        {
            QuestionLabel.Text = $"x\u00b2 + {-1* (a + b)}x + {a * b}  = 0";
        }

        else if (a < 0 && b == 0)    //if a is negative and b is 0. x(x + a)
        {
            QuestionLabel.Text = $"x\u00b2 + {-1*a}x = 0";
        }

        else if (a < 0 && b > 0) //if a is negative and b is positive. (x+a)(x-b). x^2 + (a - b)x - ab
        {
            //Need to check if question_a is more/less positive/negative than question_b
            if (question_a > Math.Abs(question_b))  // should be positive x coefficient
            {
                QuestionLabel.Text = $"x\u00b2 + {question_a + question_b}x - {-1*a * b} = 0";
            }

            else if (question_a < Math.Abs(question_b))  // should be positive x coefficient
            {
                QuestionLabel.Text = $"x\u00b2 - {-1 * (question_a + question_b)}x - {-1*a * b}  = 0";
            }
        }

        else if (a == 0 && b < 0)    //x(x+b)
        {
            QuestionLabel.Text = $"x\u00b2 + {-1 * b}x = 0";
        }

        else if (a == 0 && b > 0)    //x(x-b)
        {
            QuestionLabel.Text = $"x\u00b2 - {b}x = 0";
        }

        else if (a > 0 && b < 0) //(x-a)(x+b). x^2 + (b-a)x - ab
        {
            if (question_b > Math.Abs(question_a))
            {
                QuestionLabel.Text = $"x\u00b2 + {(question_b + question_a)}x - {-1 * a * b} = 0";
            }
            else if (question_b < Math.Abs(question_a))
            {
                QuestionLabel.Text = $"x\u00b2 - {-1 * (question_b + question_a)}x - {-1 * a * b} = 0";
            }
                
        }

        else if (a > 0 && b == 0)    //x(x-a)
        {
            QuestionLabel.Text = $"x\u00b2 - {a}x = 0";
        }

        else if (a > 0 && b > 0) //(x-a)(x-b). x^2 - (a + b)x + ab
        {
            QuestionLabel.Text = $"x\u00b2 - {a + b}x + {a*b} = 0";
        }       
    }
}