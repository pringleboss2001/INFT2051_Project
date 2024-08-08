using Mehroz;

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

        if (btn == SubmitAnswer)
        {
            var input = float.Parse(AnswerInput.Text);
            var answer = getAnswer(a, b, op);
            if (input == answer)
            {
                Vibration.Default.Vibrate(2);
                Vibration.Default.Vibrate(2);
                Vibration.Default.Vibrate(2);
                Vibration.Default.Vibrate(2);
                AnswerLabel.Text = "something else";
            }
            else
            {
                Vibration.Default.Vibrate(10);
                AnswerLabel.Text = "somenthing";
            }
                
        }
    }

    public int getOperator()
    {
        int operatorSelect=0;   //initialise operatorSelect
        Random numberGenerator = new Random();
        operatorSelect = numberGenerator.Next(1, 5);    //generators a number from 1 to 4. 1=Add, 2=Sub, 3=Multiply, 4=Div
        return operatorSelect;
    }

    public int getInteger()
    {
        int a;
        Random numberGenerator = new Random();
        a = numberGenerator.Next(1, 30);
        return a;
    }

    

    public float getAnswer(int a, int b, int operatorSelect)
    {
        Fraction frac = new Fraction(b, a); //making a fraction with numerator a, denominator b
        int answer=0;
        if (operatorSelect == 1)    //if the equation is of the from x + a = b
        {
            answer = (b - a);
            AnswerLabel.Text = answer.ToString();
            return answer;
        }

        else if (operatorSelect == 2)    //if the equation is of the from x - a = b
        {
            answer = (b + a);
            AnswerLabel.Text = answer.ToString();
            return answer;
        }

        else if (operatorSelect == 3)    //if the equation is of the from ax = b
        {
           //Need to check if the division b/a is a whole number.
           answer = (b / a);
           AnswerLabel.Text = answer.ToString();
           return answer;
        }

        else        //If the equation is of the form x/a = b
        {
            answer = (b * a);
            AnswerLabel.Text = answer.ToString();
            return answer;
        }
    }
}