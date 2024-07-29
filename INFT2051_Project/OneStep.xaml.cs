namespace INFT2051_Project;

public partial class OneStep : ContentPage
{
    int a;
    int b;
    int op;
    public OneStep()
	{
        InitializeComponent();
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {

        Button btn = (Button)sender;    //This line reads which button was pressed. Allows for unique instances of button presses.
        if (btn == Back)
            await Navigation.PushAsync(new MainPage());

        if (btn == NextQuestion)
        {
            NextQuestion.Text = "Next Question";
            a = getIntegerA();
            b = getIntegerB();
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

        if (btn == ShowAnswer)
        {
            getAnswer(a, b, op);
        }
    }

    public int getOperator()
    {
        int operatorSelect=0;   //initialise operatorSelect
        Random numberGenerator = new Random();
        operatorSelect = numberGenerator.Next(1, 5);    //generators a number from 1 to 4. 1=Add, 2=Sub, 3=Multiply, 4=Div
        return operatorSelect;
    }

    public int getIntegerA()
    {
        int a;
        Random numberGenerator = new Random();
        a = numberGenerator.Next(1, 30);
        return a;
    }
    public int getIntegerB()
    {
        int b;
        Random numberGenerator = new Random();
        b = numberGenerator.Next(1, 30);
        return b;
    }

    public void getAnswer(int a, int b, int operatorSelect)
    {
        int answer=0;
        if (operatorSelect == 1)    //if the equation is of the from x + a = b
        {
            answer = (b - a);
            AnswerLabel.Text = answer.ToString();
        }

        else if (operatorSelect == 2)    //if the equation is of the from x - a = b
        {
            answer = (b + a);
            AnswerLabel.Text = answer.ToString();
        }

        else if (operatorSelect == 3)    //if the equation is of the from ax = b
        {
            if ((b % a) == 0)       //Need to check if the division b/a is a whole number.
            {
                answer = (b / a);
                AnswerLabel.Text = answer.ToString();
            }
                
            else
                AnswerLabel.Text = $"{b}/{a}";
        }

        else        //If the equation is of the form x/a = b
        {
            answer = (b * a);
            AnswerLabel.Text = answer.ToString();
        }
    }
}