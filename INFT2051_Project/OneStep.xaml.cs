namespace INFT2051_Project;

public partial class OneStep : ContentPage
{
    public int a = 0;
    public int b = 0;
    public int c = 0;

    public OneStep()
	{
		InitializeComponent();

        a = getIntegerA();
        b = getIntegerB();
        c = getIntegerC();

        IntA_Label.Text = $"a = {a.ToString()}";
        IntB_Label.Text = $"b = {b.ToString()}";
        IntC_Label.Text = $"c = {c.ToString()}";

        Question_Label.Text = $"{a}x + {b} = {c}";
    }

    public async void OnButtonClicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
         
            if (btn == NextQuestion)
            { 
                a = getIntegerA();
                b = getIntegerB();
                c = getIntegerC();

                IntA_Label.Text = $"a = {a.ToString()}";
                IntB_Label.Text = $"b = {b.ToString()}";
                IntC_Label.Text = $"c = {c.ToString()}";

                Question_Label.Text = $"{a}x + {b} = {c}";
                Answer_Label.Text = "";
            }   

            else if (btn == ShowAnswer)
            {
                getAnswer(a, b, c);
            }

            else
                await Navigation.PushAsync(new MainPage());

    }
    public void OneStepEquationGenerator(object sender, EventArgs e)
    {       
        /*
        Random numberGenerator = new Random();
        Random OperatorGenerator = new Random();

        
            int a = numberGenerator.Next(1, 11);
            IntA_Label.Text = $"a = {a.ToString()}";

            int b = numberGenerator.Next(1, 11);
            IntB_Label.Text = $"b = {b.ToString()}";

            int c = numberGenerator.Next(1, 11);
            IntC_Label.Text = $"c = {c.ToString()}";

            string OS_equation = $"{a}x + {b} = {c}";
            Question_Label.Text = OS_equation;
        

        Button btn = (Button)sender;
        if (btn.Text == "Next Quetion")
            {int a = numberGenerator.Next(1, 11);
            IntA_Label.Text = $"a = {a.ToString()}";

            int b = numberGenerator.Next(1, 11);
            IntB_Label.Text = $"b = {b.ToString()}";

            int c = numberGenerator.Next(1, 11);
            IntC_Label.Text = $"c = {c.ToString()}";

            string OS_equation = $"{a}x + {b} = {c}";
            Question_Label.Text = OS_equation; }
        else
            int OS_Answer = (c - b) / a;
            string answerHold = "";
            int Check = (c - b)%a;
                if (Check == 0)
                    answerHold = OS_Answer.ToString();
                else
                    answerHold = $"{c-b} / {a}";}
        
       */      
    }

    public int getIntegerA()
    {
        Random numberGenerator = new Random();
        int a = numberGenerator.Next(1, 11);
        return a;
    }

    public int getIntegerB()
    {
        Random numberGenerator = new Random();
        int b = numberGenerator.Next(1, 11);
        return b;
    }

    public int getIntegerC()
    {
        Random numberGenerator = new Random();
        int c = numberGenerator.Next(1, 11);
        return c;
    }

    public void getAnswer(int a, int b, int c)
    {
        int OS_Answer = (c - b) / a;
        int Check = (c - b) % a;
        if (Check == 0)
            Answer_Label.Text = OS_Answer.ToString();
        else
            Answer_Label.Text = $"{c - b} / {a}";
    }
}
