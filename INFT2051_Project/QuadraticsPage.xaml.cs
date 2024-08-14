namespace INFT2051_Project;

public partial class QuadraticsPage : ContentPage
{
    int a = 0;
    int b = 0;
    int op_1 = 0;
    int op_2 = 0;

    public QuadraticsPage()
    {
        InitializeComponent();
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {

        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        if (btn == Back)
            await Navigation.PushAsync(new MainPage());
        else if (btn == NextQuestion)
        {
            a = getInteger();
            b = getInteger();
            createQuestion(a, b);
        }

        else if (btn == SubmitAnswer1)
        {
            string input_1 = AnswerInput1.Text;
            string input_2 = AnswerInput2.Text;
            checkAnswer(a, b, input_1, input_2);
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
            AnswerLabel.Text = "Both are correct";
        }

        else if (string_a == input_b && string_b == input_a)
        {
            AnswerLabel.Text = "Both are correct";
        }

        else if (string_a == input_a && string_b != input_b)
        {
            AnswerLabel.Text = $"{a} is correct";
        }

        else if (string_a != input_a && string_b == input_b)
        {
            AnswerLabel.Text = $"{b} is correct";
        }

        else if (string_a != input_b && string_b == input_a)
        {
            AnswerLabel.Text = $"{b} is correct";
        }

        else if (string_a == input_b && string_b != input_a)
        {
            AnswerLabel.Text = $"{a} is correct";
        }

        else
        {
            AnswerLabel.Text = $"Neither {input_a} or {input_b} are correct";    
        }
    }

    public void showWorking(int a, int b)
    {

    }

    public void createQuestion(int a, int b)
    {
        int question_a = -1 * a;
        int question_b = -1 * b;
        //Gotta checkl for all combinations of roots a and b. REMEMBER, A AND B ARE SELECTED SUCH THAT WHEN X=A OR X=B, THE EQUATION = 0
        //then check for the nature of the middle term (a + b)x
        if (a < 0 && b < 0) //if a and b are negative. i.e (x+a)(x+b)=0. 
        {
            QuestionLabel.Text = $" + {-1* (a + b)}x + {a * b}  = 0";
        }

        else if (a < 0 && b == 0)    //if a is negative and b is 0. x(x + a)
        {
            QuestionLabel.Text = $" + {-1*a}x = 0";
        }

        else if (a < 0 && b > 0) //if a is negative and b is positive. (x+a)(x-b). x^2 + (a - b)x - ab
        {
            //Need to check if question_a is more/less positive/negative than question_b
            if (question_a > Math.Abs(question_b))  // should be positive x coefficient
            {
                QuestionLabel.Text = $" + {question_a + question_b}x - {-1*a * b} = 0";
            }

            else if (question_a < Math.Abs(question_b))  // should be positive x coefficient
            {
                QuestionLabel.Text = $" - {-1*(question_a + question_b)}x - {-1*a * b}  = 0";
            }
        }

        else if (a == 0 && b < 0)    //x(x+b)
        {
            QuestionLabel.Text = $" + {-1 * b}x = 0";
        }

        else if (a == 0 && b == 0)   //x^2
        {
            QuestionLabel.Text = $" = 0";
        }

        else if (a == 0 && b > 0)    //x(x-b)
        {
            QuestionLabel.Text = $" + {b}x = 0";
        }

        else if (a > 0 && b < 0) //(x-a)(x+b). x^2 + (b-a)x - ab
        {
            if (question_b > Math.Abs(question_a))
            {
                QuestionLabel.Text = $" + {(question_b + question_a)}x - {-1 * a * b} = 0";
            }
            else if (question_b < Math.Abs(question_a))
            {
                QuestionLabel.Text = $" - {(question_b - question_a)}x - {-1 * a * b} = 0";
            }
                
        }

        else if (a > 0 && b == 0)    //x(x-a)
        {
            QuestionLabel.Text = $" - {a}x = 0";
        }

        else if (a > 0 && b > 0) //(x-a)(x-b). x^2 - (a + b)x + ab
        {
            QuestionLabel.Text = $" - {a + b}x + {a*b} = 0";
        }

        else if (a == b) // checking if it is a repeated root, i.e (x + a)^2 if a is -/ve. and (x - a)^2 if a is positive.
        {
            if (a < 0)  //(x+a)^2
            {
                QuestionLabel.Text = $" + {-2 * a}x + {a*a}  = 0";
            }
            else    //(x-a)^2
            {
                QuestionLabel.Text = $" - {2 * a}x + {a * a} = 0";
            }
        }

        else if (b == -1 * a)    //checking for difference of two squares. (x+a)(x-a)
        {
            QuestionLabel.Text = $" - {a * a} = 0";
        }
    }
}