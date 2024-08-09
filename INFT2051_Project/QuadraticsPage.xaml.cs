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
            op_1 = getOperatorAddSub();
            op_2 = getOperatorAddSub();
            showQuestion(a, b, op_1, op_2);
        }

        else if (btn == SubmitAnswer1)
        {
            string input_1 = AnswerInput1.Text;
            string input_2 = AnswerInput2.Text;
            checkAnswer(a, b, op_1, op_2, input_1, input_2);
        }
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

    public void checkAnswer(int a, int b, int op_1, int op_2, string input_a, string input_b)
    {

        //a and b are the roots of the equations.
        //check for the neature of the roots
        if (op_1 == 1 && op_2 == 1)     //(x+a)(x+b), therefore two negative roots
        {
            a = -1 * a;
            b = -1 * b;
        }

        else if (op_1 == 1 && op_2 == 2)    //(x+a)(x-b), therefore the roots are -a and b
        {
            a = -1 * a;
        }

        else if (op_1 == 2 && op_2 == 1)    //(x-a)(x+b), therefore the roots are a and -b
        {
            b = -1 * b;
        }

        else
        { 
            a = 1 * a; 
            b = 1 * b;
        }

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
            AnswerLabel.Text = "a is correct";
        }

        else if (string_a != input_a && string_b == input_b)
        {
            AnswerLabel.Text = "b is correct";
        }

        else if (string_a != input_b && string_b == input_a)
        {
            AnswerLabel.Text = "b is correct";
        }

        else if (string_a == input_b && string_b != input_a)
        {
            AnswerLabel.Text = "a is correct";
        }

        else
        {
            AnswerLabel.Text = $"{a}, {b}";
            AnswerLabel2.Text = $"{op_1}, {op_2}";
        }
    }

    public void showWorking(int a, int b)
    {

    }

    public void showQuestion(int a, int b, int operator1, int operator2)
    {
        if (operator1 == 1 && operator2 == 1)
        {
            //Quadratic of the form (x + a)(x + b) = 0
            QuestionLabel.Text = $"x^2 + {a + b}x + {a * b}";
        }

        else if (operator1 == 1 && operator2 == 2)
        {
            //Quadratic of the form (x + a)(x - b) = 0 OR x^2 + (a-b)x - ab = 0
            if (a - b < 0)
            {
                QuestionLabel.Text = $"x^2 - {b - a}x - {a * b}";
            }

            else if (a-b == 0)
            {
                QuestionLabel.Text = $"x^2  - {a * b}";
            }

            else
            {
                QuestionLabel.Text = $"x^2 + {a - b}x - {a * b}";
            }
            
        }

        else if (operator1 == 2 && operator2 == 1)
        {
            //Quadratic of the form (x - a)(x + b) = 0 OR x^2 + (b-a)x - ab = 0
            if (b - a < 0)
            {
                QuestionLabel.Text = $"x^2 - {a - b}x - {a * b}";
            }

            else if (b - a == 0)
            {
                QuestionLabel.Text = $"x^2  - {a * b}";
            }

            else
            {
                QuestionLabel.Text = $"x^2 + {b - a}x - {a * b}";
            }
        }

        else
        {
            //Quadratic of the form (x - a)(x - b) = 0 OR x^2 - (a + b)x + ab
            QuestionLabel.Text = $"x^2 - {a + b}x + {a * b}";
        }
    }
}